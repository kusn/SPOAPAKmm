using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class DeviceType : Entity
    {
        private string _name = null!;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
    }
}