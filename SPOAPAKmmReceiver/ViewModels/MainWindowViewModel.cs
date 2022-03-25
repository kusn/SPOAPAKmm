using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SPOAPAKmmReceiver.Data;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.Models;
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

        public ObservableCollection<Organization> Organizations { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }

        public ObservableCollection<Element> Elements { get; set; }

        public ObservableCollection<Device> Devices { get; set; }

        public ObservableCollection<MeasPoint> MeasPoints { get; set; }

        public ObservableCollection<Measuring> Measurings { get; set; }

        public Page UserPage { get; set; }

        public MainWindowViewModel(IStore<Organization> dBOrganization, IStore<Room> dBRoom, IStore<Element> dBElement, IStore<Device> dBDevice, IStore<MeasPoint> dBMeasPoint, IStore<Measuring> dBMeasuring)
        {
            _dBOrganization = dBOrganization;
            _dBRoom = dBRoom;
            _dBElement = dBElement;
            _dBDevice = dBDevice;
            _dBMeasPoint = dBMeasPoint;
            _dBMeasuring = dBMeasuring;

            _dBOrganization.Add(TestData.TestDataOrganizations.First());
        }

    }
}
