using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Read_Power commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Read_Power
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Read_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     READ<CH>:[POWer]
        //     Triggers power measurement and displays the results. Note: This command does
        //     not affect the local state, i.e. you can get results with local state on or off.
        //     For long measurement times, we recommend that you use an SRQ for command synchronization
        //     (MAV bit) .
        //     power: float or float,float The sensor returns the result in the unit set with
        //     command SENSech Certain power sensors, such as the R&S NRP-Z81, return two values,
        //     first the value of the average level and - separated by a comma - the peak value.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Read")
        public List<double> Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     READ<CH>:[POWer]
        //     Triggers power measurement and displays the results. Note: This command does
        //     not affect the local state, i.e. you can get results with local state on or off.
        //     For long measurement times, we recommend that you use an SRQ for command synchronization
        //     (MAV bit) .
        //     power: float or float,float The sensor returns the result in the unit set with
        //     command SENSech Certain power sensors, such as the R&S NRP-Z81, return two values,
        //     first the value of the average level and - separated by a comma - the peak value.
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public List<double> Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryBinaryOrAsciiFloatArray("READ" + repCapCmdValue + ":POWer?").ToList();
        }
    }
}
