using System.Collections.Generic;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Room : Entity
    {
        private string? _description;
        private ICollection<Device> _devices;
        private ICollection<Element> _elements;
        private MeasSettings _measSettings;
        private string _name = null!;
        private Organization _organization = null!;

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

        public ICollection<Element> Elements
        {
            get => _elements;
            set => Set(ref _elements, value);
        }

        public ICollection<Device> Devices
        {
            get => _devices;
            set => Set(ref _devices, value);
        }

        public MeasSettings MeasSettings
        {
            get => _measSettings;
            set => Set(ref _measSettings, value);
        }

        public Organization Organization
        {
            get => _organization;
            set => Set(ref _organization, value);
        }
    }
}