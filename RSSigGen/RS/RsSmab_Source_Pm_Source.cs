using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pm_Source commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Pm_Source
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Pm_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PM<CH>:SOURce
        //     Selects the modulation source for phase modulation signal.
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Pm")
        //
        // Параметры:
        //   source:
        //     LF1| LF2| NOISe| EXT1| EXT2| INTernal| EXTernal LF1|LF2 Uses an internally generated
        //     LF signal. EXT1|EXT2 Uses an externally supplied LF signal. NOISe Uses the internally
        //     generated noise signal. INTernal Uses the internally generated signal of LF1.
        //     EXTernal Uses an external LF signal (EXT1) .
        public void Set(FmSourEnum source)
        {
            Set(source, GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PM<CH>:SOURce
        //     Selects the modulation source for phase modulation signal.
        //
        // Параметры:
        //   source:
        //     LF1| LF2| NOISe| EXT1| EXT2| INTernal| EXTernal LF1|LF2 Uses an internally generated
        //     LF signal. EXT1|EXT2 Uses an externally supplied LF signal. NOISe Uses the internally
        //     generated noise signal. INTernal Uses the internally generated signal of LF1.
        //     EXTernal Uses an external LF signal (EXT1) .
        //
        //   generatorIx:
        //     Repeated capability selector
        public void Set(FmSourEnum source, GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            _grpBase.IO.Write("SOURce<HwInstance>:PM" + repCapCmdValue + ":SOURce " + source.ToScpiString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PM<CH>:SOURce
        //     Selects the modulation source for phase modulation signal.
        //     source: LF1| LF2| NOISe| EXT1| EXT2| INTernal| EXTernal LF1|LF2 Uses an internally
        //     generated LF signal. EXT1|EXT2 Uses an externally supplied LF signal. NOISe Uses
        //     the internally generated noise signal. INTernal Uses the internally generated
        //     signal of LF1. EXTernal Uses an external LF signal (EXT1) .
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Pm")
        public FmSourEnum Get()
        {
            return Get(GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PM<CH>:SOURce
        //     Selects the modulation source for phase modulation signal.
        //     source: LF1| LF2| NOISe| EXT1| EXT2| INTernal| EXTernal LF1|LF2 Uses an internally
        //     generated LF signal. EXT1|EXT2 Uses an externally supplied LF signal. NOISe Uses
        //     the internally generated noise signal. INTernal Uses the internally generated
        //     signal of LF1. EXTernal Uses an external LF signal (EXT1) .
        //
        // Параметры:
        //   generatorIx:
        //     Repeated capability selector
        public FmSourEnum Get(GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            return _grpBase.IO.QueryString("SOURce<HwInstance>:PM" + repCapCmdValue + ":SOURce?").ToScpiEnum<FmSourEnum>();
        }
    }
}
