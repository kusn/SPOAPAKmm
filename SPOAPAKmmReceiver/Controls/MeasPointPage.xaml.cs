using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.ViewModels;

namespace SPOAPAKmmReceiver.Controls
{
    /// <summary>
    /// Логика взаимодействия для MeasPointPage.xaml
    /// </summary>
    public partial class MeasPointPage : Page
    {
        public string Name_ { get; set; }

        public string? Description { get; set; }

        public double AverageE { get; set; }

        public double DX { get; set; }

        public double E { get; set; }

        public ICollection<Measuring> Measurings { get; set; }

        public MeasPointPage(MainWindowViewModel vm)
        {
            InitializeComponent();

            Name_ = vm.SelectedPoint.Name;
            Description = vm.SelectedPoint.Description;
            AverageE = vm.SelectedPoint.AverageE;
            DX = vm.SelectedPoint.DX;
            E = vm.SelectedPoint.E;
            Measurings = vm.SelectedPoint.Measurings;
        }
    }
}
