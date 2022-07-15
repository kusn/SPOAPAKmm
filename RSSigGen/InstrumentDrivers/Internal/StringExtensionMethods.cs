using System;
using System.Collections.Generic;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal static class StringExtensionMethods
    {
        internal enum TrimStringMode
        {
            WhiteCharsAllQuotes,
            WhiteCharsSingleQuotes,
            WhiteCharsDoubleQuotes,
            WhiteCharsOnly
        }

        //
        // Сводка:
        //     Trims instrument string response. In modes WhiteCharsAllQuotes,WhiteCharsSingleQuotes,WhiteCharsDoubleQuotes:
        //     All the symmetrical leading and trailing quotation marks are trimmed, but only
        //     if there are none in the remaining text.
        //
        // Параметры:
        //   text:
        //     Text to trim
        //
        //   mode:
        //     Trimming mode
        internal static string TrimStringResponse(this string text, TrimStringMode mode = TrimStringMode.WhiteCharsAllQuotes)
        {
            int num = -1;
            int num2 = -1;
            bool flag = mode == TrimStringMode.WhiteCharsAllQuotes || mode == TrimStringMode.WhiteCharsSingleQuotes;
            bool flag2 = mode == TrimStringMode.WhiteCharsAllQuotes || mode == TrimStringMode.WhiteCharsDoubleQuotes;
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            text = text.Trim();
            if (flag && text == "''")
            {
                return "";
            }

            if (flag2 && text == "\"\"")
            {
                return "";
            }

            int num3 = 0;
            int num4 = text.Length - 1;
            if (num4 - 2 < num3)
            {
                return text;
            }

            if (mode != TrimStringMode.WhiteCharsOnly)
            {
                bool flag3;
                do
                {
                    flag3 = false;
                    if (flag && text[num3] == '\'' && text[num4] == '\'')
                    {
                        if (num < 0)
                        {
                            num = num3;
                        }

                        num3++;
                        num4--;
                        flag3 = true;
                    }

                    if (num4 - 2 < num3)
                    {
                        break;
                    }

                    if (flag2 && text[num3] == '"' && text[num4] == '"')
                    {
                        if (num2 < 0)
                        {
                            num2 = num3;
                        }

                        num3++;
                        num4--;
                        flag3 = true;
                    }
                }
                while (num4 - 2 >= num3 && flag3);
                if (num3 == 0)
                {
                    return text;
                }

                int num5 = num3;
                string text2 = text.Substring(num3, text.Length - 2 * num3);
                if (num >= 0 && text2.IndexOf('\'') >= 0)
                {
                    num5 = num;
                }

                if (num2 >= 0 && text2.IndexOf('"') >= 0)
                {
                    num5 = ((num5 < num2) ? num5 : num2);
                }

                text = text.Substring(num5, text.Length - 2 * num5);
            }

            return text;
        }

        //
        // Сводка:
        //     Parses a string in a form "keyName = keyValue" Returns 1, if no '=' is found.
        //     Returns 2, if one or more '=' is found, the string is split on the first '='
        //     returns 0, if the string is empty
        //
        // Параметры:
        //   text:
        //     Text to parse
        //
        //   keyName:
        //     Returned Key Name
        //
        //   keyValue:
        //     Returned Key Value
        internal static int ParseNameValueToken(this string text, out string keyName, out string keyValue)
        {
            string[] array = text.Split(new char[1] { '=' }, 2);
            if (array.Length == 1)
            {
                keyName = array[0].Trim();
                keyValue = "";
                return 1;
            }

            if (array.Length >= 2)
            {
                keyName = array[0].Trim();
                keyValue = array[1].TrimStringResponse();
                return array.Length;
            }

            keyName = "";
            keyValue = "";
            return array.Length;
        }

        //
        // Сводка:
        //     Adds/Replaces token to dictionary: key = value
        internal static void AddToken(this Dictionary<string, string> dict, string token)
        {
            if (token.ParseNameValueToken(out var keyName, out var keyValue) != 2)
            {
                throw new ArgumentException("Token '" + token + "' is in a wrong format. Supported format: 'key = value'");
            }

            dict[keyName] = keyValue;
        }

        //
        // Сводка:
        //     The fastest way to check whether a string ends with a certain character
        internal static bool EndsWithTc(this string text, char termChar)
        {
            if (text.Length > 0)
            {
                return text[text.Length - 1] == termChar;
            }

            return false;
        }

        //
        // Сводка:
        //     The fastest way to check whether a string contains Question-mark
        //
        // Параметры:
        //   text:
        internal static bool ContainsQuestionMark(this string text)
        {
            return text.IndexOf('?') > 0;
        }
    }
}
