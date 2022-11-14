using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Kboard
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     KBOard:LAYout
        //     Selects the language for an external keyboard and assigns the keys acccordingly.
        //     layout: CHINese| DANish| DUTCh| DUTBe| ENGLish| ENGUK| FINNish| FRENch| FREBe|
        //     FRECa| GERMan| ITALian| JAPanese| KORean| NORWegian| PORTuguese| RUSSian| SPANish|
        //     SWEDish| ENGUS
        public KbLayoutEnum Layout
        {
            get
            {
                return _grpBase.IO.QueryString("KBOard:LAYout?").ToScpiEnum<KbLayoutEnum>();
            }
            set
            {
                _grpBase.IO.Write("KBOard:LAYout " + value.ToScpiString());
            }
        }

        internal RsSmab_Kboard(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Kboard", core, parent);
        }
    }
}
