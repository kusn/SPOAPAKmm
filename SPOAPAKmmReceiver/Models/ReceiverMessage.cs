using System.Collections.Generic;

namespace SPOAPAKmmReceiver.Models
{
    public class ReceiverMessage
    {
        public string Mode { get; set; }
        public List<double> FrequencyList { get; set; }
        public double StartFrequency { get; set; }
        public double EndFrequency { get; set; }
        public double Step { get; set; }
        public double Offset { get; set; }
        public double Power { get; set; }
        public int TimeOfEmission { get; set; }

        ReceiverMessage(MeasureSettings measureSettings, string mode)
        {
            FrequencyList = new List<double>(measureSettings.FrequencyList);
            StartFrequency = measureSettings.StartFrequency;
            EndFrequency = measureSettings.EndFrequency;
            Step = measureSettings.Step;
            Offset = measureSettings.Offset;
            Power = measureSettings.Power;
            TimeOfEmission = measureSettings.TimeOfEmission;
            Mode = mode;
        }
    }
}
