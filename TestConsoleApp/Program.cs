using SPOAPAKmmReceiver.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace TestConsoleApp
{
    internal class Program
    {
        /// <summary>
        /// Подключается к приложению-клиенту и выполняет прослушивание его сообщений
        /// </summary>
        private static void GetAccessToClientProgram()
        {
            TcpListener listner = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000));
            listner.Start();
            while (true)
            {
                TcpClient client = listner.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());

                var s = sr.ReadLine();
                var m = JsonSerializer.Deserialize<MeasureSettings>(s);

                Console.WriteLine("Сообщение: " + s + " получено в " + DateTime.Now.TimeOfDay.ToString());
                //Execute(sr.ReadLine());   //<---------- самописная функция Execute, что-то выполняет с пришедшими данными
                //Thread.Sleep(1000);
                SendToClient("Сообщение отправлено сервером в " + DateTime.Now.TimeOfDay.ToString());

                client.Close();
            }
        }

        /// <summary>
        /// Посылает сообщение приложению-клиенту
        /// </summary>
        /// <param name="Massage">Передаваемое сообщение</param>
        private static void SendToClient(string Massage)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11001));
                StreamWriter sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                sw.WriteLine(Massage);
            }
            catch
            {
                Console.WriteLine("Ошибка при подключении к Client.exe");
            }
            client.Close();
        }

        public static void Main(String[] args)
        {
            Thread AccessToClientProgram = new Thread(GetAccessToClientProgram);
            //AccessToClientProgram.IsBackground = true;
            AccessToClientProgram.Start();
        }
    }
}
