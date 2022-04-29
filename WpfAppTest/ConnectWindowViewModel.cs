using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPOAPAKmmReceiver.ViewModels.Base;

namespace WpfAppTest
{
    public class ConnectWindowViewModel : ViewModel
    {
        private string _reciviedMessage;

        public string ReciviedMessage
        {
            get => _reciviedMessage;
            set => Set(ref _reciviedMessage, value);
        }

        public ConnectWindowViewModel()
        {
            ReciviedMessage = new NotifyTaskCompletion<string>(AsynchronousClient.StartClient($"This is a test from WPF client {DateTime.Now.TimeOfDay}")).Result;
        }
    }
}
