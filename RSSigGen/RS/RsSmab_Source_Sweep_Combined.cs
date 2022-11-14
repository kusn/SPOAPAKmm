using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Combined commands group definition
    //     Sub-classes count: 1
    //     Commands count: 5
    //     Total commands count: 6
    public class RsSmab_Source_Sweep_Combined
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Sweep_Combined_Execute _execute;

        //
        // Сводка:
        //     Execute commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Sweep_Combined_Execute Execute => _execute ?? (_execute = new RsSmab_Source_Sweep_Combined_Execute(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:COMBined:COUNt
        //     Defines the number of sweeps you want to execute. This parameter applies to [:SOURce<hw>]:SWEep:COMBined:MODE
        //     > SINGle. To start the sweep signal generation, use the command SWEep:COMBined:EXECute.
        //     stepCount: integer Range: 1 to SeMAX_INT_STEP-1
        public int Count
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:SWEep:COMBined:COUNt?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:SWEep:COMBined:COUNt {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:COMBined:DWELl
        //     Sets the dwell time for the combined frequency / level sweep.
        //     dwell: float Range: 0.01 to 100
        public double Dwell
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:SWEep:COMBined:DWELl?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:COMBined:DWELl " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:COMBined:MODE
        //     Sets the cycle mode for the combined frequency / level sweep.
        //     sweepCombMode: AUTO| MANual| STEP AUTO Each trigger event triggers exactly one
        //     complete sweep. MANual The trigger system is not active. You can trigger every
        //     step individually by input of the frequencies with the commands FREQuency:MANual
        //     and POWer:MANual. STEP Each trigger event triggers one sweep step.
        public AutoManStepEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:COMBined:MODE?").ToScpiEnum<AutoManStepEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:COMBined:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:COMBined:RETRace
        //     Activates that the signal changes to the start level value while it is waiting
        //     for the next trigger event. You can enable this feature, when you are working
        //     with sawtooth shapes in sweep mode "Single" or "External Single".
        //     retraceState: 0| 1| OFF| ON
        public bool Retrace
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:SWEep:COMBined:RETRace?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:COMBined:RETRace " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:COMBined:SHAPe
        //     Selects the waveform shape for the combined frequency / level sweep sequence.
        //     shape: SAWTooth| TRIangle
        public SweCyclModeEnum Shape
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:COMBined:SHAPe?").ToScpiEnum<SweCyclModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:COMBined:SHAPe " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Sweep_Combined(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Combined", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Sweep_Combined Clone()
        {
            RsSmab_Source_Sweep_Combined rsSmab_Source_Sweep_Combined = new RsSmab_Source_Sweep_Combined(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Sweep_Combined);
            return rsSmab_Source_Sweep_Combined;
        }
    }
}
