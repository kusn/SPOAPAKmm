using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class InstrumentOptions
    {
        private List<string> _optionsList;

        //
        // Сводка:
        //     Initializes an instance with initial optionsString parsed
        //
        // Параметры:
        //   optionsString:
        //     Option string returned by the *OPT? query
        //
        //   mode:
        //     Select how to parse each element
        internal InstrumentOptions(string optionsString, InstrOptionsParseMode mode = InstrOptionsParseMode.Auto)
        {
            _optionsList = new List<string>();
            _InitializeFromString(optionsString, mode);
        }

        //
        // Сводка:
        //     Represent the object as comma-separated string
        public override string ToString()
        {
            return string.Join(", ", _optionsList);
        }

        //
        // Сводка:
        //     Parses options string into a string List. It removes double-entries, trims the
        //     white spaces and quotations marks. Sorts the option by the number, starting with
        //     K0, K1, K2, ... K2000, then B0, B1 ... B2000
        //
        // Параметры:
        //   optionsString:
        //     option string returned by the *OPT? query
        //
        //   mode:
        //     Select how to parse each element
        //
        // Возврат:
        //     Options List
        private void _InitializeFromString(string optionsString, InstrOptionsParseMode mode)
        {
            if (mode == InstrOptionsParseMode.Skip)
            {
                return;
            }

            List<string> source = optionsString.TrimStringResponse().Split(',').ToList();
            source = source.Select((string x) => x.TrimStringResponse()).ToList();
            source = source.Select((string x) => x.Contains(':') ? x.Substring(0, x.IndexOf(':')).TrimEnd(':').Trim() : x).ToList();
            switch (mode)
            {
                case InstrOptionsParseMode.KeepAfterDash:
                    source = source.Select((string x) => x.Contains('-') ? x.Substring(x.IndexOf('-')).TrimStart('-') : x).ToList();
                    break;
                case InstrOptionsParseMode.KeepBeforeDash:
                    source = source.Select((string x) => x.Contains('-') ? x.Substring(0, x.IndexOf('-')).TrimEnd('-') : x).ToList();
                    break;
                case InstrOptionsParseMode.Auto:
                    {
                        for (int i = 0; i < source.Count; i++)
                        {
                            int num = source[i].IndexOf('-');
                            if (num >= 0)
                            {
                                string text = source[i].Substring(0, num).TrimEnd('-');
                                string text2 = source[i].Substring(num).TrimStart('-');
                                Match match = Regex.Match(text, "^(.?)(K|B)(\\d+)(.*)$");
                                Match match2 = Regex.Match(text2, "^(.?)(K|B)(\\d+)(.*)$");
                                source[i] = ((match2.Length >= match.Length) ? text2 : text);
                            }
                        }

                        break;
                    }
            }

            source = source.Where((string s) => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            Dictionary<string, string> auxDict = new Dictionary<string, string>();
            foreach (string item in source)
            {
                string key = item;
                Match match3 = Regex.Match(item, "^(.?)(K|B)(\\d+)(.*)$");
                if (match3.Success)
                {
                    key = string.Format("{0}{1}{2:D9}{3}", match3.Groups[1].Value, (match3.Groups[2].Value == "B") ? "02" : "01", match3.Groups[3].Value.ToInt32(), match3.Groups[4].Value);
                }

                auxDict.Add(key, item);
            }

            List<string> list = auxDict.Keys.ToList();
            list.Sort();
            _optionsList = list.Select((string x) => auxDict[x]).ToList();
        }

        //
        // Сводка:
        //     Returns true, if the entered option is available
        //
        // Параметры:
        //   option:
        //     Option to check for presence
        internal bool IsAvailable(string option)
        {
            option = option.Trim();
            if (_optionsList.Contains(option))
            {
                return true;
            }

            if (option.StartsWith("K") && _optionsList.Contains("K0"))
            {
                return true;
            }

            Regex regex = new Regex("[a-zA-Z]*[-]?(?<opt>[a-zA-Z][0-9]*)");
            foreach (string options in _optionsList)
            {
                Match match = regex.Match(options);
                if (match.Success && match.Groups["opt"].Value == option)
                {
                    return true;
                }
            }

            return false;
        }

        //
        // Сводка:
        //     Returns true, if the entered option is missing
        //
        // Параметры:
        //   option:
        //     Option to check for presence
        internal bool IsMissing(string option)
        {
            return !IsAvailable(option);
        }

        //
        // Сводка:
        //     Returns all the options
        internal List<string> GetAll()
        {
            return _optionsList;
        }
    }
}
