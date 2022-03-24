using SPOAPAKmmReceiver.Models.Base;
using System.Collections.Generic;

namespace SPOAPAKmmReceiver.Models
{
    public class Organization : Entity
    {
        [NotNull]
        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Description { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
