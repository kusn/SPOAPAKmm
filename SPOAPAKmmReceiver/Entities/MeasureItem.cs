using SPOAPAKmmReceiver.Entities.Base;
using System.Collections.Generic;

namespace SPOAPAKmmReceiver.Entities
{
    public class MeasureItem : Entity
    {
        private double _freq;
        private double _p1;
        private double _p2;
        private double _averageE;
        private double _dX;
        private double _e;
        private MeasPoint _measPoint = null!;
        private ICollection<Levels> _levels;

        public double Freq
        {
            get => _freq;
            set => Set(ref _freq, value);
        }

        public double P1
        {
            get => _p1;
            set => Set(ref _p1, value);
        }

        public double P2
        {
            get => _p2;
            set => Set(ref _p2, value);
        }

        public double AverageE
        {
            get => _averageE;
            set => Set(ref _averageE, value);
        }

        public double DX
        {
            get => _dX;
            set => Set(ref _dX, value);
        }

        public double E
        {
            get => _e;
            set => Set(ref _e, value);
        }

        public ICollection<Levels> Levels
        {
            get => _levels;
            set => Set(ref _levels, value);
        }

        public MeasPoint MeasPoint
        {
            get => _measPoint;
            set => Set(ref _measPoint, value);
        }

    }
}
