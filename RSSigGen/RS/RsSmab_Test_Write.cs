using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_Write commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Test_Write
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     TEST:WRITe:RESult
        //     No additional help available
        public SelftLevWriteEnum Result
        {
            set
            {
                _grpBase.IO.Write("TEST:WRITe:RESult " + value.ToScpiString());
            }
        }

        internal RsSmab_Test_Write(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Write", core, parent);
        }
    }
}
