using SPOAPAKmmReceiver.Entities.Base;
using System.Collections.Generic;

namespace SPOAPAKmmReceiver.Entities
{
    public class Organization : Base.Entity
    {
        private string _name = null!;
        private string? _address;
        private string? _description;
        private ICollection<Room> _rooms;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string? Address
        {
            get => _address;
            set => Set(ref _address, value);
        }

        public string? Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public ICollection<Room> Rooms
        {
            get => _rooms;
            set => Set(ref _rooms, value);
        }
    }
}
