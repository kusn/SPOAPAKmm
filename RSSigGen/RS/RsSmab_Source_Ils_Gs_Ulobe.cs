﻿using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Gs_Ulobe commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Ils_Gs_Ulobe
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:ULOBe:[FREQuency]
        //     frequency: float Range: 60 to 120
        public double Frequency
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GS:ULOBe:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:ULOBe:FREQuency " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Ils_Gs_Ulobe(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ulobe", core, parent);
        }
    }
}
