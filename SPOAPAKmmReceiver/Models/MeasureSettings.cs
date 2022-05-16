using System;
using SPOAPAKmmReceiver.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPOAPAKmmReceiver.Models
{
    public class MeasureSettings : Entity
    {
        private SortedList<int, double> _frequencyList;
        private double _startFrequency = 0.0;
        private double _endFrequency = 0.0;
        private double _step = 0.0;
        private double _offset = 0.0;
        private bool _isPreferredRow = false;
        private bool _isOwnRow = false;
        private double[] freq_gost = {0.01, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.4, 0.5, 0.6, 0.8, 1.0, 1.25, 1.6, 2.0, 2.5, 3.0, 4.0, 5.0, 6.0, 8.0, 10.0, 12.5,
            16.0, 20.0, 25.0, 30.0, 40.0, 50.0, 60.0, 80.0, 100.0, 125.0, 160.0, 200.0, 300.0, 400.0, 500.0, 600.0, 800.0, 1000.0, 1250.0,
            1600.0, 2000.0, 2500.0, 3000.0, 4000.0, 5000.0, 6000.0, 8000.0, 10000.0, 12000.0, 14000.0, 16000.0, 18000.0, 20000.0, 24000.0,
            26000.0, 28000.0, 30000.0, 32000.0, 35000.0, 37500.0};

        [MinLength(5, ErrorMessage = "Минимальное количество частот равно 5")]
        public SortedList<int, double> FrequencyList
        {
            get => _frequencyList;
            set => Set(ref _frequencyList, value);
        }

        [Range(0.0, 110000.0)]
        public double StartFrequency
        {
            get => _startFrequency;
            set
            {
                Set(ref _startFrequency, value);
                if (value > 37500.0)
                {
                    IsPreferredRow = false;
                    IsOwnRow = true;
                    GetFrequencyList();
                }
            }
        }

        [Range(0.0, 110000.0)]
        public double EndFrequency
        {
            get => _endFrequency;
            set => Set(ref _endFrequency, value);
        }

        [Range(0.0, 110000.0)]
        public double Step
        {
            get => _step;
            set => Set(ref _step, value);
        }

        [Range(0.0, 110000.0)]
        public double Offset
        {
            get => _offset;
            set => Set(ref _offset, value);
        }

        public bool IsPreferredRow
        {
            get => _isPreferredRow;
            set => Set(ref _isPreferredRow, value);
        }

        public bool IsOwnRow
        {
            get => _isOwnRow;
            set => Set(ref _isOwnRow, value);
        }

        public void GetFrequencyList()
        {
            SortedList<int, double> list = new SortedList<int, double>();

            if (StartFrequency >= EndFrequency)
            {
                throw new ArgumentException("Начальная частота не может быть равна или превышать конечную!");
                return;
            }
        }
    }
}
