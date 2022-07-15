using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Shape_Pulse_Width commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_Shape_Pulse_Width
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_Shape_Pulse_Width(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Width", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:WIDTh
        //     Sets the pulse width of the generated pulse.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   width:
        //     float Range: 1E-6 to 100
        public void Set(double width)
        {
            Set(width, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:WIDTh
        //     Sets the pulse width of the generated pulse.
        //
        // Параметры:
        //   width:
        //     float Range: 1E-6 to 100
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(double width, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:PULSe:WIDTh " + width.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:WIDTh
        //     Sets the pulse width of the generated pulse.
        //     width: float Range: 1E-6 to 100
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public double Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:WIDTh
        //     Sets the pulse width of the generated pulse.
        //     width: float Range: 1E-6 to 100
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public double Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:PULSe:WIDTh?");
        }
    }
}
