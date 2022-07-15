using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Measure
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Diagnostic_Measure_Point _point;

        //
        // Сводка:
        //     Point commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Diagnostic_Measure_Point Point => _point ?? (_point = new RsSmab_Diagnostic_Measure_Point(_grpBase.Core, _grpBase));

        internal RsSmab_Diagnostic_Measure(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Measure", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Diagnostic_Measure Clone()
        {
            RsSmab_Diagnostic_Measure rsSmab_Diagnostic_Measure = new RsSmab_Diagnostic_Measure(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Diagnostic_Measure);
            return rsSmab_Diagnostic_Measure;
        }
    }
}
