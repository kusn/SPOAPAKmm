using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using SPOAPAKmmReceiver.Infrastructure.Commands;
using SPOAPAKmmReceiver.ViewModels.Base;

namespace TestClientWpfApp.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private string _sendMessage;

        public string SendMessage
        {
            get => _sendMessage;
            set => Set(ref _sendMessage, value);
        }

        private static string _recieveMessage;

        public string RecieveMessage
        {
            get => _recieveMessage;
            set => Set(ref _recieveMessage, value);
        }

        public ICommand Send { get; set; }

        public MainWindowViewModel()
        {
            Send = new LambdaCommand(OnSendExecuted, CanSendMessageExecute);

            Thread AccessToClientProgram = new Thread(GetAccessToClientProgram);
            AccessToClientProgram.IsBackground = true;
            AccessToClientProgram.Start();
        }

        private void OnSendExecuted(object p) => SendToClient(SendMessage);
        private bool CanSendMessageExecute(object arg) => true;
        
        private void GetAccessToClientProgram()
        {
            TcpListener listner = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11001));
            listner.Start();
            while (true)
            {
                TcpClient client = listner.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());

                //Console.WriteLine("Сообщение: " + sr.ReadLine() + " получено в " + DateTime.Now.TimeOfDay.ToString());
                Execute(sr.ReadLine());   //<---------- самописная функция Execute, что-то выполняет с пришедшими данными

                client.Close();
            }
        }

        /// <summary>
        /// Посылает сообщение приложению-клиенту
        /// </summary>
        /// <param name="Massage">Передаваемое сообщение</param>
        private void SendToClient(string Massage)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000));
                StreamWriter sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                sw.WriteLine(Massage);
            }
            catch
            {
                Console.WriteLine("Ошибка при подключении к Server.exe");
            }
            client.Close();
        }

        private void Execute(string Data)
        {
            //Выводим принятое сообщение на экран
            App.Current.Dispatcher.Invoke((Action)(() => this.RecieveMessage = Data));
            //Dispatcher.Invoke((Action)(() => this.RecieveMessage = Data));
        }
    }
}
