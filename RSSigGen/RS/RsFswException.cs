using System;

namespace RSSigGen.RS
{
    public class RsFswException : Exception
    {
        //
        // Сводка:
        //     Resource string of the session that threw the Exception
        public string ResourceString { get; }

        //
        // Сводка:
        //     The only available constructor with the message parameters
        public RsFswException(string resourceString, string message)
            : base(message)
        {
            ResourceString = resourceString;
        }
    }
}
