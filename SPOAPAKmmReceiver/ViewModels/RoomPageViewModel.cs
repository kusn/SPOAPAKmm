using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.ViewModels.Base;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class RoomPageViewModel : ViewModel
    {
        private Room _room;

        Room Room
        {
            get => _room;
            set => Set(ref _room, value);
        }

        public RoomPageViewModel(Room room)
        {
            _room = room;
        }
    }
}
