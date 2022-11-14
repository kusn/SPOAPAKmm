using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_SrData commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_SrData
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:SRData
        //     Queris the SCPI recording data from the internal file. This feature enables you
        //     to transfer an instrument configuration to other test environments, as e.g. laboratory
        //     virtual instruments.
        //     fileData: block data
        public byte[] Value => _grpBase.IO.QueryBinaryData("SYSTem:SRData?");

        internal RsSmab_System_SrData(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("SrData", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:SRData:DELete
        //     No additional help available
        public void Delete()
        {
            _grpBase.IO.Write("SYSTem:SRData:DELete");
        }

        //
        // Сводка:
        //     SYSTem:SRData:DELete
        //     Same as Delete, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void DeleteAndWait()
        {
            DeleteAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:SRData:DELete
        //     Same as Delete, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void DeleteAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:SRData:DELete", opcTimeoutMs);
        }
    }
}
