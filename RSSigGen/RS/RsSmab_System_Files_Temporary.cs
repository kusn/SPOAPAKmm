using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Files_Temporary commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Files_Temporary
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Files_Temporary(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Temporary", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:FILes:TEMPorary:DELete
        //     Deletes the temporary files from the internal memory or, if installed, from the
        //     SD card slot.
        public void Delete()
        {
            _grpBase.IO.Write("SYSTem:FILes:TEMPorary:DELete");
        }

        //
        // Сводка:
        //     SYSTem:FILes:TEMPorary:DELete
        //     Same as Delete, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void DeleteAndWait()
        {
            DeleteAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:FILes:TEMPorary:DELete
        //     Same as Delete, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void DeleteAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:FILes:TEMPorary:DELete", opcTimeoutMs);
        }
    }
}
