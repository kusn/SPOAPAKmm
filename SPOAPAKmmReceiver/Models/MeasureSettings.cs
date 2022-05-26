using System;
using SPOAPAKmmReceiver.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SPOAPAKmmReceiver.Models
{
    [MeasureSettingsValidation]
    public class MeasureSettings : Entity
    {
        private List<double> _frequencyList;
        private double _startFrequency = 0.0;
        private double _endFrequency = 0.0;
        private double _step = 0.0;
        private double _offset = 0.0;
        private double _power = -30.0;
        private int _timeOfEmission = 0;
        private double _span = 0.0;
        private double _rbw = 0.0;
        private int _attenuation = -40;
        private bool _isPreferredRow = false;
        private bool _isOwnRow = false;
        private bool _isPreamp = false;
        private double[] _freqGost = {0.01, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.4, 0.5, 0.6, 0.8, 1.0, 1.25, 1.6, 2.0, 2.5, 3.0, 4.0, 5.0, 6.0, 8.0, 10.0, 12.5,
            16.0, 20.0, 25.0, 30.0, 40.0, 50.0, 60.0, 80.0, 100.0, 125.0, 160.0, 200.0, 300.0, 400.0, 500.0, 600.0, 800.0, 1000.0, 1250.0,
            1600.0, 2000.0, 2500.0, 3000.0, 4000.0, 5000.0, 6000.0, 8000.0, 10000.0, 12000.0, 14000.0, 16000.0, 18000.0, 20000.0, 24000.0,
            26000.0, 28000.0, 30000.0, 32000.0, 35000.0, 37500.0};

        [MinLength(5, ErrorMessage = "Минимальное количество частот равно 5")]
        public List<double> FrequencyList
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

        [Range(-30, 30)]
        public double Power
        {
            get => _power;
            set => Set(ref _power, value);
        }

        [Range(0, Int32.MaxValue)]
        public int TimeOfEmission
        {
            get => _timeOfEmission;
            set => Set(ref _timeOfEmission, value);
        }

        [Range(0.0, 40000)]
        public double Span
        {
            get => _span;
            set => Set(ref _span, value);
        }

        [Range(0.0, 10000)]
        public double Rbw
        {
            get => _rbw;
            set => Set(ref _rbw, value);
        }

        [Range(0, 40)]
        public int Attenuation
        {
            get => _attenuation;
            set => Set(ref _attenuation, value);
        }

        public bool IsPreamp
        {
            get => _isPreamp;
            set => Set(ref _isPreamp, value);
        }

        public class MeasureSettingsValidationAttribute : ValidationAttribute
        {
            public override bool IsValid(object? value)
            {
                if (value is MeasureSettings measureSettings)
                {
                    if (measureSettings.StartFrequency < 0.0 || measureSettings.StartFrequency > 110000.0)
                    {
                        ErrorMessage = "Начальная частота не должна быть отрицательной или больше 110ГГц";
                        return false;
                    }
                    if (measureSettings.EndFrequency < 0.0 || measureSettings.EndFrequency > 110000.0)
                    {
                        ErrorMessage = "Конечная частота не должна быть отрицательной или больше 110ГГц";
                        return false;
                    }
                    if (measureSettings.EndFrequency <= measureSettings.StartFrequency)
                    {
                        ErrorMessage = "Конечная частота не может быть начальной";
                        return false;
                    }
                    if (measureSettings.StartFrequency >= 37500)
                    {
                        measureSettings.IsPreferredRow = false;
                        measureSettings.IsOwnRow = true;
                    }
                    else if (measureSettings.StartFrequency > measureSettings._freqGost[measureSettings._freqGost.Length - 5])
                    {
                        measureSettings.IsPreferredRow = false;
                        measureSettings.IsOwnRow = true;
                    }
                    else if (measureSettings.StartFrequency <= measureSettings._freqGost[measureSettings._freqGost.Length - 5])
                    {
                        int i = 0;
                        while (!(measureSettings._freqGost[i] <= measureSettings.StartFrequency && measureSettings._freqGost[i + 1] > measureSettings.StartFrequency))
                        {
                            i++;
                        }

                        if (measureSettings._freqGost[i + 4] > measureSettings.EndFrequency)
                        {
                            measureSettings.IsPreferredRow = false;
                            measureSettings.IsOwnRow = true;
                        }
                        else
                        {
                            measureSettings.IsPreferredRow = true;
                            measureSettings.IsOwnRow = false;
                        }

                    }
                    return true;
                }
                return false;
            }
        }

        public void GetFrequencyList()
        {
            if (IsPreferredRow)
            {
                FrequencyList.Clear();

                if (StartFrequency <= _freqGost[_freqGost.Length - 5])
                {
                    for (int i = 0; i < _freqGost.Length; i++)
                    {
                        if (_freqGost[i] == StartFrequency)
                        {
                            FrequencyList.Add(_freqGost[i] + _offset);
                            FrequencyList.Add(_freqGost[i + 1] + _offset);
                            FrequencyList.Add(_freqGost[i + 2] + _offset);
                            FrequencyList.Add(_freqGost[i + 3] + _offset);
                            FrequencyList.Add(_freqGost[i + 4] + _offset);
                        }
                        else if (_freqGost[i] < StartFrequency && _freqGost[i + 1] > StartFrequency)
                        {
                            FrequencyList.Add(_freqGost[i] + _offset);
                            FrequencyList.Add(_freqGost[i + 1] + _offset);
                            FrequencyList.Add(_freqGost[i + 2] + _offset);
                            FrequencyList.Add(_freqGost[i + 3] + _offset);
                            FrequencyList.Add(_freqGost[i + 4] + _offset);
                        }
                    }

                }
            }
            else
            {
                FrequencyList.Clear();
                double f = StartFrequency;
                while (f <= EndFrequency)
                {
                    FrequencyList.Add(f + Offset);
                    f = f + Step;
                }
            }
        }
    }
}
