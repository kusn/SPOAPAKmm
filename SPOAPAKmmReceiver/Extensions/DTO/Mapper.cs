using SPOAPAKmmReceiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SPOAPAKmmReceiver.Entities;

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

        public static MeasSettings MeasSettingsFromMeasureSettings(this MeasureSettings item) => item is null
            ? null
            : new MeasSettings
            {
                StartFrequency = item.StartFrequency,
                EndFrequency = item.EndFrequency,
                Step = item.Step,
                Offset = item.Offset,
                Power = item.Power,
                TimeOfEmission = item.TimeOfEmission,
                Span = item.Span,
                Rbw = item.Rbw,
                Attenuation = item.Attenuation,
                IsPreferredRow = item.IsPreferredRow,
                IsOwnRow = item.IsOwnRow,
                IsPreamp = item.IsPreamp,
                FrequencyList = new List<Frequency>(item.FrequencyList.Cast<Frequency>()),
            };

        public static MeasureSettings MeasSettingsToMeasureSettings(this MeasSettings item) => item is null
            ? null
            : new MeasureSettings
            {
                StartFrequency = item.StartFrequency,
                EndFrequency = item.EndFrequency,
                Step = item.Step,
                Offset = item.Offset,
                Power = item.Power,
                TimeOfEmission = item.TimeOfEmission,
                Span = item.Span,
                Rbw = item.Rbw,
                Attenuation = item.Attenuation,
                IsPreferredRow = item.IsPreferredRow,
                IsOwnRow = item.IsOwnRow,
                IsPreamp = item.IsPreamp,
                FrequencyList = new SortableObservableCollection<double>(item.FrequencyList.Cast<double>()),
            };

        public class InstrumentSettingsConfig
        {
            public string IpAddress { get; set; }
            public string InstrAddress { get; set; }
            public int Port { get; set; }            
        }
    }
}
