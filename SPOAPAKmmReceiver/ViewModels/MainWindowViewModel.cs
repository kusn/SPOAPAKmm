using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.Models;
using SPOAPAKmmReceiver.ViewModels.Base;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly IStore<Organization> _dbOrganizationsStore;

        public ObservableCollection<Organization> Organizations { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }

        public ObservableCollection<Element> Elements { get; set; }

        public ObservableCollection<Device> Devices { get; set; }

        public ObservableCollection<MeasPoint> MeasPoints { get; set; }

        public ObservableCollection<Measuring> Measurings { get; set; }

        public Page UserPage { get; set; }

    }
}
