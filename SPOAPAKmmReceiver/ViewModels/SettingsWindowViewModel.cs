using Microsoft.Extensions.Configuration;
using RohdeSchwarz.RsInstrument;
using SPOAPAKmmReceiver.Infrastructure.Commands;
using SPOAPAKmmReceiver.Models;
using SPOAPAKmmReceiver.ViewModels.Base;
using SPOAPAKmmReceiver.Extensions.DTO;
using System;
using System.Collections.ObjectModel;
using static SPOAPAKmmReceiver.Models.ReceiverMessage;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using static SPOAPAKmmReceiver.Extensions.DTO.Mapper;
using System.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;
using System.Windows;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class SettingsWindowViewModel : ViewModel
    {
        private static bool _simulation = false;
        private static int _timeOut = 500;

        private readonly IConfiguration _configuration;
        private IOptionsSnapshot<InstrumentSettings> _namedOptionsAccessor;

        private InstrumentSettings _receiverSettings;
        private InstrumentSettings _generatorSettings;
        private string _descriptionSelectedReceiver;
        private string _descriptionSelectedGenerator;
        private ObservableCollection<string> _devicesListReciever;
        private Dictionary<string, string> _devicesListTransmitter;
        private string _selectedItemDeviceListReceiver;
        private string _selectedItemDeviceListTransmitter;
        private string _sendMessage;
        private string _recieveMessage;
        private int _time;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancelTokenSource;
        private TcpListener _listner;
        private string _connectionString;

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
                    RsInstrument instr = new RsInstrument(value, "Simulate = " + _simulation);
                    DescriptionSelectedReceiver = instr.QueryString("*IDN?") + Environment.NewLine;
                    DescriptionSelectedReceiver += "RsInstrument Driver Version: " + instr.Identification.DriverVersion + Environment.NewLine;
                    DescriptionSelectedReceiver += "Visa Manufacturer: " + instr.Identification.VisaManufacturer + Environment.NewLine;
                    DescriptionSelectedReceiver += "Instrument Full Name: " + instr.Identification.InstrumentFullName + Environment.NewLine;
                    DescriptionSelectedReceiver += "Installed Options: " + string.Join(",", instr.Identification.InstrumentOptions);

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

        public SettingsWindowViewModel(IOptionsSnapshot<InstrumentSettings> namedOptionsAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            _namedOptionsAccessor = namedOptionsAccessor;
            
            GetAppSettings();

            Send = new LambdaCommand(OnSendExecuted, CanSendMessageExecute);

            /*Thread AccessToClientProgram = new Thread(GetAccessToClientProgram);
            AccessToClientProgram.IsBackground = true;
            AccessToClientProgram.Start();*/
            //StartListen();
        }

        #region TestSelectedReceiverCommand

        private LambdaCommand _testSelectedReceiverCommand;
        public LambdaCommand TestSelectedReceiverCommand => _testSelectedReceiverCommand
            ??= new LambdaCommand(OnTestSelectedReceiverCommandExecuted, CanTestSelectedReceiverCommandExecute);
        private void OnTestSelectedReceiverCommandExecuted(object p)
        {
            RsInstrument instr = new RsInstrument(SelectedItemDeviceListReceiver, "Simulate = " + _simulation);
            DescriptionSelectedReceiver = instr.QueryString("*IDN?");
        }
        private bool CanTestSelectedReceiverCommandExecute(object p) => true;

        #endregion

        #region SearchReceiversCommand

        private LambdaCommand _searchReceiversCommand;
        public LambdaCommand SearchReceiversCommand => _searchReceiversCommand
            ??= new LambdaCommand(OnSearchReceiversCommandExecuted, CanSearchReceiversCommandExecute);
        private void OnSearchReceiversCommandExecuted(object p)
        {
            if (DevicesListReciever is not null)
                DevicesListReciever.Clear();
            DevicesListReciever = new ObservableCollection<string>(RsInstrument.FindResources("?*"));
        }
        private bool CanSearchReceiversCommandExecute(object p) => true;

        #endregion

        #region TestSelectedGeneratorCommand

        private LambdaCommand _testSelectedGeneratorCommand;
        public LambdaCommand TestSelectedGeneratorCommand => _testSelectedGeneratorCommand
            ??= new LambdaCommand(OnTestSelectedGeneratorCommandExecuted, CanTestSelectedGeneratorCommandExecute);
        private void OnTestSelectedGeneratorCommandExecuted(object p)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
           
            StartListen();
            var message = new ReceiverMessage(WorkMode.Checking);
            message.InstrAddress = GeneratorSettings.InstrAddress;
            SendMessage = System.Text.Json.JsonSerializer.Serialize(message);
            SendToClient(SendMessage);
        }
        private bool CanTestSelectedGeneratorCommandExecute(object p) => true;

        #endregion

        #region SearchGeneratorsCommand

        private LambdaCommand _searchGeneratorsCommand;
        public LambdaCommand SearchGeneratorsCommand => _searchGeneratorsCommand
            ??= new LambdaCommand(OnSearchGeneratorsCommandExecuted, CanSearchGeneratorsCommandExecute);
        private void OnSearchGeneratorsCommandExecuted(object p)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();           

            StartListen();
            var message = new ReceiverMessage(WorkMode.Searching);            
            SendMessage = System.Text.Json.JsonSerializer.Serialize(message);
            SendToClient(SendMessage);
        }
        private bool CanSearchGeneratorsCommandExecute(object p) => true;

        #endregion

        #region SaveSettingsCommand

        private LambdaCommand _saveSettingsCommand;
        public LambdaCommand SaveSettingsCommand => _saveSettingsCommand
            ??= new LambdaCommand(OnSaveSettingsCommandExecuted, CanSaveSettingsCommandExecute);
        private void OnSaveSettingsCommandExecuted(object p)
        {
            var v = System.Text.Json.JsonSerializer.Serialize<InstrumentSettingsConfig>(ReceiverSettings.InstrumentSettingsToConfigSection());
            SetAppSettingValue("InstrumentSettings:Receiver", v);
            v = System.Text.Json.JsonSerializer.Serialize<InstrumentSettingsConfig>(GeneratorSettings.InstrumentSettingsToConfigSection());
            SetAppSettingValue("InstrumentSettings:Generator", v);
            //v = System.Text.Json.JsonSerializer.Serialize("Filename=.\\" + ConnectionString);
            //SetAppSettingValue("ConnectionStrings:Default", v);
            Application.Current.Shutdown();
        }
        private bool CanSaveSettingsCommandExecute(object p) => true;

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
        private bool CanOpenConnectionStringCommandExecute(object p) => true;

        #endregion

        private void GetAppSettings()
        {
            //ReceiverSettings = _configuration.GetSection("InstrumentSettings:Receiver").Get<InstrumentSettings>();
            //GeneratorSettings = _configuration.GetSection("InstrumentSettings:Generator").Get<InstrumentSettings>();

            ReceiverSettings = _namedOptionsAccessor.Get(InstrumentSettings.Receiver);
            GeneratorSettings = _namedOptionsAccessor.Get(InstrumentSettings.Generator);
            //ConnectionString = _configuration.GetSection("ConnectionStrings:Default").Get<string>();
            ConnectionString = _configuration.GetConnectionString("Default").Remove(0, ("Filename=.\\").Length);
        }

        private void OnSendExecuted(object p)
        {            
            SendToClient(SendMessage);
        }
        private bool CanSendMessageExecute(object arg) => true;

        private void GetAccessToClientProgram(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (_listner is null)
                    _listner = new TcpListener(new IPEndPoint(IPAddress.Parse(ReceiverSettings.IpAddress), ReceiverSettings.Port));
                _listner.Start();
                while (true)
                {
                    TcpClient client = _listner.AcceptTcpClient();
                    StreamReader sr = new StreamReader(client.GetStream());

                    Execute(sr.ReadLine());   //<---------- самописная функция Execute, что-то выполняет с пришедшими данными

                    client.Close();                    
                }                
            }
            if (token.IsCancellationRequested)
            {
                _listner.Stop();
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
                client.Connect(new IPEndPoint(IPAddress.Parse(GeneratorSettings.IpAddress), GeneratorSettings.Port));
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

        private void Execute(string data)
        {
            //Выводим принятое сообщение на экран
            //App.Current.Dispatcher.Invoke((Action)(() => this.RecieveMessage = Data));
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                var message = System.Text.Json.JsonSerializer.Deserialize<TransmitterMessage>(data);
                if (message != null)
                    if (message.Mode == WorkMode.Checking)
                    {
                        this.RecieveMessage = message.IsOk.ToString();
                        this.DescriptionSelectedGenerator = message.Message;
                        _cancelTokenSource.Cancel();
                        //_cancelTokenSource.Dispose();
                    }
                    else if (message.Mode == WorkMode.Searching)
                    { 
                        this.DevicesListTransmitter = message.DevicesList;
                        _cancelTokenSource.Cancel();
                        //_cancelTokenSource.Dispose();
                    }

            }));
        }

        private void StartListen()
        {
            _cancelTokenSource = new CancellationTokenSource();
            Task task = new Task(() =>
            {
                GetAccessToClientProgram(_cancellationToken);
                var timeOutTask = new Task(() =>
                {
                    Thread.Sleep(_timeOut);
                    _cancelTokenSource.Cancel();
                    //_cancelTokenSource.Dispose();
                    
                }, _cancelTokenSource.Token, TaskCreationOptions.AttachedToParent);
            },_cancelTokenSource.Token, TaskCreationOptions.AttachedToParent);
            task.Start();

            /*Thread AccessToClientProgram = new Thread(GetAccessToClientProgram);
            AccessToClientProgram.IsBackground = true;
            AccessToClientProgram.Start();*/
        }

        private static void SetAppSettingValue(string key, string value, string appSettingsJsonFilePath = null)
        {
            if (appSettingsJsonFilePath == null)
            {
                appSettingsJsonFilePath = System.IO.Path.Combine(System.AppContext.BaseDirectory, "appsettings.json");
            }
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
    }
}
