using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_Sw_Scmd commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Test_Sw_Scmd
    {
        //
        // Сводка:
        //     Structure for setting input parameters.
        public class Scmd_Data : ArgumentStructBase
        {
            [Arg(0, DataType.String)]
            public string Scmd { get; set; }

            [Arg(1, DataType.String)]
            public string WhatIsThis { get; set; }
        }

        private readonly CommandsGroup _grpBase;

        internal RsSmab_Test_Sw_Scmd(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Scmd", core, parent);
        }

        //
        // Сводка:
        //     TEST<HW>:SW:SCMD
        //     No additional help available
        public void Set(Scmd_Data settings)
        {
            _grpBase.IO.WriteStructure("TEST<HwInstance>:SW:SCMD", settings);
        }

        //
        // Сводка:
        //     TEST<HW>:SW:SCMD
        //     No additional help available
        public Scmd_Data Get()
        {
            return (Scmd_Data)_grpBase.IO.QueryStructure("TEST<HwInstance>:SW:SCMD?", new Scmd_Data());
        }
    }
}
