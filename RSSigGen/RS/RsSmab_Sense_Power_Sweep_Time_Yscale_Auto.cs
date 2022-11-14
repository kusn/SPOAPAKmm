using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Yscale_Auto commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Sweep_Time_Yscale_Auto
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:YSCale:AUTO
        //     Activates autoscaling of the Y axis in the diagram.
        //     auto: OFF| CEXPanding| FEXPanding| CFLoating| FFLoating OFF Auto scaling is deactivated.
        //     When switching from activated to deactivated Auto scaling, the scaling is maintained.
        //     When switching from deactivated to activated Auto scaling, the scaling is reset
        //     to min = max = 0. CEXPanding | FEXPanding Auto scale is activated. The scaling
        //     of the Y-axis is selected in such a way, that the trace is always visible. To
        //     this end, the range is expanded if the minimum or maximum values of the trace
        //     move outside the current scale. The step width is 5 dB for selection course and
        //     variable in the range of 0.2 db to 5 dB for selection fine. CFLoating | FFLoating
        //     Auto scale is activated. The scaling of the Y-axis is selected in such a way,
        //     that the trace is always visible. To this end, the range is either expanded if
        //     the minimum or maximum values of the trace move outside the current scale or
        //     scaled down if the trace fits into a reduced scale. The step width is 5 dB for
        //     selection course and variable in the range of 0.2 db to 5 dB for selection fine.
        public MeasRespYsCaleModeEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:TIME:YSCale:AUTO?").ToScpiEnum<MeasRespYsCaleModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:TIME:YSCale:AUTO " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Time_Yscale_Auto(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Auto", core, parent);
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:YSCale:AUTO:RESet
        //     Resets the Y scale to suitable values after the use of auto scaling in the expanding
        //     mode. For this mode, the scale might get expanded because of temporarily high
        //     power values. The reset function allows resetting the diagram to match smaller
        //     power values again.
        public void Reset()
        {
            _grpBase.IO.Write("SENSe:POWer:SWEep:TIME:YSCale:AUTO:RESet");
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:YSCale:AUTO:RESet
        //     Same as Reset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void ResetAndWait()
        {
            ResetAndWait(-1);
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:YSCale:AUTO:RESet
        //     Same as Reset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void ResetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SENSe:POWer:SWEep:TIME:YSCale:AUTO:RESet", opcTimeoutMs);
        }
    }
}
