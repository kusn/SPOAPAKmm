using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Device
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Device_Settings _settings;

        //
        // Сводка:
        //     Settings commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Device_Settings Settings => _settings ?? (_settings = new RsSmab_Device_Settings(_grpBase.Core, _grpBase));

        internal RsSmab_Device(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Device", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Device Clone()
        {
            RsSmab_Device rsSmab_Device = new RsSmab_Device(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Device);
            return rsSmab_Device;
        }

        //
        // Сводка:
        //     DEVice:PRESet
        //     Presets all parameters which are not related to the signal path, including the
        //     LF generator.
        public void Preset()
        {
            _grpBase.IO.Write("DEVice:PRESet");
        }

        //
        // Сводка:
        //     DEVice:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     DEVice:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("DEVice:PRESet", opcTimeoutMs);
        }
    }
}
