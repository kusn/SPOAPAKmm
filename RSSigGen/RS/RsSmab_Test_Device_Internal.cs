using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_Device_Internal commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Test_Device_Internal
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Test_Device_Internal(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Internal", core, parent);
        }

        //
        // Сводка:
        //     TEST:DEVice:INTernal
        //     No additional help available
        public TestEnum Get(string argument)
        {
            return _grpBase.IO.QueryString("TEST:DEVice:INTernal? " + argument.EncloseByQuotes()).ToScpiEnum<TestEnum>();
        }
    }
}
