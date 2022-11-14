using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Fm_Source commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Fm_Source
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Fm_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:SOURce
        //     Selects the modulation source for frequency modulation.
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Fm")
        //
        // Параметры:
        //   source:
        //     LF1| LF2| NOISe| EXT1| INTernal| EXTernal | EXT2 LF1|LF2 Uses an internally generated
        //     LF signal. INTernal = LF1 Works like LF1 EXTernal Works like EXT1 EXT1|EXT2 Uses
        //     an externally supplied LF signal. NOISe Uses the internally generated noise signal.
        public void Set(FmSourEnum source)
        {
            Set(source, GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:SOURce
        //     Selects the modulation source for frequency modulation.
        //
        // Параметры:
        //   source:
        //     LF1| LF2| NOISe| EXT1| INTernal| EXTernal | EXT2 LF1|LF2 Uses an internally generated
        //     LF signal. INTernal = LF1 Works like LF1 EXTernal Works like EXT1 EXT1|EXT2 Uses
        //     an externally supplied LF signal. NOISe Uses the internally generated noise signal.
        //
        //   generatorIx:
        //     Repeated capability selector
        public void Set(FmSourEnum source, GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            _grpBase.IO.Write("SOURce<HwInstance>:FM" + repCapCmdValue + ":SOURce " + source.ToScpiString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:SOURce
        //     Selects the modulation source for frequency modulation.
        //     source: LF1| LF2| NOISe| EXT1| INTernal| EXTernal | EXT2 LF1|LF2 Uses an internally
        //     generated LF signal. INTernal = LF1 Works like LF1 EXTernal Works like EXT1 EXT1|EXT2
        //     Uses an externally supplied LF signal. NOISe Uses the internally generated noise
        //     signal.
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Fm")
        public FmSourEnum Get()
        {
            return Get(GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:SOURce
        //     Selects the modulation source for frequency modulation.
        //     source: LF1| LF2| NOISe| EXT1| INTernal| EXTernal | EXT2 LF1|LF2 Uses an internally
        //     generated LF signal. INTernal = LF1 Works like LF1 EXTernal Works like EXT1 EXT1|EXT2
        //     Uses an externally supplied LF signal. NOISe Uses the internally generated noise
        //     signal.
        //
        // Параметры:
        //   generatorIx:
        //     Repeated capability selector
        public FmSourEnum Get(GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            return _grpBase.IO.QueryString("SOURce<HwInstance>:FM" + repCapCmdValue + ":SOURce?").ToScpiEnum<FmSourEnum>();
        }
    }
}
