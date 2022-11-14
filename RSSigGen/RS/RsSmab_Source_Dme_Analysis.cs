using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Dme_Analysis commands group definition
    //     Sub-classes count: 4
    //     Commands count: 0
    //     Total commands count: 8
    public class RsSmab_Source_Dme_Analysis
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Dme_Analysis_Efficiency _efficiency;

        private RsSmab_Source_Dme_Analysis_Power _power;

        private RsSmab_Source_Dme_Analysis_PrRate _prRate;

        private RsSmab_Source_Dme_Analysis_Time _time;

        //
        // Сводка:
        //     Efficiency commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Dme_Analysis_Efficiency Efficiency => _efficiency ?? (_efficiency = new RsSmab_Source_Dme_Analysis_Efficiency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Dme_Analysis_Power Power => _power ?? (_power = new RsSmab_Source_Dme_Analysis_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     PrRate commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Dme_Analysis_PrRate PrRate => _prRate ?? (_prRate = new RsSmab_Source_Dme_Analysis_PrRate(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Time commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Dme_Analysis_Time Time => _time ?? (_time = new RsSmab_Source_Dme_Analysis_Time(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Dme_Analysis(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Analysis", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Dme_Analysis Clone()
        {
            RsSmab_Source_Dme_Analysis rsSmab_Source_Dme_Analysis = new RsSmab_Source_Dme_Analysis(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Dme_Analysis);
            return rsSmab_Source_Dme_Analysis;
        }
    }
}
