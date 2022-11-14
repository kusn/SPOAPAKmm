using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Train_Dexchange_Afile_Separator commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Pulm_Train_Dexchange_Afile_Separator
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:DEXChange:AFILe:SEParator:COLumn
        //     Selects the separator between the frequency and level column of the ASCII table.
        //     column: TABulator| SEMicolon| COMMa| SPACe
        public DexchSepColEnum Column
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:TRAin:DEXChange:AFILe:SEParator:COLumn?").ToScpiEnum<DexchSepColEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:DEXChange:AFILe:SEParator:COLumn " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:DEXChange:AFILe:SEParator:DECimal
        //     Sets "." (decimal point) or "," (comma) as the decimal separator used in the
        //     ASCII data with floating-point numerals.
        //     decimal: DOT| COMMa
        public DecimalSeparatorEnum Decimal
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:TRAin:DEXChange:AFILe:SEParator:DECimal?").ToScpiEnum<DecimalSeparatorEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:DEXChange:AFILe:SEParator:DECimal " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Pulm_Train_Dexchange_Afile_Separator(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Separator", core, parent);
        }
    }
}
