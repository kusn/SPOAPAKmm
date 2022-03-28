using System.Collections.Generic;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Element : Base.Entity
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public ICollection<MeasPoint> Points { get; set; }

        public Room Room { get; set; } = null!;
    }
}