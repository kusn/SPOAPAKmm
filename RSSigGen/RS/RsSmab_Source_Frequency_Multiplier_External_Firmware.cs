using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Multiplier_External_Firmware commands group definition
    //     Sub-classes count: 1
    //     Commands count: 3
    //     Total commands count: 4
    public class RsSmab_Source_Frequency_Multiplier_External_Firmware
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Frequency_Multiplier_External_Firmware_Update _update;

        //
        // Сводка:
        //     Update commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Frequency_Multiplier_External_Firmware_Update Update => _update ?? (_update = new RsSmab_Source_Frequency_Multiplier_External_Firmware_Update(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:FIRMware:CATalog
        //     No additional help available
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:FIRMware:CATalog?").ToStringList();

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:FIRMware:SELect
        //     No additional help available
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:FIRMware:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:FIRMware:SELect " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:FIRMware:VERSion
        //     No additional help available
        public string Version => _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:FIRMware:VERSion?").TrimStringResponse();

        internal RsSmab_Source_Frequency_Multiplier_External_Firmware(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Firmware", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Frequency_Multiplier_External_Firmware Clone()
        {
            RsSmab_Source_Frequency_Multiplier_External_Firmware rsSmab_Source_Frequency_Multiplier_External_Firmware = new RsSmab_Source_Frequency_Multiplier_External_Firmware(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Frequency_Multiplier_External_Firmware);
            return rsSmab_Source_Frequency_Multiplier_External_Firmware;
        }
    }
}
