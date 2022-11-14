using Microsoft.Extensions.Configuration;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.Models;
using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static SPOAPAKmmReceiver.Interfaces.INetConnection;

namespace SPOAPAKmmReceiver.Services
{
    public class NetConnection : INetConnection
    {
        private readonly IConfiguration _configuration;
        private InstrumentSettings _instrumentSettings;
        private TcpListener _listner;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancelTokenSource;
        private static int _timeOut = 500;        

        public NetConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Получение настроек "InstrumentSettings" из файла конфигурации
        /// </summary>
        /// <param name="sectionKey">Пример: "InstrumentSettings:Receiver"</param>
        public void GetConnectionSettings(string sectionKey)
        {
            _instrumentSettings = _configuration.GetSection(sectionKey).Get<InstrumentSettings>();
        }

        public void StartListen(Execute execute)
        {
            _cancelTokenSource = new CancellationTokenSource();
            Task task = new Task(() =>
            {
                GetAccessToClientProgram(execute, _cancellationToken);
                var timeOutTask = new Task(() =>
                {
                    Thread.Sleep(_timeOut);
                    _cancelTokenSource.Cancel();
                    //_cancelTokenSource.Dispose();

                }, _cancelTokenSource.Token, TaskCreationOptions.AttachedToParent);
            }, _cancelTokenSource.Token, TaskCreationOptions.AttachedToParent);
            task.Start();
        }        

        public void StopListen()
        {
            throw new NotImplementedException();
        }

        private void GetAccessToClientProgram(Execute execute, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (_listner is null)
                    _listner = new TcpListener(new IPEndPoint(IPAddress.Parse(_instrumentSettings.IpAddress), _instrumentSettings.Port));
                _listner.Start();
                while (true)
                {
                    TcpClient client = _listner.AcceptTcpClient();
                    StreamReader sr = new StreamReader(client.GetStream());

                    execute();   //<---------- самописная функция Execute, что-то выполняет с пришедшими данными

                    client.Close();
                }
            }
            if (token.IsCancellationRequested)
            {
                _listner.Stop();
            }
        }
    }
}
