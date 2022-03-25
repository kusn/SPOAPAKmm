using SPOAPAKmmReceiver.Models.Base;
using System.Collections.Generic;

namespace SPOAPAKmmReceiver.Models
{
    public class Organization : Entity
    {
        public string Name { get; set; } = null!;

        public string Address { get; set; }

        public string? Description { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
