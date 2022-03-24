using System.Collections.Generic;
using SPOAPAKmmReceiver.Models.Base;

namespace SPOAPAKmmReceiver.Models
{
    public class Room : Entity
    {
        [NotNull]
        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Element> Elements { get; set; }

        public ICollection<Device> Devices { get; set; }

        public Organization Organization { get; set; }
    }
}