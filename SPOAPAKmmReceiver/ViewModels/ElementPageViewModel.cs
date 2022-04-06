using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.ViewModels.Base;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class ElementPageViewModel : ViewModel
    {
        private Element _element;

        Element Element
        {
            get => _element;
            set => Set(ref _element, value);
        }

        public ElementPageViewModel(Element element)
        {
            _element = element;
        }
    }
}
