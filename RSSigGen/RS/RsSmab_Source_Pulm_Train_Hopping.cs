using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Train_Hopping commands group definition
    //     Sub-classes count: 5
    //     Commands count: 3
    //     Total commands count: 13
    public class RsSmab_Source_Pulm_Train_Hopping
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Pulm_Train_Hopping_Frequency _frequency;

        private RsSmab_Source_Pulm_Train_Hopping_OffTime _offTime;

        private RsSmab_Source_Pulm_Train_Hopping_Ontime _ontime;

        private RsSmab_Source_Pulm_Train_Hopping_Power _power;

        private RsSmab_Source_Pulm_Train_Hopping_Repetition _repetition;

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Pulm_Train_Hopping_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Pulm_Train_Hopping_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     OffTime commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Pulm_Train_Hopping_OffTime OffTime => _offTime ?? (_offTime = new RsSmab_Source_Pulm_Train_Hopping_OffTime(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ontime commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Pulm_Train_Hopping_Ontime Ontime => _ontime ?? (_ontime = new RsSmab_Source_Pulm_Train_Hopping_Ontime(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Pulm_Train_Hopping_Power Power => _power ?? (_power = new RsSmab_Source_Pulm_Train_Hopping_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Repetition commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Pulm_Train_Hopping_Repetition Repetition => _repetition ?? (_repetition = new RsSmab_Source_Pulm_Train_Hopping_Repetition(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:HOPPing:CATalog
        //     No additional help available
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SOURce<HwInstance>:PULM:TRAin:HOPPing:CATalog?").ToStringList();

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:HOPPing:SELect
        //     No additional help available
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:TRAin:HOPPing:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:HOPPing:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Source_Pulm_Train_Hopping(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Hopping", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Pulm_Train_Hopping Clone()
        {
            RsSmab_Source_Pulm_Train_Hopping rsSmab_Source_Pulm_Train_Hopping = new RsSmab_Source_Pulm_Train_Hopping(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Pulm_Train_Hopping);
            return rsSmab_Source_Pulm_Train_Hopping;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:HOPPing:DELete
        //     No additional help available
        public void Delete(string filename)
        {
            _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:HOPPing:DELete " + filename.EncloseByQuotes());
        }
    }
}
