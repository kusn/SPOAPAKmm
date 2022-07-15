namespace RSSigGen.RS
{
    public class VisaException : RsSmabException
    {
        //
        // Сводка:
        //     The only available constructor with the message parameters
        public VisaException(string resourceString, string message)
            : base(resourceString, message)
        {
        }
    }
}
