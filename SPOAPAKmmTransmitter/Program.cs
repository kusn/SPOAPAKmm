using SPOAPAKmmReceiver.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using static SPOAPAKmmReceiver.Models.ReceiverMessage;

namespace SPOAPAKmmTransmitter
{
    internal class Program
    {
        static private string _ipAddress = "127.0.0.1";
        static private int _listenerPort = 11000;
        static private int _sendPort = 11001;

        private static void GetAccessToClientProgram()
        {
            TcpListener listner = new TcpListener(new IPEndPoint(IPAddress.Parse(_ipAddress), _listenerPort));
            listner.Start();
            while (true)
            {
                TcpClient client = listner.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());

                var s = sr.ReadLine();
                var m = JsonSerializer.Deserialize<ReceiverMessage>(s);

                if (m != null)
                {
                    if(m.Mode == WorkMode.Searching)
                    {

                    }
                    else if (m.Mode == WorkMode.ApplyInstrumentSettings)
                    {

                    }
                    else if (m.Mode == WorkMode.ApplyMeasureSettings)
                    {
                        Console.WriteLine("Получены настройки: " + s);
                        SendToClient("Настройки приняты: " + DateTime.Now.TimeOfDay.ToString());
                    }
                    else if (m.Mode == WorkMode.Сalibration)
                    {

                    }
                    else if (m.Mode == WorkMode.Measuring)
                    {

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
                client.Connect(new IPEndPoint(IPAddress.Parse(_ipAddress), _sendPort));
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
