using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_PciFpga commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 5
    public class RsSmab_System_PciFpga
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_PciFpga_Update _update;

        //
        // Сводка:
        //     Update commands group
        //     Sub-classes count: 3
        //     Commands count: 1
        //     Total commands count: 5
        public RsSmab_System_PciFpga_Update Update => _update ?? (_update = new RsSmab_System_PciFpga_Update(_grpBase.Core, _grpBase));

        internal RsSmab_System_PciFpga(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("PciFpga", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_PciFpga Clone()
        {
            RsSmab_System_PciFpga rsSmab_System_PciFpga = new RsSmab_System_PciFpga(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_PciFpga);
            return rsSmab_System_PciFpga;
        }
    }
}
