using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pgenerator commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 3
    public class RsSmab_Source_Pgenerator
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Pgenerator_Output _output;

        //
        // Сводка:
        //     Output commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Pgenerator_Output Output => _output ?? (_output = new RsSmab_Source_Pgenerator_Output(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:PGENerator:STATe
        //     Enables the output of the video/sync signal. If the pulse generator is the current
        //     modulation source, activating the pulse modulation automatically activates the
        //     signal output and the pulse generator.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:PGENerator:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PGENerator:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Pgenerator(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Pgenerator", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Pgenerator Clone()
        {
            RsSmab_Source_Pgenerator rsSmab_Source_Pgenerator = new RsSmab_Source_Pgenerator(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Pgenerator);
            return rsSmab_Source_Pgenerator;
        }
    }
}
