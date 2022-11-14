using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_Serror commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Test_Serror
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Test_Serror_Set _set;

        //
        // Сводка:
        //     Set commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Test_Serror_Set Set => _set ?? (_set = new RsSmab_Test_Serror_Set(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     TEST:SERRor:UNSet
        //     No additional help available
        public int Unset
        {
            set
            {
                _grpBase.IO.Write($"TEST:SERRor:UNSet {value}");
            }
        }

        internal RsSmab_Test_Serror(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Serror", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Test_Serror Clone()
        {
            RsSmab_Test_Serror rsSmab_Test_Serror = new RsSmab_Test_Serror(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Test_Serror);
            return rsSmab_Test_Serror;
        }
    }
}
