namespace RSSigGen.RS
{
    public class VisaTimeoutException : OperationTimeoutException
    {
        //
        // Сводка:
        //     The only available constructor with the message parameters
        public VisaTimeoutException(string resourceString, string message, int timeout)
            : base(resourceString, message, timeout)
        {
        }
    }
}
