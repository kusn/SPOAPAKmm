using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using SPOAPAKmmReceiver.Data;
using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.Extensions;
using SPOAPAKmmReceiver.Infrastructure.Commands;
using SPOAPAKmmReceiver.ViewModels.Base;

namespace WpfAppTest
{
    public class MainViewModel : ViewModel
    {
        private object _CurrentNode;
        private string _reciviedMessage;
        public object CurrentNode
        {
            get => _CurrentNode;
            set => Set(ref _CurrentNode, value);
        }

        public string ReciviedMessage
        {
            get => _reciviedMessage;
            set => Set(ref _reciviedMessage, value);
        }

        public NotifyTaskCompletion<string> MessageFromServer { get; private set; }

        // called when the user selects a new node in the tree view
        private LambdaCommand _selectedNodeChangedCommand;
        public LambdaCommand SelectedNodeChangedCommand => _selectedNodeChangedCommand
            ??= new LambdaCommand(OnSelectedNodeChangedCommandExecuted, CanSelectedNodeChangedCommandExecute);
        private void OnSelectedNodeChangedCommandExecuted(object p)
        {
            CurrentNode = p;
        }
        private bool CanSelectedNodeChangedCommandExecute(object p) => true;

        private LambdaCommand _sendMessageCommand;
        public LambdaCommand SendMessageCommand => _sendMessageCommand
            ??= new LambdaCommand(OnSendMessageCommandExecuted, CanSendMessageCommandExecute);
        private void OnSendMessageCommandExecuted(object p)
        {
            ConnectWindow connectWindow = new ConnectWindow();
            connectWindow.Show();
            //MessageFromServer = new NotifyTaskCompletion<string>(AsynchronousClient.StartClient("This is a test from WPF client"));
            //ReciviedMessage = MessageFromServer.Result;
        }
        private bool CanSendMessageCommandExecute(object p) => true;

        // list of items to display in the tree view
        private SortableObservableCollection<Organization> _Items;
        public SortableObservableCollection<Organization> Items
        {
            get => _Items;
            set => Set(ref _Items, value);
        }

        public MainViewModel()
        {
            Items = new SortableObservableCollection<Organization>(TestData.TestDataOrganizations);
        }
    }
}
