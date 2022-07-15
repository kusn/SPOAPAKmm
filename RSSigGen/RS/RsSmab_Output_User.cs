using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Output_User commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Output_User
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     OUTPut:USER:MARKer
        //     Selects the signal for output at the Marker User1 connector.
        //     selUserMarker: MARK| USER MARK Assigns a marker signal to the output. USER Intended
        //     for future use.
        public SelOutpMarkUserEnum Marker
        {
            get
            {
                return _grpBase.IO.QueryString("OUTPut:USER:MARKer?").ToScpiEnum<SelOutpMarkUserEnum>();
            }
            set
            {
                _grpBase.IO.Write("OUTPut:USER:MARKer " + value.ToScpiString());
            }
        }

        internal RsSmab_Output_User(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("User", core, parent);
        }
    }
}
