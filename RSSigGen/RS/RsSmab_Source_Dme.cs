using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Dme commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 9
    public class RsSmab_Source_Dme
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Dme_Analysis _analysis;

        //
        // Сводка:
        //     Analysis commands group
        //     Sub-classes count: 4
        //     Commands count: 0
        //     Total commands count: 8
        public RsSmab_Source_Dme_Analysis Analysis => _analysis ?? (_analysis = new RsSmab_Source_Dme_Analysis(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:DME:LOWemission
        //     No additional help available
        public bool LowEmission
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:DME:LOWemission?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:DME:LOWemission " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Dme(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Dme", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Dme Clone()
        {
            RsSmab_Source_Dme rsSmab_Source_Dme = new RsSmab_Source_Dme(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Dme);
            return rsSmab_Source_Dme;
        }
    }
}
