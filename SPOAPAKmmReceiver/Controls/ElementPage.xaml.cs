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
    /// Логика взаимодействия для ElementPage.xaml
    /// </summary>
    public partial class ElementPage : Page
    {
        public string Name_ { get; set; }
        public string? Description { get; set; }

        public ElementPage(MainWindowViewModel vm)
        {
            InitializeComponent();

            Name_ = vm.SelectedElement.Name;
            Description = vm.SelectedElement.Description;
        }
    }
}
