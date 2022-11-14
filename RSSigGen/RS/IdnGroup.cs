using System;
using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class IdnGroup
    {
        private readonly Core _core;

        //
        // Сводка:
        //     Returns the current instrument driver version
        public Version DriverVersion => _core.DriverVersion;

        //
        // Сводка:
        //     Returns the current instrument core engine version
        public Version CoreVersion => _core.Version;

        //
        // Сводка:
        //     SCPI Command: *IDN? Returns instrument's Identification string
        public string IdnString => _core.IO.IdnString;

        //
        // Сводка:
        //     Returns manufacturer of the instrument
        public string Manufacturer => _core.IO.Manufacturer;

        //
        // Сводка:
        //     Return the current instrument's full name e.g. FSW26
        public string InstrumentFullName => _core.IO.FullInstrumentModelName;

        //
        // Сводка:
        //     Return the current instrument's family name e.g. FSW
        public string InstrumentName => _core.IO.Model;

        //
        // Сводка:
        //     Return the instrument resource name used to initialize the instrument session
        public string ResourceName => _core.IO.ResourceName;

        //
        // Сводка:
        //     Returns a list of the instrument models supported by this instrument driver
        public IEnumerable<string> SupportedModels => _core.SupportedInstrModels;

        //
        // Сводка:
        //     Returns instrument's firmware revision
        public string InstrumentFirmwareVersion => _core.IO.FirmwareRevision;

        //
        // Сводка:
        //     Returns instrument's serial number
        public string InstrumentSerialNumber => _core.IO.SerialNumber;

        //
        // Сводка:
        //     Returns all the instrument options. The options are sorted in the ascending order
        //     starting with K-options and continuing with B-options
        public IEnumerable<string> InstrumentOptions => _core.IO.InstrOptions.GetAll();

        //
        // Сводка:
        //     Returns the manufacturer of the current VISA session
        public string VisaManufacturer => _core.IO.VisaManufacturer;

        //
        // Сводка:
        //     Returns used Visa DLL name including bittness
        public string VisaDllName => _core.IO.VisaDllName;

        internal IdnGroup(Core core)
        {
            _core = core;
        }
    }
}
