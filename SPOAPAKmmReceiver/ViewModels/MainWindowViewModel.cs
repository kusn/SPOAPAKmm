using SPOAPAKmmReceiver.Data;
using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        public object SelectedValue
        {
            get => _selectedValue;
            set
            {
                Set(ref _selectedValue, value);
                OpenValue(value);
            }
        }

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
            _dBOrganization = dBOrganization;
            _dBRoom = dBRoom;
            _dBElement = dBElement;
            _dBDevice = dBDevice;
            _dBMeasPoint = dBMeasPoint;
            _dBMeasuring = dBMeasuring;

            IEnumerable<Organization> organizationsInDb = new List<Organization>();


            organizationsInDb = _dBOrganization.GetAll();
            var c = organizationsInDb.Count();


            foreach (var org in TestData.TestDataOrganizations)
            {
                if(c == 0 || (organizationsInDb.First(o => o.Name == org.Name) == null))
                    _dBOrganization.Add(org);
            }
            
            Organizations = new ObservableCollection<Organization>(_dBOrganization.GetAll());
            Rooms = new ObservableCollection<Room>(_dBRoom.GetAll());
            Elements = new ObservableCollection<Element>(_dBElement.GetAll());
            Devices = new ObservableCollection<Device>(_dBDevice.GetAll());
            Points = new ObservableCollection<MeasPoint>(_dBMeasPoint.GetAll());
            Measurings = new ObservableCollection<Measuring>(_dBMeasuring.GetAll());
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
                    IsVisibilityOrganization = Visibility.Visible;
                    IsVisibilityRoom = Visibility.Hidden;
                    IsVisibilityElement = Visibility.Hidden;
                    IsVisibilityPoint = Visibility.Hidden;
                    SelectedTab = 0;
                }
                else if (obj is Room)
                {
                    SelectedRoom = (Room)obj;
                    IsVisibilityOrganization = Visibility.Hidden;
                    IsVisibilityRoom = Visibility.Visible;
                    IsVisibilityElement = Visibility.Hidden;
                    IsVisibilityPoint = Visibility.Hidden;
                    SelectedTab = 1;
                }
                else if (obj is Element)
                {
                    SelectedElement = (Element)obj;
                    IsVisibilityOrganization = Visibility.Hidden;
                    IsVisibilityRoom = Visibility.Hidden;
                    IsVisibilityElement = Visibility.Visible;
                    IsVisibilityPoint = Visibility.Hidden;
                    SelectedTab = 2;
                }
                else if (obj is MeasPoint)
                {
                    SelectedPoint = (MeasPoint)obj;
                    IsVisibilityOrganization = Visibility.Hidden;
                    IsVisibilityRoom = Visibility.Hidden;
                    IsVisibilityElement = Visibility.Hidden;
                    IsVisibilityPoint = Visibility.Visible;
                    SelectedTab = 3;
                }
            }
        }
    }
}
