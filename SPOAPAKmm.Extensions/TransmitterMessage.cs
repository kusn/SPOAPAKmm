using System.Collections.Generic;

namespace SPOAPAKmm.Extensions
{
    public class TransmitterMessage
    {
        public ReceiverMessage.WorkMode Mode { get; set; }
        public bool IsOk { get; set; }

        public Dictionary<string, string> DevicesList { get; set; }

        //public Dictionary<double, double> Spectrum { get; set; }
        public string Message { get; set; }
    }
}