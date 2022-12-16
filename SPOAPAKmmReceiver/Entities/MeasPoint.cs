using System.Collections.Generic;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class MeasPoint : Entity
    {
        private string? _description;
        private Element _element = null!;
        private ICollection<MeasureItem> _measureItems;
        private string _name = null!;

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

        public ICollection<MeasureItem> MeasureItems
        {
            get => _measureItems;
            set => Set(ref _measureItems, value);
        }

        public Element Element
        {
            get => _element;
            set => Set(ref _element, value);
        }
    }
}