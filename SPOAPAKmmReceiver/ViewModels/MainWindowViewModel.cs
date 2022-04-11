using SPOAPAKmmReceiver.Data;
using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SPOAPAKmmReceiver.Infrastructure.Commands;
using SPOAPAKmmReceiver.Infrastructure.Commands.Base;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private IStore<Organization> _dBOrganization;
        private IStore<Room> _dBRoom;
        private IStore<Element> _dBElement;
        private IStore<Device> _dBDevice;
        private IStore<MeasPoint> _dBMeasPoint;
        private IStore<Measuring> _dBMeasuring;
        
        private bool _isSelected;
        private bool _isChanged;
        private object _selectedValue;
        private Page _userPage;
        private Organization _selectedOrganization;
        private Room _selectedRoom;
        private Element _selectedElement;
        private MeasPoint _selectedPoint;
        private ViewModel _selectedViewModel;
        private Visibility _isVisibilityOrganization = Visibility.Collapsed;
        private Visibility _isVisibilityRoom = Visibility.Collapsed;
        private Visibility _isVisibilityElement = Visibility.Collapsed;
        private Visibility _isVisibilityPoint = Visibility.Collapsed;
        private Visibility _isVisibilityTabControl = Visibility.Hidden;
        private int _selectedTab = 0;
        private string _selectedOrganizationName;
        private string? _selectedOrganizationDescription;
        private string? _selectedOrganizationAddress;
        private string _selectedRoomName;
        private string? _selectedRoomDescription;
        private string _selectedElementName;
        private string? _selectedElementDescription;
        private string _selectedPointName;
        private string? _selectedPointDescription;
        private string _originalselectedOrganizationName;
        private string? _originalselectedOrganizationDescription;
        private string? _originalselectedOrganizationAddress;
        private string _originalselectedRoomName;
        private string? _originalselectedRoomDescription;
        private string _originalselectedElementName;
        private string? _originalselectedElementDescription;
        private string _originalselectedPointName;
        private string? _originalselectedPointDescription;

        public ObservableCollection<Organization> Organizations { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<Element> Elements { get; set; }
        public ObservableCollection<Device> Devices { get; set; }
        public ObservableCollection<MeasPoint> Points { get; set; }
        public ObservableCollection<Measuring> Measurings { get; set; }

        public Organization SelectedOrganization
        {
            get => _selectedOrganization;
            set => Set(ref _selectedOrganization, value);
        }
        public Room SelectedRoom
        {
            get => _selectedRoom;
            set => Set(ref _selectedRoom, value);
        }
        public Element SelectedElement
        {
            get => _selectedElement;
            set => Set(ref _selectedElement, value);
        }
        public MeasPoint SelectedPoint
        {
            get => _selectedPoint;
            set => Set(ref _selectedPoint, value);
        }
        public Visibility IsVisibilityOrganization
        {
            get => _isVisibilityOrganization;
            set => Set(ref _isVisibilityOrganization, value);
        }
        public Visibility IsVisibilityRoom
        {
            get => _isVisibilityRoom;
            set => Set(ref _isVisibilityRoom, value);
        }
        public Visibility IsVisibilityElement
        {
            get => _isVisibilityElement;
            set => Set(ref _isVisibilityElement, value);
        }
        public Visibility IsVisibilityPoint
        {
            get => _isVisibilityPoint;
            set => Set(ref _isVisibilityPoint, value);
        }
        public Visibility IsVisibilityTabControl
        {
            get => _isVisibilityTabControl;
            set => Set(ref _isVisibilityTabControl, value);
        }
        public int SelectedTab
        {
            get => _selectedTab;
            set => Set(ref _selectedTab, value);
        }
        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }
        public bool IsChanged
        {
            get => _isChanged;
            set => Set(ref _isChanged, value);
        }
        public object SelectedValue
        {
            get => _selectedValue;
            set
            {
                Set(ref _selectedValue, value);
                OpenValue(value);
                IsChanged = false;
            }
        }
        public string SelectedOrganizationName
        {
            get => _selectedOrganizationName;
            set
            {
                Set(ref _selectedOrganizationName, value);
                IsChanged = IsChangeText(_originalselectedOrganizationName, value);
            } 
        }
        public string? SelectedOrganizationAddress
        {
            get => _selectedOrganizationAddress;
            set
            {
                Set(ref _selectedOrganizationAddress, value);
                IsChanged = IsChangeText(_originalselectedOrganizationAddress, value);
            }
        }
        public string? SelectedOrganizationDescription
        {
            get => _selectedOrganizationDescription;
            set
            {
                Set(ref _selectedOrganizationDescription, value);
                IsChanged = IsChangeText(_originalselectedOrganizationDescription, value);
            }
        }
        public string SelectedRoomName
        {
            get => _selectedRoomName;
            set
            {
                Set(ref _selectedRoomName, value);
                IsChanged = IsChangeText(_originalselectedRoomName, value);
            }
        }
        public string? SelectedRoomDescription
        {
            get => _selectedRoomDescription;
            set
            {
                Set(ref _selectedRoomDescription, value);
                IsChanged = IsChangeText(_originalselectedRoomDescription, value);
            }
        }
        public string SelectedElementName
        {
            get => _selectedElementName;
            set
            {
                Set(ref _selectedElementName, value);
                IsChanged = IsChangeText(_originalselectedElementName, value);
            }
        }
        public string? SelectedElementDescription
        {
            get => _selectedElementDescription;
            set
            {
                Set(ref _selectedElementDescription, value);
                IsChanged = IsChangeText(_originalselectedElementDescription, value);
            }
        }
        public string SelectedPointName
        {
            get => _selectedPointName;
            set
            {
                Set(ref _selectedPointName, value);
                IsChanged = IsChangeText(_originalselectedPointName, value);
            }
        }
        public string? SelectedPointDescription
        {
            get => _selectedPointDescription;
            set
            {
                Set(ref _selectedPointDescription, value);
                IsChanged = IsChangeText(_originalselectedPointDescription, value);
            }
        }
        public IStore<Organization> DbOrganizationStore { get; set; }
        public IStore<Room> DbRoomStore { get; set; }
        public IStore<Element> DbElementStore { get; set; }
        public IStore<MeasPoint> DbPointStore { get; set; }
        public IStore<Device> DbDeviceStore { get; set; }
        public IStore<Measuring> DbMeasuringStore { get; set; }

        public ViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value);
        }
        public Page UserPage
        {
            get => _userPage;
            set => Set(ref _userPage, value);
        }

        public MainWindowViewModel(IStore<Organization> dBOrganization,
            IStore<Room> dBRoom,
            IStore<Element> dBElement,
            IStore<Device> dBDevice,
            IStore<MeasPoint> dBMeasPoint,
            IStore<Measuring> dBMeasuring)
        {
            DbOrganizationStore = dBOrganization;
            DbRoomStore = dBRoom;
            DbElementStore = dBElement;
            DbDeviceStore = dBDevice;
            DbPointStore = dBMeasPoint;
            DbMeasuringStore = dBMeasuring;

            IEnumerable<Organization> organizationsInDb = new List<Organization>();


            organizationsInDb = DbOrganizationStore.GetAll();
#if DEBUG
            var c = organizationsInDb.Count();

            foreach (var org in TestData.TestDataOrganizations)
            {
                if(c == 0 || (organizationsInDb.FirstOrDefault(o => o.Name == org.Name) == null))
                    DbOrganizationStore.Add(org);
            }
#endif

            Organizations = new ObservableCollection<Organization>(DbOrganizationStore.GetAll());
            Rooms = new ObservableCollection<Room>(DbRoomStore.GetAll());
            Elements = new ObservableCollection<Element>(DbElementStore.GetAll());
            Devices = new ObservableCollection<Device>(DbDeviceStore.GetAll());
            Points = new ObservableCollection<MeasPoint>(DbPointStore.GetAll());
            Measurings = new ObservableCollection<Measuring>(DbMeasuringStore.GetAll());
        }

        private void OpenValue(object obj)
        {
            IsVisibilityTabControl = Visibility.Hidden;
            if (obj != null)
            {
                IsVisibilityTabControl = Visibility.Visible;

                if (obj is Organization)
                {
                    SelectedOrganization = (Organization)obj;
                    SelectedOrganizationName = SelectedOrganization.Name;
                    _originalselectedOrganizationName = SelectedOrganization.Name;
                    SelectedOrganizationDescription = SelectedOrganization.Description;
                    _originalselectedOrganizationDescription = SelectedOrganization.Description;
                    SelectedOrganizationAddress = SelectedOrganization.Address;
                    _originalselectedOrganizationAddress = SelectedOrganization.Address;
                    IsVisibilityOrganization = Visibility.Visible;
                    IsVisibilityRoom = Visibility.Hidden;
                    IsVisibilityElement = Visibility.Hidden;
                    IsVisibilityPoint = Visibility.Hidden;
                    SelectedTab = 0;
                }
                else if (obj is Room)
                {
                    SelectedRoom = (Room)obj;
                    SelectedRoomName = SelectedRoom.Name;
                    _originalselectedRoomName = SelectedRoom.Name;
                    SelectedRoomDescription = SelectedRoom.Description;
                    _originalselectedRoomDescription = SelectedRoom.Description;
                    IsVisibilityOrganization = Visibility.Hidden;
                    IsVisibilityRoom = Visibility.Visible;
                    IsVisibilityElement = Visibility.Hidden;
                    IsVisibilityPoint = Visibility.Hidden;
                    SelectedTab = 1;
                }
                else if (obj is Element)
                {
                    SelectedElement = (Element)obj;
                    SelectedElementName = SelectedElement.Name;
                    _originalselectedElementName = SelectedElement.Name;
                    SelectedElementDescription = SelectedElement.Description;
                    _originalselectedElementDescription = SelectedElement.Description;
                    IsVisibilityOrganization = Visibility.Hidden;
                    IsVisibilityRoom = Visibility.Hidden;
                    IsVisibilityElement = Visibility.Visible;
                    IsVisibilityPoint = Visibility.Hidden;
                    SelectedTab = 2;
                }
                else if (obj is MeasPoint)
                {
                    SelectedPoint = (MeasPoint)obj;
                    SelectedPointName = SelectedPoint.Name;
                    _originalselectedPointName = SelectedPoint.Name;
                    SelectedPointDescription = SelectedPoint.Description;
                    _originalselectedPointDescription = SelectedPoint.Description;
                    IsVisibilityOrganization = Visibility.Hidden;
                    IsVisibilityRoom = Visibility.Hidden;
                    IsVisibilityElement = Visibility.Hidden;
                    IsVisibilityPoint = Visibility.Visible;
                    SelectedTab = 3;
                }
            }
        }

        private bool IsChangeText(string? oldText, string? newText)
        {
            bool isChange = false;
            if (oldText != newText)
                isChange = true;
            return isChange;
        }

        private LambdaCommand _saveChangesCommand;

        public LambdaCommand SaveChangesCommand => _saveChangesCommand
            ??= new LambdaCommand(OnSaveChangesCommandExecuted, CanSaveChangesCommandExecute);

        private void OnSaveChangesCommandExecuted(object p)
        {
            if (SelectedValue is Organization)
            {
                SelectedOrganization.Name = SelectedOrganizationName;
                SelectedOrganization.Description = SelectedOrganizationDescription;
                SelectedOrganization.Address = SelectedOrganizationAddress;
                DbOrganizationStore.Update(SelectedOrganization);
            }
            else if (SelectedValue is Room)
            {
                SelectedRoom.Name = SelectedRoomName;
                SelectedRoom.Description = SelectedRoomDescription;
                DbRoomStore.Update(SelectedRoom);
            }
            else if (SelectedValue is Element)
            {
                SelectedElement.Name = SelectedElementName;
                SelectedElement.Description = SelectedElementDescription;
            }
            else if (SelectedValue is MeasPoint)
            {
                SelectedPoint.Name = SelectedElementName;
                SelectedPoint.Description = SelectedElementDescription;
            }
        }

        private bool CanSaveChangesCommandExecute(object p) => IsChanged;
    }
}
