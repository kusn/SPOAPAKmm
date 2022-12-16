using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Frequency : Entity
    {
        private double _freq;
        private MeasSettings _measSettings;

        public double Freq
        {
            get => _freq;
            set => Set(ref _freq, value);
        }

        public MeasSettings MeasSettings
        {
            get => _measSettings;
            set => Set(ref _measSettings, value);
        }
    }
}