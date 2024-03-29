﻿using SPOAPAKmm.Extensions.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SPOAPAKmm.Extensions
{
    [MeasureSettingsValidation]
    [Serializable]
    public class MeasureSettings : Model, IDataErrorInfo
    {
        private int _attenuation = 40;
        private double _endFrequency = 0.01;

        private double[] _freqGost =
        {
            0.01, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.4, 0.5, 0.6, 0.8, 1.0, 1.25, 1.6, 2.0, 2.5, 3.0, 4.0, 5.0, 6.0,
            8.0, 10.0, 12.5,
            16.0, 20.0, 25.0, 30.0, 40.0, 50.0, 60.0, 80.0, 100.0, 125.0, 160.0, 200.0, 300.0, 400.0, 500.0, 600.0,
            800.0, 1000.0, 1250.0,
            1600.0, 2000.0, 2500.0, 3000.0, 4000.0, 5000.0, 6000.0, 8000.0, 10000.0, 12000.0, 14000.0, 16000.0, 18000.0,
            20000.0, 24000.0,
            26000.0, 28000.0, 30000.0, 32000.0, 35000.0, 37500.0
        };

        private SortableObservableCollection<double> _frequencyList = new();
        private bool _isOwnRow = true;
        private bool _isPreamp;
        private bool _isPreferredRow;
        private double _offset;
        private double _power = -30.0;
        private double _rbw = 1.0;
        private double _span = 10.0;
        private double _startFrequency = 0.01;
        private double _step;
        private int _timeOfEmission = 5;

        [MinLength(5, ErrorMessage = "Минимальное количество частот равно 5")]
        public SortableObservableCollection<double> FrequencyList
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
                if (value > _endFrequency)
                    EndFrequency = value;
                Set(ref _startFrequency, value);
            }
        }

        [Range(0.0, 110000.0)]
        public double EndFrequency
        {
            get => _endFrequency;
            set
            {
                if (value < _startFrequency)
                    value = _startFrequency;
                Set(ref _endFrequency, value);
            }
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
            set
            {
                Set(ref _isPreferredRow, value);
                if (value)
                    _isOwnRow = false;
                else
                    _isOwnRow = true;
            }
        }

        public bool IsOwnRow
        {
            get => _isOwnRow;
            set
            {
                Set(ref _isOwnRow, value);
                if (value)
                    _isPreferredRow = false;
                else
                    _isPreferredRow = true;
            }
        }

        [Range(-30, 30)]
        public double Power
        {
            get => _power;
            set => Set(ref _power, value);
        }

        [Range(0, int.MaxValue)]
        public int TimeOfEmission
        {
            get => _timeOfEmission;
            set => Set(ref _timeOfEmission, value);
        }

        [Range(0.0, 110000.0)]
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

        [field: NonSerialized()] public string Error => string.Empty;

        [field: NonSerialized()]
        public string this[string columnName]
        {
            get
            {
                var error = string.Empty;
                switch (columnName)
                {
                    case "StartFrequency":
                        if (StartFrequency < 0.0 || StartFrequency > 110000.0)
                            error = "Начальная частота не должна быть отрицательной или больше 110ГГц";
                        else if (EndFrequency < StartFrequency)
                            error = "Конечная частота не может быть начальной";
                        break;

                    case "EndFrequency":
                        if (EndFrequency < 0.0 || EndFrequency > 110000.0)
                            error = "Конечная частота не должна быть отрицательной или больше 110ГГц";
                        else if (EndFrequency < StartFrequency)
                            error = "Конечная частота не может быть начальной";
                        break;

                    case "Step":
                        if (Step < 0.0 || Step > 110000.0)
                            error = "Величина шага не может быть отрицательной или больше 110ГГц";
                        break;

                    case "Offset":
                        if (Offset < 0.0 || Offset > 110000.0)
                            error = "Величина отстройки не может быть отрицательной или больше 110ГГц";
                        break;

                    case "Power":
                        if (Power < -30.0 || Power > 30.0)
                            error = "Мощность должна быть в диапазоне от -30 до +30 дБм";
                        break;

                    case "TimeOfEmission":
                        if (TimeOfEmission < 0.0 || TimeOfEmission > int.MaxValue)
                            error = "Велична времени излучения не может быть отрицательной";
                        break;

                    case "Span":
                        if (Span < 0.0 || Span > 10000.0)
                            error = "Полоса обзора не может быть отрицательной или больше 10 МГц";
                        break;

                    case "Rbw":
                        if (Rbw < 0.0 || Rbw > 10000.0)
                            error = "Полоса пропускания не может быть отрицательной или больше 10 МГц";
                        break;

                    case "Attenuation":
                        if (Attenuation < 0.0 || Attenuation > 40.0)
                            error = "Аттенюация не может быть отрицательной или больше 40 дБ";
                        break;
                }

                return error;
            }
        }

        public void GetFrequencyList()
        {
            if (_isPreferredRow)
            {
                _frequencyList.Clear();

                if (_startFrequency <= _freqGost[_freqGost.Length - 5])
                    for (var i = 0; i < _freqGost.Length; i++)
                        if (_freqGost[i] == _startFrequency)
                            for (var j = i; j < _freqGost.Length && _freqGost[j] <= _endFrequency; j++)
                                _frequencyList.Add(_freqGost[j] + _offset);
                        else if (_freqGost[i] < _startFrequency && _freqGost[i + 1] > _startFrequency)
                            for (var j = i; j < _freqGost.Length && _freqGost[j] <= _endFrequency; j++)
                                _frequencyList.Add(_freqGost[j] + _offset);
            }
            else
            {
                if (_frequencyList is not null)
                    _frequencyList.Clear();
                else
                    _frequencyList = new SortableObservableCollection<double>();

                var f = _startFrequency;
                if (_step != 0.0)
                {
                    while (f < _endFrequency)
                    {
                        _frequencyList.Add(f + Offset);
                        f = f + _step;
                    }
                }
                else
                {
                    var s = (_endFrequency - _startFrequency) / 4.0;
                    for (var i = 0; i < 5; i++)
                    {
                        _frequencyList.Add(f + _offset);
                        f = f + s;
                    }
                }
            }
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

                    if (measureSettings.EndFrequency < measureSettings.StartFrequency)
                    {
                        ErrorMessage = "Конечная частота не может быть начальной";
                        return false;
                    }

                    if (measureSettings.StartFrequency >= 37500)
                    {
                        measureSettings.IsPreferredRow = false;
                        measureSettings.IsOwnRow = true;
                    }
                    else if (measureSettings.StartFrequency >
                             measureSettings._freqGost[measureSettings._freqGost.Length - 5])
                    {
                        measureSettings.IsPreferredRow = false;
                        measureSettings.IsOwnRow = true;
                    }
                    else if (measureSettings.StartFrequency <=
                             measureSettings._freqGost[measureSettings._freqGost.Length - 5])
                    {
                        var i = 0;
                        while (!(measureSettings._freqGost[i] <= measureSettings.StartFrequency &&
                                 measureSettings._freqGost[i + 1] > measureSettings.StartFrequency)) i++;

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
    }
}