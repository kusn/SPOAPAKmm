using RohdeSchwarz.RsInstrument;
using SPOAPAKmmReceiver.Models;
using System;
using System.Collections.Generic;
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
        static private List<string> _devicesList = new List<string>();

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
                        Console.WriteLine("Получен запрос: " + s);
                        _devicesList = new List<string>(RsInstrument.FindResources("?*"));
                        Dictionary<string, string> data = new Dictionary<string, string>();

                        foreach (string device in _devicesList)
                        {                            
                            string descr;
                            try
                            {
                                RsInstrument instrument = new RsInstrument(device);
                                descr = instrument.QueryString("*IDN?");                                
                            }
                            catch (Exception ex)
                            {

                                descr = ex.Message;
                            }
                            data.Add(device, descr);
                        }
                        TransmitterMessage transmitterMessage = new TransmitterMessage();
                        transmitterMessage.Mode = m.Mode;
                        transmitterMessage.DevicesList = data;
                        var message = JsonSerializer.Serialize<TransmitterMessage>(transmitterMessage);
                        SendToClient(message);
                    }
                    else if (m.Mode == WorkMode.ApplyInstrumentSettings)
                    {

                    }
                    else if (m.Mode == WorkMode.ApplyMeasureSettings)
                    {
                        Console.WriteLine("Получены настройки: " + s);
                        TransmitterMessage transmitterMessage = new TransmitterMessage();
                        transmitterMessage.Mode = m.Mode;
                        transmitterMessage.IsOk = true;
                        var message = JsonSerializer.Serialize<TransmitterMessage>(transmitterMessage);
                        SendToClient(message);                        
                    }
                    else if (m.Mode == WorkMode.Сalibration)
                    {
                        
                    }
                    else if (m.Mode == WorkMode.Checking)
                    {
                        Console.WriteLine("Получен запрос: " + s);
                        TransmitterMessage transmitterMessage = new TransmitterMessage();
                        transmitterMessage.Mode = m.Mode;
                        transmitterMessage.IsOk = true;
                        var message = JsonSerializer.Serialize<TransmitterMessage>(transmitterMessage);
                        SendToClient(message);
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
