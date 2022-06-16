using RohdeSchwarz.RsInstrument;
using SPOAPAKmmReceiver.Infrastructure.Commands;
using SPOAPAKmmReceiver.Models;
using SPOAPAKmmReceiver.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class SettingsWindowViewModel : ViewModel
    {
        private InstrumentSettings _receiverSettings;
        private InstrumentSettings _generatorSettings;
        private string _descriptionSelectedReceiver;
        private string _descriptionSelectedGenerator;
        private ObservableCollection<string> _devicesListResiever;
        private ObservableCollection<string> _devicesListTransmitter;

        public InstrumentSettings RecieverSettings
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
        public ObservableCollection<string> DevicesListResiever
        {
            get => _devicesListResiever;
            set => Set(ref _devicesListResiever, value);
        }
        public ObservableCollection<string> DevicesListTransmitter
        {
            get => _devicesListTransmitter;
            set => Set(ref _devicesListTransmitter, value);
        }

        public SettingsWindowViewModel()
        {

        }

        #region TestSelectedReceiverCommand

        private LambdaCommand _testSelectedReceiverCommand;
        public LambdaCommand TestSelectedReceiverCommand => _testSelectedReceiverCommand
            ??= new LambdaCommand(OnTestSelectedReceiverCommandExecuted, CanTestSelectedReceiverCommandExecute);
        private void OnTestSelectedReceiverCommandExecuted(object p)
        {
            DevicesListResiever = new ObservableCollection<string>();
            DevicesListTransmitter = new ObservableCollection<string>();
        }
        private bool CanTestSelectedReceiverCommandExecute(object p) => true;

        #endregion

        #region SearchReceiversCommand

        private LambdaCommand _searchReceiversCommand;
        public LambdaCommand SearchReceiversCommand => _searchReceiversCommand
            ??= new LambdaCommand(OnSearchReceiversCommandExecuted, CanSearchReceiversCommandExecute);
        private void OnSearchReceiversCommandExecuted(object p)
        {
            if (DevicesListResiever is not null)
                DevicesListResiever.Clear();
            DevicesListResiever = new ObservableCollection<string>(RsInstrument.FindResources("?*"));
        }
        private bool CanSearchReceiversCommandExecute(object p) => true;

        #endregion

        #region TestSelectedGeneratorCommand

        private LambdaCommand _testSelectedGeneratorCommand;
        public LambdaCommand TestSelectedGeneratorCommand => _testSelectedGeneratorCommand
            ??= new LambdaCommand(OnTestSelectedGeneratorCommandExecuted, CanTestSelectedGeneratorCommandExecute);
        private void OnTestSelectedGeneratorCommandExecuted(object p)
        {

        }
        private bool CanTestSelectedGeneratorCommandExecute(object p) => true;

        #endregion

        #region SearchGeneratorsCommand

        private LambdaCommand _searchGeneratorsCommand;
        public LambdaCommand SearchGeneratorsCommand => _searchGeneratorsCommand
            ??= new LambdaCommand(OnSearchGeneratorsCommandExecuted, CanSearchGeneratorsCommandExecute);
        private void OnSearchGeneratorsCommandExecuted(object p)
        {

        }
        private bool CanSearchGeneratorsCommandExecute(object p) => true;

        #endregion
    }
}
