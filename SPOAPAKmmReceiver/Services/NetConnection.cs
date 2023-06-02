using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.Models;
using static SPOAPAKmmReceiver.Interfaces.INetConnection;

namespace SPOAPAKmmReceiver.Services
{
    public class NetConnection : INetConnection
    {
        private static readonly int _timeOut = 500;
        private readonly IConfiguration _configuration;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancelTokenSource;
        private InstrumentSettings _instrumentSettings;
        private TcpListener _listner;

        public NetConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        ///     Получение настроек "InstrumentSettings" из файла конфигурации
        /// </summary>
        /// <param name="sectionKey">Пример: "InstrumentSettings:Receiver"</param>
        public void GetConnectionSettings(string sectionKey)
        {
            _instrumentSettings = _configuration.GetSection(sectionKey).Get<InstrumentSettings>();
        }

        public void StartListen(Execute execute)
        {
            _cancelTokenSource = new CancellationTokenSource();
            var task = new Task(() =>
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
                    _listner = new TcpListener(new IPEndPoint(IPAddress.Parse(_instrumentSettings.IpAddress),
                        _instrumentSettings.Port));
                _listner.Start();
                while (true)
                {
                    var client = _listner.AcceptTcpClient();
                    var sr = new StreamReader(client.GetStream());

                    execute(); //<---------- самописная функция Execute, что-то выполняет с пришедшими данными

                    client.Close();
                }
            }

            if (token.IsCancellationRequested) _listner.Stop();
        }
    }
}