using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 5
    //     Total commands count: 5
    public class RsSmab_Source_LfOutput_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:FREQuency:MANual
        //     Sets the frequency of the subsequent sweep step if LFO:SWE:MODE MAN. Use a separate
        //     command for each sweep step.
        //     manual: float You can select any value within the setting range, where: STARt
        //     is set with LFOutput:FREQuency:STARt STOP is set with LFOutput:FREQuency:STOP
        //     Range: STARt to STOP
        public double Manual
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput:FREQuency:MANual?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:FREQuency:MANual " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:FREQuency:MODE
        //     Sets the mode for the output of the LF generator frequency, and determines the
        //     commands to be used for frequency settings.
        //     mode: CW| FIXed| SWEep CW|FIXed Sets the fixed-frequency mode. CW and FIXed are
        //     synonyms. To set the output frequency, use command LFOutputch:FREQuency SWEep
        //     Sets sweep mode. To set the frequency, use the commands: LFOutput:FREQuency:STARt
        //     and LFOutput:FREQuency:STOP Or LFOutput:FREQuency:MANual
        public LfFreqModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LFOutput:FREQuency:MODE?").ToScpiEnum<LfFreqModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:FREQuency:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:FREQuency:STARt
        //     Sets the start/stop frequency for LFOutput:FREQuency:MODE SWEep.
        //     start: float Range: 0.1 Hz to 1 MHz
        public double Start
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput:FREQuency:STARt?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:FREQuency:STARt " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:FREQuency:STOP
        //     Sets the start/stop frequency for LFOutput:FREQuency:MODE SWEep.
        public double Stop
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput:FREQuency:STOP?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:FREQuency:STOP " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_LfOutput_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:FREQuency
        //     Sets the frequency of the LF signal in LFOutput:FREQuency:MODE CW|FIXed mode.
        //     Table Header: Note - If signal source "Internal" is set, the instrument performs
        //     the analog modulations (AM/FM/PhiM/PM) with this frequency., - In sweep mode
        //     (LFOutput:FREQuency:MODE SWE) , the frequency is coupled with the sweep frequency.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   frequency:
        //     float Range: depends on the installed options , Unit: Hz
        public void Set(double frequency)
        {
            Set(frequency, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:FREQuency
        //     Sets the frequency of the LF signal in LFOutput:FREQuency:MODE CW|FIXed mode.
        //     Table Header: Note - If signal source "Internal" is set, the instrument performs
        //     the analog modulations (AM/FM/PhiM/PM) with this frequency., - In sweep mode
        //     (LFOutput:FREQuency:MODE SWE) , the frequency is coupled with the sweep frequency.
        //
        // Параметры:
        //   frequency:
        //     float Range: depends on the installed options , Unit: Hz
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(double frequency, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce:LFOutput" + repCapCmdValue + ":FREQuency " + frequency.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:FREQuency
        //     Sets the frequency of the LF signal in LFOutput:FREQuency:MODE CW|FIXed mode.
        //     Table Header: Note - If signal source "Internal" is set, the instrument performs
        //     the analog modulations (AM/FM/PhiM/PM) with this frequency., - In sweep mode
        //     (LFOutput:FREQuency:MODE SWE) , the frequency is coupled with the sweep frequency.
        //     frequency: float Range: depends on the installed options , Unit: Hz
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public double Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:FREQuency
        //     Sets the frequency of the LF signal in LFOutput:FREQuency:MODE CW|FIXed mode.
        //     Table Header: Note - If signal source "Internal" is set, the instrument performs
        //     the analog modulations (AM/FM/PhiM/PM) with this frequency., - In sweep mode
        //     (LFOutput:FREQuency:MODE SWE) , the frequency is coupled with the sweep frequency.
        //     frequency: float Range: depends on the installed options , Unit: Hz
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public double Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryDouble("SOURce:LFOutput" + repCapCmdValue + ":FREQuency?");
        }
    }
}
