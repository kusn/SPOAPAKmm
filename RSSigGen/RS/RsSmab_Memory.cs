using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Memory
    {
        //
        // Сводка:
        //     Structure for reading output parameters
        public class Hfree_Data : ArgumentStructBase
        {
            //
            // Сводка:
            //     ParamHelp: integer Total physical memory.
            [Arg(0, DataType.IntegerArray, false, true, 1)]
            public List<int> TotalPhysMemKb { get; set; }

            //
            // Сводка:
            //     ParamHelp: integer Application memory.
            [Arg(1, DataType.Integer)]
            public int ApplicMemKb { get; set; }

            //
            // Сводка:
            //     ParamHelp: integer Used heap memory.
            [Arg(2, DataType.Integer)]
            public int HeapUsedKb { get; set; }

            //
            // Сводка:
            //     ParamHelp: integer Available heap memory.
            [Arg(3, DataType.Integer)]
            public int HeapAvailableKb { get; set; }
        }

        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     MEMory:HFRee
        //     Returns the used and available memory in Kb.
        //     For return value, see the help for Hfree_Data structure arguments
        public Hfree_Data Hfree => (Hfree_Data)_grpBase.IO.QueryStructure("MEMory:HFRee?", new Hfree_Data());

        internal RsSmab_Memory(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Memory", core, parent);
        }
    }
}
