using System.ComponentModel;
using System.Windows;

namespace SPOAPAKmmReceiver.Views
{
    /// <summary>
    ///     Логика взаимодействия для DevicesWindow.xaml
    /// </summary>
    public partial class DevicesWindow : Window
    {
        private bool? _result;

        public DevicesWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            DialogResult = true;
        }
    }
}