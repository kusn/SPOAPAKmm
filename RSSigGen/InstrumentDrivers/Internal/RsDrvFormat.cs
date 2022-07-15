using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using RSSigGen.RS;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal static class RsDrvFormat
    {
        internal static NumberFormatInfo Number;

        private static readonly NumberStyles _numberStyle;

        private static readonly Dictionary<string, bool> _booleanLookup;

        private static readonly Dictionary<string, bool> _passFailLookup;

        private static readonly HashSet<string> _numbersPlusInfLookup;

        private static readonly HashSet<string> _numbersMinusInfLookup;

        private static readonly HashSet<string> _numbersNanLookup;

        private static readonly HashSet<string> _numbersMaxLookup;

        private static readonly HashSet<string> _numbersMinLookup;

        private static readonly Dictionary<string, double> _specialDoubleExtStrValLookup;

        private static readonly Dictionary<double, string> _specialDoubleExtValStrLookup;

        private static readonly Dictionary<string, double> _specialDoubleSiSuffixes;

        private static readonly Dictionary<string, int> _specialIntExtStrValLookup;

        private static readonly Dictionary<int, string> _specialIntExtValStrLookup;

        private static readonly Dictionary<string, long> _specialLongsLookup;

        //
        // Сводка:
        //     Constructor of the static class
        static RsDrvFormat()
        {
            _numberStyle = NumberStyles.Number | NumberStyles.AllowExponent;
            Number = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = ""
            };
            _booleanLookup = new Dictionary<string, bool>
            {
                { "0", false },
                { "False", false },
                { "FALSE", false },
                { "false", false },
                { "VI_FALSE", false },
                { "OFF", false },
                { "Off", false },
                { "off", false },
                { "1", true },
                { "True", true },
                { "TRUE", true },
                { "true", true },
                { "VI_TRUE", true },
                { "ON", true },
                { "On", true },
                { "on", true }
            };
            _passFailLookup = new Dictionary<string, bool>
            {
                { "Passed", true },
                { "PASSED", true },
                { "passed", true },
                { "Pass", true },
                { "PASS", true },
                { "pass", true },
                { "Failed", false },
                { "FAILED", false },
                { "failed", false },
                { "Fail", false },
                { "FAIL", false },
                { "fail", false }
            };
            _numbersPlusInfLookup = new HashSet<string> { "Inf", "INF", "INFINITY", "+Inf", "+INF", "+inf", "+INFINITY", "+Infinity", "+infinity" };
            _numbersMinusInfLookup = new HashSet<string> { "-Inf", "-INF", "-inf", "-INFINITY", "-Infinity", "-infinity" };
            _numbersNanLookup = new HashSet<string>
            {
                "Nan", "NAN", "nan", "NaN", "NAV", "NaV", "NCAP", "INV", "NONE", "none",
                "None", "DTX", "Dtx", "dtx", "UND", "und"
            };
            _numbersMaxLookup = new HashSet<string> { "OFL", "ofl", "Ofl" };
            _numbersMinLookup = new HashSet<string> { "UFL", "ufl", "Ufl" };
            _specialDoubleExtStrValLookup = new Dictionary<string, double>
            {
                { "OFF", -4.94065645841247E-324 },
                { "ON", -9.8813129168249309E-324 },
                {
                    "OK",
                    double.Epsilon
                },
                { "DC", -1.7976931348623156E+306 },
                { "ULEU", 1.7976931348623158E+307 },
                { "ULEL", -1.7976931348623158E+307 }
            };
            _specialDoubleExtValStrLookup = _specialDoubleExtStrValLookup.ToDictionary((KeyValuePair<string, double> x) => x.Value, (KeyValuePair<string, double> y) => y.Key);
            _specialDoubleSiSuffixes = new Dictionary<string, double>
            {
                { "fs", 1E-15 },
                { "fW", 1E-15 },
                { "pHz", 1E-12 },
                { "ps", 1E-12 },
                { "pF", 1E-12 },
                { "pA", 1E-12 },
                { "pV", 1E-12 },
                { "pW", 1E-12 },
                { "pm", 1E-12 },
                { "nHz", 1E-09 },
                { "ns", 1E-09 },
                { "nF", 1E-09 },
                { "nA", 1E-09 },
                { "nV", 1E-09 },
                { "nW", 1E-09 },
                { "nm", 1E-09 },
                { "uHz", 1E-06 },
                { "us", 1E-06 },
                { "uF", 1E-06 },
                { "uA", 1E-06 },
                { "uV", 1E-06 },
                { "uW", 1E-06 },
                { "um", 1E-06 },
                { "\ufffdHz", 1E-06 },
                { "\ufffds", 1E-06 },
                { "\ufffdF", 1E-06 },
                { "\ufffdA", 1E-06 },
                { "\ufffdV", 1E-06 },
                { "\ufffdW", 1E-06 },
                { "\ufffdm", 1E-06 },
                { "mHz", 0.001 },
                { "ms", 0.001 },
                { "mF", 0.001 },
                { "mA", 0.001 },
                { "mV", 0.001 },
                { "mW", 0.001 },
                { "mm", 0.001 },
                { "Hz", 1.0 },
                { "s", 1.0 },
                { "F", 1.0 },
                { "A", 1.0 },
                { "V", 1.0 },
                { "W", 1.0 },
                { "m", 1.0 },
                { "kHz", 1000.0 },
                { "kA", 1000.0 },
                { "kV", 1000.0 },
                { "kW", 1000.0 },
                { "km", 1000.0 },
                { "MHz", 1000000.0 },
                { "MA", 1000000.0 },
                { "MV", 1000000.0 },
                { "MW", 1000000.0 },
                { "GHz", 1000000000.0 },
                { "GW", 1000000000.0 },
                { "THz", 1000000000000.0 }
            };
            List<KeyValuePair<string, double>> list = _specialDoubleSiSuffixes.ToList();
            list.Sort((KeyValuePair<string, double> firstPair, KeyValuePair<string, double> nextPair) => -firstPair.Key.Length.CompareTo(nextPair.Key.Length));
            _specialDoubleSiSuffixes = list.ToDictionary((KeyValuePair<string, double> pair) => pair.Key, (KeyValuePair<string, double> pair) => pair.Value);
            _specialIntExtStrValLookup = new Dictionary<string, int>
            {
                { "OFF", -2147483647 },
                { "ON", -2147483646 },
                { "NAN", -2147483645 },
                { "OK", 2147483646 },
                { "DC", -21474836 },
                { "ULEU", 214748364 },
                { "ULEL", -214748364 },
                {
                    "-INF",
                    int.MinValue
                },
                {
                    "INF",
                    int.MaxValue
                }
            };
            _specialIntExtValStrLookup = _specialIntExtStrValLookup.ToDictionary((KeyValuePair<string, int> x) => x.Value, (KeyValuePair<string, int> y) => y.Key);
            _specialLongsLookup = new Dictionary<string, long>
            {
                { "OFF", -9223372036854775807L },
                { "ON", -9223372036854775806L },
                { "OK", 9223372036854775806L },
                { "DC", -92233720368547758L },
                { "ULEU", 922337203685477580L },
                { "ULEL", -922337203685477580L },
                {
                    "-INF",
                    long.MinValue
                },
                {
                    "INF",
                    long.MaxValue
                }
            };
        }

        //
        // Сводка:
        //     Converts string to boolean
        //
        // Параметры:
        //   value:
        //
        // Возврат:
        //     true or false boolean value
        internal static bool ToBoolean(this string value)
        {
            if (_booleanLookup.ContainsKey(value))
            {
                return _booleanLookup[value];
            }

            value = value.TrimEnd();
            if (_booleanLookup.ContainsKey(value))
            {
                return _booleanLookup[value];
            }

            string text = value.TrimStringResponse();
            if (text != value && _booleanLookup.ContainsKey(text))
            {
                return _booleanLookup[text];
            }

            throw new ArgumentException("String value '" + value + "' cannot be converted to Boolean.");
        }

        //
        // Сводка:
        //     Returns special value as Double
        internal static bool SpecialValuesToDouble(string text, out double value)
        {
            text = text.Trim();
            if (_numbersPlusInfLookup.Contains(text))
            {
                value = double.PositiveInfinity;
                return true;
            }

            if (_numbersMinusInfLookup.Contains(text))
            {
                value = double.NegativeInfinity;
                return true;
            }

            if (_numbersNanLookup.Contains(text))
            {
                value = double.NaN;
                return true;
            }

            if (_numbersMaxLookup.Contains(text))
            {
                value = double.MaxValue;
                return true;
            }

            if (_numbersMinLookup.Contains(text))
            {
                value = double.MinValue;
                return true;
            }

            if (_specialDoubleExtStrValLookup.ContainsKey(text))
            {
                value = _specialDoubleExtStrValLookup[text];
                return true;
            }

            value = double.NaN;
            return false;
        }

        //
        // Сводка:
        //     Tries to find defined suffixes in the text and returns the stripped text and
        //     the multiplier as double number. If no known suffix is detected, the method returns
        //     false, strippedText=text, multiplier=1.0 Example: text='123 MHz' strippedText='123'
        //     multiplier=1E6
        internal static bool StripSpecialSuffixes(string text, out string strippedText, out double multiplier)
        {
            text = text.Trim();
            foreach (string key in _specialDoubleSiSuffixes.Keys)
            {
                if (text.EndsWith(key))
                {
                    strippedText = text.Substring(0, text.Length - key.Length).TrimEnd();
                    multiplier = _specialDoubleSiSuffixes[key];
                    return true;
                }
            }

            strippedText = text;
            multiplier = 1.0;
            return false;
        }

        //
        // Сводка:
        //     wrapper for double.tryParse() In .NET 4.8 the TryParse returns false for numbers
        //     that exceed the double range In .NET Core, the TryParse return true, and the
        //     value is Positive or Negative Infinity Unify the behaviour like in the .NET Core
        private static bool _tryParseToDouble(this string text, out double value)
        {
            if (double.TryParse(text, _numberStyle, Number, out value))
            {
                return true;
            }

            try
            {
                double.Parse(text, _numberStyle, Number);
            }
            catch (OverflowException)
            {
                value = (text.Trim().StartsWith("-") ? double.NegativeInfinity : double.PositiveInfinity);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }

            return false;
        }

        //
        // Сводка:
        //     Converts string to Double value. Also recognizes case-insensitive "NAN", "+Inf",
        //     "-Inf" If you provide defValue, any parsing exception is suppressed and the method
        //     returns that defValue
        //
        // Параметры:
        //   text:
        //     Text to convert
        //
        //   defValue:
        //     Default value. None if not entered
        internal static double ToDouble(this string text, double? defValue = null)
        {
            if (SpecialValuesToDouble(text, out var value))
            {
                return value;
            }

            if (text._tryParseToDouble(out value))
            {
                return value;
            }

            text = text.TrimStringResponse();
            if (text._tryParseToDouble(out value))
            {
                return value;
            }

            if (StripSpecialSuffixes(text, out var strippedText, out var multiplier) && strippedText._tryParseToDouble(out value))
            {
                return value * multiplier;
            }

            if (defValue.HasValue)
            {
                return defValue.Value;
            }

            throw new FormatException("The string '" + text + "' can not be converted to a double value");
        }

        //
        // Сводка:
        //     Converts the extended double to scpi string Works as the double.ToDoubleString(),
        //     but consideres special strings defined in the _specialDoubleExtValStrLookup For
        //     example, the string "OFF" is converted to the -double.Epsilon
        internal static string ToDoubleExtString(this double value)
        {
            if (_specialDoubleExtValStrLookup.ContainsKey(value))
            {
                return _specialDoubleExtValStrLookup[value];
            }

            return value.ToDoubleString();
        }

        //
        // Сводка:
        //     Converts string to single-float value. Also recognizes case-insensitive "NAN",
        //     "+Inf", "-Inf" If you provide defValue, any parsing exception is suppressed and
        //     the method returns that defValue
        //
        // Параметры:
        //   text:
        //     Text to convert
        //
        //   defValue:
        //     Default value. None if not entered
        internal static float ToSingleFloat(this string text, float? defValue = null)
        {
            return (float)text.ToDouble(defValue);
        }

        //
        // Сводка:
        //     Returns special value as Int32
        internal static bool SpecialValuesToInt32(string text, out int value)
        {
            text = text.Trim();
            if (_numbersPlusInfLookup.Contains(text))
            {
                value = int.MaxValue;
                return true;
            }

            if (_numbersMinusInfLookup.Contains(text))
            {
                value = int.MinValue;
                return true;
            }

            if (_numbersNanLookup.Contains(text))
            {
                value = int.MinValue;
                return true;
            }

            if (_numbersMaxLookup.Contains(text))
            {
                value = int.MaxValue;
                return true;
            }

            if (_numbersMinLookup.Contains(text))
            {
                value = int.MinValue;
                return true;
            }

            if (_specialIntExtStrValLookup.ContainsKey(text))
            {
                value = _specialIntExtStrValLookup[text];
                return true;
            }

            value = int.MinValue;
            return false;
        }

        //
        // Сводка:
        //     Converts string to Int32 value. Also recognizes special text values If you provide
        //     defValue, any parsing exception is suppressed and the method returns that defValue
        //
        // Параметры:
        //   text:
        //     Text to convert
        //
        //   defValue:
        //     Default value. None if not entered
        internal static int ToInt32(this string text, int? defValue = null)
        {
            if (SpecialValuesToInt32(text, out var value))
            {
                return value;
            }

            if (int.TryParse(text, _numberStyle, Number, out value))
            {
                return value;
            }

            text = text.TrimStringResponse();
            if (int.TryParse(text, _numberStyle, Number, out value))
            {
                return value;
            }

            if (text._tryParseToDouble(out var value2))
            {
                if (!(value2 > 2147483647.0))
                {
                    if (!(value2 < -2147483648.0))
                    {
                        return (int)value2;
                    }

                    return int.MinValue;
                }

                return int.MaxValue;
            }

            if (StripSpecialSuffixes(text, out var strippedText, out var multiplier) && strippedText._tryParseToDouble(out value2))
            {
                value2 *= multiplier;
                if (!(value2 > 2147483647.0))
                {
                    if (!(value2 < -2147483648.0))
                    {
                        return (int)value2;
                    }

                    return int.MinValue;
                }

                return int.MaxValue;
            }

            if (defValue.HasValue)
            {
                return defValue.Value;
            }

            throw new FormatException("The string '" + text + "' can not be converted to an Integer32 value");
        }

        //
        // Сводка:
        //     Converts the extended integer to scpi string Works as the int32.ToString(), but
        //     consideres special strings defined in the _specialIntExtValStrLookup For example,
        //     the string "OFF" is converted to the int.MinValue+1
        internal static string ToInt32ExtString(this int value)
        {
            if (_specialIntExtValStrLookup.ContainsKey(value))
            {
                return _specialIntExtValStrLookup[value];
            }

            return value.ToString();
        }

        //
        // Сводка:
        //     Returns special value as Int64
        internal static bool SpecialValuesToInt64(string text, out long value)
        {
            text = text.Trim();
            if (_numbersPlusInfLookup.Contains(text))
            {
                value = long.MaxValue;
                return true;
            }

            if (_numbersMinusInfLookup.Contains(text))
            {
                value = long.MinValue;
                return true;
            }

            if (_numbersNanLookup.Contains(text))
            {
                value = long.MinValue;
                return true;
            }

            if (_numbersMaxLookup.Contains(text))
            {
                value = long.MaxValue;
                return true;
            }

            if (_numbersMinLookup.Contains(text))
            {
                value = long.MinValue;
                return true;
            }

            if (_specialLongsLookup.ContainsKey(text))
            {
                value = _specialLongsLookup[text];
                return true;
            }

            value = long.MinValue;
            return false;
        }

        //
        // Сводка:
        //     Converts string to Int64 value. Also recognizes case-insensitive "NAN"(=Int64.MinValue),
        //     "+Inf"(=Int64.MaxValue), "-Inf"(=Int64.MinValue) If you provide defValue, any
        //     parsing exception is suppressed and the method returns that defValue
        //
        // Параметры:
        //   text:
        //     Text to convert
        //
        //   defValue:
        //     Default value. None if not entered
        internal static long ToInt64(this string text, long? defValue = null)
        {
            if (SpecialValuesToInt64(text, out var value))
            {
                return value;
            }

            if (long.TryParse(text, _numberStyle, Number, out value))
            {
                return value;
            }

            text = text.TrimStringResponse();
            if (long.TryParse(text, _numberStyle, Number, out value))
            {
                return value;
            }

            if (text._tryParseToDouble(out var value2))
            {
                if (!(value2 > 9.2233720368547758E+18))
                {
                    if (!(value2 < -9.2233720368547758E+18))
                    {
                        return (long)value2;
                    }

                    return long.MinValue;
                }

                return long.MaxValue;
            }

            if (StripSpecialSuffixes(text, out var strippedText, out var multiplier) && strippedText._tryParseToDouble(out value2))
            {
                value2 *= multiplier;
                if (!(value2 > 9.2233720368547758E+18))
                {
                    if (!(value2 < -9.2233720368547758E+18))
                    {
                        return (long)value2;
                    }

                    return long.MinValue;
                }

                return long.MaxValue;
            }

            if (defValue.HasValue)
            {
                return defValue.Value;
            }

            throw new FormatException("The string '" + text + "' can not be converted to an Integer64 value");
        }

        //
        // Сводка:
        //     Converts double number to string using {0:g} formatter
        internal static string ToDoubleString(this double number)
        {
            return number.ToString("g", Number);
        }

        //
        // Сводка:
        //     Converts float number to string using {0:g} formatter
        internal static string ToSingleFloatString(this float number)
        {
            return number.ToString("g", Number);
        }

        //
        // Сводка:
        //     Converts Boolean to string using ? "ON" : "OFF"
        //
        // Параметры:
        //   number:
        //     boolean to convert to string
        //
        // Возврат:
        //     Converted boolean as "ON" / "OFF" string
        internal static string ToBooleanString(this bool number)
        {
            if (!number)
            {
                return "OFF";
            }

            return "ON";
        }

        //
        // Сводка:
        //     Converts array of strings to string. Each element is assured to be enclosed by
        //     single quotes
        //
        // Возврат:
        //     Converted array of strings to string
        internal static string ToCsvQuotesString(this string[] strArray)
        {
            return string.Join(",", Array.ConvertAll(strArray, (string x) => "'" + x.TrimStringResponse() + "'"));
        }

        //
        // Сводка:
        //     Converts array of strings to string. Separed by the commas
        //
        // Возврат:
        //     Converted array of strings to string
        internal static string ToCsvString(this string[] strArray)
        {
            return string.Join(",", strArray);
        }

        //
        // Сводка:
        //     Converts array of integers to string
        //
        // Возврат:
        //     Converted array of integers to string
        internal static string ToCsvString(this int[] array)
        {
            return string.Join(",", Array.ConvertAll(array, (int x) => x.ToString()));
        }

        //
        // Сводка:
        //     Converts array of booleans to string
        //
        // Возврат:
        //     Converted array of booleans to string
        internal static string ToCsvString(this bool[] array)
        {
            return string.Join(",", Array.ConvertAll(array, (bool x) => x.ToBooleanString()));
        }

        //
        // Сводка:
        //     Converts array of doubles to string
        //
        // Возврат:
        //     Converted array of doubles to string
        internal static string ToCsvString(this double[] array)
        {
            return string.Join(",", Array.ConvertAll(array, (double x) => x.ToDoubleString()));
        }

        //
        // Сводка:
        //     Converts string with comma-separated values to array of Doubles If you provide
        //     defValue, any parsing exception is suppressed and the method returns that defValue
        //     Also recognizes case-insensitive "NAN", "+Inf", "-Inf" If the text is null or
        //     empty, the method returns array with 0-length
        //
        // Параметры:
        //   text:
        //     Text to convert
        //
        //   defValue:
        //     Default value. None if not entered
        internal static double[] ToDoubleArray(this string text, double? defValue = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new double[0];
            }

            string[] array = text.Split(',');
            double[] array2 = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = array[i].ToDouble(defValue);
            }

            return array2;
        }

        //
        // Сводка:
        //     Converts string with comma-separated values to array of Single Floats If you
        //     provide defValue, any parsing exception is suppressed and the method returns
        //     that defValue Also recognizes case-insensitive "NAN", "+Inf", "-Inf"
        //
        // Параметры:
        //   text:
        //     Text to convert
        //
        //   defValue:
        //     Default value. None if not entered
        internal static float[] ToSingleFloatArray(this string text, float? defValue = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new float[0];
            }

            string[] array = text.Split(',');
            float[] array2 = new float[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = array[i].ToSingleFloat(defValue);
            }

            return array2;
        }

        //
        // Сводка:
        //     Converts string with comma-separated values to array of int values. Also recognizes
        //     case-insensitive "NAN"(=Int32.MinValue), "+Inf"(=Int32.MaxValue), "-Inf"(=Int32.MinValue)
        //     If you provide defValue, any parsing exception is suppressed and the method returns
        //     that defValue. If the text is null or empty, the method returns array with 0-length
        //
        // Параметры:
        //   text:
        //     Text to convert
        //
        //   defValue:
        //     Default value. None if not entered
        internal static int[] ToInt32Array(this string text, int? defValue = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new int[0];
            }

            string[] array = text.Split(',');
            int[] array2 = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = array[i].ToInt32(defValue);
            }

            return array2;
        }

        //
        // Сводка:
        //     Converts string with comma-separated values to array of int64 values. Also recognizes
        //     case-insensitive "NAN"(=Int64.MinValue), "+Inf"(=Int64.MaxValue), "-Inf"(=Int64.MinValue)
        //     If you provide defValue, any parsing exception is suppressed and the method returns
        //     that defValue. If the text is null or empty, the method returns array with 0-length
        //
        // Параметры:
        //   text:
        //     Text to convert
        //
        //   defValue:
        //     Default value. None if not entered
        internal static long[] ToInt64Array(this string text, long? defValue = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new long[0];
            }

            string[] array = text.Split(',');
            long[] array2 = new long[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = array[i].ToInt64(defValue);
            }

            return array2;
        }

        //
        // Сводка:
        //     Converts string with comma-separated values to array of Booleans
        //
        // Параметры:
        //   text:
        //     Text to convert
        internal static bool[] ToBooleanArray(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new bool[0];
            }

            string[] array = text.Split(',');
            bool[] array2 = new bool[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = array[i].ToBoolean();
            }

            return array2;
        }

        //
        // Сводка:
        //     Converts string array segment to a list of Booleans
        //
        // Параметры:
        //   segment:
        internal static List<bool> ToBoolList(this ArraySegment<string> segment)
        {
            List<bool> list = new List<bool>(segment.Count);
            for (int i = segment.Offset; i < segment.Offset + segment.Count; i++)
            {
                list.Add(segment.Array[i].ToBoolean());
            }

            return list;
        }

        //
        // Сводка:
        //     Converts string array segment to a list of Integers
        //
        // Параметры:
        //   segment:
        internal static List<int> ToInt32List(this ArraySegment<string> segment)
        {
            List<int> list = new List<int>(segment.Count);
            for (int i = segment.Offset; i < segment.Offset + segment.Count; i++)
            {
                list.Add(segment.Array[i].ToInt32());
            }

            return list;
        }

        //
        // Сводка:
        //     Converts string array segment to a list of Strings - paired quotes are removed
        //
        // Параметры:
        //   segment:
        internal static List<string> ToStringList(this ArraySegment<string> segment)
        {
            List<string> list = new List<string>(segment.Count);
            for (int i = segment.Offset; i < segment.Offset + segment.Count; i++)
            {
                list.Add(segment.Array[i].TrimStringResponse());
            }

            return list;
        }

        //
        // Сводка:
        //     Returns an empty list if the input list contains only one item with an empty
        //     string. Otherwise returns the unchanged list.
        internal static List<string> ClearEmptySingleString(this List<string> value)
        {
            if (value.Count != 1)
            {
                return value;
            }

            if (!string.IsNullOrEmpty(value[0]))
            {
                return value;
            }

            return new List<string>();
        }

        //
        // Сводка:
        //     Returns entered text enclosed by single quotes
        internal static string EncloseByQuotes(this string text)
        {
            return "'" + text + "'";
        }

        //
        // Сводка:
        //     Returns entered list joined by comma. Each element is enclosed by single quotes
        internal static string ToCsvString(this List<string> value)
        {
            return string.Join(",", value.Select((string x) => x.EncloseByQuotes()));
        }

        //
        // Сводка:
        //     Returns entered array joined by comma. Each element is trimmed for paired quotes
        //     and trailing spaces
        internal static List<string> ToStringList(this string[] value)
        {
            return value.Select((string x) => x.TrimStringResponse()).ToList();
        }

        //
        // Сводка:
        //     Returns entered list joined by comma. No changes to the items
        internal static string ToCsvRawString(this List<string> value)
        {
            return string.Join(",", value);
        }

        //
        // Сводка:
        //     Returns entered list of integers joined by comma. No changes to the items
        internal static string ToCsvString(this List<int> value)
        {
            return string.Join(",", value);
        }

        //
        // Сводка:
        //     Returns entered list of integer64s joined by comma. No changes to the items
        internal static string ToCsvString(this List<long> value)
        {
            return string.Join(",", value);
        }

        //
        // Сводка:
        //     Returns entered list joined by comma. No changes to the items, consideres special
        //     integer values
        internal static string IntExtToCsvString(this List<int> value)
        {
            return string.Join(",", value.Select((int x) => x.ToInt32ExtString()));
        }

        //
        // Сводка:
        //     Returns entered bool list 0/1 joined by comma
        internal static string ToCsvString(this List<bool> value)
        {
            return string.Join(",", value.Select((bool x) => (!x) ? "1" : "0"));
        }

        //
        // Сводка:
        //     Returns entered double list joined by comma
        internal static string ToCsvString(this List<double> value)
        {
            return string.Join(",", value.Select((double x) => x.ToDoubleString()));
        }

        //
        // Сводка:
        //     Returns entered double list joined by comma, consideres special double values
        internal static string DoubleExtToCsvString(this List<double> value)
        {
            return string.Join(",", value.Select((double x) => x.ToDoubleExtString()));
        }

        //
        // Сводка:
        //     Converts string Pass/Fail to boolean True/False, case-insensitive.
        //
        // Параметры:
        //   value:
        //     Pass/Fail string
        //
        // Возврат:
        //     true for "Pass" / "Passed", false for "Fail" / "Failed"
        internal static bool PassFailToTrueFalse(this string value)
        {
            if (_passFailLookup.ContainsKey(value))
            {
                return _passFailLookup[value];
            }

            value = value.TrimEnd();
            if (_passFailLookup.ContainsKey(value))
            {
                return _passFailLookup[value];
            }

            string text = value.TrimStringResponse();
            if (text != value && _passFailLookup.ContainsKey(text))
            {
                return _passFailLookup[text];
            }

            throw new ArgumentException("String value '" + value + "' cannot be converted to Pass/Fail boolean.");
        }

        //
        // Сводка:
        //     Converts Binary data byte[] to 4 Bytes/Number array of Single Floats. The array
        //     is returned as float[] type
        //
        // Параметры:
        //   data:
        //     Input binary data to convert
        //
        //   swapEndianness:
        //     If false, keeps the endianness as it is. If true, swaps the endianness
        //
        // Возврат:
        //     Double array of float32 numbers
        internal static float[] ToSingleFloat32Array(this byte[] data, bool swapEndianness = false)
        {
            int num = data.Length / 4;
            float[] array = new float[num];
            if (!swapEndianness)
            {
                for (int i = 0; i < num; i++)
                {
                    array[i] = BitConverter.ToSingle(data, i * 4);
                }
            }
            else
            {
                byte[] array2 = new byte[4];
                for (int j = 0; j < num; j++)
                {
                    array2[0] = data[j * 4 + 3];
                    array2[1] = data[j * 4 + 2];
                    array2[2] = data[j * 4 + 1];
                    array2[3] = data[j * 4];
                    array[j] = BitConverter.ToSingle(array2, 0);
                }
            }

            return array;
        }

        //
        // Сводка:
        //     Converts Binary data byte[] to 4 Bytes/Number array of Doubles. The array is
        //     returned as double[] type
        //
        // Параметры:
        //   data:
        //     Input binary data to convert
        //
        //   swapEndianness:
        //     If false, keeps the endianness as it is. If true, swaps the endianness
        //
        // Возврат:
        //     Double array of float32 numbers
        internal static double[] ToFloat32Array(this byte[] data, bool swapEndianness = false)
        {
            int num = data.Length / 4;
            double[] array = new double[num];
            if (!swapEndianness)
            {
                for (int i = 0; i < num; i++)
                {
                    array[i] = BitConverter.ToSingle(data, i * 4);
                }
            }
            else
            {
                byte[] array2 = new byte[4];
                for (int j = 0; j < num; j++)
                {
                    array2[0] = data[j * 4 + 3];
                    array2[1] = data[j * 4 + 2];
                    array2[2] = data[j * 4 + 1];
                    array2[3] = data[j * 4];
                    array[j] = BitConverter.ToSingle(array2, 0);
                }
            }

            return array;
        }

        //
        // Сводка:
        //     Converts Binary data byte[] to 8 Bytes/Number array of Doubles. The array is
        //     returned as double[] type
        //
        // Параметры:
        //   data:
        //     Input binary data to convert
        //
        //   swapEndianness:
        //     If false, keeps the endianness as it is. If true, swaps the endianness
        //
        // Возврат:
        //     Double array of double64 numbers
        internal static double[] ToDouble64Array(this byte[] data, bool swapEndianness = false)
        {
            int num = data.Length / 8;
            double[] array = new double[num];
            if (!swapEndianness)
            {
                for (int i = 0; i < num; i++)
                {
                    array[i] = BitConverter.ToDouble(data, i * 8);
                }
            }
            else
            {
                byte[] array2 = new byte[8];
                for (int j = 0; j < num; j++)
                {
                    array2[0] = data[j * 8 + 7];
                    array2[1] = data[j * 8 + 6];
                    array2[2] = data[j * 8 + 5];
                    array2[3] = data[j * 8 + 4];
                    array2[4] = data[j * 8 + 3];
                    array2[5] = data[j * 8 + 2];
                    array2[6] = data[j * 8 + 1];
                    array2[7] = data[j * 8];
                    array[j] = BitConverter.ToDouble(array2, 0);
                }
            }

            return array;
        }

        //
        // Сводка:
        //     Converts Binary data byte[] to 4 Bytes/Number array of Integers. The array is
        //     returned as int32[] type
        //
        // Параметры:
        //   data:
        //     Input binary data to convert
        //
        //   swapEndianness:
        //     If false, keeps the endianness as it is. If true, swaps the endianness
        //
        // Возврат:
        //     Integer array of int32 numbers
        internal static int[] ToInt32Array(this byte[] data, bool swapEndianness = false)
        {
            int num = data.Length / 4;
            int[] array = new int[num];
            if (!swapEndianness)
            {
                for (int i = 0; i < num; i++)
                {
                    array[i] = BitConverter.ToInt32(data, i * 4);
                }
            }
            else
            {
                byte[] array2 = new byte[4];
                for (int j = 0; j < num; j++)
                {
                    array2[0] = data[j * 4 + 3];
                    array2[1] = data[j * 4 + 2];
                    array2[2] = data[j * 4 + 1];
                    array2[3] = data[j * 4];
                    array[j] = BitConverter.ToInt32(array2, 0);
                }
            }

            return array;
        }

        //
        // Сводка:
        //     Converts Binary data byte[] to 2 Bytes/Number array of Integers. The array is
        //     returned as int32[] type
        //
        // Параметры:
        //   data:
        //     Input binary data to convert
        //
        //   swapEndianness:
        //     If false, keeps the endianness as it is. If true, swaps the endianness
        //
        // Возврат:
        //     Integer array of int16 numbers
        internal static int[] ToInt16Array(this byte[] data, bool swapEndianness = false)
        {
            int num = data.Length / 2;
            int[] array = new int[num];
            if (!swapEndianness)
            {
                for (int i = 0; i < num; i++)
                {
                    array[i] = BitConverter.ToInt16(data, i * 2);
                }
            }
            else
            {
                byte[] array2 = new byte[2];
                for (int j = 0; j < num; j++)
                {
                    array2[0] = data[j * 2 + 1];
                    array2[1] = data[j * 2];
                    array[j] = BitConverter.ToInt16(array2, 0);
                }
            }

            return array;
        }

        //
        // Сводка:
        //     Decodes binary data to an array of floating-point numbers based on the entered
        //     format
        internal static double[] ToArrayOfFloatNumbers(this byte[] data, InstrBinaryFloatNumbersFormat binaryFloatNumbersFormat)
        {
            return binaryFloatNumbersFormat switch
            {
                InstrBinaryFloatNumbersFormat.Single4Bytes => data.ToFloat32Array(),
                InstrBinaryFloatNumbersFormat.Single4BytesSwapped => data.ToFloat32Array(swapEndianness: true),
                InstrBinaryFloatNumbersFormat.Double8Bytes => data.ToDouble64Array(),
                InstrBinaryFloatNumbersFormat.Double8BytesSwapped => data.ToDouble64Array(swapEndianness: true),
                _ => data.ToFloat32Array(),
            };
        }

        //
        // Сводка:
        //     Converts to double float array from the byte[] array either as binary or as ascii
        //     data
        internal static double[] ToArrayOfFloatNumbers(this byte[] data, bool binData, InstrBinaryFloatNumbersFormat binaryFloatNumbersFormat)
        {
            if (binData)
            {
                return data.ToArrayOfFloatNumbers(binaryFloatNumbersFormat);
            }

            return Encoding.ASCII.GetString(data).TrimEnd().ToDoubleArray();
        }

        //
        // Сводка:
        //     Decodes binary data to an array of floating-point numbers single precision based
        //     on the entered format. The formats Double8Bytes and Double8BytesSwapped are not
        //     allowed
        internal static float[] ToArrayOfSingleFloatNumbers(this byte[] data, InstrBinaryFloatNumbersFormat binaryFloatNumbersFormat)
        {
            return binaryFloatNumbersFormat switch
            {
                InstrBinaryFloatNumbersFormat.Single4Bytes => data.ToSingleFloat32Array(),
                InstrBinaryFloatNumbersFormat.Single4BytesSwapped => data.ToSingleFloat32Array(swapEndianness: true),
                _ => throw new ArgumentException($"ToArrayOfSingleFloatNumbers - Unsupported data format {binaryFloatNumbersFormat}"),
            };
        }

        //
        // Сводка:
        //     Converts to single float array from the byte[] array either as binary or as ascii
        //     data
        internal static float[] ToArrayOfSingleFloatNumbers(this byte[] data, bool binData, InstrBinaryFloatNumbersFormat binaryFloatNumbersFormat)
        {
            if (binData)
            {
                return data.ToArrayOfSingleFloatNumbers(binaryFloatNumbersFormat);
            }

            return Encoding.ASCII.GetString(data).TrimEnd().ToSingleFloatArray();
        }

        //
        // Сводка:
        //     Decodes binary data to an array of integer numbers based on the entered format
        //
        // Параметры:
        //   data:
        //     Binary data
        //
        //   binaryIntegerNumbersFormat:
        //     Format in which the data is to be parsed
        //
        // Возврат:
        //     Array of decoded integer numbers always returned as int32
        internal static int[] ToArrayOfIntegerNumbers(this byte[] data, InstrBinaryIntegerNumbersFormat binaryIntegerNumbersFormat)
        {
            return binaryIntegerNumbersFormat switch
            {
                InstrBinaryIntegerNumbersFormat.Integer324Bytes => data.ToInt32Array(),
                InstrBinaryIntegerNumbersFormat.Integer324BytesSwapped => data.ToInt32Array(swapEndianness: true),
                InstrBinaryIntegerNumbersFormat.Integer162Bytes => data.ToInt16Array(),
                InstrBinaryIntegerNumbersFormat.Integer162BytesSwapped => data.ToInt16Array(swapEndianness: true),
                _ => data.ToInt32Array(),
            };
        }

        //
        // Сводка:
        //     Converts to int32 array from the byte[] array either as binary or as ascii data
        internal static int[] ToArrayOfIntegerNumbers(this byte[] data, bool binData, InstrBinaryIntegerNumbersFormat binaryIntegerNumbersFormat)
        {
            if (binData)
            {
                return data.ToArrayOfIntegerNumbers(binaryIntegerNumbersFormat);
            }

            return Encoding.ASCII.GetString(data).TrimEnd().ToInt32Array();
        }
    }
}
