using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source commands group definition
    //     Sub-classes count: 29
    //     Commands count: 1
    //     Total commands count: 499
    public class RsSmab_Source
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Adf _adf;

        private RsSmab_Source_Am _am;

        private RsSmab_Source_Bb _bb;

        private RsSmab_Source_Chirp _chirp;

        private RsSmab_Source_Combined _combined;

        private RsSmab_Source_Correction _correction;

        private RsSmab_Source_Dme _dme;

        private RsSmab_Source_Fm _fm;

        private RsSmab_Source_Frequency _frequency;

        private RsSmab_Source_FreqSweep _freqSweep;

        private RsSmab_Source_Ils _ils;

        private RsSmab_Source_Input _input;

        private RsSmab_Source_LffSweep _lffSweep;

        private RsSmab_Source_LfOutput _lfOutput;

        private RsSmab_Source_List _list;

        private RsSmab_Source_Mbeacon _mbeacon;

        private RsSmab_Source_Modulation _modulation;

        private RsSmab_Source_Noise _noise;

        private RsSmab_Source_Path _path;

        private RsSmab_Source_Pgenerator _pgenerator;

        private RsSmab_Source_Phase _phase;

        private RsSmab_Source_Pm _pm;

        private RsSmab_Source_Power _power;

        private RsSmab_Source_Psweep _psweep;

        private RsSmab_Source_Pulm _pulm;

        private RsSmab_Source_Roscillator _roscillator;

        private RsSmab_Source_Sweep _sweep;

        private RsSmab_Source_ValRf _valRf;

        private RsSmab_Source_Vor _vor;

        //
        // Сводка:
        //     Adf commands group
        //     Sub-classes count: 2
        //     Commands count: 2
        //     Total commands count: 16
        public RsSmab_Source_Adf Adf => _adf ?? (_adf = new RsSmab_Source_Adf(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Am commands group
        //     Sub-classes count: 4
        //     Commands count: 3
        //     Total commands count: 11
        //     Repeated Capability: GeneratorIxRepCap, default value after init: GeneratorIxRepCap.Nr1
        public RsSmab_Source_Am Am => _am ?? (_am = new RsSmab_Source_Am(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Bb commands group
        //     Sub-classes count: 4
        //     Commands count: 0
        //     Total commands count: 17
        public RsSmab_Source_Bb Bb => _bb ?? (_bb = new RsSmab_Source_Bb(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Chirp commands group
        //     Sub-classes count: 4
        //     Commands count: 3
        //     Total commands count: 9
        public RsSmab_Source_Chirp Chirp => _chirp ?? (_chirp = new RsSmab_Source_Chirp(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Combined commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Source_Combined Combined => _combined ?? (_combined = new RsSmab_Source_Combined(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Correction commands group
        //     Sub-classes count: 3
        //     Commands count: 2
        //     Total commands count: 19
        public RsSmab_Source_Correction Correction => _correction ?? (_correction = new RsSmab_Source_Correction(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Dme commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 9
        public RsSmab_Source_Dme Dme => _dme ?? (_dme = new RsSmab_Source_Dme(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Fm commands group
        //     Sub-classes count: 3
        //     Commands count: 3
        //     Total commands count: 8
        //     Repeated Capability: GeneratorIxRepCap, default value after init: GeneratorIxRepCap.Nr1
        public RsSmab_Source_Fm Fm => _fm ?? (_fm = new RsSmab_Source_Fm(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 6
        //     Commands count: 8
        //     Total commands count: 50
        public RsSmab_Source_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     FreqSweep commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_FreqSweep FreqSweep => _freqSweep ?? (_freqSweep = new RsSmab_Source_FreqSweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ils commands group
        //     Sub-classes count: 5
        //     Commands count: 3
        //     Total commands count: 96
        public RsSmab_Source_Ils Ils => _ils ?? (_ils = new RsSmab_Source_Ils(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Input commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Source_Input Input => _input ?? (_input = new RsSmab_Source_Input(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     LffSweep commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_LffSweep LffSweep => _lffSweep ?? (_lffSweep = new RsSmab_Source_LffSweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     LfOutput commands group
        //     Sub-classes count: 8
        //     Commands count: 2
        //     Total commands count: 34
        //     Repeated Capability: LfOutputRepCap, default value after init: LfOutputRepCap.Nr1
        public RsSmab_Source_LfOutput LfOutput => _lfOutput ?? (_lfOutput = new RsSmab_Source_LfOutput(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     List commands group
        //     Sub-classes count: 8
        //     Commands count: 8
        //     Total commands count: 34
        public RsSmab_Source_List List => _list ?? (_list = new RsSmab_Source_List(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Mbeacon commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Mbeacon Mbeacon => _mbeacon ?? (_mbeacon = new RsSmab_Source_Mbeacon(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Modulation commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_Modulation Modulation => _modulation ?? (_modulation = new RsSmab_Source_Modulation(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Noise commands group
        //     Sub-classes count: 2
        //     Commands count: 1
        //     Total commands count: 5
        public RsSmab_Source_Noise Noise => _noise ?? (_noise = new RsSmab_Source_Noise(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Path commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Path Path => _path ?? (_path = new RsSmab_Source_Path(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Pgenerator commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 3
        public RsSmab_Source_Pgenerator Pgenerator => _pgenerator ?? (_pgenerator = new RsSmab_Source_Pgenerator(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Phase commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Source_Phase Phase => _phase ?? (_phase = new RsSmab_Source_Phase(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Pm commands group
        //     Sub-classes count: 3
        //     Commands count: 3
        //     Total commands count: 8
        //     Repeated Capability: GeneratorIxRepCap, default value after init: GeneratorIxRepCap.Nr1
        public RsSmab_Source_Pm Pm => _pm ?? (_pm = new RsSmab_Source_Pm(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 8
        //     Commands count: 8
        //     Total commands count: 37
        public RsSmab_Source_Power Power => _power ?? (_power = new RsSmab_Source_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Psweep commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_Psweep Psweep => _psweep ?? (_psweep = new RsSmab_Source_Psweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Pulm commands group
        //     Sub-classes count: 4
        //     Commands count: 10
        //     Total commands count: 46
        public RsSmab_Source_Pulm Pulm => _pulm ?? (_pulm = new RsSmab_Source_Pulm(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Roscillator commands group
        //     Sub-classes count: 3
        //     Commands count: 2
        //     Total commands count: 14
        public RsSmab_Source_Roscillator Roscillator => _roscillator ?? (_roscillator = new RsSmab_Source_Roscillator(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sweep commands group
        //     Sub-classes count: 4
        //     Commands count: 2
        //     Total commands count: 35
        public RsSmab_Source_Sweep Sweep => _sweep ?? (_sweep = new RsSmab_Source_Sweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     ValRf commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_ValRf ValRf => _valRf ?? (_valRf = new RsSmab_Source_ValRf(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Vor commands group
        //     Sub-classes count: 8
        //     Commands count: 4
        //     Total commands count: 31
        public RsSmab_Source_Vor Vor => _vor ?? (_vor = new RsSmab_Source_Vor(_grpBase.Core, _grpBase));

        internal RsSmab_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source Clone()
        {
            RsSmab_Source rsSmab_Source = new RsSmab_Source(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source);
            return rsSmab_Source;
        }

        //
        // Сводка:
        //     SOURce<HW>:PRESet
        //     Presets all parameters which are related to the selected signal path.
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:PRESet");
        }

        //
        // Сводка:
        //     SOURce<HW>:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     SOURce<HW>:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:PRESet", opcTimeoutMs);
        }
    }
}
