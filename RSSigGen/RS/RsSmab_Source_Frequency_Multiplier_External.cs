using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Multiplier_External commands group definition
    //     Sub-classes count: 3
    //     Commands count: 15
    //     Total commands count: 30
    public class RsSmab_Source_Frequency_Multiplier_External
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Frequency_Multiplier_External_Correction _correction;

        private RsSmab_Source_Frequency_Multiplier_External_Firmware _firmware;

        private RsSmab_Source_Frequency_Multiplier_External_Loader _loader;

        //
        // Сводка:
        //     Correction commands group
        //     Sub-classes count: 3
        //     Commands count: 5
        //     Total commands count: 10
        public RsSmab_Source_Frequency_Multiplier_External_Correction Correction => _correction ?? (_correction = new RsSmab_Source_Frequency_Multiplier_External_Correction(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Firmware commands group
        //     Sub-classes count: 1
        //     Commands count: 3
        //     Total commands count: 4
        public RsSmab_Source_Frequency_Multiplier_External_Firmware Firmware => _firmware ?? (_firmware = new RsSmab_Source_Frequency_Multiplier_External_Firmware(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Loader commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Frequency_Multiplier_External_Loader Loader => _loader ?? (_loader = new RsSmab_Source_Frequency_Multiplier_External_Loader(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:DAC0
        //     No additional help available
        public int Dac0
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:DAC0?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:DAC0 {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:DAC1
        //     No additional help available
        public int Dac1 => _grpBase.IO.QueryInt32("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:DAC1?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:FMAXimum
        //     No additional help available
        public double Fmaximum => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:FMAXimum?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:FMINimum
        //     No additional help available
        public double Fminimum => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:FMINimum?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:IPMax
        //     No additional help available
        public double Ipmax => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:IPMax?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:IPOWer
        //     No additional help available
        public double Ipower => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:IPOWer?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:MULTiplier
        //     No additional help available
        public double Multiplier => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:MULTiplier?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:PADJust
        //     No additional help available
        public double Padjust => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:PADJust?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:PMAXimum
        //     No additional help available
        public double Pmaximum => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:PMAXimum?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:PMINimum
        //     No additional help available
        public double Pminimum => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:PMINimum?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:PSDMinimum
        //     No additional help available
        public double PsdMinimum => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:PSDMinimum?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:REVision
        //     No additional help available
        public string Revision => _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:REVision?").TrimStringResponse();

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:SNUMber
        //     No additional help available
        public string Snumber => _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:SNUMber?").TrimStringResponse();

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:STATe
        //     No additional help available
        public bool State => _grpBase.IO.QueryBoolean("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:STATe?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:TYPE
        //     No additional help available
        public string Type => _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:TYPE?").TrimStringResponse();

        internal RsSmab_Source_Frequency_Multiplier_External(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("External", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Frequency_Multiplier_External Clone()
        {
            RsSmab_Source_Frequency_Multiplier_External rsSmab_Source_Frequency_Multiplier_External = new RsSmab_Source_Frequency_Multiplier_External(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Frequency_Multiplier_External);
            return rsSmab_Source_Frequency_Multiplier_External;
        }
    }
}
