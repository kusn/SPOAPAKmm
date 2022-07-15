using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Filter_Length_User commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Filter_Length_User
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Filter_Length_User(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("User", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:LENGth:[USER]
        //     Selects the filter length for SENS:POW:FILT:'TYPE USER. As the filter length
        //     works as a multiplier for the time window, a constant filter length results in
        //     a constant measurement time (see also "About the measuring principle, averaging
        //     filter, filter length, and achieving stable results") . Table Header: The R&S
        //     NRP power sensors provide different resolutions for setting the filter length,
        //     depending on the used sensor type: - Resolution = 1 for R&S NRPxx power sensors,
        //     - Resolution = 2n for sensors of the R&S NRP-Zxx family, with n = 1 to 16
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   user:
        //     float Range: 1 to 65536
        public void Set(double user)
        {
            Set(user, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:LENGth:[USER]
        //     Selects the filter length for SENS:POW:FILT:'TYPE USER. As the filter length
        //     works as a multiplier for the time window, a constant filter length results in
        //     a constant measurement time (see also "About the measuring principle, averaging
        //     filter, filter length, and achieving stable results") . Table Header: The R&S
        //     NRP power sensors provide different resolutions for setting the filter length,
        //     depending on the used sensor type: - Resolution = 1 for R&S NRPxx power sensors,
        //     - Resolution = 2n for sensors of the R&S NRP-Zxx family, with n = 1 to 16
        //
        // Параметры:
        //   user:
        //     float Range: 1 to 65536
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double user, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:FILTer:LENGth:USER " + user.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:LENGth:[USER]
        //     Selects the filter length for SENS:POW:FILT:'TYPE USER. As the filter length
        //     works as a multiplier for the time window, a constant filter length results in
        //     a constant measurement time (see also "About the measuring principle, averaging
        //     filter, filter length, and achieving stable results") . Table Header: The R&S
        //     NRP power sensors provide different resolutions for setting the filter length,
        //     depending on the used sensor type: - Resolution = 1 for R&S NRPxx power sensors,
        //     - Resolution = 2n for sensors of the R&S NRP-Zxx family, with n = 1 to 16
        //     user: float Range: 1 to 65536
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:LENGth:[USER]
        //     Selects the filter length for SENS:POW:FILT:'TYPE USER. As the filter length
        //     works as a multiplier for the time window, a constant filter length results in
        //     a constant measurement time (see also "About the measuring principle, averaging
        //     filter, filter length, and achieving stable results") . Table Header: The R&S
        //     NRP power sensors provide different resolutions for setting the filter length,
        //     depending on the used sensor type: - Resolution = 1 for R&S NRPxx power sensors,
        //     - Resolution = 2n for sensors of the R&S NRP-Zxx family, with n = 1 to 16
        //     user: float Range: 1 to 65536
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:FILTer:LENGth:USER?");
        }
    }
}
