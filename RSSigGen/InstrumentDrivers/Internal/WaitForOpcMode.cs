namespace RSSigGen.InstrumentDrivers.Internal
{
    internal enum WaitForOpcMode
    {
        StbPolling = 1,
        StbPollingSlow,
        StbPollingSuperSlow,
        ServiceRequest,
        OpcQuery
    }
}
