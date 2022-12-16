using System.Collections.Generic;
using static SPOAPAKmmReceiver.Models.ReceiverMessage;

namespace SPOAPAKmmReceiver.Models
{
    public class TransmitterMessage
    {
        public WorkMode Mode { get; set; }
        public bool IsOk { get; set; }

        public Dictionary<string, string> DevicesList { get; set; }

        //public Dictionary<double, double> Spectrum { get; set; }
        public string Message { get; set; }
    }
}