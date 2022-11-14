using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Multiplier commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 31
    public class RsSmab_Source_Frequency_Multiplier
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Frequency_Multiplier_External _external;

        //
        // Сводка:
        //     External commands group
        //     Sub-classes count: 3
        //     Commands count: 15
        //     Total commands count: 30
        public RsSmab_Source_Frequency_Multiplier_External External => _external ?? (_external = new RsSmab_Source_Frequency_Multiplier_External(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier
        //     Sets the multiplication factor NFREQ:MULT of a subsequent downstream instrument.
        //     The parameters offset fFREQ:OFFSer and multiplier NFREQ:MULT affect the frequency
        //     value set with the command [:​SOURce<hw>]:​FREQuency[:​CW|FIXed]. The query [:​SOURce<hw>]:​FREQuency[:​CW|FIXed]
        //     returns the value corresponding to the formula: fFREQ = fRFout * NFREQ:MULT +
        //     fFREQ:OFFSer See "RF frequency and level display with a downstream instrument".
        //     multiplier: float Range: -10000 to 10000
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MULTiplier " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Frequency_Multiplier(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Multiplier", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Frequency_Multiplier Clone()
        {
            RsSmab_Source_Frequency_Multiplier rsSmab_Source_Frequency_Multiplier = new RsSmab_Source_Frequency_Multiplier(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Frequency_Multiplier);
            return rsSmab_Source_Frequency_Multiplier;
        }
    }
}
