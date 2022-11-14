using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Correction commands group definition
    //     Sub-classes count: 3
    //     Commands count: 2
    //     Total commands count: 19
    public class RsSmab_Source_Correction
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Correction_Cset _cset;

        private RsSmab_Source_Correction_Dexchange _dexchange;

        private RsSmab_Source_Correction_Zeroing _zeroing;

        //
        // Сводка:
        //     Cset commands group
        //     Sub-classes count: 1
        //     Commands count: 3
        //     Total commands count: 8
        public RsSmab_Source_Correction_Cset Cset => _cset ?? (_cset = new RsSmab_Source_Correction_Cset(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Dexchange commands group
        //     Sub-classes count: 2
        //     Commands count: 2
        //     Total commands count: 8
        public RsSmab_Source_Correction_Dexchange Dexchange => _dexchange ?? (_dexchange = new RsSmab_Source_Correction_Dexchange(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Zeroing commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Correction_Zeroing Zeroing => _zeroing ?? (_zeroing = new RsSmab_Source_Correction_Zeroing(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:VALue
        //     Queries the current value for user correction.
        //     value: float Range: -100 to 100
        public double Value => _grpBase.IO.QueryDouble("SOURce<HwInstance>:CORRection:VALue?");

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:[STATe]
        //     Activates user correction with the currently selected table.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:CORRection:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CORRection:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Correction(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Correction", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Correction Clone()
        {
            RsSmab_Source_Correction rsSmab_Source_Correction = new RsSmab_Source_Correction(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Correction);
            return rsSmab_Source_Correction;
        }
    }
}
