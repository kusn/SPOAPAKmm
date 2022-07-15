using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Unit commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Unit
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     UNIT:ANGLe
        //     Sets the default unit for phase modulation angle. The command affects no other
        //     parameters, such as RF phase, or the manual control or display.
        //     angle: DEGree| DEGRee| RADian
        public UnitAngleEnum Angle
        {
            get
            {
                return _grpBase.IO.QueryString("UNIT:ANGLe?").ToScpiEnum<UnitAngleEnum>();
            }
            set
            {
                _grpBase.IO.Write("UNIT:ANGLe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     UNIT:POWer
        //     Sets the default unit for all power parameters. This setting affects the GUI,
        //     as well as all remote control commands that determine power values.
        //     power: V| DBUV| DBM
        public UnitPowerEnum Power
        {
            get
            {
                return _grpBase.IO.QueryString("UNIT:POWer?").ToScpiEnum<UnitPowerEnum>();
            }
            set
            {
                _grpBase.IO.Write("UNIT:POWer " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     UNIT:VELocity
        //     No additional help available
        public UnitSpeedEnum Velocity
        {
            get
            {
                return _grpBase.IO.QueryString("UNIT:VELocity?").ToScpiEnum<UnitSpeedEnum>();
            }
            set
            {
                _grpBase.IO.Write("UNIT:VELocity " + value.ToScpiString());
            }
        }

        internal RsSmab_Unit(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Unit", core, parent);
        }
    }
}
