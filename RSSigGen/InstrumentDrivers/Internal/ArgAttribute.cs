using System;
using System.Data;
using System.Reflection;

namespace RSSigGen.InstrumentDrivers.Internal
{
    public class ArgAttribute : Attribute, IArgConvertible
    {
        internal object Parent { get; set; }

        internal int ArgumentIndex { get; }

        internal bool Optional { get; }

        internal bool IsOpenList { get; }

        internal int Repetition { get; }

        internal string InternalLinking { get; }

        internal PropertyInfo Property { get; set; }

        public Type EnumType
        {
            get
            {
                if (Type == DataType.Enum)
                {
                    return Property.PropertyType;
                }

                if (Type == DataType.EnumArray)
                {
                    return Property.PropertyType.GetGenericArguments()[0];
                }

                throw new DataException("Argument data type is not enum or enum list. Data type: " + Type);
            }
        }

        public string Name => Property.Name;

        public DataType Type { get; }

        public object Value
        {
            get
            {
                return Property.GetValue(Parent, null);
            }
            set
            {
                Property.SetValue(Parent, value, null);
            }
        }

        //
        // Сводка:
        //     Non-optional arguments always have value
        public bool HasValue
        {
            get
            {
                if (!Optional)
                {
                    return true;
                }

                DataType type = Type;
                if ((uint)(type - 2) <= 6u)
                {
                    try
                    {
                        Property.GetValue(Parent, null);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

                return Property.GetValue(Parent, null) != null;
            }
        }

        internal ArgAttribute(int argumentIndex, DataType type)
            : this(argumentIndex, type, optional: false, isOpenList: false, 1, null)
        {
        }

        internal ArgAttribute(int argumentIndex, DataType type, bool optional)
            : this(argumentIndex, type, optional, isOpenList: false, 1, null)
        {
        }

        internal ArgAttribute(int argumentIndex, DataType type, bool optional, bool isOpenList, int repetition)
            : this(argumentIndex, type, optional, isOpenList, repetition, null)
        {
        }

        internal ArgAttribute(int argumentIndex, DataType type, bool optional, bool isOpenList, int repetition, string internalLinking)
        {
            ArgumentIndex = argumentIndex;
            Type = type;
            Optional = optional;
            IsOpenList = isOpenList;
            Repetition = repetition;
            InternalLinking = internalLinking;
        }

        public override string ToString()
        {
            string text = "ArgAttr '" + Property.Name + "'";
            text = ((!IsOpenList && Repetition > 1) ? (text + $" {Type} [{Repetition}]") : ((!IsOpenList) ? (text + $" {Type}") : (text + $" {Type} [{Repetition}...]")));
            if (InternalLinking != null)
            {
                text = text + ", Linking: '" + InternalLinking + "'";
            }

            return text;
        }
    }
}
