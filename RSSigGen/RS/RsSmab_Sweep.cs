using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sweep commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sweep
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SWEep:TYPE
        //     Provided for compatibility between SCPI and Rohde & Schwarz commands.
        //     sweepType: ADVanced| STANdard
        public SweepTypeEnum Type
        {
            get
            {
                return _grpBase.IO.QueryString("SWEep:TYPE?").ToScpiEnum<SweepTypeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SWEep:TYPE " + value.ToScpiString());
            }
        }

        internal RsSmab_Sweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sweep", core, parent);
        }
    }
}
