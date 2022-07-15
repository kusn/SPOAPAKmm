using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Source commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_Source
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:SOURce
        //     Determines the LF signal to be synchronized, when monitoring is enabled.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   source:
        //     LF1| LF2| NOISe| AM| FMPM| EXT1 | | EXT2 LF1|LF2 Selects an internally generated
        //     LF signal. NOISe Selects an internally generated noise signal. EXT1|EXT2 Selects
        //     an externally supplied LF signal AM Selects the AM signal. FMPM Selects the signal
        //     also used by the frequency or phase modulations.
        public void Set(LfSourceEnum source)
        {
            Set(source, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:SOURce
        //     Determines the LF signal to be synchronized, when monitoring is enabled.
        //
        // Параметры:
        //   source:
        //     LF1| LF2| NOISe| AM| FMPM| EXT1 | | EXT2 LF1|LF2 Selects an internally generated
        //     LF signal. NOISe Selects an internally generated noise signal. EXT1|EXT2 Selects
        //     an externally supplied LF signal AM Selects the AM signal. FMPM Selects the signal
        //     also used by the frequency or phase modulations.
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(LfSourceEnum source, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce:LFOutput" + repCapCmdValue + ":SOURce " + source.ToScpiString());
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:SOURce
        //     Determines the LF signal to be synchronized, when monitoring is enabled.
        //     source: LF1| LF2| NOISe| AM| FMPM| EXT1 | | EXT2 LF1|LF2 Selects an internally
        //     generated LF signal. NOISe Selects an internally generated noise signal. EXT1|EXT2
        //     Selects an externally supplied LF signal AM Selects the AM signal. FMPM Selects
        //     the signal also used by the frequency or phase modulations.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public LfSourceEnum Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:SOURce
        //     Determines the LF signal to be synchronized, when monitoring is enabled.
        //     source: LF1| LF2| NOISe| AM| FMPM| EXT1 | | EXT2 LF1|LF2 Selects an internally
        //     generated LF signal. NOISe Selects an internally generated noise signal. EXT1|EXT2
        //     Selects an externally supplied LF signal AM Selects the AM signal. FMPM Selects
        //     the signal also used by the frequency or phase modulations.
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public LfSourceEnum Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryString("SOURce:LFOutput" + repCapCmdValue + ":SOURce?").ToScpiEnum<LfSourceEnum>();
        }
    }
}
