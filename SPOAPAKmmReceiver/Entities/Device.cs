using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Device : Base.Entity
    {
        public string Type { get; set; }
        
        public string Name { get; set; } = null!;

        public string Number { get; set; }

        public Room Room { get; set; } = null!;
    }
}