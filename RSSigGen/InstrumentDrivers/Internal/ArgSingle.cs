using System;
using System.Data;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class ArgSingle : IArgConvertible
    {
        internal bool IsOpenList { get; }

        internal int Repetition { get; }

        internal int ArgumentIndex { get; }

        internal string InternalLinking { get; }

        public string Name => "";

        public DataType Type { get; }

        public object Value { get; set; }

        public Type EnumType
        {
            get
            {
                if (Type == DataType.Enum)
                {
                    return Value.GetType();
                }

                if (Type == DataType.EnumArray)
                {
                    return Value.GetType().GetGenericArguments()[0];
                }

                throw new DataException("Argument data type is not enum or enum list. Data type: " + Type);
            }
        }

        public bool HasValue => true;

        internal ArgSingle(object arg, int argumentIndex, DataType type)
            : this(arg, argumentIndex, type, isOpenList: false, 1, null)
        {
        }

        internal ArgSingle(object arg, int argumentIndex, DataType type, bool isOpenList, int repetition)
            : this(arg, argumentIndex, type, isOpenList, repetition, null)
        {
        }

        internal ArgSingle(object arg, int argumentIndex, DataType type, bool isOpenList, int repetition, string internalLinking)
        {
            Value = arg;
            ArgumentIndex = argumentIndex;
            Type = type;
            IsOpenList = isOpenList;
            Repetition = repetition;
            InternalLinking = internalLinking;
        }

        public override string ToString()
        {
            string text = "";
            text = ((!IsOpenList && Repetition > 1) ? (text + $"Arg {Type} [{Repetition}]") : ((!IsOpenList) ? (text + $"Arg {Type}") : (text + $"Arg {Type} [{Repetition}...]")));
            text = ((Value == null) ? (text + ", <no value>") : (text + $" {Value}"));
            if (InternalLinking != null)
            {
                text = text + ", Linking: '" + InternalLinking + "'";
            }

            return text;
        }
    }
}
