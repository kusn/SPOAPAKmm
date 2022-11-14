using System;

namespace RSSigGen.InstrumentDrivers.Internal
{
    public interface IArgConvertible
    {
        DataType Type { get; }

        string Name { get; }

        object Value { get; set; }

        Type EnumType { get; }

        bool HasValue { get; }
    }
}
