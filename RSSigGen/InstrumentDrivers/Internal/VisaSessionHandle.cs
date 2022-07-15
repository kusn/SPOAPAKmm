using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using RSSigGen.RS;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class VisaSessionHandle
    {
        //
        // Сводка:
        //     Full Resource name including plugins
        internal string ResourceName { get; private set; }

        //
        // Сводка:
        //     Resource name stripped of the round brackets part
        internal string VisaResourceName { get; private set; }

        internal int RmHandle { get; set; }

        internal int Handle { get; set; }

        internal VisaPlugin Plugin { get; set; }

        internal bool Simulate { get; private set; }

        internal bool CreatedAsDirect { get; }

        //
        // Сводка:
        //     Returns true, if the Resource manager is valid
        internal bool ValidRm => RmHandle > 0;

        //
        // Сводка:
        //     Returns true, if the Handle is valid (connected)
        internal bool ValidConnection
        {
            get
            {
                if (ValidRm)
                {
                    return Handle > 0;
                }

                return false;
            }
        }

        //
        // Сводка:
        //     Returns true, if the VISA plugin is default
        internal bool HasDefaultPlugin
        {
            get
            {
                if (Plugin != VisaPlugin.NativeVisa && Plugin != 0)
                {
                    return Plugin == VisaPlugin.Undefined;
                }

                return true;
            }
        }

        //
        // Сводка:
        //     Private constructor with all the parameters
        private VisaSessionHandle(string resourceName, int rmHandle, int handle, string plugin, bool simulate)
        {
            CreatedAsDirect = false;
            ResourceName = resourceName;
            VisaResourceName = resourceName;
            string rnPlugin = ParseResourceNamePlugin(resourceName);
            Plugin = _ResolveDirectAndRnPlugin(plugin, rnPlugin);
            RmHandle = rmHandle;
            Handle = handle;
            Simulate = simulate;
        }

        //
        // Сводка:
        //     Standard Session Handle
        internal VisaSessionHandle(string resourceName, string plugin, bool simulate)
            : this(resourceName, 0, 0, plugin, simulate)
        {
            if (simulate)
            {
                RmHandle = 1;
                Handle = 1;
            }
        }

        //
        // Сводка:
        //     Session Handle from serialized data
        internal VisaSessionHandle(byte[] session)
        {
            CreatedAsDirect = true;
            _Deserialize(session);
            VisaResourceName = ResourceName;
            ParseResourceNamePlugin(ResourceName);
        }

        public override string ToString()
        {
            string text = $"VisaSessionHandle {Handle} plugin {Plugin}";
            if (Simulate)
            {
                text += "(Simulating)";
            }

            return text;
        }

        //
        // Сводка:
        //     Encodes the current VISA session parameters into a byte array
        internal byte[] Serialize()
        {
            Dictionary<string, string> source = new Dictionary<string, string>
            {
                ["ResourceName"] = ResourceName,
                ["Plugin"] = Plugin.ToString(),
                ["RmHandle"] = RmHandle.ToString(),
                ["Handle"] = Handle.ToString(),
                ["Simulate"] = Simulate.ToBooleanString()
            };
            string s = string.Join(",", source.Select((KeyValuePair<string, string> x) => x.Key + "=" + x.Value));
            return Encoding.ASCII.GetBytes(s);
        }

        //
        // Сводка:
        //     Decodes entered byte array and returns the VISA session parameters The input
        //     resourceName is only used for exceptions
        private void _Deserialize(byte[] data)
        {
            Dictionary<string, string> tokensDict = new Dictionary<string, string>();
            List<string> list = Encoding.ASCII.GetString(data).Split(',').ToList();
            if (list.Count < 5)
            {
                throw new RsSmabException(ResourceName, $"Entered direct VISA session data is invalid - wrong number of elements {list.Count} != 5");
            }

            try
            {
                list.ForEach(delegate (string x)
                {
                    tokensDict.AddToken(x);
                });
                ResourceName = tokensDict["ResourceName"];
                Plugin = (VisaPlugin)Enum.Parse(typeof(VisaPlugin), tokensDict["Plugin"]);
                RmHandle = tokensDict["RmHandle"].ToInt32();
                Handle = tokensDict["Handle"].ToInt32();
                Simulate = tokensDict["Simulate"].ToBoolean();
            }
            catch (Exception)
            {
                throw new RsSmabException(ResourceName, "Entered direct VISA session data is invalid (wrong format)");
            }
        }

        //
        // Сводка:
        //     Parses input resourceName and returns: plugin string if present in the resourceName,
        //     else null Sets the VisaResourceName if the plugin was stripped
        internal string ParseResourceNamePlugin(string resourceName)
        {
            Match match = new Regex("(.+)\\(SelectVisa=([^\\),]+)\\)", RegexOptions.IgnoreCase).Match(resourceName);
            if (!match.Success)
            {
                return null;
            }

            VisaResourceName = match.Groups[1].Value.Trim();
            return match.Groups[2].Value.Trim();
        }

        //
        // Сводка:
        //     Converts input string to VisaPlugin enum
        internal VisaPlugin ConvertFromString(string visaPlugin)
        {
            VisaPlugin num = VisaC.StringToPlugin(visaPlugin);
            if (num == VisaPlugin.Unknown)
            {
                throw new RsSmabException(ResourceName, "Non-supported plugin '" + visaPlugin + "'. Supported are: SocketIo, RsVisa, RsVisaPrio, NativeVisa");
            }

            return num;
        }

        //
        // Сводка:
        //     Returns resolved plugin, direct plugin has priority
        private VisaPlugin _ResolveDirectAndRnPlugin(string directPlugin, string rnPlugin)
        {
            VisaPlugin result = VisaPlugin.Undefined;
            if (!string.IsNullOrEmpty(directPlugin) || !string.IsNullOrEmpty(rnPlugin))
            {
                if (!string.IsNullOrEmpty(directPlugin) && string.IsNullOrEmpty(rnPlugin))
                {
                    return ConvertFromString(directPlugin);
                }

                if (string.IsNullOrEmpty(directPlugin) && !string.IsNullOrEmpty(rnPlugin))
                {
                    return ConvertFromString(rnPlugin);
                }

                result = ConvertFromString(directPlugin);
                VisaPlugin visaPlugin = ConvertFromString(rnPlugin);
                result = ((result == VisaPlugin.Undefined) ? visaPlugin : result);
            }

            return result;
        }

        //
        // Сводка:
        //     Sets RmHandle and Handle to 0
        internal void InvalidateHandles()
        {
            RmHandle = 0;
            Handle = 0;
        }
    }
}
