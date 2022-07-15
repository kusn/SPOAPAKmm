using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using RSSigGen.RS;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class Core : IDisposable
    {
        private readonly Dictionary<string, EventHandler<Instrument.ReturnArgLinkedEventArgs>> _events;

        //
        // Сводка:
        //     Owner of the core - usually the driver object
        internal object Owner { get; set; }

        //
        // Сводка:
        //     Version of the Core and the whole Internal Folder
        internal Version Version => new Version(1, 21, 0, 61);

        //
        // Сводка:
        //     Interface for instrument's Write and Query operations.
        public Instrument IO { get; protected set; }

        internal ArgumentsSingleList ArgsList { get; set; }

        //
        // Сводка:
        //     List of instrument models supported by the driver - used only in the exception
        //     message
        internal List<string> SupportedInstrModels { get; set; }

        //
        // Сводка:
        //     List of RegEx patterns to evaluate whether the current instrument model is supported
        //     by the driver
        internal List<string> SupportedIdnPatterns { get; set; }

        //
        // Сводка:
        //     Instrument driver version
        internal Version DriverVersion { get; set; }

        //
        // Сводка:
        //     Constructor with all parameters
        //
        // Параметры:
        //   resourceName:
        //     VISA resource to open the instrument
        //
        //   idQuery:
        //     Check Identification query and throw an exception if the instrument does not
        //     fit the supported instruments
        //
        //   resetDevice:
        //     Perform a reset
        //
        //   driverOptions:
        //     Additional driver-specific options
        //
        //   userOptions:
        //     Additional user options
        //
        //   directSession:
        //     If not null, a new session will not be opened, but the directSession will be
        //     reused
        private Core(string resourceName, bool idQuery, bool resetDevice, string driverOptions, string userOptions, byte[] directSession)
        {
            _events = new Dictionary<string, EventHandler<Instrument.ReturnArgLinkedEventArgs>>();
            XElement xElement = XElement.Load("InstrumentDrivers\\Internal\\SessionSettings.xml");
            XElement xElement2 = new XElement((XName?)"Config");
            xElement2.Add(new XElement((XName?)"Literal", driverOptions));
            xElement.Add(xElement2);
            string text = "SessionSettings.xml";
            if (File.Exists(text))
            {
                try
                {
                    XElement[] array = XElement.Load(text).Elements("Config").ToArray();
                    object[] content = array;
                    xElement.Add(content);
                }
                catch (XmlException)
                {
                    throw new RsSmabException(resourceName, "Wrong format of the XML data '" + text + "'. File path:\n" + Assembly.GetExecutingAssembly().Location + "\\" + text + "\nFile content: \n\n" + File.ReadAllText(text));
                }
            }

            XElement xElement3 = new XElement((XName?)"Config");
            xElement3.Add(new XElement((XName?)"Literal", userOptions));
            xElement.Add(xElement3);
            IO = new Instrument(resourceName, directSession, xElement);
            Instrument iO = IO;
            iO.ReturnArgLinked = (EventHandler<Instrument.ReturnArgLinkedEventArgs>)Delegate.Combine(iO.ReturnArgLinked, new EventHandler<Instrument.ReturnArgLinkedEventArgs>(_C_ReturnArgLinked));
            if (idQuery)
            {
                IO.FitsIdnPattern(IO.Settings.SupportedIdnPatterns, IO.Settings.SupportedInstrModels);
            }

            if (resetDevice)
            {
                IO.Reset();
            }
            else
            {
                IO.CheckStatus();
            }

            ArgsList = new ArgumentsSingleList();
        }

        internal Core(string resourceName, bool idQuery, bool resetDevice, string driverOptions, string optionString)
            : this(resourceName, idQuery, resetDevice, driverOptions, optionString, null)
        {
        }

        internal Core(string resourceName, string driverOptions)
            : this(resourceName, idQuery: false, resetDevice: false, driverOptions, "", null)
        {
        }

        internal Core(string resourceName, bool idQuery, bool resetDevice, string driverOptions)
            : this(resourceName, idQuery, resetDevice, driverOptions, "", null)
        {
        }

        internal Core(byte[] directSession, string driverOptions)
            : this(null, idQuery: false, resetDevice: false, driverOptions, "", directSession)
        {
        }

        //
        // Сводка:
        //     Disposes of the Core object
        protected virtual void Dispose(bool disposing)
        {
            IO.Dispose();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        //
        // Сводка:
        //     Allows for the custom driver to register for value changed events. One handler
        //     can only be registered once
        //
        // Параметры:
        //   name:
        //     Name of the parameter to be invoke an Value Change event on
        //
        //   handler:
        //     event handler to associate with the event
        internal void RegisterForReturnArgSuppressed(string name, EventHandler<Instrument.ReturnArgLinkedEventArgs> handler)
        {
            if (_events.ContainsKey(name))
            {
                Dictionary<string, EventHandler<Instrument.ReturnArgLinkedEventArgs>> events = _events;
                string key = name;
                events[key] = (EventHandler<Instrument.ReturnArgLinkedEventArgs>)Delegate.Remove(events[key], handler);
                events = _events;
                key = name;
                events[key] = (EventHandler<Instrument.ReturnArgLinkedEventArgs>)Delegate.Combine(events[key], handler);
            }
            else
            {
                _events.Add(name, handler);
            }
        }

        //
        // Сводка:
        //     Splits the events to their appropriate event handlers
        private void _C_ReturnArgLinked(object sender, Instrument.ReturnArgLinkedEventArgs e)
        {
            if (_events.ContainsKey(e.Name))
            {
                _events[e.Name]?.Invoke(this, e);
            }
        }

        //
        // Сводка:
        //     Add new StreamWriter listener
        internal void AddLogger(Stream sw)
        {
            IO.AddLogger(sw);
        }

        //
        // Сводка:
        //     Remove StreamWriter listener
        internal void RemoveLogger(Stream sw)
        {
            IO.RemoveLogger(sw);
        }

        //
        // Сводка:
        //     Writes string message to log.
        internal void WriteStringToLog(string logMessage)
        {
            IO.WriteStringToLog(logMessage);
        }

        //
        // Сводка:
        //     Returns true, if the instrument has the entered option installed
        internal bool IsOptionAvailable(string option)
        {
            return IO.InstrOptions.IsAvailable(option);
        }

        //
        // Сводка:
        //     Composes 1 parameter as a string from the ArgumentDefine definition
        internal string ComposeCmdArg(ArgSingle arg1)
        {
            return ArgsList.ComposeCmdString(arg1);
        }

        //
        // Сводка:
        //     /// Composes 2 parameters as a string from the ArgumentDefine definitions
        internal string ComposeCmdArg(ArgSingle arg1, ArgSingle arg2)
        {
            return ArgsList.ComposeCmdString(arg1, arg2);
        }

        //
        // Сводка:
        //     /// Composes 3 parameters as a string from the ArgumentDefine definitions
        internal string ComposeCmdArg(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3)
        {
            return ArgsList.ComposeCmdString(arg1, arg2, arg3);
        }

        //
        // Сводка:
        //     /// Composes 4 parameters as a string from the ArgumentDefine definitions
        internal string ComposeCmdArg(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4)
        {
            return ArgsList.ComposeCmdString(arg1, arg2, arg3, arg4);
        }

        //
        // Сводка:
        //     /// Composes 5 parameters as a string from the ArgumentDefine definitions
        internal string ComposeCmdArg(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4, ArgSingle arg5)
        {
            return ArgsList.ComposeCmdString(arg1, arg2, arg3, arg4, arg5);
        }

        //
        // Сводка:
        //     /// Composes 6 parameters as a string from the ArgumentDefine definitions
        internal string ComposeCmdArg(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4, ArgSingle arg5, ArgSingle arg6)
        {
            return ArgsList.ComposeCmdString(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        //
        // Сводка:
        //     /// Composes 7 parameters as a string from the ArgumentDefine definitions
        internal string ComposeCmdArg(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4, ArgSingle arg5, ArgSingle arg6, ArgSingle arg7)
        {
            return ArgsList.ComposeCmdString(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        //
        // Сводка:
        //     /// Composes 8 parameters as a string from the ArgumentDefine definitions
        internal string ComposeCmdArg(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4, ArgSingle arg5, ArgSingle arg6, ArgSingle arg7, ArgSingle arg8)
        {
            return ArgsList.ComposeCmdString(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        //
        // Сводка:
        //     /// Composes 9 parameters as a string from the ArgumentDefine definitions
        internal string ComposeCmdArg(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4, ArgSingle arg5, ArgSingle arg6, ArgSingle arg7, ArgSingle arg8, ArgSingle arg9)
        {
            return ArgsList.ComposeCmdString(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
    }
}
