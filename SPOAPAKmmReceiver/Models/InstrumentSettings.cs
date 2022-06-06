using SPOAPAKmmReceiver.Models.Base;
using System;
using System.Net;

namespace SPOAPAKmmReceiver.Models
{
    [Serializable()]
    public class InstrumentSettings : Model
    {
        private IPAddress _ipAddress;
        private int _port;
        private string _instrAddress;

        public IPAddress IpAddress
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
    }
}
