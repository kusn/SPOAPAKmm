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
using SPOAPAKmmReceiver.ViewModels;

namespace SPOAPAKmmReceiver.Controls
{
    /// <summary>
    /// Логика взаимодействия для OrganizationPage.xaml
    /// </summary>
    public partial class OrganizationPage : Page
    {
        public string Name_ { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }

        public OrganizationPage(MainWindowViewModel vm)
        {
            InitializeComponent();

            Name_ = vm.SelectedOrganization.Name;
            Address = vm.SelectedOrganization.Address;
            Description = vm.SelectedOrganization.Description;

        }
    }
}
