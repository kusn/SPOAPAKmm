using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Shape_Pulse_Dcycle commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_Shape_Pulse_Dcycle
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_Shape_Pulse_Dcycle(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Dcycle", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:DCYCle
        //     Sets the duty cycle for the shape pulse.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   dcycle:
        //     float Range: 1E-6 to 100, Unit: PCT
        public void Set(double dcycle)
        {
            Set(dcycle, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:DCYCle
        //     Sets the duty cycle for the shape pulse.
        //
        // Параметры:
        //   dcycle:
        //     float Range: 1E-6 to 100, Unit: PCT
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(double dcycle, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:PULSe:DCYCle " + dcycle.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:DCYCle
        //     Sets the duty cycle for the shape pulse.
        //     dcycle: float Range: 1E-6 to 100, Unit: PCT
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public double Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:DCYCle
        //     Sets the duty cycle for the shape pulse.
        //     dcycle: float Range: 1E-6 to 100, Unit: PCT
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public double Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:PULSe:DCYCle?");
        }
    }
}
