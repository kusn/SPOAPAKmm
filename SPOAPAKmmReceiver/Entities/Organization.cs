using SPOAPAKmmReceiver.Entities.Base;
using System.Collections.Generic;

namespace SPOAPAKmmReceiver.Entities
{
    public class Organization : Base.Entity
    {
        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Description { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
