using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Fm_Deviation commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_Fm_Deviation
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:FM:DEViation:MODE
        //     Selects the coupling mode. The coupling mode parameter also determines the mode
        //     for fixing the total deviation.
        //     fmDevMode: UNCoupled| TOTal| RATio UNCoupled Does not couple the LF signals.
        //     The deviation values of both paths are independent. TOTal Couples the deviation
        //     of both paths. RATio Couples the deviation ratio of both paths
        public ModulationDevModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:FM:DEViation:MODE?").ToScpiEnum<ModulationDevModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FM:DEViation:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM:DEViation:SUM
        //     Sets the total deviation of the LF signal when using combined signal sources
        //     in frequency modulation.
        //     fmDevSum: float Range: 0 to 40E6
        public double Sum
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FM:DEViation:SUM?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FM:DEViation:SUM " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Fm_Deviation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Deviation", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:[DEViation]
        //     Sets the modulation deviation of the frequency modulation in Hz.
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Fm")
        //
        // Параметры:
        //   deviation:
        //     float The maximum deviation depends on the RF frequency and the selected modulation
        //     mode (see data sheet) . Range: 0 to max
        public void Set(double deviation)
        {
            Set(deviation, GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:[DEViation]
        //     Sets the modulation deviation of the frequency modulation in Hz.
        //
        // Параметры:
        //   deviation:
        //     float The maximum deviation depends on the RF frequency and the selected modulation
        //     mode (see data sheet) . Range: 0 to max
        //
        //   generatorIx:
        //     Repeated capability selector
        public void Set(double deviation, GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            _grpBase.IO.Write("SOURce<HwInstance>:FM" + repCapCmdValue + ":DEViation " + deviation.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:[DEViation]
        //     Sets the modulation deviation of the frequency modulation in Hz.
        //     deviation: float The maximum deviation depends on the RF frequency and the selected
        //     modulation mode (see data sheet) . Range: 0 to max
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Fm")
        public double Get()
        {
            return Get(GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:[DEViation]
        //     Sets the modulation deviation of the frequency modulation in Hz.
        //     deviation: float The maximum deviation depends on the RF frequency and the selected
        //     modulation mode (see data sheet) . Range: 0 to max
        //
        // Параметры:
        //   generatorIx:
        //     Repeated capability selector
        public double Get(GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FM" + repCapCmdValue + ":DEViation?");
        }
    }
}
