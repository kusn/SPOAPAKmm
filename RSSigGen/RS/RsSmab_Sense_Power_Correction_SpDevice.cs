using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Correction_SpDevice commands group definition
    //     Sub-classes count: 3
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_Sense_Power_Correction_SpDevice
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Correction_SpDevice_List _list;

        private RsSmab_Sense_Power_Correction_SpDevice_Select _select;

        private RsSmab_Sense_Power_Correction_SpDevice_State _state;

        //
        // Сводка:
        //     List commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Correction_SpDevice_List List => _list ?? (_list = new RsSmab_Sense_Power_Correction_SpDevice_List(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Select commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Correction_SpDevice_Select Select => _select ?? (_select = new RsSmab_Sense_Power_Correction_SpDevice_Select(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Correction_SpDevice_State State => _state ?? (_state = new RsSmab_Sense_Power_Correction_SpDevice_State(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Correction_SpDevice(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("SpDevice", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Correction_SpDevice Clone()
        {
            RsSmab_Sense_Power_Correction_SpDevice rsSmab_Sense_Power_Correction_SpDevice = new RsSmab_Sense_Power_Correction_SpDevice(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Correction_SpDevice);
            return rsSmab_Sense_Power_Correction_SpDevice;
        }
    }
}
