using System;
using SPOAPAKmmReceiver.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace SPOAPAKmmReceiver.Models
{
    [MeasureSettingsValidation]
    public class MeasureSettings : Entity, IDataErrorInfo
    {
        private ObservableCollection<double> _frequencyList = new ObservableCollection<double>();
        private double _startFrequency = 0.01;
        private double _endFrequency = 0.01;
        private double _step = 0.0;
        private double _offset = 0.0;
        private double _power = -30.0;
        private int _timeOfEmission = 0;
        private double _span = 0.0;
        private double _rbw = 0.0;
        private int _attenuation = 40;
        private bool _isPreferredRow = false;
        private bool _isOwnRow = false;
        private bool _isPreamp = false;
        private double[] _freqGost = {0.01, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.4, 0.5, 0.6, 0.8, 1.0, 1.25, 1.6, 2.0, 2.5, 3.0, 4.0, 5.0, 6.0, 8.0, 10.0, 12.5,
            16.0, 20.0, 25.0, 30.0, 40.0, 50.0, 60.0, 80.0, 100.0, 125.0, 160.0, 200.0, 300.0, 400.0, 500.0, 600.0, 800.0, 1000.0, 1250.0,
            1600.0, 2000.0, 2500.0, 3000.0, 4000.0, 5000.0, 6000.0, 8000.0, 10000.0, 12000.0, 14000.0, 16000.0, 18000.0, 20000.0, 24000.0,
            26000.0, 28000.0, 30000.0, 32000.0, 35000.0, 37500.0};

        [MinLength(5, ErrorMessage = "Минимальное количество частот равно 5")]
        public ObservableCollection<double> FrequencyList
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
                /*if (value > 37500.0)
                {
                    _isPreferredRow = false;
                    _isOwnRow = true;                    
                }
                else if (value > _freqGost[_freqGost.Length - 5])
                {
                    _isPreferredRow = false;
                    _isOwnRow = true;
                }
                else if (value <= _freqGost[_freqGost.Length - 5])
                {
                    int i = 0;
                    while (!(_freqGost[i] <= value && _freqGost[i + 1] > value) && i < _freqGost.Length - 5)
                    {
                        i++;
                    }
                    if (_freqGost[i + 4] > _endFrequency)
                    {
                        _isPreferredRow = false;
                        _isOwnRow = true;
                    }
                    else
                    {
                        _isPreferredRow = true;
                        _isOwnRow = false;
                    }
                }*/
                //GetFrequencyList();
            }
        }

        [Range(0.0, 110000.0)]
        public double EndFrequency
        {
            get => _endFrequency;
            set 
            {
                Set(ref _endFrequency, value);
                /*if (value > 37500.0)
                {
                    IsPreferredRow = false;
                    IsOwnRow = true;
                }
                else if (_startFrequency > _freqGost[_freqGost.Length - 5])
                {
                    IsPreferredRow = false;
                    IsOwnRow = true;
                }
                else if (_startFrequency <= _freqGost[_freqGost.Length - 5])
                {
                    int i = 0;
                    while (!(_freqGost[i] <= _startFrequency && _startFrequency < _freqGost[i + 1]) && i < _freqGost.Length - 5)
                    {
                        i++;
                    }
                    if (_freqGost[i + 4] > value)
                    {
                        IsPreferredRow = false;
                        IsOwnRow = true;
                    }
                    else
                    {
                        IsPreferredRow = true;
                        IsOwnRow = false;
                    }
                }*/
                //GetFrequencyList();
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

        [Range(0, Int32.MaxValue)]
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

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch(columnName)
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
                        if (TimeOfEmission < 0.0 || TimeOfEmission > Int32.MaxValue)
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
                        if (Attenuation < 0.0 || Attenuation > 10000.0)
                            error = "Аттенюация не может быть отрицательной или больше 40 дБ";
                        break;
                }

                return error;
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
            if (_isPreferredRow)
            {
                _frequencyList.Clear();

                if (_startFrequency <= _freqGost[_freqGost.Length - 5])
                {
                    for (int i = 0; i < _freqGost.Length; i++)
                    {
                        if (_freqGost[i] == _startFrequency)
                        {
                            for(int j = i; j < _freqGost.Length && _freqGost[j] <= _endFrequency; j++)
                            {
                                _frequencyList.Add(_freqGost[j] + _offset);
                            }
                        }
                        else if (_freqGost[i] < _startFrequency && _freqGost[i + 1] > _startFrequency)
                        {
                            for (int j = i; j < _freqGost.Length && _freqGost[j] <= _endFrequency; j++)
                            {
                                _frequencyList.Add(_freqGost[j] + _offset);
                            }
                        }
                    }

                }
            }
            else
            {
                if (_frequencyList is not null)
                    _frequencyList.Clear();
                else
                    _frequencyList = new ObservableCollection<double>();
                
                double f = _startFrequency;
                if (_step != 0.0)
                    while (f < _endFrequency)
                    {
                        _frequencyList.Add(f + Offset);
                        f = f + _step;
                    }
                else
                {
                    var s = (_endFrequency - _startFrequency) / 4.0;
                    for(int i = 0; i < 5; i++)
                    {
                        _frequencyList.Add(f + _offset);
                        f = f + s;
                    }
                }
            }
        }
    }
}
