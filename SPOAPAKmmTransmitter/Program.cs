using RohdeSchwarz.RsInstrument;
using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using static SPOAPAKmmReceiver.Models.ReceiverMessage;
using RSSigGen;
using RSSigGen.RS;
using System.Linq;

namespace SPOAPAKmmTransmitter
{
    internal class Program
    {
        static private string _ipAddress = "127.0.0.1";
        static private string _ipAddressTransmitter = "127.0.0.1";
        static private int _listenerPort = 11000;
        static private int _sendPort = 11001;
        static private List<string> _devicesList = new List<string>();
        static private bool _isSimulate = false;
        static private int _timeCorrection = 150;       //Поправка времени 

        private static void GetAccessToClientProgram()
        {
            while (true)
            {
                TcpListener listner = new TcpListener(new IPEndPoint(IPAddress.Parse(_ipAddressTransmitter), _listenerPort));
                listner.Start();

                TcpClient client = listner.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());

                var s = sr.ReadLine();
                var m = JsonSerializer.Deserialize<ReceiverMessage>(s);

                if (m != null)
                {
                    _ipAddress = m.ReceiverIp;
                    _sendPort = m.ReceiverPort;
                    Console.WriteLine("Получен запрос: " + s);

                    if (m.Mode == WorkMode.Searching)
                    {
                        try
                        {
                            Console.WriteLine("Режим поиска подключённых устройств.");
                            _devicesList = new List<string>(RsInstrument.FindResources("?*"));
                            Dictionary<string, string> data = new Dictionary<string, string>();

                            foreach (string device in _devicesList)
                            {
                                string descr;
                                try
                                {
                                    RsInstrument instrument = new RsInstrument(device);
                                    descr = instrument.QueryString("*IDN?");
                                    Console.WriteLine("Найдено устройство - " + descr);
                                    instrument.Dispose();
                                }
                                catch (Exception ex)
                                {
                                    descr = ex.Message;
                                    Console.WriteLine("Ошибка: " + ex.Message);
                                }

                                data.Add(device, descr);
                            }

                            TransmitterMessage transmitterMessage = new TransmitterMessage();
                            transmitterMessage.Mode = m.Mode;
                            transmitterMessage.DevicesList = data;
                            var message = JsonSerializer.Serialize<TransmitterMessage>(transmitterMessage);
                            SendToClient(message);
                            Console.WriteLine("Отправлено сообщение: " + message);
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                    else if (m.Mode == WorkMode.ApplyInstrumentSettings)
                    {

                    }
                    else if (m.Mode == WorkMode.ApplyMeasureSettings)
                    {
                        Console.WriteLine("Режим получения настроек");
                        Console.WriteLine("Получены настройки: " + s);
                        TransmitterMessage transmitterMessage = new TransmitterMessage();
                        transmitterMessage.Mode = m.Mode;
                        transmitterMessage.IsOk = true;
                        var message = JsonSerializer.Serialize<TransmitterMessage>(transmitterMessage);
                        SendToClient(message);
                        Console.WriteLine("Отправлено сообщение: " + message);
                    }
                    else if (m.Mode == WorkMode.Сalibration)
                    {
                        Console.WriteLine("Режим калибровки");

                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        TransmitterMessage transmitterMessage = new TransmitterMessage();
                        transmitterMessage.Mode = m.Mode;
                        try
                        {
                            var resourceString = m.InstrAddress;
                            RsSmab smab = new RsSmab(resourceString, true, true, "Simulate = " + _isSimulate.ToString());
                            Console.WriteLine("Генератор проинициализирован по адрессу {0}. Симуляция - {1}", resourceString, _isSimulate);
                            smab.Utilities.InstrumentStatusChecking = true;
                            smab.Utilities.Reset();
                            smab.Source.Power.Level.Immediate.Amplitude = m.Power;
                            Console.WriteLine("Выставлена выходная мощность: " + m.Power);
                            smab.Output.State.Value = true;
                            Console.WriteLine("Излучение влючено");
                            foreach (var freq in m.FrequencyList)
                            {
                                smab.Source.Frequency.Fixed.Value = freq * 1e+6;
                                Console.WriteLine("Частота: " + freq * 1e+6);
                                Thread.Sleep(m.TimeOfEmission * 1000 + _timeCorrection);
                            }
                            smab.Output.State.Value = false;
                            Console.WriteLine("Излучение выключено");
                            transmitterMessage.IsOk = true;
                        }
                        catch (Exception ex)
                        {

                            transmitterMessage.IsOk = false;
                            transmitterMessage.Message = ex.Message;
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }

                        stopwatch.Stop();
                        Console.WriteLine("Время работы: " + stopwatch.ElapsedMilliseconds + "мс");

                        var message = JsonSerializer.Serialize<TransmitterMessage>(transmitterMessage);
                        SendToClient(message);
                        Console.WriteLine("Отправлено сообщение: " + message);
                    }
                    else if (m.Mode == WorkMode.Checking)
                    {
                        Console.WriteLine("Режим проверки");

                        TransmitterMessage transmitterMessage = new TransmitterMessage();
                        transmitterMessage.Mode = m.Mode;
                        var resourceString = m.InstrAddress;
                        
                        try
                        {
                            RsInstrument instrument = new RsInstrument(resourceString, true, true, "Simulate = " + _isSimulate.ToString());
                            transmitterMessage.Message = instrument.Query("*IDN?");
                            transmitterMessage.IsOk = true;
                            instrument.Dispose();
                            Console.WriteLine("Генератор проинициализирован по адрессу {0}. Симуляция - {1}", resourceString, _isSimulate);
                        }
                        catch (Exception ex)
                        {
                            transmitterMessage.IsOk = false;                            
                            transmitterMessage.Message = ex.Message;
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }
                        
                        var message = JsonSerializer.Serialize<TransmitterMessage>(transmitterMessage);
                        SendToClient(message);
                        Console.WriteLine("Отправлено сообщение: " + message);
                        
                    }
                    else if (m.Mode == WorkMode.Measuring)
                    {
                        Console.WriteLine("Режим измерения");

                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        TransmitterMessage transmitterMessage = new TransmitterMessage();
                        transmitterMessage.Mode = m.Mode;
                        try
                        {
                            var resourceString = m.InstrAddress;
                            RsSmab smab = new RsSmab(resourceString, true, true, "Simulate = " + _isSimulate.ToString());
                            Console.WriteLine("Генератор проинициализирован по адрессу {0}. Симуляция - {1}", resourceString, _isSimulate);
                            smab.Utilities.InstrumentStatusChecking = true;
                            smab.Utilities.Reset();                            
                            smab.Source.Power.Level.Immediate.Amplitude = m.Power;
                            Console.WriteLine("Выставлена выходная мощность: " + m.Power);
                            Thread.Sleep(60000);
                            smab.Output.State.Value = true;
                            Console.WriteLine("Излучение выключено");
                            foreach (var freq in m.FrequencyList)
                            {
                                smab.Source.Frequency.Fixed.Value = freq * 1e+6;
                                Console.WriteLine("Частота: " + freq * 1e+6);
                                Thread.Sleep(m.TimeOfEmission * 1000 + _timeCorrection);
                            }
                            smab.Output.State.Value = false;
                            Console.WriteLine("Излучение выключено");
                            transmitterMessage.IsOk = true;
                        }
                        catch (Exception ex)
                        {

                            transmitterMessage.IsOk = false;
                            transmitterMessage.Message = ex.Message;
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }

                        stopwatch.Stop();
                        Console.WriteLine("Время работы: " + stopwatch.ElapsedMilliseconds + "мс");

                        var message = JsonSerializer.Serialize<TransmitterMessage>(transmitterMessage);
                        SendToClient(message);
                        Console.WriteLine("Отправлено сообщение: " + message);
                    }
                }

                //Console.WriteLine("Сообщение: " + s + " получено в " + DateTime.Now.TimeOfDay.ToString());
                //Execute(sr.ReadLine());   //<---------- самописная функция Execute, что-то выполняет с пришедшими данными
                //Thread.Sleep(1000);
                //SendToClient("Сообщение отправлено сервером в " + DateTime.Now.TimeOfDay.ToString());

                sr.Close();
                client.Close();
                listner.Stop();
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
                sw.Close();
            }
            catch
            {
                Console.WriteLine("Ошибка при подключении к Client.exe");
            }
            client.Close();
        }

        static void Main(string[] args)
        {
            string host = Dns.GetHostName();
            Console.WriteLine($"Имя компьютера: {host}");
            _ipAddressTransmitter = Dns.GetHostAddresses(host).First<IPAddress>(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            if (_ipAddressTransmitter != null)
            {
                Console.WriteLine($"Адрес: {_ipAddressTransmitter}");
            }

            Thread AccessToClientProgram = new Thread(GetAccessToClientProgram);            
            AccessToClientProgram.Start();
        }
    }
}
