using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv commands group definition
    //     Sub-classes count: 1
    //     Commands count: 3
    //     Total commands count: 4
    public class RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv_Column _column;

        //
        // Сводка:
        //     Column commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv_Column Column => _column ?? (_column = new RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv_Column(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:DEVice:LANGuage:CSV:DPOint
        //     Defines which character is used as the decimal point of the values, either dot
        //     or comma.
        //     dpoint: DOT| COMMa
        public DecimalSeparatorEnum Dpoint
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:DEVice:LANGuage:CSV:DPOint?").ToScpiEnum<DecimalSeparatorEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:DEVice:LANGuage:CSV:DPOint " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:DEVice:LANGuage:CSV:HEADer
        //     Defines whether each row (or column depending on the orientation) should be preceded
        //     by a header containing information about the trace (see also SWEep:HCOPy:DATA)
        //     .
        //     header: OFF| STANdard
        public MeasRespHcOpCsvhEaderEnum Header
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:DEVice:LANGuage:CSV:HEADer?").ToScpiEnum<MeasRespHcOpCsvhEaderEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:DEVice:LANGuage:CSV:HEADer " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:DEVice:LANGuage:CSV:ORIentation
        //     Defines the orientation of the X/Y value pairs.
        //     orientation: HORizontal| VERTical
        public MeasRespHcOpCsvoRientEnum Orientation
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:DEVice:LANGuage:CSV:ORIentation?").ToScpiEnum<MeasRespHcOpCsvoRientEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:DEVice:LANGuage:CSV:ORIentation " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Csv", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv Clone()
        {
            RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv rsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv = new RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv);
            return rsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv;
        }
    }
}
