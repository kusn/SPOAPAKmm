using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Output_Protection
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     OUTPut<HW>:PROTection:TRIPped
        //     Queries the state of the protective circuit.
        //     tripped: 0| 1| OFF| ON
        public bool Tripped => _grpBase.IO.QueryBoolean("OUTPut<HwInstance>:PROTection:TRIPped?");

        internal RsSmab_Output_Protection(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Protection", core, parent);
        }

        //
        // Сводка:
        //     OUTPut<HW>:PROTection:CLEar
        //     Resets the protective circuit after it has been tripped. To define the output
        //     state, use the command :​OUTPut<hw>[:​STATe].
        public void Clear()
        {
            _grpBase.IO.Write("OUTPut<HwInstance>:PROTection:CLEar");
        }

        //
        // Сводка:
        //     OUTPut<HW>:PROTection:CLEar
        //     Same as Clear, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void ClearAndWait()
        {
            ClearAndWait(-1);
        }

        //
        // Сводка:
        //     OUTPut<HW>:PROTection:CLEar
        //     Same as Clear, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void ClearAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("OUTPut<HwInstance>:PROTection:CLEar", opcTimeoutMs);
        }
    }
}
