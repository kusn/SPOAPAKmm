using System;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Entities
{
    public class Device : Entity
    {
        private string _name = null!;
        private string _number = "";
        private MeasRange _range = new() { StartFreq = 0.1, EndFreq = 0.1 };
        private DeviceType _type;
        private DateTime _verificationDate;
        private string _verificationInformation = "";

        private string _verificationOrganization = "";
        //private Room _room = null!;

        public DeviceType Type
        {
            get => _type;
            set => Set(ref _type, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Number
        {
            get => _number;
            set => Set(ref _number, value);
        }

        public MeasRange Range
        {
            get => _range;
            set => Set(ref _range, value);
        }

        public DateTime VerificationDate
        {
            get => _verificationDate;
            set => Set(ref _verificationDate, value);
        }

        public string VerificationInformation
        {
            get => _verificationInformation;
            set => Set(ref _verificationInformation, value);
        }

        public string VerificationOrganization
        {
            get => _verificationOrganization;
            set => Set(ref _verificationOrganization, value);
        }

        //public Room Room
        //{ 
        //    get => _room;
        //    set => Set(ref _room, value);

        //}
    }
}