using SPOAPAKmmReceiver.Infrastructure.Commands;
using SPOAPAKmmReceiver.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfAppTest
{
    public class MainViewModel : ViewModel
    {
        private string _username;
        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        private string _address;
        public string Address
        {
            get => _address;
            set => Set(ref _address, value);
        }

        private string _port = "8000";
        public string Port
        {
            get => _port;
            set => Set(ref _port, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => Set(ref _message, value);
        }

        private string _colorCode;
        public string ColorCode
        {
            get => _colorCode;
            set => Set(ref _colorCode, value);
        }

        public ICommand ConnectCommand { get; set; }
        public ICommand DisconnectCommand { get; set; }
        public ICommand SendCommand { get; set; }

        private ChatroomViewModel _chatRoom;
        public ChatroomViewModel ChatRoom
        {
            get => _chatRoom;
            set => Set(ref _chatRoom, value);
        }

        public NotifyTaskCompletion<string> MessageFromServer { get; private set; }
        
        public MainViewModel()
        {
            ChatRoom = new ChatroomViewModel();

            ConnectCommand = new AsyncCommand(Connect, CanConnect);
            DisconnectCommand = new AsyncCommand(Disconnect, CanDisconnect);
            SendCommand = new AsyncCommand(Send, CanSend);
        }

        private async Task Connect()
        {
            ChatRoom = new ChatroomViewModel();
            int socketPort = 0;
            var validPort = int.TryParse(Port, out socketPort);

            if (!validPort)
            {
                DisplayError("Please provide a valid port.");
                return;
            }

            if (String.IsNullOrWhiteSpace(Address))
            {
                DisplayError("Please provide a valid address.");
                return;
            }

            if (String.IsNullOrWhiteSpace(Username))
            {
                DisplayError("Please provide a username.");
                return;
            }

            ChatRoom.Clear();
            await Task.Run(() => ChatRoom.Connect(Username, Address, socketPort));
        }
        private async Task Disconnect()
        {
            if (ChatRoom == null)
                DisplayError("You are not connected to a server.");

            await ChatRoom.Disconnect();
        }
        private async Task Send()
        {
            if (ChatRoom == null)
                DisplayError("You are not connected to a server.");

            await ChatRoom.Send(Username, Message, ColorCode);
            Message = string.Empty;
        }
        private bool CanConnect() => !ChatRoom.IsRunning;
        private bool CanDisconnect() => ChatRoom.IsRunning;
        private bool CanSend() => !String.IsNullOrWhiteSpace(Message) && ChatRoom.IsRunning;

        private void DisplayError(string message) =>
            MessageBox.Show(message, "Woah there!", MessageBoxButton.OK, MessageBoxImage.Error);

        private LambdaCommand _serverWindowShowCommand;

        public LambdaCommand ServerWindowShowCommand => _serverWindowShowCommand
            ??= new LambdaCommand(OnServerWindowShowCommandExecuted, CanServerWindowShowCommandExecute);

        private void OnServerWindowShowCommandExecuted(object p)
        {
            ServerWindow serverWindow = new ServerWindow();
            serverWindow.Show();
        }
        private bool CanServerWindowShowCommandExecute(object p) => true;
    }
}
