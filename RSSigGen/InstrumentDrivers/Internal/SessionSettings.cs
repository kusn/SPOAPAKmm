using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using RSSigGen.RS;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class SessionSettings
    {
        internal class Tokens
        {
            private Dictionary<string, string> _dict;

            //
            // Сводка:
            //     Returns all the defined names
            internal IEnumerable<string> Names => _dict.Keys;

            //
            // Сводка:
            //     Returns number of tokens in the dictionary
            internal int Count => _dict.Count;

            //
            // Сводка:
            //     Creates tokens from the string values. Separator: ',' If a value is enclosed
            //     by single quotes, e.g. 'K20,K30', the separator is escaped.
            internal Tokens(string content)
            {
                _ParseFromString(content);
            }

            //
            // Сводка:
            //     Creates tokens from the attributes of an XML element
            internal Tokens(XElement element)
            {
                _Parse(element);
            }

            //
            // Сводка:
            //     Creates empty tokens
            internal Tokens()
            {
                _ParseFromString("");
            }

            //
            // Сводка:
            //     String representation of the class
            public override string ToString()
            {
                if (_dict.Count > 0)
                {
                    return $"Tokens, count: {_dict.Count}";
                }

                return "Empty tokens";
            }

            //
            // Сводка:
            //     Sets/Updates value of the token
            internal void SetStringValue(string name, string value)
            {
                _dict[name.ToUpper()] = value;
            }

            //
            // Сводка:
            //     Merges the entered tokens with higher priority
            internal void MergeWith(Tokens tokens)
            {
                foreach (string name in tokens.Names)
                {
                    SetStringValue(name, tokens.GetStringValue(name));
                }
            }

            //
            // Сводка:
            //     Parses string into Tokens. Values of the repeated tokens are overwritten - the
            //     last one wins
            private void _ParseFromString(string content)
            {
                _dict = new Dictionary<string, string>();
                if (string.IsNullOrWhiteSpace(content))
                {
                    return;
                }

                Regex regex = new Regex("'([^']+)'");
                while (true)
                {
                    Match match = regex.Match(content);
                    if (!match.Success)
                    {
                        break;
                    }

                    content = content.Substring(0, match.Index) + "\"" + match.Groups[1].Value.Replace(",", "<COMMA_ESC>") + "\"" + content.Substring(match.Index + match.Length);
                }

                foreach (string item in from s in content.Split(',').ToList()
                                        where !string.IsNullOrWhiteSpace(s)
                                        select s)
                {
                    if (item.Replace("<COMMA_ESC>", ",").Trim().ParseNameValueToken(out var keyName, out var keyValue) > 1)
                    {
                        string key = keyName.ToUpper(CultureInfo.InvariantCulture);
                        _dict[key] = keyValue;
                    }
                }
            }

            //
            // Сводка:
            //     Parses all the element attributes to tokens
            //
            // Параметры:
            //   el:
            private void _Parse(XElement el)
            {
                _dict = el.Attributes().ToDictionary((XAttribute x) => x.Name.LocalName.ToUpper(), (XAttribute x) => x.Value);
            }

            //
            // Сводка:
            //     Returns true, if the value is defines
            internal bool IsDefined(string name)
            {
                return _dict.ContainsKey(name.ToUpper(CultureInfo.InvariantCulture));
            }

            //
            // Сводка:
            //     Returns string token value or dflt if not found
            internal string GetStringValue(string name, string dflt = null)
            {
                if (!IsDefined(name))
                {
                    return dflt;
                }

                return _dict[name.ToUpper(CultureInfo.InvariantCulture)];
            }

            //
            // Сводка:
            //     Returns Integer token value or dflt if not found
            internal int GetIntValue(string name, int dflt)
            {
                if (!IsDefined(name))
                {
                    return dflt;
                }

                return _dict[name.ToUpper(CultureInfo.InvariantCulture)].ToInt32();
            }

            //
            // Сводка:
            //     Returns boolean token value or dflt if not found
            internal bool GetBoolValue(string name, bool dflt)
            {
                if (!IsDefined(name))
                {
                    return dflt;
                }

                return _dict[name.ToUpper(CultureInfo.InvariantCulture)].ToBoolean();
            }

            //
            // Сводка:
            //     Returns Enum token value or exception if not found
            internal T GetEnumValue<T>(string name) where T : Enum
            {
                return GetStringValue(name).ToScpiEnum<T>();
            }

            //
            // Сводка:
            //     Returns list of strings token value or dflt if not found String is split on comma
            //     ',' or forward slash '/'
            internal List<string> GetStringListValue(string name, List<string> dflt = null)
            {
                if (!IsDefined(name))
                {
                    return dflt;
                }

                return _dict[name.ToUpper(CultureInfo.InvariantCulture)].Split(',', '/').ToList();
            }
        }

        //
        // Сводка:
        //     If TRUE, each VISA read must end with TermChar. If not, the reading continues
        //     If FALSE, (default) the reading can end with any character
        internal bool AssureResponseEndWithTc;

        //
        // Сводка:
        //     Delay before each Write (not valid for segmented writes)
        internal int WriteDelay { get; set; }

        //
        // Сводка:
        //     Delay before each Read (not valid for segmented reads)
        internal int ReadDelay { get; set; }

        //
        // Сводка:
        //     If true, the code performs viClear() after viOpen
        internal bool PerformVisaClear { get; set; }

        //
        // Сводка:
        //     Maximum read/write segment size when communicating with the instrument
        internal int IoSegmentSize { get; set; }

        //
        // Сводка:
        //     OPC timeout in milliseconds for all write/read with OPC sync operations
        internal int OpcTimeout { get; set; }

        //
        // Сводка:
        //     VISA timeout in milliseconds for all VISA operations
        internal int VisaTimeout { get; set; }

        //
        // Сводка:
        //     If true, RS VISA is preferred. If false, System Default VISA is chosen
        internal bool PreferRsVisa { get; set; }

        //
        // Сводка:
        //     If non-null, the custom VISA plugin is selected
        internal string SelectVisa { get; set; }

        //
        // Сводка:
        //     Timeout for Self-test procedure
        internal int SelfTestTimeout { get; set; }

        //
        // Сводка:
        //     Parsing mode for the *OPT? response
        internal InstrOptionsParseMode OptionsParseMode { get; set; }

        //
        // Сводка:
        //     If true, the instrument Model has the full *IDN? query name (e.g. "NRP2"). If
        //     false, the name has only the A-Z prefix (e.g. "NRP")
        internal bool IdnModelFullName { get; set; }

        //
        // Сводка:
        //     If true, the IO communication logging is enabled
        internal bool LoggingEnabled { get; set; }

        //
        // Сводка:
        //     If true, the IO communication logging has more detailed format including source
        //     code lines
        internal bool LoggingDebug { get; set; }

        //
        // Сводка:
        //     Maximal length of an ASCII IO communication logging entry until the middle part
        //     is truncated
        internal int LoggingMaxAsciiEntryLength { get; set; }

        //
        // Сводка:
        //     Maximal length of a binary IO communication logging entry until the middle part
        //     is truncated
        internal int LoggingMaxBinEntryLength { get; set; }

        //
        // Сводка:
        //     Defines binary data coding of instrument's floating-point numbers - used by all
        //     methods that decode binary data to an array of floating-point numbers.
        internal InstrBinaryFloatNumbersFormat BinFloatNumbersFormat { get; set; }

        //
        // Сводка:
        //     Defines binary data coding of instrument's integer numbers - used by all methods
        //     that decode binary data to an array of integer numbers.
        internal InstrBinaryIntegerNumbersFormat BinIntNumbersFormat { get; set; }

        //
        // Сводка:
        //     If >0, during STB polling sets the VISA Timeout to a this number to avoid long
        //     waiting times by some instruments (NRP-S/SN) sensors
        internal int ReadStbVisaTimeout { get; set; }

        //
        // Сводка:
        //     If true, each io.write is followed by a *OPC? query
        internal bool OpcQueryAfterEachSetting { get; set; }

        //
        // Сводка:
        //     If true, Checking of instrument status after each command is ON
        internal bool QueryInstrumentStatus { get; set; }

        //
        // Сводка:
        //     IDN string in simulation mode
        internal string SimulationIdnString { get; set; }

        //
        // Сводка:
        //     OPT string in simulation mode
        internal string SimulationOptString { get; set; }

        //
        // Сводка:
        //     Simulation mode ON/OFF
        internal bool Simulate { get; set; }

        //
        // Сводка:
        //     Forward-slash-separated list of the supported instrument models
        internal List<string> SupportedInstrModels { get; set; }

        //
        // Сводка:
        //     Forward-slash-separated list of the Regexes evaluated against *IDN? response
        internal List<string> SupportedIdnPatterns { get; set; }

        //
        // Сводка:
        //     You can define the default OpcWaitMode. It might be coerced to OpcQuery, depending
        //     on the session kind
        internal WaitForOpcMode OpcWaitMode { get; set; }

        //
        // Сводка:
        //     If true, writing of binary data to the instrument is appended by the TermChar.
        //     It might be coerced to TRUE, depending on the session kind
        internal bool AddTermCharToWriteBinData { get; set; }

        //
        // Сводка:
        //     If true, every write string is checked for the TermChar at the end. If the TermChar
        //     is missing, it is added. You can define the default AssureWriteWithTc value.
        //     It might be coerced to TRUE depending on the session kind
        internal bool AssureWriteWithTc { get; set; }

        //
        // Сводка:
        //     Termination character for reading and writing. Default is LF
        internal char TermChar { get; set; }

        //
        // Сводка:
        //     You can define the default VxiCapable value. It might be coerced to FALSE, depending
        //     on the session kind
        internal bool VxiCapable { get; set; }

        //
        // Сводка:
        //     If TRUE (default), the error checking starts with *STB? query If FALSE, the error
        //     checking calls directly the SYST:ERR? query
        internal bool StbInErrorCheck { get; set; }

        //
        // Сводка:
        //     If FALSE (default), the error checking calls directly the SYST:ERR? query Set
        //     it to TRUE for instrument that do not support *OPC?
        internal bool DisableOpcQuery { get; set; }

        //
        // Сводка:
        //     Creates the SessionSettings from the xml file, only applying the common settings
        //
        // Параметры:
        //   xml:
        internal SessionSettings(XElement xml)
        {
            Tokens tokens = _ParseFromXml(xml, null, null, null);
            _ApplyTokens(tokens);
        }

        //
        // Сводка:
        //     Creates the SessionSettings from the xml file, considering the specifics of the
        //     resourceName and sessionKind
        internal SessionSettings(XElement xml, string resourceName, string sessionKind, string idnPattern)
        {
            Tokens tokens = _ParseFromXml(xml, resourceName, sessionKind, idnPattern);
            _ApplyTokens(tokens);
        }

        //
        // Сводка:
        //     Apply settings to Property fields. Also applies default values if the tokens
        //     are not present
        private void _ApplyTokens(Tokens tokens)
        {
            if (tokens.Count != 0)
            {
                PreferRsVisa = tokens.GetBoolValue("PreferRsVisa", dflt: false);
                SelectVisa = tokens.GetStringValue("SelectVisa");
                VisaTimeout = tokens.GetIntValue("VisaTimeout", 10000);
                WriteDelay = tokens.GetIntValue("WriteDelay", 0);
                ReadDelay = tokens.GetIntValue("ReadDelay", 0);
                IoSegmentSize = tokens.GetIntValue("IoSegmentSize", 10000000);
                PerformVisaClear = tokens.GetBoolValue("PerformVisaClear", dflt: true);
                AssureWriteWithTc = tokens.GetBoolValue("AssureWriteWithTc", dflt: false);
                AssureWriteWithTc = tokens.GetBoolValue("AssureWriteWithLf", AssureWriteWithTc);
                TermChar = tokens.GetStringValue("TermChar", "\n").ToCharArray()[0];
                AddTermCharToWriteBinData = tokens.GetBoolValue("AddTermCharToWriteBinData", dflt: false);
                VxiCapable = tokens.GetBoolValue("VxiCapable", dflt: true);
                DisableOpcQuery = tokens.GetBoolValue("DisableOpcQuery", dflt: false);
                AssureResponseEndWithTc = tokens.GetBoolValue("AssureResponseEndWithTc", dflt: false);
                OpcTimeout = tokens.GetIntValue("OpcTimeout", 30000);
                ReadStbVisaTimeout = tokens.GetIntValue("ReadStbVisaTimeout", -1);
                OpcWaitMode = WaitForOpcMode.StbPolling;
                string stringValue;
                if ((stringValue = tokens.GetStringValue("OpcWaitMode")) != null)
                {
                    OpcWaitMode = stringValue.ToScpiEnum<WaitForOpcMode>();
                }

                SelfTestTimeout = tokens.GetIntValue("SelfTestTimeout", 600000);
                OpcQueryAfterEachSetting = tokens.GetBoolValue("OpcQueryAfterEachSetting", dflt: false);
                LoggingEnabled = tokens.GetBoolValue("LoggingEnabled", dflt: false);
                LoggingDebug = tokens.GetBoolValue("LoggingDebug", dflt: false);
                LoggingMaxBinEntryLength = tokens.GetIntValue("LoggingMaxBinEntryLength", -1);
                LoggingMaxAsciiEntryLength = tokens.GetIntValue("LoggingMaxAsciiEntryLength", -1);
                IdnModelFullName = tokens.GetBoolValue("IdnModelFullName", dflt: true);
                StbInErrorCheck = tokens.GetBoolValue("StbInErrorCheck", dflt: true);
                OptionsParseMode = InstrOptionsParseMode.Auto;
                if ((stringValue = tokens.GetStringValue("OptionsParseMode")) != null)
                {
                    OptionsParseMode = stringValue.ToScpiEnum<InstrOptionsParseMode>();
                }

                BinFloatNumbersFormat = InstrBinaryFloatNumbersFormat.Single4Bytes;
                if ((stringValue = tokens.GetStringValue("BinFloatNumbersFormat")) != null)
                {
                    BinFloatNumbersFormat = stringValue.ToScpiEnum<InstrBinaryFloatNumbersFormat>();
                }

                BinIntNumbersFormat = InstrBinaryIntegerNumbersFormat.Integer324Bytes;
                if ((stringValue = tokens.GetStringValue("BinIntNumbersFormat")) != null)
                {
                    BinIntNumbersFormat = stringValue.ToScpiEnum<InstrBinaryIntegerNumbersFormat>();
                }

                QueryInstrumentStatus = tokens.GetBoolValue("QueryInstrumentStatus", dflt: true);
                SimulationIdnString = tokens.GetStringValue("SimulationIdnString");
                SimulationOptString = tokens.GetStringValue("SimulationOptString");
                Simulate = tokens.GetBoolValue("Simulate", dflt: false);
                SupportedInstrModels = tokens.GetStringListValue("SupportedInstrModels");
                SupportedIdnPatterns = tokens.GetStringListValue("SupportedIdnPatterns");
            }
        }

        //
        // Сводка:
        //     Returns the tokens from the XML that fulfill the entered 'resourceName' and 'sessionKind'
        //     The tokens are created by accumulating all the settings in the order as they
        //     are defined, meaning the latest setting wins
        private Tokens _ParseFromXml(XElement xml, string resourceName, string sessionKind, string idnPattern)
        {
            IEnumerable<XElement> configs = from x in xml.Descendants("Config")
                                            where _FulfillsCondition(x, "ResourceName", resourceName) && _FulfillsCondition(x, "SessionKind", sessionKind) && _FulfillsCondition(x, "IdnPattern", idnPattern)
                                            select x;
            return _GetAllTokens(configs);
        }

        //
        // Сводка:
        //     Returns true, if the entered XML element or its ancestors fulfill the condition:
        //     attrName.Value == conditionValue If the attrName is not present, the condition
        //     is fulfilled If the conditionValue == null, the condition is fulfilled If the
        //     attrName is present, and the conditionValue is equal the attribute value (case-insensitive),
        //     the condition is fulfilled If the very first character is '!', the condition
        //     logic is inverted: attrName.Value != conditionValue If the start of the condition
        //     value is '[RE]', the matching switches to Regular Expression (case-insensitive).
        //     You can also use the combination of '![RE]'
        private bool _FulfillsCondition(XElement el, string attrName, string conditionValue)
        {
            if (conditionValue == null)
            {
                return true;
            }

            XElement xElement = el.AncestorsAndSelf().FirstOrDefault((XElement e) => e.Attribute((XName?)attrName) != null);
            if (xElement == null)
            {
                return true;
            }

            bool flag = false;
            bool flag2 = false;
            string text = xElement.Attribute((XName?)attrName)!.Value.Trim();
            if (text.StartsWith("!"))
            {
                flag = true;
                text = text.Substring(1);
            }

            if (text.StartsWith("[RE]"))
            {
                flag2 = true;
                text = text.Substring(4);
            }

            bool flag3 = ((!flag2) ? string.Equals(text, conditionValue, StringComparison.CurrentCultureIgnoreCase) : Regex.IsMatch(conditionValue, text, RegexOptions.IgnoreCase));
            if (flag)
            {
                flag3 = !flag3;
            }

            return flag3;
        }

        //
        // Сводка:
        //     Return accumulated tokens from all the entered config elements
        private Tokens _GetAllTokens(IEnumerable<XElement> configs)
        {
            Tokens tokens = new Tokens();
            foreach (XElement config in configs)
            {
                foreach (XElement item in config.Elements("Settings"))
                {
                    tokens.MergeWith(new Tokens(item));
                }

                foreach (XElement item2 in config.Elements("Literal"))
                {
                    tokens.MergeWith(new Tokens(item2.Value));
                }
            }

            return tokens;
        }
    }
}
