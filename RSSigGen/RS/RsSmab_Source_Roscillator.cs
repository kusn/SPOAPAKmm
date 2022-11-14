using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator commands group definition
    //     Sub-classes count: 3
    //     Commands count: 2
    //     Total commands count: 14
    public class RsSmab_Source_Roscillator
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Roscillator_External _external;

        private RsSmab_Source_Roscillator_Internal _internal;

        private RsSmab_Source_Roscillator_Output _output;

        //
        // Сводка:
        //     External commands group
        //     Sub-classes count: 2
        //     Commands count: 3
        //     Total commands count: 6
        public RsSmab_Source_Roscillator_External External => _external ?? (_external = new RsSmab_Source_Roscillator_External(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Internal commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Source_Roscillator_Internal Internal => _internal ?? (_internal = new RsSmab_Source_Roscillator_Internal(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Output commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Source_Roscillator_Output Output => _output ?? (_output = new RsSmab_Source_Roscillator_Output(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce]:ROSCillator:SOURce
        //     Selects between internal or external reference frequency.
        //     source: INTernal| EXTernal
        public SourceIntEnum Source
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce:ROSCillator:SOURce?").ToScpiEnum<SourceIntEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce:ROSCillator:SOURce " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Roscillator(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Roscillator", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Roscillator Clone()
        {
            RsSmab_Source_Roscillator rsSmab_Source_Roscillator = new RsSmab_Source_Roscillator(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Roscillator);
            return rsSmab_Source_Roscillator;
        }

        //
        // Сводка:
        //     [SOURce]:ROSCillator:PRESet
        //     Resets the reference oscillator settings.
        public void Preset()
        {
            _grpBase.IO.Write("SOURce:ROSCillator:PRESet");
        }

        //
        // Сводка:
        //     [SOURce]:ROSCillator:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce]:ROSCillator:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce:ROSCillator:PRESet", opcTimeoutMs);
        }
    }
}
