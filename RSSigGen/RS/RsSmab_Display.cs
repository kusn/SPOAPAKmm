using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Display_Annotation _annotation;

        private RsSmab_Display_Button _button;

        private RsSmab_Display_Dialog _dialog;

        private RsSmab_Display_Psave _psave;

        private RsSmab_Display_Ukey _ukey;

        private RsSmab_Display_Window _window;

        //
        // Сводка:
        //     Annotation commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Display_Annotation Annotation => _annotation ?? (_annotation = new RsSmab_Display_Annotation(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Button commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Display_Button Button => _button ?? (_button = new RsSmab_Display_Button(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Dialog commands group
        //     Sub-classes count: 0
        //     Commands count: 4
        //     Total commands count: 4
        public RsSmab_Display_Dialog Dialog => _dialog ?? (_dialog = new RsSmab_Display_Dialog(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Psave commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Display_Psave Psave => _psave ?? (_psave = new RsSmab_Display_Psave(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ukey commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 3
        public RsSmab_Display_Ukey Ukey => _ukey ?? (_ukey = new RsSmab_Display_Ukey(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Window commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Display_Window Window => _window ?? (_window = new RsSmab_Display_Window(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     DISPlay:BRIGhtness
        //     Sets the brightness of the dispaly.
        //     brightness: float Range: 1.0 to 20.0
        public double Brightness
        {
            get
            {
                return _grpBase.IO.QueryDouble("DISPlay:BRIGhtness?");
            }
            set
            {
                _grpBase.IO.Write("DISPlay:BRIGhtness " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     DISPlay:FOCusobject
        //     No additional help available
        public string FocusObject
        {
            set
            {
                _grpBase.IO.Write("DISPlay:FOCusobject " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     DISPlay:MESSage
        //     No additional help available
        public string Message
        {
            set
            {
                _grpBase.IO.Write("DISPlay:MESSage " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     DISPlay:UPDate
        //     Activates the refresh mode of the display.
        //     update: 0| 1| OFF| ON
        public bool Update
        {
            get
            {
                return _grpBase.IO.QueryBoolean("DISPlay:UPDate?");
            }
            set
            {
                _grpBase.IO.Write("DISPlay:UPDate " + value.ToBooleanString());
            }
        }

        internal RsSmab_Display(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Display", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Display Clone()
        {
            RsSmab_Display rsSmab_Display = new RsSmab_Display(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Display);
            return rsSmab_Display;
        }
    }
}
