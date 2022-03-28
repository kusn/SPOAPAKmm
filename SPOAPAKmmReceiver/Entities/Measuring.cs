using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Measuring : Base.Entity
    {
        public double Freq { get; set; }

        public double P1 { get; set; }

        public double P2 { get; set; }

        public MeasPoint MeasPoint { get; set; } = null!;
    }
}