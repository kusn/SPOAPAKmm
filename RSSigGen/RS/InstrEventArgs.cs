namespace RSSigGen.RS
{
    public class InstrEventArgs : BaseInstrEventArgs
    {
        //
        // Сводка:
        //     Response data. The actual format depends on the type of the query
        public object Data { get; set; }

        //
        // Сводка:
        //     True, if the data is binary
        public bool BinData { get; set; }

        //
        // Сводка:
        //     Status Byte value at the time of invoking
        public StatusByte StatusByte { get; set; }

        //
        // Сводка:
        //     Initializes a new instance of the InstrEventArgs class.
        public InstrEventArgs(string resourceName)
            : base(resourceName)
        {
            Data = null;
        }
    }
}
