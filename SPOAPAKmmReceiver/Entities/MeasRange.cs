using Microsoft.EntityFrameworkCore;

namespace SPOAPAKmmReceiver.Entities
{
    [Owned]
    public class MeasRange : Base.Entity
    {
        public double SartFreq { get; set; }
        public double EndFreq { get; set; }
    }
}
