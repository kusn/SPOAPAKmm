using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Frequency_Math_Subtract
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calculate_Power_Sweep_Frequency_Math_Subtract(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Subtract", core, parent);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:FREQuency:MATH<CH>:SUBTract
        //     Subtracts the operands 1 and 2 and assigns the result to the selected trace in
        //     "Frequency" measurement mode.
        //     Used Repeated Capabilities default values:
        //     MathRepCap.Nr1 (settable in the interface "Math")
        //
        // Параметры:
        //   subtract:
        //     T1T1| T1T2| T1T3| T1T4| T1REf| T2T1| T2T2| T2T3| T2T4| T2REf| T3T1| T3T2| T3T3|
        //     T3T4| T3REf| T4T1| T4T2| T4T3| T4T4| T4REf
        public void Set(MeasRespMathEnum subtract)
        {
            Set(subtract, MathRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:FREQuency:MATH<CH>:SUBTract
        //     Subtracts the operands 1 and 2 and assigns the result to the selected trace in
        //     "Frequency" measurement mode.
        //
        // Параметры:
        //   subtract:
        //     T1T1| T1T2| T1T3| T1T4| T1REf| T2T1| T2T2| T2T3| T2T4| T2REf| T3T1| T3T2| T3T3|
        //     T3T4| T3REf| T4T1| T4T2| T4T3| T4T4| T4REf
        //
        //   math:
        //     Repeated capability selector
        public void Set(MeasRespMathEnum subtract, MathRepCap math)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(math);
            _grpBase.IO.Write("CALCulate:POWer:SWEep:FREQuency:MATH" + repCapCmdValue + ":SUBTract " + subtract.ToScpiString());
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:FREQuency:MATH<CH>:SUBTract
        //     Subtracts the operands 1 and 2 and assigns the result to the selected trace in
        //     "Frequency" measurement mode.
        //     subtract: T1T1| T1T2| T1T3| T1T4| T1REf| T2T1| T2T2| T2T3| T2T4| T2REf| T3T1|
        //     T3T2| T3T3| T3T4| T3REf| T4T1| T4T2| T4T3| T4T4| T4REf
        //     Used Repeated Capabilities default values:
        //     MathRepCap.Nr1 (settable in the interface "Math")
        public MeasRespMathEnum Get()
        {
            return Get(MathRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:FREQuency:MATH<CH>:SUBTract
        //     Subtracts the operands 1 and 2 and assigns the result to the selected trace in
        //     "Frequency" measurement mode.
        //     subtract: T1T1| T1T2| T1T3| T1T4| T1REf| T2T1| T2T2| T2T3| T2T4| T2REf| T3T1|
        //     T3T2| T3T3| T3T4| T3REf| T4T1| T4T2| T4T3| T4T4| T4REf
        //
        // Параметры:
        //   math:
        //     Repeated capability selector
        public MeasRespMathEnum Get(MathRepCap math)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(math);
            return _grpBase.IO.QueryString("CALCulate:POWer:SWEep:FREQuency:MATH" + repCapCmdValue + ":SUBTract?").ToScpiEnum<MeasRespMathEnum>();
        }
    }
}
