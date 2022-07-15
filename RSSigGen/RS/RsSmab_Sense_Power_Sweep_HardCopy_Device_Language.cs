using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_Device_Language commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 5
    public class RsSmab_Sense_Power_Sweep_HardCopy_Device_Language
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv _csv;

        //
        // Сводка:
        //     Csv commands group
        //     Sub-classes count: 1
        //     Commands count: 3
        //     Total commands count: 4
        public RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv Csv => _csv ?? (_csv = new RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:DEVice:LANGuage
        //     Selects the bitmap graphic format for the screenshot of the power analysis trace.
        //     In addition, ASCII file format *.csv is offered. If file format *.csv is selected,
        //     the trace data is saved as an ASCII file with comma separated values. It is also
        //     possible to directly retrieve the data using command SWEep:HCOPy:DATA
        //     language: BMP| JPG| XPM| PNG| CSV
        public MeasRespHcOpFileFormatEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:DEVice:LANGuage?").ToScpiEnum<MeasRespHcOpFileFormatEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:DEVice:LANGuage " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_HardCopy_Device_Language(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Language", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_HardCopy_Device_Language Clone()
        {
            RsSmab_Sense_Power_Sweep_HardCopy_Device_Language rsSmab_Sense_Power_Sweep_HardCopy_Device_Language = new RsSmab_Sense_Power_Sweep_HardCopy_Device_Language(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_HardCopy_Device_Language);
            return rsSmab_Sense_Power_Sweep_HardCopy_Device_Language;
        }
    }
}
