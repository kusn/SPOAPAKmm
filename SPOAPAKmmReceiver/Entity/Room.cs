using System.Collections.Generic;
using SPOAPAKmmReceiver.Models.Base;

namespace SPOAPAKmmReceiver.Models
{
    public class Room : Entity
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public ICollection<Element> Elements { get; set; }

        public ICollection<Device> Devices { get; set; }

        public Organization Organization { get; set; } = null!;
    }
}