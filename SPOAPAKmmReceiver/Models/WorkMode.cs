namespace SPOAPAKmmReceiver.Models
{
    public partial class ReceiverMessage
    {
        public enum WorkMode
        {
            ApplyInstrumentSettings,
            ApplyMeasureSettings,
            Сalibration,
            Checking,
            Measuring,
            Searching
        }
    }
}