using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_List_Dwell commands group definition
    //     Sub-classes count: 1
    //     Commands count: 2
    //     Total commands count: 4
    public class RsSmab_Source_List_Dwell
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_List_Dwell_List _list;

        //
        // Сводка:
        //     List commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_List_Dwell_List List => _list ?? (_list = new RsSmab_Source_List_Dwell_List(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:DWELl:MODE
        //     Selects the dwell time mode.
        //     dwellMode: LIST| GLOBal LIST Uses the dwell time, specified in the data table
        //     for each value pair individually. GLOBal Uses a constant dwell time, set with
        //     command LIST:DWELl.
        public ParameterSetModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LIST:DWELl:MODE?").ToScpiEnum<ParameterSetModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:DWELl:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:DWELl
        //     Sets the global dwell time. The instrument generates the signal with the frequency
        //     / power value pairs of ​​each list entry for that particular period. See also
        //     "Significant Parameters and Functions".
        //     dwell: float Range: 1E-3 to 100
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LIST:DWELl?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:DWELl " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_List_Dwell(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Dwell", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_List_Dwell Clone()
        {
            RsSmab_Source_List_Dwell rsSmab_Source_List_Dwell = new RsSmab_Source_List_Dwell(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_List_Dwell);
            return rsSmab_Source_List_Dwell;
        }
    }
}
