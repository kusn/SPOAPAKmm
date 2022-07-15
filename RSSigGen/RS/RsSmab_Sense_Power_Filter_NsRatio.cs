using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Filter_NsRatio commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Filter_NsRatio
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Filter_NsRatio_Mtime _mtime;

        //
        // Сводка:
        //     Mtime commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Filter_NsRatio_Mtime Mtime => _mtime ?? (_mtime = new RsSmab_Sense_Power_Filter_NsRatio_Mtime(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Filter_NsRatio(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("NsRatio", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Filter_NsRatio Clone()
        {
            RsSmab_Sense_Power_Filter_NsRatio rsSmab_Sense_Power_Filter_NsRatio = new RsSmab_Sense_Power_Filter_NsRatio(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Filter_NsRatio);
            return rsSmab_Sense_Power_Filter_NsRatio;
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:NSRatio
        //     Sets an upper limit for the relative noise content in fixed noise filter mode
        //     (FILTer:TYPE) . This value determines the proportion of intrinsic noise in the
        //     measurement results.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   nsRatio:
        //     float Range: 0.001 to 1
        public void Set(double nsRatio)
        {
            Set(nsRatio, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:NSRatio
        //     Sets an upper limit for the relative noise content in fixed noise filter mode
        //     (FILTer:TYPE) . This value determines the proportion of intrinsic noise in the
        //     measurement results.
        //
        // Параметры:
        //   nsRatio:
        //     float Range: 0.001 to 1
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double nsRatio, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:FILTer:NSRatio " + nsRatio.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:NSRatio
        //     Sets an upper limit for the relative noise content in fixed noise filter mode
        //     (FILTer:TYPE) . This value determines the proportion of intrinsic noise in the
        //     measurement results.
        //     nsRatio: float Range: 0.001 to 1
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:NSRatio
        //     Sets an upper limit for the relative noise content in fixed noise filter mode
        //     (FILTer:TYPE) . This value determines the proportion of intrinsic noise in the
        //     measurement results.
        //     nsRatio: float Range: 0.001 to 1
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:FILTer:NSRatio?");
        }
    }
}
