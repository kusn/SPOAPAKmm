using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Time commands group definition
    //     Sub-classes count: 3
    //     Commands count: 3
    //     Total commands count: 11
    public class RsSmab_System_Time
    {
        //
        // Сводка:
        //     Structure for setting input parameters.
        public class Time_Data : ArgumentStructBase
        {
            //
            // Сводка:
            //     ParamHelp: integer Range: 0 to 23
            [Arg(0, DataType.IntegerArray, false, true, 1)]
            public List<int> Hour { get; set; }

            //
            // Сводка:
            //     ParamHelp: integer Range: 0 to 59
            [Arg(1, DataType.Integer)]
            public int Minute { get; set; }

            //
            // Сводка:
            //     ParamHelp: integer Range: 0 to 59
            [Arg(2, DataType.Integer)]
            public int Second { get; set; }
        }

        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Time_DaylightSavingTime _daylightSavingTime;

        private RsSmab_System_Time_HrTimer _hrTimer;

        private RsSmab_System_Time_Zone _zone;

        //
        // Сводка:
        //     DaylightSavingTime commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 3
        public RsSmab_System_Time_DaylightSavingTime DaylightSavingTime => _daylightSavingTime ?? (_daylightSavingTime = new RsSmab_System_Time_DaylightSavingTime(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     HrTimer commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 3
        public RsSmab_System_Time_HrTimer HrTimer => _hrTimer ?? (_hrTimer = new RsSmab_System_Time_HrTimer(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Zone commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Time_Zone Zone => _zone ?? (_zone = new RsSmab_System_Time_Zone(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:TIME:LOCal
        //     No additional help available
        public string Local
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:TIME:LOCal?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:TIME:LOCal " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:TIME:UTC
        //     No additional help available
        public string Utc
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:TIME:UTC?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:TIME:UTC " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Time(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Time", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Time Clone()
        {
            RsSmab_System_Time rsSmab_System_Time = new RsSmab_System_Time(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Time);
            return rsSmab_System_Time;
        }

        //
        // Сводка:
        //     SYSTem:TIME
        //     Queries or sets the time for the instrument-internal clock. This is a password-protected
        //     function. Unlock the protection level 1 to access it. See SYSTem.
        //
        // Параметры:
        //   settings:
        //     For set value see the help for Time_Data structure arguments
        public void Set(Time_Data settings)
        {
            _grpBase.IO.WriteStructure("SYSTem:TIME", settings);
        }

        //
        // Сводка:
        //     SYSTem:TIME
        //     Queries or sets the time for the instrument-internal clock. This is a password-protected
        //     function. Unlock the protection level 1 to access it. See SYSTem.
        //     For return value see the help for Time_Data structure arguments
        public Time_Data Get()
        {
            return (Time_Data)_grpBase.IO.QueryStructure("SYSTem:TIME?", new Time_Data());
        }
    }
}
