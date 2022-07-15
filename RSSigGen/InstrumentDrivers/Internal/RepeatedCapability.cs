using System;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class RepeatedCapability
    {
        //
        // Сводка:
        //     RepCap value as enum value. Settable and gettable via methods
        private object _enumValue;

        private readonly object _startValue;

        //
        // Сводка:
        //     Name of the RepCap - corresponds to the Enum Type short name
        internal string Name { get; }

        //
        // Сводка:
        //     Name of the header - corresponds to the Commands Group name
        internal string HeaderName { get; }

        //
        // Сводка:
        //     Name of the Group Property setting the value
        internal string PropertyName { get; }

        //
        // Сводка:
        //     Type of the RepCap enum. e.g. "InstanceRepCap"
        internal Type EnumType { get; }

        //
        // Сводка:
        //     Static function to get an integer interpretation of a direct enum value Does
        //     not work with Empty or Default
        private static int _GetDirectCmdValueInt(object repcapEnumValue)
        {
            return (int)repcapEnumValue;
        }

        //
        // Сводка:
        //     Converts RepCap integer value to string ValueEmpty is converted to "" ValueDefault
        //     throws an exception 0 is converted to "". If the enum contains the value null,
        //     then 0 is converted to "0" Positive numbers are converted to integer strings
        //     e.g. 1 => "1"
        internal static string GetCmdStringValue(object enumValue)
        {
            switch (_GetDirectCmdValueInt(enumValue))
            {
                case -2:
                    return "";
                case 0:
                    if (enumValue.ToString()!.EndsWith("0"))
                    {
                        return "0";
                    }

                    return "";
                case -1:
                    throw new InvalidOperationException($"RepCap enum value Default can not be converted to the command string value. RepCap: {enumValue}");
                default:
                    return _GetDirectCmdValueInt(enumValue).ToString();
            }
        }

        //
        // Сводка:
        //     Returns true, if the entered value is enum.Default
        internal static bool IsDefaultValue(object repcapEnumValue)
        {
            return _GetDirectCmdValueInt(repcapEnumValue) == -1;
        }

        //
        // Сводка:
        //     Converts RepCap integer value to string ValueEmpty is converted to "" ValueDefault
        //     is converted to null - invalid 0 is converted to "0". Positive numbers are converted
        //     to integer strings e.g. 1 => "1", 2 => "2" and so on...
        internal string GetCmdStringValue()
        {
            return GetCmdStringValue(_enumValue);
        }

        //
        // Сводка:
        //     Returns true, if the current value is enum.Default
        internal bool IsDefaultValue()
        {
            return IsDefaultValue(_enumValue);
        }

        //
        // Сводка:
        //     Constructor with enum type, header name and the start value
        internal RepeatedCapability(Type enumType, string headerName, string propertyName, object startValue)
        {
            EnumType = enumType;
            HeaderName = headerName;
            Name = EnumType.Name;
            _startValue = startValue;
            PropertyName = propertyName;
            SetToStartValue();
        }

        //
        // Сводка:
        //     String representation of the RepCap
        public override string ToString()
        {
            string text = "RepCap " + Name;
            if (_enumValue != null)
            {
                text += $" = {_enumValue}";
            }

            return text;
        }

        //
        // Сводка:
        //     Sets new enum value Can not be Default
        internal void SetEnumValue(object enumValue)
        {
            if (IsDefaultValue(enumValue))
            {
                throw new ArgumentException($"Setting Repeated Capability Default Enum value is not allowed. Enum {enumValue}");
            }

            _enumValue = enumValue;
        }

        //
        // Сводка:
        //     Sets back to the value entered in the constructor
        internal void SetToStartValue()
        {
            SetEnumValue(_startValue);
        }

        //
        // Сводка:
        //     Returns current enum value
        internal object GetEnumValue()
        {
            return _enumValue;
        }

        //
        // Сводка:
        //     Returns true, if the entered type matches the EnumType
        internal bool MatchesType(Type rcType)
        {
            return EnumType == rcType;
        }
    }
}
