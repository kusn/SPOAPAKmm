using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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

        public ObservableCollection<Organization> Organizations { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }

        public ObservableCollection<Element> Elements { get; set; }

        public ObservableCollection<Device> Devices { get; set; }

        public ObservableCollection<MeasPoint> Points { get; set; }

        public ObservableCollection<Measuring> Measurings { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }

        public object SelectedValue
        {
            get => _selectedValue;
            set => Set(ref _selectedValue, value);
        }

        public Page UserPage { get; set; }

        public MainWindowViewModel(IStore<Organization> dBOrganization, IStore<Room> dBRoom, IStore<Element> dBElement, IStore<Device> dBDevice, IStore<MeasPoint> dBMeasPoint, IStore<Measuring> dBMeasuring)
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
