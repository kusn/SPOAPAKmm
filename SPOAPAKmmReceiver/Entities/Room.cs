using System.Collections.Generic;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Room : Base.Entity
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public ICollection<Element> Elements { get; set; }

        public ICollection<Device> Devices { get; set; }

        public Organization Organization { get; set; } = null!;
    }
}