using System.Collections.Generic;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Element : Entity
    {
        private string? _description;
        private ICollection<MeasPoint> _measPoints;
        private string _name = null!;
        private Room _room = null!;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string? Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public ICollection<MeasPoint> Points
        {
            get => _measPoints;
            set => Set(ref _measPoints, value);
        }

        public Room Room
        {
            get => _room;
            set => Set(ref _room, value);
        }
    }
}