using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Cw commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Frequency_Cw
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:[CW]:RCL
        //     Set whether the RF frequency value is retained or taken from a loaded instrument
        //     configuration, when you recall instrument settings with command *RCL.
        //     rcl: INCLude| EXCLude INCLude Takes the frequency value of the loaded settings.
        //     EXCLude Retains the current frequency when an instrument configuration is loaded.
        public InclExclEnum Recall
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:CW:RCL?").ToScpiEnum<InclExclEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:CW:RCL " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:[CW]
        //     Sets the frequency of the RF output signal in the selected path. Table Header:
        //     The effect depends on the selected mode: - In CW mode (FREQ:MODE CW | FIXed)
        //     , the instrument operates at a fixed frequency., - In sweep mode (FREQ:MODE SWE)
        //     , the value applies to the sweep frequency. The instrument processes the frequency
        //     settings in defined sweep steps., - In user mode (FREQ:STEP:MODE USER) , you
        //     can vary the current frequency step by step.
        //     fixedX: float The following settings influence the value range: An offset set
        //     with the command FREQuency:OFFSet Numerical value Sets the frequency in CW and
        //     sweep mode UP|DOWN Varies the frequency step by step in user mode. The frequency
        //     is increased or decreased by the value set with the command FREQuency. Range:
        //     (RFmin + OFFSet) to (RFmax + OFFSet)
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:CW?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:CW " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Frequency_Cw(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Cw", core, parent);
        }
    }
}
