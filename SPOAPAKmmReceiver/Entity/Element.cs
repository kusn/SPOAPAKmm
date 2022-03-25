using System.Collections.Generic;
using SPOAPAKmmReceiver.Models.Base;

namespace SPOAPAKmmReceiver.Models
{
    public class Element : Entity
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public ICollection<MeasPoint> Points { get; set; }

        public Room Room { get; set; } = null!;
    }
}