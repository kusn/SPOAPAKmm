using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Status_Queue commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Status_Queue
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     STATus:QUEue:[NEXT]
        //     Queries the oldest entry in the error queue and then deletes it. Positive error
        //     numbers denote device-specific errors, and negative error numbers denote error
        //     messages defined by SCPI. If the error queue is empty, 0 ("No error") is returned.
        //     The command is identical to SYSTem.
        //     next: string
        public string Next => _grpBase.IO.QueryString("STATus:QUEue:NEXT?").TrimStringResponse();

        internal RsSmab_Status_Queue(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Queue", core, parent);
        }
    }
}
