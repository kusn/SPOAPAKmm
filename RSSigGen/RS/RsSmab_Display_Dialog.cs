using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display_Dialog
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     DISPlay:DIALog:ID
        //     Returns the dialog identifiers of the open dialogs in a string separated by blanks.
        //     dialogIdList: DialogID#1 DialogID#2 ... DialogID#n Dialog identifiers are string
        //     without blanks. Blanks are represented as $. Dialog identifiers DialogID are
        //     composed of two main parts: DialogName[OptionalParts] DialogName Meaningful information,
        //     mandatory input parameter for the commands: method RsSmab.Display.Dialog.Open
        //     method RsSmab.Display.Dialog.Close Optional parts String of $X values, where
        //     X is a character, interpreted as follows: $qDialogQualifier: optional dialog
        //     qualifier, usually the letter A or B, as displayed in the dialog title. $iInstances:
        //     comma-separated list of instance indexes, given in the order h,c,s,d,g,u,0. Default
        //     is zero; the terminating ",0" can be omitted. $tTabIds: comma-separated indexes
        //     or tab names; required, if a dialog is composed of several tabs. $xLeft$yTop$hLeft$wTop:
        //     position and size; superfluous information.
        public string Id => _grpBase.IO.QueryString("DISPlay:DIALog:ID?").TrimStringResponse();

        internal RsSmab_Display_Dialog(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Dialog", core, parent);
        }

        //
        // Сводка:
        //     DISPlay:DIALog:CLOSe
        //     Closes the specified dialog.
        //
        // Параметры:
        //   dialogId:
        //     string To find out the dialog identifier, use the query method RsSmab.Display.Dialog.Id.
        //     The DialogName part of the query result is sufficient.
        public void Close(string dialogId)
        {
            _grpBase.IO.Write("DISPlay:DIALog:CLOSe " + dialogId.EncloseByQuotes());
        }

        //
        // Сводка:
        //     DISPlay:DIALog:CLOSe:ALL
        //     Closes all open dialogs.
        public void CloseAll()
        {
            _grpBase.IO.Write("DISPlay:DIALog:CLOSe:ALL");
        }

        //
        // Сводка:
        //     DISPlay:DIALog:CLOSe:ALL
        //     Same as CloseAll, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void CloseAllAndWait()
        {
            CloseAllAndWait(-1);
        }

        //
        // Сводка:
        //     DISPlay:DIALog:CLOSe:ALL
        //     Same as CloseAll, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void CloseAllAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("DISPlay:DIALog:CLOSe:ALL", opcTimeoutMs);
        }

        //
        // Сводка:
        //     DISPlay:DIALog:OPEN
        //     Opens the specified dialog.
        //
        // Параметры:
        //   dialogId:
        //     string To find out the dialog identifier, use the query method RsSmab.Display.Dialog.Id.
        //     The DialogName part of the query result is mandatory.
        public void Open(string dialogId)
        {
            _grpBase.IO.Write("DISPlay:DIALog:OPEN " + dialogId.EncloseByQuotes());
        }
    }
}
