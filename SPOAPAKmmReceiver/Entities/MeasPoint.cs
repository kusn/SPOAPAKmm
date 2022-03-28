using System.Collections.Generic;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class MeasPoint : Base.Entity
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public double AverageE { get; set; }

        public double DX { get; set; }

        public double E { get; set; }

        public ICollection<Measuring> Measurings { get; set; }

        public Element Element { get; set; } = null!;
    }
}