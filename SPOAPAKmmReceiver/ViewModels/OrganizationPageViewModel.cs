using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.ViewModels.Base;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class OrganizationPageViewModel : ViewModel
    {
        private Organization? _organization;
        
        public Organization? Organization
        { 
            get => _organization;
            set => Set(ref _organization, value);
        }

        public OrganizationPageViewModel(object obj)
        {
            if(obj is Organization)
                Organization = obj as Organization;
        }
    }
}
