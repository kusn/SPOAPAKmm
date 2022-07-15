using System.Collections.Generic;
using System.Linq;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal static class ResourceManager
    {
        //
        // Сводка:
        //     List of RmSessions=VisaSessions and SocketIo Objects
        internal static Dictionary<int, VisaSocket> SessionsList;

        //
        // Сводка:
        //     Last error assigned to the session
        internal static Dictionary<int, string> LastError;

        static ResourceManager()
        {
            SessionsList = new Dictionary<int, VisaSocket>();
            LastError = new Dictionary<int, string>();
        }

        //
        // Сводка:
        //     Finds new Resource Manager and VISA session handle (starting from 1) and sets
        //     it up
        internal static int GetNewSessionHandle()
        {
            int num = 1;
            if (SessionsList.Count > 0)
            {
                num = SessionsList.Max((KeyValuePair<int, VisaSocket> x) => x.Key) + 1;
            }

            SessionsList[num] = null;
            LastError[num] = null;
            return num;
        }
    }
}
