﻿using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Localizer_Icao commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Ils_Localizer_Icao
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:ICAO:CHANnel
        //     Sets the ICAO channel and the corresponding transmitting frequency. If avionic
        //     standard modulation is activated and you change the "RF Frequency", the frequency
        //     value of the closest ICAO channel is applied automatically. The "ICAO Channel"
        //     is also updated. The ICAO channel settings for ILS glide slope/localizer components
        //     are coupled. For an overview of the ILS ICAO channel frequencies, see Table "ILS
        //     glide slope and localizer ICAO standard frequencies (MHz) and channels".
        //     selIcaoChan: CH18X| CH18Y| CH20X| CH20Y| CH22X| CH22Y| CH24X| CH24Y| CH26X| CH26Y|
        //     CH28X| CH28Y| CH30X| CH30Y| CH32X| CH32Y| CH34X| CH34Y| CH36X| CH36Y| CH38X|
        //     CH38Y| CH40X| CH40Y| CH42X| CH42Y| CH44X| CH44Y| CH46X| CH46Y| CH48X| CH48Y|
        //     CH50X| CH50Y| CH52X| CH52Y| CH54X| CH54Y| CH56X| CH56Y
        public AvionicIlsIcaoChanEnum Channel
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:LOCalizer:ICAO:CHANnel?").ToScpiEnum<AvionicIlsIcaoChanEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:ICAO:CHANnel " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Ils_Localizer_Icao(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Icao", core, parent);
        }
    }
}
