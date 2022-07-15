namespace RSSigGen.InstrumentDrivers.Internal
{
    internal enum InstrOptionsParseMode
    {
        //
        // Сводка:
        //     No options reading / parsing / applying
        Skip,
        //
        // Сводка:
        //     No parsing, just trimming white spaces
        KeepOriginal,
        //
        // Сводка:
        //     If dash is present, only the the part before dash is kept e.g. 'K200-FSH' =>
        //     'K200'
        KeepBeforeDash,
        //
        // Сводка:
        //     If dash is present, only the part after dash is kept e.g. 'SMU200-K1' => 'K1'
        KeepAfterDash,
        //
        // Сводка:
        //     Parses the option automatically - takes the portion before or after dash depending
        //     on sucessfull parsing K/B
        Auto
    }
}
