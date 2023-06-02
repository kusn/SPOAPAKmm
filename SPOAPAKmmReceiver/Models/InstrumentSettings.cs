using System;
using System.ComponentModel;
using System.Net;
using SPOAPAKmmReceiver.Models.Base;

namespace SPOAPAKmmReceiver.Models
{
    [Serializable]
    public class InstrumentSettings : Model, IDataErrorInfo
    {
        [field: NonSerialized] public const string Generator = "Generator";

        [field: NonSerialized] public const string Receiver = "Receiver";

        private string _instrAddress;
        private string _ipAddress;
        private int _port;

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

        [field: NonSerialized()] public string Error => string.Empty;

        [field: NonSerialized()]
        public string this[string columnName]
        {
            get
            {
                var error = string.Empty;
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