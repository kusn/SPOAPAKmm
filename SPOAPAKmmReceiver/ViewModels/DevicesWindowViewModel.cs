using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using SPOAPAKmmReceiver.Infrastructure.Commands;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class DevicesWindowViewModel : ViewModel
    {
        private DeviceType _selectedDeviceType;
        private string _newNameDeviceType;
        private DeviceType _selectedDeviceTypeInDevicePanel;
        private Device _selectedDeviceInDevicePanel;
        private string _newDeviceName;
        private DeviceType _newDeviceType;
        private Device _newDevice;

        public DeviceType SelectedDeviceType
        {
            get => _selectedDeviceType;
            set
            {
                Set(ref _selectedDeviceType, value);
                Devices.Clear();
                if(value !=null)
                    foreach (var device in DbDeviceStore.GetAll().Where(d => d.Type.Name == value.Name))
                    {
                        Devices.Add(device);
                    }
            }
        }

        public string NewNameDeviceType
        {
            get => _newNameDeviceType;
            set => Set(ref _newNameDeviceType, value);
        }

        public Device SelectedDeviceInDevicePanel
        {
            get => _selectedDeviceInDevicePanel;
            set => Set(ref _selectedDeviceInDevicePanel, value);
        }

        public string NewDeviceName
        {
            get => _newDeviceName;
            set => Set(ref _newDeviceName, value);
        }

        public ObservableCollection<DeviceType> DeviceTypes { get; set; }
        public ObservableCollection<Device> Devices { get; set; }

        public IStore<Device> DbDeviceStore { get; set; }
        public IStore<DeviceType> DbDeviceTypeStore { get; set; }

        public DevicesWindowViewModel(IStore<DeviceType> dBDeviceType, IStore<Device> dBDevice)
        {
            DbDeviceStore = dBDevice;
            DbDeviceTypeStore = dBDeviceType;

            DeviceTypes = new ObservableCollection<DeviceType>(dBDeviceType.GetAll());
            Devices = new ObservableCollection<Device>();
        }

        #region AddNewDeviceTypeCommand

        private LambdaCommand _addNewDeviceTypeCommand;

        public LambdaCommand AddNewDeviceTypeCommand => _addNewDeviceTypeCommand
            ??= new LambdaCommand(OnAddNewDeviceTypeCommandExecuted, CanAddNewDeviceTypeCommandExecute);

        private void OnAddNewDeviceTypeCommandExecuted(object p)
        {
            _newDeviceType = new()
            {
                Name = NewNameDeviceType,
            };
            DbDeviceTypeStore.Add(_newDeviceType);
            DeviceTypes.Add(_newDeviceType);
        }

        private bool CanAddNewDeviceTypeCommandExecute(object p) =>
            NewNameDeviceType is not null || NewNameDeviceType != "";

        #endregion

        #region RemoveDeviceTypeCommand

        private LambdaCommand _removeDeviceTypeCommand;

        public LambdaCommand RemoveDeviceTypeCommand => _removeDeviceTypeCommand
            ??= new LambdaCommand(OnRemoveDeviceTypeCommandExecuted, CanRemoveDeviceTypeCommandExecute);

        private void OnRemoveDeviceTypeCommandExecuted(object p)
        {
            DbDeviceTypeStore.Delete(DeviceTypes.FirstOrDefault(t => t.Name == SelectedDeviceType.Name).Id);
            DeviceTypes.Remove(SelectedDeviceType);
        }
        private bool CanRemoveDeviceTypeCommandExecute(object p) => SelectedDeviceType is not null;

        #endregion
    }
}
