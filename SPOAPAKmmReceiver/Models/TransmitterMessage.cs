using SPOAPAKmmReceiver.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SPOAPAKmmReceiver.Models.ReceiverMessage;

namespace SPOAPAKmmReceiver.Models
{
    public class TransmitterMessage
    {
        public WorkMode Mode { get; set; }
        public bool IsOk { get; set; }
        public Dictionary<string, string> DevicesList { get; set; }
        public Dictionary<double, double> Spectrum { get; set; }
        public string Message { get; set; }
    }
}