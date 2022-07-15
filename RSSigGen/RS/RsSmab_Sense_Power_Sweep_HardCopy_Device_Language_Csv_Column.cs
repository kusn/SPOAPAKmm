using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv_Column commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv_Column
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:DEVice:LANGuage:CSV:[COLumn]:SEParator
        //     Defines which character is to separate the values, either tabulator, semicolon,
        //     comma or blank.
        //     separator: TABulator| SEMicolon| COMMa| BLANk
        public MeasRespHcOpCsvcLmSepEnum Separator
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:DEVice:LANGuage:CSV:COLumn:SEParator?").ToScpiEnum<MeasRespHcOpCsvcLmSepEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:DEVice:LANGuage:CSV:COLumn:SEParator " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_HardCopy_Device_Language_Csv_Column(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Column", core, parent);
        }
    }
}
