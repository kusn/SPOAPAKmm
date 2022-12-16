using System.Collections.Generic;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class MeasSettings : Entity
    {
        private int _attenuation;
        private double _endFrequency;
        private ICollection<Frequency> _frequencyList;
        private bool _isOwnRow;
        private bool _isPreamp;
        private bool _isPreferredRow;
        private double _offset;
        private double _power;
        private double _rbw;
        private double _span;
        private double _startFrequency;
        private double _step;
        private int _timeOfEmission;

        public ICollection<Frequency> FrequencyList
        {
            get => _frequencyList;
            set => Set(ref _frequencyList, value);
        }

        public double StartFrequency
        {
            get => _startFrequency;
            set => Set(ref _startFrequency, value);
        }

        public double EndFrequency
        {
            get => _endFrequency;
            set => Set(ref _endFrequency, value);
        }

        public double Step
        {
            get => _step;
            set => Set(ref _step, value);
        }

        public double Offset
        {
            get => _offset;
            set => Set(ref _offset, value);
        }

        public double Power
        {
            get => _power;
            set => Set(ref _power, value);
        }

        public int TimeOfEmission
        {
            get => _timeOfEmission;
            set => Set(ref _timeOfEmission, value);
        }

        public double Span
        {
            get => _span;
            set => Set(ref _span, value);
        }

        public double Rbw
        {
            get => _rbw;
            set => Set(ref _rbw, value);
        }

        public int Attenuation
        {
            get => _attenuation;
            set => Set(ref _attenuation, value);
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

        public bool IsPreamp
        {
            get => _isPreamp;
            set => Set(ref _isPreamp, value);
        }
    }
}