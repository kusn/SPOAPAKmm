using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Status commands group definition
    //     Sub-classes count: 3
    //     Commands count: 1
    //     Total commands count: 22
    public class RsSmab_Status
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Status_Operation _operation;

        private RsSmab_Status_Questionable _questionable;

        private RsSmab_Status_Queue _queue;

        //
        // Сводка:
        //     Operation commands group
        //     Sub-classes count: 1
        //     Commands count: 5
        //     Total commands count: 10
        public RsSmab_Status_Operation Operation => _operation ?? (_operation = new RsSmab_Status_Operation(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Questionable commands group
        //     Sub-classes count: 1
        //     Commands count: 5
        //     Total commands count: 10
        public RsSmab_Status_Questionable Questionable => _questionable ?? (_questionable = new RsSmab_Status_Questionable(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Queue commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Status_Queue Queue => _queue ?? (_queue = new RsSmab_Status_Queue(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     STATus:PRESet
        //     Resets the status registers. All PTRansition parts are set to FFFFh (32767) ,
        //     i.e. all transitions from 0 to 1 are detected. All NTRansition parts are set
        //     to 0, i.e. a transition from 1 to 0 in a CONDition bit is not detected. The ENABle
        //     parts of STATus:OPERation and STATus:QUEStionable are set to 0, i.e. all events
        //     in these registers are not passed on.
        //     preset: string
        public string Preset
        {
            get
            {
                return _grpBase.IO.QueryString("STATus:PRESet?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("STATus:PRESet " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Status(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Status", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Status Clone()
        {
            RsSmab_Status rsSmab_Status = new RsSmab_Status(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Status);
            return rsSmab_Status;
        }
    }
}
