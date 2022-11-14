using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Gpib_Self commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Communicate_Gpib_Self
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:COMMunicate:GPIB:[SELF]:ADDRess
        //     Sets the GPIB address.
        //     address: integer Range: 0 to 30
        public int Address
        {
            get
            {
                return _grpBase.IO.QueryInt32("SYSTem:COMMunicate:GPIB:SELF:ADDRess?");
            }
            set
            {
                _grpBase.IO.Write($"SYSTem:COMMunicate:GPIB:SELF:ADDRess {value}");
            }
        }

        internal RsSmab_System_Communicate_Gpib_Self(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Self", core, parent);
        }
    }
}
