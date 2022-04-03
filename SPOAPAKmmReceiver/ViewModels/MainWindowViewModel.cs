using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SPOAPAKmmReceiver.Controls;
using SPOAPAKmmReceiver.Data;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.ViewModels.Base;

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

                if (value != null)
                {
                    if (value is Organization)
                    {
                        SelectedOrganization = (Organization)value;
                        UserPage = new OrganizationPage();
                        UserPage.DataContext = SelectedOrganization;
                    }
                    else if (value is Room)
                    {
                        SelectedRoom = (Room)value;
                        UserPage = new RoomPage(this);
                    }
                    else if (value is Element)
                    {
                        SelectedElement = (Element)value;
                        UserPage = new ElementPage(this);
                    }
                    else if (value is MeasPoint)
                    {
                        SelectedPoint = (MeasPoint)value;
                        UserPage = new MeasPointPage(this);
                    }
                }
            }
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

            var v = SelectedValue;

        }

    }
}
