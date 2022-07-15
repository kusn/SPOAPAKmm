namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class ArgSuppressed
    {
        internal DataType Type { get; }

        internal bool IsOpenList { get; }

        internal int Repetition { get; }

        internal int ArgumentIndex { get; }

        internal string InternalLinking { get; }

        internal ArgSuppressed(int argumentIndex, DataType type)
        {
            ArgumentIndex = argumentIndex;
            Type = type;
            IsOpenList = false;
            Repetition = 1;
        }

        internal ArgSuppressed(int argumentIndex, DataType type, bool isOpenList, int repetition)
        {
            ArgumentIndex = argumentIndex;
            Type = type;
            IsOpenList = isOpenList;
            Repetition = repetition;
        }

        internal ArgSuppressed(int argumentIndex, DataType type, bool isOpenList, int repetition, string internalLinking)
        {
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
            if (InternalLinking != null)
            {
                text = text + ", Linking: '" + InternalLinking + "'";
            }

            return text;
        }
    }
}
