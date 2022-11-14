using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Output_Filter
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     OUTPut<HW>:FILTer:MODE
        //     Activates low harmonic filter or enables its automatic switching.
        //     mode: ON| AUTO| 1 ON|1 Ensures best low harmonics performance but decreases the
        //     level range AUTO Applies an automatically selected harmonic filter that fits
        //     to the current level setting.
        public PowHarmModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("OUTPut<HwInstance>:FILTer:MODE?").ToScpiEnum<PowHarmModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("OUTPut<HwInstance>:FILTer:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Output_Filter(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Filter", core, parent);
        }
    }
}
