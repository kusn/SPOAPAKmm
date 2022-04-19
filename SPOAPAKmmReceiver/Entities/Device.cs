using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Device : Base.Entity
    {
        private string _name = null!;
        private string _type;
        private string _number;
        private Room _room = null!;

        public string Type
        {
            get => _type;
            set => Set(ref _type, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Number
        {
            get => _number;
            set => Set(ref _number, value);
        }

        public Room Room
        { 
            get => _room;
            set => Set(ref _room, value);

        }
    }
}