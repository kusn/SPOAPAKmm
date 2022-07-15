using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Bandwidth commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_Bandwidth
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_Bandwidth(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Bandwidth", core, parent);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:BANDwidth
        //     Queries the bandwidth of the external LF signal.
        //     bandwidth: BW0M2| BW10m
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public LfBwidthEnum Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:BANDwidth
        //     Queries the bandwidth of the external LF signal.
        //     bandwidth: BW0M2| BW10m
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public LfBwidthEnum Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryString("SOURce:LFOutput" + repCapCmdValue + ":BANDwidth?").ToScpiEnum<LfBwidthEnum>();
        }
    }
}
