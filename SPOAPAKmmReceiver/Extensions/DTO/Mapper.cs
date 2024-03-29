﻿using System.Collections.Generic;
using SPOAPAKmm.Extensions;
using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.Models;

namespace SPOAPAKmmReceiver.Extensions.DTO
{
    public static class Mapper
    {
        public static InstrumentSettingsConfig InstrumentSettingsToConfigSection(this InstrumentSettings item)
        {
            return item is null
                ? null
                : new InstrumentSettingsConfig
                {
                    InstrAddress = item.InstrAddress,
                    IpAddress = item.IpAddress,
                    Port = item.Port
                };
        }

        public static InstrumentSettings ConfigSectionToInstrumentSettings(this InstrumentSettingsConfig item)
        {
            return item is null
                ? null
                : new InstrumentSettings
                {
                    InstrAddress = item.InstrAddress,
                    IpAddress = item.IpAddress,
                    Port = item.Port
                };
        }

        public static MeasSettings MeasSettingsFromMeasureSettings(this MeasureSettings item)
        {
            ICollection<Frequency> lf = new List<Frequency>();

            if (item is null) return null;

            foreach (var f in item.FrequencyList)
            {
                var fr = new Frequency();
                fr.Freq = f;
                lf.Add(fr);
            }

            return new MeasSettings
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
                FrequencyList = lf
            };
        }

        public static MeasureSettings MeasSettingsToMeasureSettings(this MeasSettings item)
        {
            var cf = new SortableObservableCollection<double>();

            if (item is null) return null;

            if (item.FrequencyList is null)
                item.FrequencyList = new List<Frequency>();

            foreach (var rsFrequency in item.FrequencyList)
            {
                double f;
                f = rsFrequency.Freq;
                cf.Add(f);
            }

            return new MeasureSettings
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
                FrequencyList = cf
            };
        }

        public class InstrumentSettingsConfig
        {
            public string IpAddress { get; set; }
            public string InstrAddress { get; set; }
            public int Port { get; set; }
        }
    }
}