﻿using System.Collections.Generic;
using SPOAPAKmmReceiver.Models.Base;

namespace SPOAPAKmmReceiver.Models
{
    public class Element : Entity
    {
        [NotNull]
        public string Name { get; set; }

        public string? Description { get; set; }

        [NotNull]
        public Room Room { get; set; }

        public ICollection<MeasPoint> Points { get; set; }
    }
}