using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPOAPAKmmReceiver.Models.Base;

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
