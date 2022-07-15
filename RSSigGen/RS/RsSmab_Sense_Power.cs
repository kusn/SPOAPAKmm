using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power commands group definition
    //     Sub-classes count: 15
    //     Commands count: 0
    //     Total commands count: 119
    public class RsSmab_Sense_Power
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Aperture _aperture;

        private RsSmab_Sense_Power_Correction _correction;

        private RsSmab_Sense_Power_Direct _direct;

        private RsSmab_Sense_Power_Display _display;

        private RsSmab_Sense_Power_Filter _filter;

        private RsSmab_Sense_Power_Frequency _frequency;

        private RsSmab_Sense_Power_Logging _logging;

        private RsSmab_Sense_Power_Offset _offset;

        private RsSmab_Sense_Power_Snumber _snumber;

        private RsSmab_Sense_Power_Source _source;

        private RsSmab_Sense_Power_Status _status;

        private RsSmab_Sense_Power_Sversion _sversion;

        private RsSmab_Sense_Power_Sweep _sweep;

        private RsSmab_Sense_Power_Type _type;

        private RsSmab_Sense_Power_Zero _zero;

        //
        // Сводка:
        //     Aperture commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Sense_Power_Aperture Aperture => _aperture ?? (_aperture = new RsSmab_Sense_Power_Aperture(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Correction commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Sense_Power_Correction Correction => _correction ?? (_correction = new RsSmab_Sense_Power_Correction(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Direct commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Direct Direct => _direct ?? (_direct = new RsSmab_Sense_Power_Direct(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Display commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Sense_Power_Display Display => _display ?? (_display = new RsSmab_Sense_Power_Display(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Filter commands group
        //     Sub-classes count: 4
        //     Commands count: 0
        //     Total commands count: 6
        public RsSmab_Sense_Power_Filter Filter => _filter ?? (_filter = new RsSmab_Sense_Power_Filter(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Sense_Power_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Logging commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Sense_Power_Logging Logging => _logging ?? (_logging = new RsSmab_Sense_Power_Logging(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Offset commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Sense_Power_Offset Offset => _offset ?? (_offset = new RsSmab_Sense_Power_Offset(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Snumber commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Snumber Snumber => _snumber ?? (_snumber = new RsSmab_Sense_Power_Snumber(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Source Source => _source ?? (_source = new RsSmab_Sense_Power_Source(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Status commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Sense_Power_Status Status => _status ?? (_status = new RsSmab_Sense_Power_Status(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sversion commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sversion Sversion => _sversion ?? (_sversion = new RsSmab_Sense_Power_Sversion(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sweep commands group
        //     Sub-classes count: 4
        //     Commands count: 4
        //     Total commands count: 95
        public RsSmab_Sense_Power_Sweep Sweep => _sweep ?? (_sweep = new RsSmab_Sense_Power_Sweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Type commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Type Type => _type ?? (_type = new RsSmab_Sense_Power_Type(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Zero commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Zero Zero => _zero ?? (_zero = new RsSmab_Sense_Power_Zero(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power Clone()
        {
            RsSmab_Sense_Power rsSmab_Sense_Power = new RsSmab_Sense_Power(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power);
            return rsSmab_Sense_Power;
        }
    }
}
