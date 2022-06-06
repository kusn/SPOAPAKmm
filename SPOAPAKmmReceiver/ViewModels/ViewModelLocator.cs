using Microsoft.Extensions.DependencyInjection;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
        public SettingsWindowViewModel SettingsViewModel => App.Services.GetRequiredService<SettingsWindowViewModel>();
    }
}
