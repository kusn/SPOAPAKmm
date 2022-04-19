using System.Collections.Generic;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class MeasPoint : Base.Entity
    {
        private string _name = null!;
        private string? _description;
        private double _averageE;
        private double _dX;
        private double _e;
        private ICollection<Measuring> _measurings;
        private Element _element = null!;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string? Description
        {
            get => _description;
            set => Set(ref _description, value);
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

        public ICollection<Measuring> Measurings
        {
            get => _measurings;
            set => Set(ref _measurings, value);
        }

        public Element Element
        {
            get => _element;
            set => Set(ref _element, value);
        }
    }
}