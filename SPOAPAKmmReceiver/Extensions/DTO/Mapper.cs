using SPOAPAKmmReceiver.Models;
using System;

namespace SPOAPAKmmReceiver.Extensions.DTO
{
    public static class Mapper
    {
        public static InstrumentSettingsConfig InstrumentSettingsToConfigSection(this InstrumentSettings item) => item is null
            ? null
            : new InstrumentSettingsConfig
            {
                InstrAddress = item.InstrAddress,
                IpAddress = item.IpAddress,
                Port = item.Port,
            };

        public static InstrumentSettings ConfigSectionToInstrumentSettings(this InstrumentSettingsConfig item) => item is null
            ? null
            : new InstrumentSettings
            {
                InstrAddress = item.InstrAddress,
                IpAddress = item.IpAddress,
                Port = item.Port,                
            };

        public class InstrumentSettingsConfig
        {
            public string IpAddress { get; set; }
            public string InstrAddress { get; set; }
            public int Port { get; set; }            
        }
    }
}
