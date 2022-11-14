using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class ScpiEnums
    {
        internal readonly bool HasCustomValues;

        //
        // Сводка:
        //     If true, the custom values contain quotes
        internal readonly bool HasQuotes;

        //
        // Сводка:
        //     Type information
        internal readonly TypeInfo EnumTypeInfo;

        //
        // Сводка:
        //     Contains all the member strings. If the member has a DescriptionAttribute, the
        //     description attribute is returned.
        internal readonly string[] Members;

        //
        // Сводка:
        //     Exact members of the enum
        private readonly string[] _membersRaw;

        //
        // Сводка:
        //     _Members that are resolved by the special values. This is a lazy property to
        //     save time. It is initialized by the method ResolveSpecialValues()
        private string[] _membersSpec;

        private Dictionary<string, string> _customValues;

        internal ScpiEnums(Type enumType)
        {
            HasCustomValues = GetHasCustomValues(enumType);
            HasQuotes = false;
            EnumTypeInfo = enumType.GetTypeInfo();
            _membersRaw = Enum.GetNames(enumType);
            if (!HasCustomValues)
            {
                Members = _membersRaw;
                return;
            }

            Members = new string[_membersRaw.Length];
            _customValues = new Dictionary<string, string>();
            for (int i = 0; i < _membersRaw.Length; i++)
            {
                DescriptionAttribute descriptionAttribute = EnumTypeInfo.GetMember(_membersRaw[i])[0].GetCustomAttribute(typeof(DescriptionAttribute), inherit: false) as DescriptionAttribute;
                Members[i] = ((descriptionAttribute == null) ? _membersRaw[i] : descriptionAttribute.Description);
                _customValues[_membersRaw[i]] = Members[i];
                if (!HasQuotes)
                {
                    HasQuotes = Members[i].Contains("'");
                }
            }
        }

        public override string ToString()
        {
            if (HasCustomValues)
            {
                return $"Enum with custom values {Members.Length} items.";
            }

            return $"Enum {Members.Length} items.";
        }

        //
        // Сводка:
        //     Returns true, if the entered enum has custom values
        internal static bool GetHasCustomValues(Type enumType)
        {
            return enumType.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false).Length != 0;
        }

        //
        // Сводка:
        //     Returns the SCPI value of the item. If the item has no DescriptionAttribute,
        //     the method returns the standart item value converted to string. If the Description
        //     attribute exists, the method returns the string value of the DescriptionAttribute.
        internal string GetScpiValue(string enumValue)
        {
            if (!HasCustomValues)
            {
                return enumValue;
            }

            return _customValues[enumValue];
        }

        //
        // Сводка:
        //     Returns the SCPI value of the item. If the item has no DescriptionAttribute,
        //     the method returns the standart item value converted to string. If the Description
        //     attribute exists, the method returns the string value of the DescriptionAttribute.
        internal string GetScpiValue(object enumValue)
        {
            return GetScpiValue(enumValue.ToString());
        }

        //
        // Сводка:
        //     Returns either an EnumMember item or null if not found. The matching is done
        //     against the Members, and if unsuccessful, then against the _membersSpec The response
        //     is always a member_raw item.
        internal string FindInEnumMembersAsString(bool forceCommaRemove, string item)
        {
            int num = _FindIxInMembers(Members, forceCommaRemove, item);
            if (num >= 0)
            {
                return _membersRaw[num];
            }

            _InitSpecialValues();
            num = _FindIxInMembers(_membersSpec, forceCommaRemove, item);
            if (num >= 0)
            {
                return _membersRaw[num];
            }

            return null;
        }

        //
        // Сводка:
        //     Returns the enum value as object
        internal object FindInEnumMembersAsObj(bool forceCommaRemove, string item)
        {
            string text = FindInEnumMembersAsString(forceCommaRemove, item);
            if (text == null)
            {
                return null;
            }

            return Enum.Parse(EnumTypeInfo, text);
        }

        //
        // Сводка:
        //     Searches the 'item' in the list of 'members': - First as prefixes cs: item =
        //     'MAX' matches members[x] = 'MAXpeak' - Then as short form by removing all the
        //     LC character a-z: item = 'SPECtrum1' matches members[x] = 'SPEC1' If the item
        //     contains a comma, the function checks if there is a comma defined in the enum_members.
        //     - If no, the comma and all after it is removed. - If yes, the comma is kept.
        //     You can override the behaviour by forcing the removal of the comma Returns found
        //     index in the enum_members list.
        private int _FindIxInMembers(string[] members, bool forceCommaRemove, string item)
        {
            if (item.Contains(','))
            {
                bool flag = true;
                if (!forceCommaRemove)
                {
                    foreach (string text in members)
                    {
                        if (text.Contains(",") || text.Contains("_cma_"))
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                if (flag)
                {
                    item = item.Substring(0, item.IndexOf(',')).Trim();
                }
            }

            for (int j = 0; j < members.Length; j++)
            {
                if (members[j].StartsWith(item, StringComparison.CurrentCultureIgnoreCase))
                {
                    return j;
                }
            }

            Regex regex = new Regex("[a-z]+");
            item = regex.Replace(item, "").TrimStringResponse();
            for (int k = 0; k < members.Length; k++)
            {
                if (members[k].Any(new Func<char, bool>(char.IsLower)))
                {
                    string text2 = regex.Replace(members[k], "");
                    if (item == text2)
                    {
                        return k;
                    }
                }
                else if (item == members[k])
                {
                    return k;
                }
            }

            return -1;
        }

        //
        // Сводка:
        //     Convert the members to the SCPI values - values to be sent to the instrument
        //     Resolves escapes: '^_' => '' '^_minus' => '-' '_dash_' => '-' '_dot_' => '.'
        //     '_cma_' => ',' This method is used in convertors: ToScpiEnumList => converts
        //     response from the instrument to a List of enums members ScpiStringToEnumString
        //     => converts response from the instrument to an existing enum member as string
        private void _InitSpecialValues()
        {
            if (_membersSpec != null)
            {
                return;
            }

            _membersSpec = new string[Members.Length];
            Members.CopyTo(_membersSpec, 0);
            for (int i = 0; i < _membersSpec.Length; i++)
            {
                foreach (KeyValuePair<string, string> enumSpecialPrefix in EnumConversions.EnumSpecialPrefixes)
                {
                    if (_membersSpec[i].StartsWith(enumSpecialPrefix.Key))
                    {
                        _membersSpec[i] = enumSpecialPrefix.Value + _membersSpec[i].Substring(enumSpecialPrefix.Key.Length);
                    }
                }

                foreach (KeyValuePair<string, string> enumSpecialString in EnumConversions.EnumSpecialStrings)
                {
                    _membersSpec[i] = _membersSpec[i].Replace(enumSpecialString.Key, enumSpecialString.Value);
                }
            }
        }
    }
}
