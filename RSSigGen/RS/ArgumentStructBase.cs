using System.Data;

namespace RSSigGen.RS
{
    public class ArgumentStructBase
    {
        internal string RawReturnData { get; set; }

        //
        // Сводка:
        //     Returns raw instrument response. Throws DataException if no response string was
        //     returned yet
        public string GetRawReturnData()
        {
            if (RawReturnData == null)
            {
                throw new DataException("Return raw string not available. The structure was probably not used in any Query method.");
            }

            return RawReturnData;
        }
    }
}
