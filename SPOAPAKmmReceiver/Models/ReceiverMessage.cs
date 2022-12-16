using System;
using System.Collections.Generic;

namespace SPOAPAKmmReceiver.Models
{
    [Serializable]
    public partial class ReceiverMessage
    {
        public ReceiverMessage(WorkMode mode)
        {
            Mode = mode;
        }

        public WorkMode Mode { get; set; }
        public string InstrAddress { get; set; }
        public string ReceiverIp { get; set; }
        public int ReceiverPort { get; set; }
        public List<double> FrequencyList { get; set; }
        public double StartFrequency { get; set; }
        public double EndFrequency { get; set; }
        public double Step { get; set; }
        public double Offset { get; set; }
        public double Power { get; set; }
        public int TimeOfEmission { get; set; }

        public void FromMeasureSettings(MeasureSettings measureSettings)
        {
            FrequencyList = new List<double>(measureSettings.FrequencyList);
            StartFrequency = measureSettings.StartFrequency;
            EndFrequency = measureSettings.EndFrequency;
            Step = measureSettings.Step;
            Offset = measureSettings.Offset;
            Power = measureSettings.Power;
            TimeOfEmission = measureSettings.TimeOfEmission;
        }
    }
}