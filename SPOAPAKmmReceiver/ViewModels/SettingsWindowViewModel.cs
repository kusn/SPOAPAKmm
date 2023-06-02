using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RohdeSchwarz.RsInstrument;
using SPOAPAKmm.Extensions;
using SPOAPAKmmReceiver.Extensions.DTO;
using SPOAPAKmmReceiver.Infrastructure.Commands;
using SPOAPAKmmReceiver.Models;
using SPOAPAKmmReceiver.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class SettingsWindowViewModel : ViewModel
    {
        private static readonly bool _simulation = false;
        private static readonly int _timeOut = 500;

        private readonly IConfiguration _configuration;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancelTokenSource;
        private string _connectionString;
        private string _descriptionSelectedGenerator;
        private string _descriptionSelectedReceiver;
        private ObservableCollection<string> _devicesListReciever;
        private Dictionary<string, string> _devicesListTransmitter;
        private InstrumentSettings _generatorSettings;
        private TcpListener _listner;
        private readonly IOptionsSnapshot<InstrumentSettings> _namedOptionsAccessor;

        private InstrumentSettings _receiverSettings;
        private string _recieveMessage;
        private string _selectedItemDeviceListReceiver;
        private string _selectedItemDeviceListTransmitter;
        private string _sendMessage;
        private int _time;
        private Window _window;

        public SettingsWindowViewModel(IOptionsSnapshot<InstrumentSettings> namedOptionsAccessor,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _namedOptionsAccessor = namedOptionsAccessor;

            GetAppSettings();

            Send = new LambdaCommand(OnSendExecuted, CanSendMessageExecute);

            /*Thread AccessToClientProgram = new Thread(GetAccessToClientProgram);
            AccessToClientProgram.IsBackground = true;
            AccessToClientProgram.Start();*/
            //StartListen();

            string host = Dns.GetHostName();
            _receiverSettings.IpAddress = Dns.GetHostAddresses(host).First<IPAddress>(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();

        }

        public InstrumentSettings ReceiverSettings
        {
            get => _receiverSettings;
            set => Set(ref _receiverSettings, value);
        }

        public InstrumentSettings GeneratorSettings
        {
            get => _generatorSettings;
            set => Set(ref _generatorSettings, value);
        }

        public string DescriptionSelectedReceiver
        {
            get => _descriptionSelectedReceiver;
            set => Set(ref _descriptionSelectedReceiver, value);
        }

        public string DescriptionSelectedGenerator
        {
            get => _descriptionSelectedGenerator;
            set => Set(ref _descriptionSelectedGenerator, value);
        }

        public ObservableCollection<string> DevicesListReciever
        {
            get => _devicesListReciever;
            set => Set(ref _devicesListReciever, value);
        }

        public Dictionary<string, string> DevicesListTransmitter
        {
            get => _devicesListTransmitter;
            set => Set(ref _devicesListTransmitter, value);
        }

        public string SelectedItemDeviceListReceiver
        {
            get => _selectedItemDeviceListReceiver;
            set
            {
                Set(ref _selectedItemDeviceListReceiver, value);
                try
                {
                    var instr = new RsInstrument(value, "Simulate = " + _simulation);
                    DescriptionSelectedReceiver = instr.QueryString("*IDN?") + Environment.NewLine;
                    DescriptionSelectedReceiver += "RsInstrument Driver Version: " +
                                                   instr.Identification.DriverVersion + Environment.NewLine;
                    DescriptionSelectedReceiver += "Visa Manufacturer: " + instr.Identification.VisaManufacturer +
                                                   Environment.NewLine;
                    DescriptionSelectedReceiver += "Instrument Full Name: " + instr.Identification.InstrumentFullName +
                                                   Environment.NewLine;
                    DescriptionSelectedReceiver +=
                        "Installed Options: " + string.Join(",", instr.Identification.InstrumentOptions);

                    ReceiverSettings.InstrAddress = value;
                }
                catch (Exception ex)
                {
                    DescriptionSelectedReceiver = ex.Message;
                }
            }
        }

        public string SelectedItemDeviceListTransmitter
        {
            get => _selectedItemDeviceListTransmitter;
            set
            {
                Set(ref _selectedItemDeviceListTransmitter, value);
                DescriptionSelectedGenerator = DevicesListTransmitter[value];
                GeneratorSettings.InstrAddress = value;
            }
        }

        public string SendMessage
        {
            get => _sendMessage;
            set => Set(ref _sendMessage, value);
        }

        public string RecieveMessage
        {
            get => _recieveMessage;
            set => Set(ref _recieveMessage, value);
        }

        public string ConnectionString
        {
            get => _connectionString;
            set => Set(ref _connectionString, value);
        }

        public ICommand Send { get; set; }

        private void GetAppSettings()
        {
            //ReceiverSettings = _configuration.GetSection("InstrumentSettings:Receiver").Get<InstrumentSettings>();
            //GeneratorSettings = _configuration.GetSection("InstrumentSettings:Generator").Get<InstrumentSettings>();

            ReceiverSettings = _namedOptionsAccessor.Get(InstrumentSettings.Receiver);
            GeneratorSettings = _namedOptionsAccessor.Get(InstrumentSettings.Generator);
            //ConnectionString = _configuration.GetSection("ConnectionStrings:Default").Get<string>();
            ConnectionString = _configuration.GetConnectionString("Default").Remove(0, "Filename=.\\".Length);
        }

        private void OnSendExecuted(object p)
        {
            SendToClient(SendMessage);
        }

        private bool CanSendMessageExecute(object arg)
        {
            return true;
        }

        private void GetAccessToClientProgram(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (_listner is null)
                    _listner = new TcpListener(new IPEndPoint(IPAddress.Parse(ReceiverSettings.IpAddress),
                        ReceiverSettings.Port));
                _listner.Start();
                while (true)
                {
                    var client = _listner.AcceptTcpClient();
                    var sr = new StreamReader(client.GetStream());

                    Execute(sr.ReadLine()); //<---------- самописная функция Execute, что-то выполняет с пришедшими данными

                    sr.Close();
                    client.Close();
                }

                _listner.Stop();
            }

            if (token.IsCancellationRequested) _listner.Stop();
        }

        /// <summary>
        ///     Посылает сообщение приложению-клиенту
        /// </summary>
        /// <param name="Massage">Передаваемое сообщение</param>
        private void SendToClient(string Massage)
        {
            var client = new TcpClient();
            try
            {
                client.Connect(new IPEndPoint(IPAddress.Parse(GeneratorSettings.IpAddress), GeneratorSettings.Port));
                var sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                sw.WriteLine(Massage);
            }
            catch
            {
                Console.WriteLine("Ошибка при подключении к Server.exe");
            }

            client.Close();
        }

        private void Execute(string data)
        {
            //Выводим принятое сообщение на экран
            //App.Current.Dispatcher.Invoke((Action)(() => this.RecieveMessage = Data));
            Application.Current.Dispatcher.Invoke((Action)(() =>
            {
                var message = JsonSerializer.Deserialize<TransmitterMessage>(data);
                if (message != null)
                    if (message.Mode == ReceiverMessage.WorkMode.Checking)
                    {
                        RecieveMessage = message.IsOk.ToString();
                        DescriptionSelectedGenerator = message.Message;
                        _cancelTokenSource.Cancel();
                        //_cancelTokenSource.Dispose();
                    }
                    else if (message.Mode == ReceiverMessage.WorkMode.Searching)
                    {
                        DevicesListTransmitter = message.DevicesList;
                        _cancelTokenSource.Cancel();
                        //_cancelTokenSource.Dispose();
                    }
            }));
        }

        private void StartListen()
        {
            _cancelTokenSource = new CancellationTokenSource();
            var task = new Task(() =>
            {
                GetAccessToClientProgram(_cancellationToken);
                var timeOutTask = new Task(() =>
                {
                    Thread.Sleep(_timeOut);
                    _cancelTokenSource.Cancel();
                    //_cancelTokenSource.Dispose();
                }, _cancelTokenSource.Token, TaskCreationOptions.AttachedToParent);
            }, _cancelTokenSource.Token, TaskCreationOptions.AttachedToParent);
            task.Start();

            /*Thread AccessToClientProgram = new Thread(GetAccessToClientProgram);
            AccessToClientProgram.IsBackground = true;
            AccessToClientProgram.Start();*/
        }

        private static void SetAppSettingValue(string key, string value, string appSettingsJsonFilePath = null)
        {
            if (appSettingsJsonFilePath == null)
                appSettingsJsonFilePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            var config = File.ReadAllText(appSettingsJsonFilePath);
            var json = JObject.Parse(config);
            var updatedConfigDict = UpdateJson(key, value, json);
            File.WriteAllText(appSettingsJsonFilePath, updatedConfigDict.ToString());
        }

        private static JObject UpdateJson(string key, object value, JObject jsonSegment)
        {
            const char keySeparator = ':';

            var keyParts = key.Split(keySeparator);
            var isKeyNested = keyParts.Length > 1;
            if (isKeyNested)
            {
                var firstKeyPart = keyParts[0];
                var remainingKey = string.Join(keySeparator, keyParts.Skip(1));

                var newJsonSegment = (JObject)jsonSegment.SelectToken(firstKeyPart);
                jsonSegment[firstKeyPart] = UpdateJson(remainingKey, value, newJsonSegment);
            }
            else
            {
                jsonSegment[key] = JObject.Parse(value.ToString());
            }

            return jsonSegment;
        }

        #region TestSelectedReceiverCommand - Команда тестирования выбранного приёмника

        private LambdaCommand _testSelectedReceiverCommand;

        public LambdaCommand TestSelectedReceiverCommand => _testSelectedReceiverCommand
            ??= new LambdaCommand(OnTestSelectedReceiverCommandExecuted, CanTestSelectedReceiverCommandExecute);

        private void OnTestSelectedReceiverCommandExecuted(object p)
        {
            if (ReceiverSettings.InstrAddress is null)
                MessageBox.Show("Выберите приёмник из списка");
            else
                try
                {
                    var instr = new RsInstrument(ReceiverSettings.InstrAddress, "Simulate = " + _simulation);
                    DescriptionSelectedReceiver = instr.QueryString("*IDN?");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    Console.WriteLine(e);
                    throw;
                }
        }

        private bool CanTestSelectedReceiverCommandExecute(object p)
        {
            return true;
        }

        #endregion

        #region SearchReceiversCommand - Команда поиска приёмников

        private LambdaCommand _searchReceiversCommand;

        public LambdaCommand SearchReceiversCommand => _searchReceiversCommand
            ??= new LambdaCommand(OnSearchReceiversCommandExecuted, CanSearchReceiversCommandExecute);

        private void OnSearchReceiversCommandExecuted(object p)
        {
            if (DevicesListReciever is not null)
                DevicesListReciever.Clear();
            DevicesListReciever = new ObservableCollection<string>(RsInstrument.FindResources("?*"));
        }

        private bool CanSearchReceiversCommandExecute(object p)
        {
            return true;
        }

        #endregion

        #region TestSelectedGeneratorCommand - Команда тестирования выбранного генератора

        private LambdaCommand _testSelectedGeneratorCommand;

        public LambdaCommand TestSelectedGeneratorCommand => _testSelectedGeneratorCommand
            ??= new LambdaCommand(OnTestSelectedGeneratorCommandExecuted, CanTestSelectedGeneratorCommandExecute);

        private void OnTestSelectedGeneratorCommandExecuted(object p)
        {
            var cancelTokenSource = new CancellationTokenSource();

            StartListen();
            var message = new ReceiverMessage(ReceiverMessage.WorkMode.Checking);
            message.ReceiverIp = _receiverSettings.IpAddress;
            message.ReceiverPort = _receiverSettings.Port;
            message.InstrAddress = GeneratorSettings.InstrAddress;
            SendMessage = JsonSerializer.Serialize(message);
            SendToClient(SendMessage);
        }

        private bool CanTestSelectedGeneratorCommandExecute(object p)
        {
            return true;
        }

        #endregion

        #region SearchGeneratorsCommand - Команда поиска генераторов

        private LambdaCommand _searchGeneratorsCommand;

        public LambdaCommand SearchGeneratorsCommand => _searchGeneratorsCommand
            ??= new LambdaCommand(OnSearchGeneratorsCommandExecuted, CanSearchGeneratorsCommandExecute);

        private void OnSearchGeneratorsCommandExecuted(object p)
        {
            var cancelTokenSource = new CancellationTokenSource();

            StartListen();
            var message = new ReceiverMessage(ReceiverMessage.WorkMode.Searching);
            message.ReceiverIp = _receiverSettings.IpAddress;
            message.ReceiverPort = _receiverSettings.Port;
            SendMessage = JsonSerializer.Serialize(message);
            SendToClient(SendMessage);
        }

        private bool CanSearchGeneratorsCommandExecute(object p)
        {
            return true;
        }

        #endregion

        #region SaveSettingsCommand

        private LambdaCommand _saveSettingsCommand;

        public LambdaCommand SaveSettingsCommand => _saveSettingsCommand
            ??= new LambdaCommand(OnSaveSettingsCommandExecuted, CanSaveSettingsCommandExecute);

        private void OnSaveSettingsCommandExecuted(object p)
        {
            var v = JsonSerializer.Serialize(ReceiverSettings.InstrumentSettingsToConfigSection());
            SetAppSettingValue("InstrumentSettings:Receiver", v);
            v = JsonSerializer.Serialize(GeneratorSettings.InstrumentSettingsToConfigSection());
            SetAppSettingValue("InstrumentSettings:Generator", v);
            //v = System.Text.Json.JsonSerializer.Serialize("Filename=.\\" + ConnectionString);
            //SetAppSettingValue("ConnectionStrings:Default", v);

            _window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Title.Contains("Настройки"));
            _window.Close();
            //Application.Current.Shutdown();
        }

        private bool CanSaveSettingsCommandExecute(object p)
        {
            return true;
        }

        #endregion

        #region OpenConnectionStringCommand

        private LambdaCommand _openConnectionStringCommand;

        public LambdaCommand OpenConnectionStringCommand => _openConnectionStringCommand
            ??= new LambdaCommand(OnOpenConnectionStringCommandExecuted, CanOpenConnectionStringCommandExecute);

        private void OnOpenConnectionStringCommandExecuted(object p)
        {
            /*SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = System.AppContext.BaseDirectory;
            saveFileDialog.FileName = ConnectionString;
            if(saveFileDialog.ShowDialog() != null)
            {
                var v = saveFileDialog.FileName;
                //FileInfo fileInfo = new FileInfo(v);
                //var dir = fileInfo.DirectoryName;
                if (v.Contains(System.AppContext.BaseDirectory))
                    ConnectionString = v.Remove(0, System.AppContext.BaseDirectory.Length);
                else
                    ConnectionString = v;
            }*/
        }

        private bool CanOpenConnectionStringCommandExecute(object p)
        {
            return true;
        }

        #endregion
    }
}