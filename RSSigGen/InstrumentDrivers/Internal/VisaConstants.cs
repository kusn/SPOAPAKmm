namespace RSSigGen.InstrumentDrivers.Internal
{
    internal static class VisaConstants
    {
        internal enum EventMechanism
        {
            Queue = 1,
            Handler,
            AllMech
        }

        //
        // Сводка:
        //     Indicates the type of a VISA.NET event.
        internal enum VisaEventType : uint
        {
            Custom = 0u,
            ServiceRequest = 1073684491u,
            AllEnabled = 1073709055u
        }

        //
        // Сводка:
        //     This is attribute names for function viSetAttribute and viGetAttribute
        internal const uint ViAttrTmoValue = 1073676314u;

        internal const uint ViAttrIntfType = 1073676657u;

        internal const uint ViAttrTermCharEn = 1073676344u;

        internal const uint ViAttrTermChar = 1073676312u;

        internal const uint ViAttrRsrcClass = 3221159937u;

        internal const uint ViAttrRsrcManfName = 3221160308u;

        internal const uint ViAttrSendEndEn = 1073676310u;

        internal const uint ViAttrAsrlEndIn = 1073676467u;

        internal const uint ViAttrAsrlEndOut = 1073676468u;

        internal const uint ViAttrTcpipIsHislip = 1073677059u;

        internal const uint RsFindResourceAttributeMode = 263127042u;

        internal const int ViSuccessMaxCnt = 1073676294;

        internal const int ViErrorTmo = -1073807339;

        internal const int ViErrorRsrcNotFound = -1073807343;

        internal const int ViErrorInvalidRsrcName = -1073807342;

        internal const int ViErrorInvalidObject = -1073807346;

        internal const int ViErrorNsupAttr = -1073807331;

        internal const int ViErrorDirectStatusMessage = -5001;

        internal const int ViSuccess = 0;
    }
}
