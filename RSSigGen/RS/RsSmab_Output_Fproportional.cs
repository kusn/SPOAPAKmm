using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Output_Fproportional
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     OUTPut:FPRoportional:SCALe
        //     Selects the mode the voltage is supplied depending on the frequency. The R&S
        //     SMA100B supplies the signal at the V/GHz X-Axis connector.
        //     outpSelScale: S0V25| S0V5| S1V0| XAXis S0V25|S0V5|S1V0 Supplies the voltage proportional
        //     to the set frequency, derived from the selected setting. XAXis Supplies a voltage
        //     range from 0 V to 10 V proportional to the frequency sweep range, set withFREQuency:STARt
        //     and FREQuency:STOP.
        public SelOutpVxAxisEnum Scale
        {
            get
            {
                return _grpBase.IO.QueryString("OUTPut:FPRoportional:SCALe?").ToScpiEnum<SelOutpVxAxisEnum>();
            }
            set
            {
                _grpBase.IO.Write("OUTPut:FPRoportional:SCALe " + value.ToScpiString());
            }
        }

        internal RsSmab_Output_Fproportional(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Fproportional", core, parent);
        }
    }
}
