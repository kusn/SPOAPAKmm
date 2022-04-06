using Microsoft.Extensions.DependencyInjection;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
        public OrganizationPageViewModel OrganizationPageModel => App.Services.GetRequiredService<OrganizationPageViewModel>();
        public RoomPageViewModel RoomPageModel => App.Services.GetRequiredService<RoomPageViewModel>();
        public ElementPageViewModel ElementPageModel => App.Services.GetRequiredService<ElementPageViewModel>();
        public MeasPointPageViewModel MeasPointPageModel => App.Services.GetRequiredService<MeasPointPageViewModel>();
    }
}
