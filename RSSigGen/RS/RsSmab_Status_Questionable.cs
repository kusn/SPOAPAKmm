using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Status_Questionable commands group definition
    //     Sub-classes count: 1
    //     Commands count: 5
    //     Total commands count: 10
    public class RsSmab_Status_Questionable
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Status_Questionable_Bit _bit;

        //
        // Сводка:
        //     Bit commands group
        //     Sub-classes count: 5
        //     Commands count: 0
        //     Total commands count: 5
        //     Repeated Capability: BitNumberNullRepCap, default value after init: BitNumberNullRepCap.Nr0
        public RsSmab_Status_Questionable_Bit Bit => _bit ?? (_bit = new RsSmab_Status_Questionable_Bit(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     STATus:QUEStionable:CONDition
        //     Queries the content of the CONDition part of the STATus:QUEStionable register.
        //     This part contains information on the action currently being performed in the
        //     instrument. The content is not deleted after being read out since it indicates
        //     the current hardware status.
        //     condition: string
        public string Condition
        {
            get
            {
                return _grpBase.IO.QueryString("STATus:QUEStionable:CONDition?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("STATus:QUEStionable:CONDition " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     STATus:QUEStionable:ENABle
        //     Sets the bits of the ENABle part of the STATus:QUEStionable register. The enable
        //     part determines which events of the STATus:EVENt part are enabled for the summary
        //     bit in the status byte. These events can be used for a service request. If a
        //     bit in the ENABle part is 1, and the correesponding EVENt bit is true, a positive
        //     transition occurs in the summary bit. This transition is reportet to the next
        //     higher level.
        //     enable: string
        public string Enable
        {
            get
            {
                return _grpBase.IO.QueryString("STATus:QUEStionable:ENABle?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("STATus:QUEStionable:ENABle " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     STATus:QUEStionable:NTRansition
        //     Sets the bits of the NTRansition part of the STATus:QUEStionable register. If
        //     a bit is set, a transition from 1 to 0 in the condition part causes an entry
        //     to be made in the EVENt part of the register.
        //     ntransition: string
        public string Ntransition
        {
            get
            {
                return _grpBase.IO.QueryString("STATus:QUEStionable:NTRansition?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("STATus:QUEStionable:NTRansition " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     STATus:QUEStionable:PTRansition
        //     Sets the bits of the NTRansition part of the STATus:QUEStionable register. If
        //     a bit is set, a transition from 1 to 0 in the condition part causes an entry
        //     to be made in the EVENt part of the register.
        //     ptransition: string
        public string Ptransition
        {
            get
            {
                return _grpBase.IO.QueryString("STATus:QUEStionable:PTRansition?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("STATus:QUEStionable:PTRansition " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     STATus:QUEStionable:[EVENt]
        //     Queries the content of the EVENt part of the method RsSmab.Status.Questionable.Event
        //     register. This part contains information on the actions performed in the instrument
        //     since the last readout. The content of the EVENt part is deleted after being
        //     read out.
        public string Event
        {
            get
            {
                return _grpBase.IO.QueryString("STATus:QUEStionable:EVENt?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("STATus:QUEStionable:EVENt " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Status_Questionable(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Questionable", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Status_Questionable Clone()
        {
            RsSmab_Status_Questionable rsSmab_Status_Questionable = new RsSmab_Status_Questionable(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Status_Questionable);
            return rsSmab_Status_Questionable;
        }
    }
}
