using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Gpib commands group definition
    //     Sub-classes count: 1
    //     Commands count: 2
    //     Total commands count: 3
    public class RsSmab_System_Communicate_Gpib
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Communicate_Gpib_Self _self;

        //
        // Сводка:
        //     Self commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Communicate_Gpib_Self Self => _self ?? (_self = new RsSmab_System_Communicate_Gpib_Self(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:COMMunicate:GPIB:LTERminator
        //     Sets the terminator recognition for remote control via GPIB interface.
        //     lterminator: STANdard| EOI EOI Recognizes an LF (Line Feed) as the terminator
        //     only when it is sent with the line message EOI (End of Line) . This setting is
        //     recommended particularly for binary block transmissions, as binary blocks may
        //     coincidentally contain a characater with value LF (Line Feed) , although it is
        //     not determined as a terminator. STANdard Recognizes an LF (Line Feed) as the
        //     terminator regardless of whether it is sent with or without EOI.
        public IecTermModeEnum Lterminator
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:GPIB:LTERminator?").ToScpiEnum<IecTermModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:GPIB:LTERminator " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SYSTem:COMMunicate:GPIB:RESource
        //     Queries the visa resource string for remote control via the GPIB interface. To
        //     change the GPIB address, use the command SYSTem:COMMunicate:ADDRess.
        //     resource: string
        public string Resource => _grpBase.IO.QueryString("SYSTem:COMMunicate:GPIB:RESource?").TrimStringResponse();

        internal RsSmab_System_Communicate_Gpib(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Gpib", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Communicate_Gpib Clone()
        {
            RsSmab_System_Communicate_Gpib rsSmab_System_Communicate_Gpib = new RsSmab_System_Communicate_Gpib(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Communicate_Gpib);
            return rsSmab_System_Communicate_Gpib;
        }
    }
}
