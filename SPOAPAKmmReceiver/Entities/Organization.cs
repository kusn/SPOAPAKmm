using System;
using System.Collections.Generic;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Organization : Entity
    {
        private string? _address = String.Empty;
        private string? _description = String.Empty;
        private string _name = null!;
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