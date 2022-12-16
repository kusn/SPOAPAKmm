using Microsoft.EntityFrameworkCore;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    [Owned]
    public class MeasRange : Entity
    {
        public double StartFreq { get; set; }
        public double EndFreq { get; set; }
    }
}