using SPOAPAKmmReceiver.Models.Base;
using System;
using System.ComponentModel;
using System.Net;

namespace SPOAPAKmmReceiver.Models
{
    [Serializable()]
    public class InstrumentSettings : Model, IDataErrorInfo
    {
        private string _ipAddress;
        private int _port;
        private string _instrAddress;

        [field: NonSerialized()]
        public const string Generator = "Generator";
        [field: NonSerialized()]
        public const string Receiver = "Receiver";

        public string IpAddress
        { 
            get => _ipAddress;
            set => Set(ref _ipAddress, value);
        }
        public string InstrAddress
        {
            get => _instrAddress;
            set => Set(ref _instrAddress, value);
        }

        public int Port
        {
            get => _port;
            set => Set(ref _port, value);
        }

        [field: NonSerialized()]
        public string Error => String.Empty;
        
        [field: NonSerialized()]
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "IpAddress":
                        IPAddress address;
                        if (!IPAddress.TryParse(IpAddress, out address))
                            error = "Неверный формат IP адреса";
                        break;

                    case "InstrAddress":
                        break;

                    case "Port":
                        if (Port <= 0)
                            error = "Неверное значение порта";
                        break;
                }
                return error;
            }
        }
    }
}
