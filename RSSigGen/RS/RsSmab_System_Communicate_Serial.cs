using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Serial commands group definition
    //     Sub-classes count: 0
    //     Commands count: 4
    //     Total commands count: 4
    public class RsSmab_System_Communicate_Serial
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:COMMunicate:SERial:BAUD
        //     Defines the baudrate for the serial remote control interface.
        //     baud: 2400| 4800| 9600| 19200| 38400| 57600| 115200
        public Rs232BdRateEnum Baud
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:SERial:BAUD?").ToScpiEnum<Rs232BdRateEnum>();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:SERial:BAUD " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SYSTem:COMMunicate:SERial:PARity
        //     Enters the parity for the serial remote control interface.
        //     parity: NONE| ODD| EVEN
        public ParityEnum Parity
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:SERial:PARity?").ToScpiEnum<ParityEnum>();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:SERial:PARity " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SYSTem:COMMunicate:SERial:RESource
        //     Queries the visa resource string for the serial remote control interface. This
        //     string is used for remote control of the instrument.
        //     resource: string
        public string Resource => _grpBase.IO.QueryString("SYSTem:COMMunicate:SERial:RESource?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:COMMunicate:SERial:SBITs
        //     Defines the number of stop bits for the serial remote control interface.
        //     sbits: 1| 2
        public Rs232StopBitsEnum Sbits
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:SERial:SBITs?").ToScpiEnum<Rs232StopBitsEnum>();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:SERial:SBITs " + value.ToScpiString());
            }
        }

        internal RsSmab_System_Communicate_Serial(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Serial", core, parent);
        }
    }
}
