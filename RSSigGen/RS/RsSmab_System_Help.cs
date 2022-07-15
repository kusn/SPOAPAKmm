using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Help commands group definition
    //     Sub-classes count: 1
    //     Commands count: 2
    //     Total commands count: 4
    public class RsSmab_System_Help
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Help_Syntax _syntax;

        //
        // Сводка:
        //     Syntax commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Help_Syntax Syntax => _syntax ?? (_syntax = new RsSmab_System_Help_Syntax(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:HELP:HEADers
        //     No additional help available
        public string Headers => _grpBase.IO.QueryString("SYSTem:HELP:HEADers?").TrimStringResponse();

        internal RsSmab_System_Help(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Help", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Help Clone()
        {
            RsSmab_System_Help rsSmab_System_Help = new RsSmab_System_Help(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Help);
            return rsSmab_System_Help;
        }

        //
        // Сводка:
        //     SYSTem:HELP:EXPort
        //     Saves the online help as zip archive in the user directory.
        public void Export()
        {
            _grpBase.IO.Write("SYSTem:HELP:EXPort");
        }

        //
        // Сводка:
        //     SYSTem:HELP:EXPort
        //     Same as Export, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void ExportAndWait()
        {
            ExportAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:HELP:EXPort
        //     Same as Export, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void ExportAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:HELP:EXPort", opcTimeoutMs);
        }
    }
}
