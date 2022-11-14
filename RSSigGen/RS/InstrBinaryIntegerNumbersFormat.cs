namespace RSSigGen.RS
{
    public enum InstrBinaryIntegerNumbersFormat
    {
        //
        // Сводка:
        //     4 bytes/number (FORMAT INT,32)
        Integer324Bytes = 1,
        //
        // Сводка:
        //     4 bytes/number (FORMAT INT,32) swapped endianness
        Integer324BytesSwapped,
        //
        // Сводка:
        //     2 bytes/number (FORMAT INT,16)
        Integer162Bytes,
        //
        // Сводка:
        //     2 bytes/number (FORMAT INT,16) swapped endianness
        Integer162BytesSwapped
    }
}
