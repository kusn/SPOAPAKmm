using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSigGen.RS
{
    public class OperationTimeoutException : RsFswException
    {
        //
        // Сводка:
        //     Timeout value reached
        public int Timeout { get; }

        //
        // Сводка:
        //     The only available constructor with the message parameters
        public OperationTimeoutException(string resourceString, string message, int timeout)
            : base(resourceString, message)
        {
            Timeout = timeout;
        }
    }
}
