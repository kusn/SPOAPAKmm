using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.ViewModels.Base;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class MeasPointPageViewModel : ViewModel
    {
        private MeasPoint _point;

        public MeasPoint Point
        {
            get => _point;
            set => Set(ref _point, value);
        }

        public MeasPointPageViewModel(MeasPoint point)
        {
            _point = point;
        }
    }
}
