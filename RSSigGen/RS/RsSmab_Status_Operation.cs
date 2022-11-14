using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Status_Operation commands group definition
    //     Sub-classes count: 1
    //     Commands count: 5
    //     Total commands count: 10
    public class RsSmab_Status_Operation
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Status_Operation_Bit _bit;

        //
        // Сводка:
        //     Bit commands group
        //     Sub-classes count: 5
        //     Commands count: 0
        //     Total commands count: 5
        //     Repeated Capability: BitNumberNullRepCap, default value after init: BitNumberNullRepCap.Nr0
        public RsSmab_Status_Operation_Bit Bit => _bit ?? (_bit = new RsSmab_Status_Operation_Bit(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     STATus:OPERation:CONDition
        //     Quieries the content of the CONDition part of the STATus:OPERation register.
        //     This part contains information on the action currently being performed in the
        //     instrument. The content is not deleted after being read out because it indicates
        //     the current hardware status.
        //     condition: string
        public string Condition => _grpBase.IO.QueryString("STATus:OPERation:CONDition?").TrimStringResponse();

        //
        // Сводка:
        //     STATus:OPERation:ENABle
        //     Sets the bits of the ENABle part of the STATus:OPERation register. This setting
        //     determines which events of the Status-Event part are forwarded to the sum bit
        //     in the status byte. These events can be used for a service request.
        //     enable: string
        public string Enable
        {
            get
            {
                return _grpBase.IO.QueryString("STATus:OPERation:ENABle?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("STATus:OPERation:ENABle " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     STATus:OPERation:NTRansition
        //     Sets the bits of the NTRansition part of the STATus:OPERation register. If a
        //     bit is set, a transition from 1 to 0 in the condition part causes an entry to
        //     be made in the EVENt part of the register. The disappearance of an event in the
        //     hardware is thus registered, for example the end of an adjustment.
        //     ntransition: string
        public string Ntransition
        {
            get
            {
                return _grpBase.IO.QueryString("STATus:OPERation:NTRansition?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("STATus:OPERation:NTRansition " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     STATus:OPERation:PTRansition
        //     Sets the bits of the PTRansition part of the STATus:OPERation register. If a
        //     bit is set, a transition from 0 to 1 in the condition part causes an entry to
        //     be made in the EVENt part of the register. A new event in the hardware is thus
        //     registered, for example the start of an adjustment.
        //     ptransition: string
        public string Ptransition
        {
            get
            {
                return _grpBase.IO.QueryString("STATus:OPERation:PTRansition?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("STATus:OPERation:PTRansition " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     STATus:OPERation:[EVENt]
        //     Queries the content of the EVENt part of the STATus:OPERation register. This
        //     part contains information on the actions performed in the instrument since the
        //     last readout. The content of the EVENt part is deleted after being read out.
        public string Event
        {
            get
            {
                return _grpBase.IO.QueryString("STATus:OPERation:EVENt?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("STATus:OPERation:EVENt " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Status_Operation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Operation", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Status_Operation Clone()
        {
            RsSmab_Status_Operation rsSmab_Status_Operation = new RsSmab_Status_Operation(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Status_Operation);
            return rsSmab_Status_Operation;
        }
    }
}
