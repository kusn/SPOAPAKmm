using System;
using System.Collections.Generic;
using System.Linq;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal static class EnumConversions
    {
        internal static readonly Dictionary<string, string> EnumSpecialPrefixes;

        internal static readonly Dictionary<string, string> EnumSpecialStrings;

        static EnumConversions()
        {
            EnumSpecialPrefixes = new Dictionary<string, string>
            {
                ["_minus"] = "-",
                ["_plus"] = "+",
                ["_"] = ""
            };
            EnumSpecialStrings = new Dictionary<string, string>
            {
                ["_dash_"] = "-",
                ["_dot_"] = ".",
                ["_cma_"] = ","
            };
        }

        //
        // Сводка:
        //     Conversion ENUM -> SCPIsend. Converts enum value (as object) to a SCPI string.
        //     Use this to send the scpi enum value to the instrument. Throws an exception if
        //     the enum value is not defined in the enum type.
        internal static string EnumValueToScpiString(this Type enumType, object enumVal)
        {
            if (!Enum.IsDefined(enumType, enumVal))
            {
                throw new ArgumentException($"Converting single enum value to string error. Current value '{enumVal}' is not found in the enum type '{enumType}' definition.");
            }

            string text = enumVal.ToString();
            if (ScpiEnums.GetHasCustomValues(enumType))
            {
                text = new ScpiEnums(enumType).GetScpiValue(text);
            }

            foreach (KeyValuePair<string, string> enumSpecialPrefix in EnumSpecialPrefixes)
            {
                if (text.StartsWith(enumSpecialPrefix.Key))
                {
                    text = enumSpecialPrefix.Value + text.Substring(enumSpecialPrefix.Key.Length);
                }
            }

            foreach (KeyValuePair<string, string> enumSpecialString in EnumSpecialStrings)
            {
                text = text.Replace(enumSpecialString.Key, enumSpecialString.Value);
            }

            return text;
        }

        //
        // Сводка:
        //     Conversion ENUM -> SCPIsend. Wrapper for EnumValueToScpiString used for simple
        //     conversion of enum value to SCPI string
        internal static string ToScpiString<T>(this T enumVal) where T : Enum
        {
            return typeof(T).EnumValueToScpiString(enumVal);
        }

        //
        // Сводка:
        //     Conversion ENUM[] -> SCPIsend[]. Wrapper for EnumValueToScpiString used for conversion
        //     of List{enum} value to SCPI CSV-string
        internal static string ToScpiCsvString<T>(this List<T> value) where T : Enum
        {
            Type t = typeof(T);
            return string.Join(",", value.Select((T x) => t.EnumValueToScpiString(x)));
        }

        //
        // Сводка:
        //     Conversion SCPIresponse -> ENUMvalue. Converts text to enum value. Special enum
        //     values, prefixes, and special integer string value same as the ToInt32() convertor
        internal static T ToScpiEnum<T>(this string scpiText) where T : Enum
        {
            string text = scpiText.ScpiStringToEnumString(typeof(T));
            if (text != null)
            {
                return (T)Enum.Parse(typeof(T), text);
            }

            if (!RsDrvFormat.SpecialValuesToInt32(scpiText, out var value))
            {
                throw new ArgumentException($"String '{scpiText}' can not be converted to an enum {typeof(T)} element");
            }

            return (T)Enum.ToObject(typeof(T), value);
        }

        //
        // Сводка:
        //     Conversion SCPIresponse[] -> ENUMvalue[]. Converts csv-text (instrument-returned
        //     string) to List[enum]. To optimize the performance, it does the members and potentiall
        //     membersSpec parsing only once for the entire array of conversions.
        internal static List<T> ToScpiEnumList<T>(this string scpiCsvResponse)
        {
            ScpiEnums scpiEnums = new ScpiEnums(typeof(T));
            List<T> list = new List<T>();
            string[] array = scpiCsvResponse.Split(',');
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i].TrimStringResponse(scpiEnums.HasQuotes ? StringExtensionMethods.TrimStringMode.WhiteCharsDoubleQuotes : StringExtensionMethods.TrimStringMode.WhiteCharsAllQuotes);
                object obj = scpiEnums.FindInEnumMembersAsObj(forceCommaRemove: true, text);
                if (obj != null)
                {
                    list.Add((T)obj);
                    continue;
                }

                if (!RsDrvFormat.SpecialValuesToInt32(text, out var value))
                {
                    throw new ArgumentException($"String '{text}' can not be converted to an enum {typeof(T)} element");
                }

                list.Add((T)Enum.ToObject(typeof(T), value));
            }

            return list;
        }

        //
        // Сводка:
        //     Conversion SCPIresonse -> ENUMstringValue. Returns string value of the provided
        //     enumType member. If the value is not found, the function returns null. If this
        //     function returns a non-null string, you can safely convert it to the enumType
        //     enum
        internal static string ScpiStringToEnumString(this string text, Type enumType)
        {
            ScpiEnums scpiEnums = new ScpiEnums(enumType);
            text = text.TrimStringResponse(scpiEnums.HasQuotes ? StringExtensionMethods.TrimStringMode.WhiteCharsDoubleQuotes : StringExtensionMethods.TrimStringMode.WhiteCharsAllQuotes);
            string text2 = scpiEnums.FindInEnumMembersAsString(forceCommaRemove: false, text);
            if (text2 != null)
            {
                return text2;
            }

            return scpiEnums.FindInEnumMembersAsString(forceCommaRemove: true, text);
        }
    }
}
