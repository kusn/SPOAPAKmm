using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Multiplier_External_Correction commands group definition
    //     Sub-classes count: 3
    //     Commands count: 5
    //     Total commands count: 10
    public class RsSmab_Source_Frequency_Multiplier_External_Correction
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Frequency_Multiplier_External_Correction_Frequency _frequency;

        private RsSmab_Source_Frequency_Multiplier_External_Correction_Power _power;

        private RsSmab_Source_Frequency_Multiplier_External_Correction_Sensor _sensor;

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Frequency_Multiplier_External_Correction_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Frequency_Multiplier_External_Correction_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Frequency_Multiplier_External_Correction_Power Power => _power ?? (_power = new RsSmab_Source_Frequency_Multiplier_External_Correction_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sensor commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        //     Repeated Capability: ChannelRepCap, default value after init: ChannelRepCap.Nr1
        public RsSmab_Source_Frequency_Multiplier_External_Correction_Sensor Sensor => _sensor ?? (_sensor = new RsSmab_Source_Frequency_Multiplier_External_Correction_Sensor(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:CATalog
        //     No additional help available
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:CATalog?").ToStringList();

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:CLOSs
        //     No additional help available
        public double Closs
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:CLOSs?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:CLOSs " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:MODE
        //     No additional help available
        public RfFreqMultCcorModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:MODE?").ToScpiEnum<RfFreqMultCcorModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:SELect
        //     No additional help available
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Source_Frequency_Multiplier_External_Correction(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Correction", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Frequency_Multiplier_External_Correction Clone()
        {
            RsSmab_Source_Frequency_Multiplier_External_Correction rsSmab_Source_Frequency_Multiplier_External_Correction = new RsSmab_Source_Frequency_Multiplier_External_Correction(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Frequency_Multiplier_External_Correction);
            return rsSmab_Source_Frequency_Multiplier_External_Correction;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:DELete
        //     No additional help available
        public void Delete(string filename)
        {
            _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:DELete " + filename.EncloseByQuotes());
        }
    }
}
