using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Multiplier_External_Loader commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Frequency_Multiplier_External_Loader
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:LOADer:VERSion
        //     No additional help available
        public string Version => _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:LOADer:VERSion?").TrimStringResponse();

        internal RsSmab_Source_Frequency_Multiplier_External_Loader(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Loader", core, parent);
        }
    }
}
