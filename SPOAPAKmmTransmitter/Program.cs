using SPOAPAKmmReceiver.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;

namespace SPOAPAKmmTransmitter
{
    internal class Program
    {
        private static void GetAccessToClientProgram()
        {
            TcpListener listner = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000));
            listner.Start();
            while (true)
            {
                TcpClient client = listner.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());

                var s = sr.ReadLine();
                var m = JsonSerializer.Deserialize<ReceiverMessage>(s);

                if (m != null)
                {
                    if (m.Mode == ReceiverMessage.WorkMode.ApplyMeasureSettings)
                    {
                        Console.WriteLine("Получены настройки: " + s);
                        SendToClient("Настройки приняты: " + DateTime.Now.TimeOfDay.ToString());
                    }
                }

                //Console.WriteLine("Сообщение: " + s + " получено в " + DateTime.Now.TimeOfDay.ToString());
                //Execute(sr.ReadLine());   //<---------- самописная функция Execute, что-то выполняет с пришедшими данными
                //Thread.Sleep(1000);
                //SendToClient("Сообщение отправлено сервером в " + DateTime.Now.TimeOfDay.ToString());

                client.Close();
            }
        }

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

        static void Main(string[] args)
        {
            Thread AccessToClientProgram = new Thread(GetAccessToClientProgram);            
            AccessToClientProgram.Start();
        }
    }
}
