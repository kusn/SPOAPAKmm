using Microsoft.EntityFrameworkCore;

namespace SPOAPAKmmReceiver.Entities
{
    [Owned]
    public class MeasRange : Base.Entity
    {
        public double StartFreq { get; set; }
        public double EndFreq { get; set; }
    }
}
