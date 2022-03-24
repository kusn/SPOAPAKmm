using SPOAPAKmmReceiver.Models.Base;

namespace SPOAPAKmmReceiver.Models
{
    public class Device : Entity
    {
        public string Type { get; set; }

        public string Number { get; set; }

        public Room Room { get; set; }
    }
}