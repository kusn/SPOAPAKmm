using System.IO;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class LoggingGroup
    {
        private readonly Core _core;

        //
        // Сводка:
        //     Switches driver's logging status Use the AddStreamLogger or RemoveStreamLogger
        //     to attach or remove logging streams
        public bool Logging
        {
            get
            {
                return _core.IO.LoggingEnabled;
            }
            set
            {
                _core.IO.LoggingEnabled = value;
            }
        }

        internal LoggingGroup(Core core)
        {
            _core = core;
        }

        //
        // Сводка:
        //     Adds the stream for logging
        public void AddStreamLogger(Stream stream)
        {
            _core.AddLogger(stream);
        }

        //
        // Сводка:
        //     Removes the logging stream
        public void RemoveStreamLogger(Stream stream)
        {
            _core.AddLogger(stream);
        }

        //
        // Сводка:
        //     Writes a custom message to log
        public void WriteStringToLog(string logMessage)
        {
            _core.IO.WriteStringToLog(logMessage);
        }
    }
}
