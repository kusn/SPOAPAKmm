using System.Collections.Generic;

namespace RSSigGen.RS
{
    public class InstrumentStatusException : RsSmabException
    {
        //
        // Сводка:
        //     List of all the error that occurred, the oldest one is first in the list
        public List<string> ErrorsList { get; }

        //
        // Сводка:
        //     The only available constructor with the message parameters
        public InstrumentStatusException(string resourceString, string message, List<string> errors)
            : base(resourceString, message)
        {
            ErrorsList = errors;
        }
    }
}
