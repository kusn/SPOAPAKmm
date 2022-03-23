using SPOAPAKmmReceiver.Models.Base;

namespace SPOAPAKmmReceiver.Models
{
    public class Measuring : Entity
    {
        public double Freq { get; set; }

        public double P1 { get; set; }

        public double P2 { get; set; }

        public MeasPoint MeasPoint { get; set; }
    }
}