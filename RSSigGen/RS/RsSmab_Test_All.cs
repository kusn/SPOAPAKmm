using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_All commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Test_All
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     TEST<HW>:ALL:RESult
        //     Queries the result of the performed selftest. Start the selftest with method
        //     RsSmab.Test.All.Start.
        //     result: 0| 1| RUNning| STOPped
        public TestEnum Result => _grpBase.IO.QueryString("TEST<HwInstance>:ALL:RESult?").ToScpiEnum<TestEnum>();

        internal RsSmab_Test_All(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("All", core, parent);
        }

        //
        // Сводка:
        //     TEST<HW>:ALL:STARt
        //     No additional help available
        public void Start()
        {
            _grpBase.IO.Write("TEST<HwInstance>:ALL:STARt");
        }

        //
        // Сводка:
        //     TEST<HW>:ALL:STARt
        //     Same as Start, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void StartAndWait()
        {
            StartAndWait(-1);
        }

        //
        // Сводка:
        //     TEST<HW>:ALL:STARt
        //     Same as Start, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void StartAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("TEST<HwInstance>:ALL:STARt", opcTimeoutMs);
        }
    }
}
