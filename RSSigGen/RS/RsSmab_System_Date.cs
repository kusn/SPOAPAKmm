using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Date commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_System_Date
    {
        //
        // Сводка:
        //     Structure for setting input parameters.
        public class Date_Data : ArgumentStructBase
        {
            //
            // Сводка:
            //     ParamHelp: integer
            [Arg(0, DataType.IntegerArray, false, true, 1)]
            public List<int> Year { get; set; }

            //
            // Сводка:
            //     ParamHelp: integer Range: 1 to 12
            [Arg(1, DataType.Integer)]
            public int Month { get; set; }

            //
            // Сводка:
            //     ParamHelp: integer Range: 1 to 31
            [Arg(2, DataType.Integer)]
            public int Day { get; set; }
        }

        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:DATE:LOCal
        //     No additional help available
        public string Local
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:DATE:LOCal?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:DATE:LOCal " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:DATE:UTC
        //     No additional help available
        public string Utc
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:DATE:UTC?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:DATE:UTC " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Date(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Date", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:DATE
        //     Queries or sets the date for the instrument-internal calendar. This is a password-protected
        //     function. Unlock the protection level 1 to access it. See SYSTem.
        //
        // Параметры:
        //   settings:
        //     For set value see the help for Date_Data structure arguments
        public void Set(Date_Data settings)
        {
            _grpBase.IO.WriteStructure("SYSTem:DATE", settings);
        }

        //
        // Сводка:
        //     SYSTem:DATE
        //     Queries or sets the date for the instrument-internal calendar. This is a password-protected
        //     function. Unlock the protection level 1 to access it. See SYSTem.
        //     For return value see the help for Date_Data structure arguments
        public Date_Data Get()
        {
            return (Date_Data)_grpBase.IO.QueryStructure("SYSTem:DATE?", new Date_Data());
        }
    }
}
