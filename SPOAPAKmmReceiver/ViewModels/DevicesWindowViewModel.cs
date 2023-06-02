using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.Infrastructure.Commands;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.ViewModels.Base;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class DevicesWindowViewModel : ViewModel
    {
        private Device _newDevice;
        private string _newDeviceName;
        private DeviceType _newDeviceType;
        private string _newNameDeviceType;
        private Device _oldSelectedDevice;
        private Device _selectedDeviceInDevicePanel;
        private DeviceType _selectedDeviceType;
        private DeviceType _selectedDeviceTypeInDevicePanel;

        public DevicesWindowViewModel(IStore<DeviceType> dBDeviceType, IStore<Device> dBDevice)
        {
            DbDeviceStore = dBDevice;
            DbDeviceTypeStore = dBDeviceType;

            DeviceTypes = new ObservableCollection<DeviceType>(dBDeviceType.GetAll());
            Devices = new ObservableCollection<Device>();
        }

        public DeviceType SelectedDeviceType
        {
            get => _selectedDeviceType;
            set
            {
                Set(ref _selectedDeviceType, value);
                Devices.Clear();
                if (value != null)
                    foreach (var device in DbDeviceStore.GetAll().Where(d => d.Type.Name == value.Name))
                        Devices.Add(device);
            }
        }

        public string NewNameDeviceType
        {
            get => _newNameDeviceType;
            set => Set(ref _newNameDeviceType, value);
        }

        public DeviceType SelectedDeviceTypeInDevicePanel
        {
            get => _selectedDeviceTypeInDevicePanel;
            set => Set(ref _selectedDeviceTypeInDevicePanel, value);
        }

        public Device SelectedDeviceInDevicePanel
        {
            get => _selectedDeviceInDevicePanel;
            set
            {
                _oldSelectedDevice = value;
                Set(ref _selectedDeviceInDevicePanel, value);
                if (value != null)
                    SelectedDeviceTypeInDevicePanel = value.Type;
            }
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

        #region AddNewDeviceTypeCommand

        private LambdaCommand _addNewDeviceTypeCommand;

        public LambdaCommand AddNewDeviceTypeCommand => _addNewDeviceTypeCommand
            ??= new LambdaCommand(OnAddNewDeviceTypeCommandExecuted, CanAddNewDeviceTypeCommandExecute);

        private void OnAddNewDeviceTypeCommandExecuted(object p)
        {
            _newDeviceType = new DeviceType
            {
                Name = NewNameDeviceType
            };
            DbDeviceTypeStore.Add(_newDeviceType);
            DeviceTypes.Add(_newDeviceType);
        }

        private bool CanAddNewDeviceTypeCommandExecute(object p)
        {
            return NewNameDeviceType is not null || NewNameDeviceType != "" || NewNameDeviceType != string.Empty;
        }

        #endregion

        #region RemoveDeviceTypeCommand

        private LambdaCommand _removeDeviceTypeCommand;

        public LambdaCommand RemoveDeviceTypeCommand => _removeDeviceTypeCommand
            ??= new LambdaCommand(OnRemoveDeviceTypeCommandExecuted, CanRemoveDeviceTypeCommandExecute);

        private void OnRemoveDeviceTypeCommandExecuted(object p)
        {
            var result = MessageBoxResult.None;

            if (DbDeviceStore.GetAll().Where(d => d.Type.Name == SelectedDeviceType.Name).Count() > 0)
            {
                result = MessageBox.Show(
                    "Данный тип содержит устройства!\nДействительно хотите удалить данный тип оборудования?",
                    "Внимание!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (MessageBox.Show("Удалить также всё оборудование данного типа?", "Внимание!",
                            MessageBoxButton.YesNo) ==
                        MessageBoxResult.Yes)
                    {
                        foreach (var device in
                                 DbDeviceStore.GetAll().Where(d => d.Type.Name == SelectedDeviceType.Name))
                            DbDeviceStore.Delete(device.Id);
                        DbDeviceTypeStore.Delete(DeviceTypes.FirstOrDefault(t => t.Name == SelectedDeviceType.Name).Id);
                        DeviceTypes.Remove(SelectedDeviceType);
                    }
                    else
                    {
                        var type = new DeviceType();
                        type = DbDeviceTypeStore.GetAll().FirstOrDefault(t => t.Name == SelectedDeviceType.Name);
                        type.Name = "Неопределён";
                        DbDeviceTypeStore.Update(type);
                        SelectedDeviceType = type;
                    }
                }
                else
                {
                }
            }
            else
            {
                DbDeviceTypeStore.Delete(SelectedDeviceType.Id);
                DeviceTypes.Remove(SelectedDeviceType);
            }
        }

        private bool CanRemoveDeviceTypeCommandExecute(object p)
        {
            return SelectedDeviceType is not null;
        }

        #endregion

        #region AddNewDeviceCommand

        private LambdaCommand _addNewDeviceCommand;

        public LambdaCommand AddNewDeviceCommand => _addNewDeviceCommand
            ??= new LambdaCommand(OnAddNewDeviceCommandExecute, CanAddNewDeviceCommandExecuted);

        private void OnAddNewDeviceCommandExecute(object p)
        {
            _newDevice = new Device
            {
                Name = NewDeviceName,
                Number = ""
            };
            if (SelectedDeviceType != null)
            {
                _newDevice.Type = SelectedDeviceType;
                Devices.Add(_newDevice);
            }
            else
            {
                var type = DeviceTypes.FirstOrDefault(t => t.Name == "Неопределён");
                if (type == null)
                    type = new DeviceType
                    {
                        Name = "Неопределён"
                    };
                _newDevice.Type = type;
                DbDeviceTypeStore.Add(type);
                DeviceTypes.Add(type);
            }

            DbDeviceStore.Add(_newDevice);
        }

        private bool CanAddNewDeviceCommandExecuted(object p)
        {
            return NewDeviceName != null || NewDeviceName != " " || NewDeviceName != string.Empty;
        }

        #endregion

        #region SaveChangesSelectedDeviceCommand

        private LambdaCommand _saveChangesSelectedDeviceCommand;

        public LambdaCommand SaveChangesSelectedDeviceCommand => _saveChangesSelectedDeviceCommand
            ??= new LambdaCommand(OnSaveChangesSelectedDeviceCommandExecute,
                CanSaveChangesSelectedDeviceCommandExecuted);

        private void OnSaveChangesSelectedDeviceCommandExecute(object p)
        {
            SelectedDeviceInDevicePanel.Type = SelectedDeviceTypeInDevicePanel;
            DbDeviceStore.Update(SelectedDeviceInDevicePanel);
            DeviceTypes = new ObservableCollection<DeviceType>(DbDeviceTypeStore.GetAll());
            Devices.Clear();
        }

        private bool CanSaveChangesSelectedDeviceCommandExecuted(object p)
        {
            return true;
        }

        #endregion

        #region RemoveSelectedDeviceCommand

        private LambdaCommand _removeSelectedDeviceCommand;

        public LambdaCommand RemoveSelectedDeviceCommand => _removeSelectedDeviceCommand
            ??= new LambdaCommand(OnRemoveSelectedDeviceCommandExecuted, CanRemoveSelectedDeviceCommandExecute);

        private void OnRemoveSelectedDeviceCommandExecuted(object p)
        {
            DbDeviceStore.Delete(SelectedDeviceInDevicePanel.Id);
            Devices.Remove(SelectedDeviceInDevicePanel);
        }

        private bool CanRemoveSelectedDeviceCommandExecute(object p)
        {
            return SelectedDeviceInDevicePanel != null;
        }

        #endregion
    }
}