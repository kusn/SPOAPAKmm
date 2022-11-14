using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Point_Configuration
    {
        //
        // Сводка:
        //     Response structure
        public class Get_Data : ArgumentStructBase
        {
            [Arg(0, DataType.String)]
            public string DevBoard { get; set; }

            [Arg(1, DataType.String)]
            public string Point { get; set; }
        }

        private readonly CommandsGroup _grpBase;

        internal RsSmab_Diagnostic_Point_Configuration(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Configuration", core, parent);
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:POINt:CONFiguration
        //     No additional help available
        public void Set(string devBoard, string point, string data)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(devBoard, 0, DataType.String), new ArgSingle(point, 1, DataType.String), new ArgSingle(data, 2, DataType.String));
            _grpBase.IO.Write("DIAGnostic<HwInstance>:POINt:CONFiguration " + text);
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:POINt:CONFiguration
        //     No additional help available
        public Get_Data Get()
        {
            return (Get_Data)_grpBase.IO.QueryStructure("DIAGnostic<HwInstance>:POINt:CONFiguration?", new Get_Data());
        }
    }
}
