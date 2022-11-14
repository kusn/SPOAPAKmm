using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trigger_LffSweep commands group definition
    //     Sub-classes count: 2
    //     Commands count: 1
    //     Total commands count: 4
    public class RsSmab_Trigger_LffSweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trigger_LffSweep_Immediate _immediate;

        private RsSmab_Trigger_LffSweep_Source _source;

        //
        // Сводка:
        //     Immediate commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trigger_LffSweep_Immediate Immediate => _immediate ?? (_immediate = new RsSmab_Trigger_LffSweep_Immediate(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trigger_LffSweep_Source Source => _source ?? (_source = new RsSmab_Trigger_LffSweep_Source(_grpBase.Core, _grpBase));

        internal RsSmab_Trigger_LffSweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("LffSweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trigger_LffSweep Clone()
        {
            RsSmab_Trigger_LffSweep rsSmab_Trigger_LffSweep = new RsSmab_Trigger_LffSweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trigger_LffSweep);
            return rsSmab_Trigger_LffSweep;
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep
        //     Table Header: Executes an LF frequency sweep in the following configuration:
        //     - method RsSmab.Trigger.LffSweep.Source.Set SING, - LFO:SWE:MODE AUTO
        //
        // Параметры:
        //   inputIx:
        //     Repeated capability selector
        public void Set(InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            _grpBase.IO.Write("TRIGger" + repCapCmdValue + ":LFFSweep");
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait(InputIxRepCap inputIx)
        {
            SetAndWait(inputIx, -1);
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(InputIxRepCap inputIx, int opcTimeoutMs)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            _grpBase.IO.WriteWithOpc("TRIGger" + repCapCmdValue + ":LFFSweep", opcTimeoutMs);
        }
    }
}
