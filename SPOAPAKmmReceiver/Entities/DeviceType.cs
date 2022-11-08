using Microsoft.EntityFrameworkCore;

namespace SPOAPAKmmReceiver.Entities
{    
    public class DeviceType : Base.Entity
    {
        private string _name = null!;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
    }
}
