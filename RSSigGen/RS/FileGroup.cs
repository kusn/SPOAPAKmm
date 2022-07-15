using System.IO;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class FileGroup
    {
        private readonly Core _core;

        internal FileGroup(Core core)
        {
            _core = core;
        }

        //
        // Сводка:
        //     SCPI Command: MMEM:DATA Sends file from the provided stream to the Instrument
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public void FromStreamToInstrument(Stream sourceStream, string targetInstrFile)
        {
            string command = "MMEM:DATA '" + targetInstrFile + "',";
            _core.IO.WriteBinaryData(command, sourceStream);
        }

        //
        // Сводка:
        //     SCPI Command: MMEM:DATA Sends file from PC to the Instrument
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public void FromPcToInstrument(string sourcePcFile, string targetInstrFile)
        {
            using FileStream sourceStream = new FileStream(sourcePcFile, FileMode.Open, FileAccess.Read);
            FromStreamToInstrument(sourceStream, targetInstrFile);
        }

        //
        // Сводка:
        //     SCPI Command: MMEM:DATA? Reads file from Instrument to the provided stream
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public void FromInstrumentToStream(string sourceInstrFile, Stream targetStream)
        {
            string query = "MMEM:DATA? '" + sourceInstrFile + "'";
            _core.IO.QueryBinaryData(query, targetStream);
        }

        //
        // Сводка:
        //     SCPI Command: MMEM:DATA? Reads file from Instrument to the PC
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public void FromInstrumentToPc(string sourceInstrFile, string targetPcFile, bool appendToPcFile = false)
        {
            using FileStream targetStream = new FileStream(targetPcFile, appendToPcFile ? FileMode.Append : FileMode.Create, FileAccess.Write);
            FromInstrumentToStream(sourceInstrFile, targetStream);
        }
    }
}
