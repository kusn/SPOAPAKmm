﻿using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Levels : Entity
    {
        private MeasureItem _measureItem = null!;
        private double _p1;
        private double _p2;

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

        public MeasureItem MeasureItem
        {
            get => _measureItem;
            set => Set(ref _measureItem, value);
        }
    }
}