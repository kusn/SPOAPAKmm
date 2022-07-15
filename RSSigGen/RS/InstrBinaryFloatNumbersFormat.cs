namespace RSSigGen.RS
{
    public enum InstrBinaryFloatNumbersFormat
    {
        //
        // Сводка:
        //     4 bytes/number (FORMAT REAL,32)
        Single4Bytes = 1,
        //
        // Сводка:
        //     4 bytes/number (FORMAT REAL,32) swapped endianness
        Single4BytesSwapped,
        //
        // Сводка:
        //     8 bytes/number (FORMAT REAL,64 or FORMAT REAL)
        Double8Bytes,
        //
        // Сводка:
        //     8 bytes/number (FORMAT REAL,64 or FORMAT REAL) swapped endianess
        Double8BytesSwapped
    }
}
