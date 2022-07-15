using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pm_Deviation commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_Pm_Deviation
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PM:DEViation:MODE
        //     Selects the coupling mode. The coupling mode parameter also determines the mode
        //     for fixing the total deviation.
        //     pmDevMode: UNCoupled| TOTal| RATio UNCoupled Does not couple the LF signals.
        //     The deviation values of both paths are independent. TOTal Couples the deviation
        //     of both paths. RATio Couples the deviation ratio of both paths
        public ModulationDevModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PM:DEViation:MODE?").ToScpiEnum<ModulationDevModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PM:DEViation:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PM:DEViation:SUM
        //     Sets the total deviation of the LF signal when using combined signal sources
        //     in phase modulation.
        //     pmDevSum: float Range: 0 to 20
        public double Sum
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:PM:DEViation:SUM?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PM:DEViation:SUM " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Pm_Deviation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Deviation", core, parent);
        }

        //
        // Сводка:
        //     [SOURce]:PM<CH>:[DEViation]
        //     Sets the modulation deviation of the phase modulation in RAD.
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Pm")
        //
        // Параметры:
        //   deviation:
        //     float The maximal deviation depends on the RF frequency and the selected modulation
        //     mode (see data sheet) . Range: 0 to max, Unit: RAD
        public void Set(double deviation)
        {
            Set(deviation, GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:PM<CH>:[DEViation]
        //     Sets the modulation deviation of the phase modulation in RAD.
        //
        // Параметры:
        //   deviation:
        //     float The maximal deviation depends on the RF frequency and the selected modulation
        //     mode (see data sheet) . Range: 0 to max, Unit: RAD
        //
        //   generatorIx:
        //     Repeated capability selector
        public void Set(double deviation, GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            _grpBase.IO.Write("SOURce:PM" + repCapCmdValue + ":DEViation " + deviation.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce]:PM<CH>:[DEViation]
        //     Sets the modulation deviation of the phase modulation in RAD.
        //     deviation: float The maximal deviation depends on the RF frequency and the selected
        //     modulation mode (see data sheet) . Range: 0 to max, Unit: RAD
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Pm")
        public double Get()
        {
            return Get(GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:PM<CH>:[DEViation]
        //     Sets the modulation deviation of the phase modulation in RAD.
        //     deviation: float The maximal deviation depends on the RF frequency and the selected
        //     modulation mode (see data sheet) . Range: 0 to max, Unit: RAD
        //
        // Параметры:
        //   generatorIx:
        //     Repeated capability selector
        public double Get(GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            return _grpBase.IO.QueryDouble("SOURce:PM" + repCapCmdValue + ":DEViation?");
        }
    }
}
