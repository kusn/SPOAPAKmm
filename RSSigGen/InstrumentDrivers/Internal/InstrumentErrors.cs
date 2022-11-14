using System.Collections.Generic;
using System.Linq;
using RSSigGen.RS;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal static class InstrumentErrors
    {
        internal static void AssertNoInstrumentStatusErrors(string resourceName, List<string> errors, string context = "")
        {
            if (errors.Count != 0)
            {
                string text = (string.IsNullOrEmpty(context) ? ("'" + resourceName + "': ") : ("'" + resourceName + "': " + context + " "));
                if (errors.Count == 1)
                {
                    throw new InstrumentStatusException(resourceName, text + "Instrument error detected: " + errors.ToArray()[0], errors.ToList());
                }

                if (errors.Count > 1)
                {
                    throw new InstrumentStatusException(resourceName, string.Format("{0}{1} instrument errors detected:\n{2}", text, errors.Count, string.Join("\n", errors)), errors.ToList());
                }
            }
        }

        //
        // Сводка:
        //     Throws OperationTimeoutException - use it for any timeout error
        internal static void ThrowOpcToutException(string resourceName, int opcTimeoutMs, int usedTimeoutMs, string context = "")
        {
            string text = ((!string.IsNullOrEmpty(context)) ? (context.Trim() + " ") : "");
            if (usedTimeoutMs < 0 || usedTimeoutMs == opcTimeoutMs)
            {
                usedTimeoutMs = opcTimeoutMs;
                text = text + $"Timeout expired before the operation completed. Current OPC timeout is set to {opcTimeoutMs} ms." + "Change it with the property _driver.UtilityFunctions.OPCTimeout.Optionally, if the method API contains timeout parameter, change it there.";
            }
            else
            {
                text += $"Timeout expired before the operation completed. Used timeout: {usedTimeoutMs} ms";
            }

            throw new OperationTimeoutException(resourceName, text, usedTimeoutMs);
        }

        //
        // Сводка:
        //     Checks a command and throws RsFswException if the command contains a question-mark
        internal static void AssertCommandContainsNoQuestionMark(string resourceName, string command, string context)
        {
            if (!command.ContainsQuestionMark())
            {
                return;
            }

            string text = ((!string.IsNullOrEmpty(context)) ? (context.Trim() + " ") : "");
            text = text + "Set commands must not end with question-marks. Sent Command: '" + command.Trim() + "'";
            throw new RsFswException(resourceName, text);
        }

        //
        // Сводка:
        //     Checks a command and throws RsFswException if the query does not contain a question-mark
        internal static void AssertQueryContainsQuestionMark(string resourceName, string query, string context)
        {
            if (query.ContainsQuestionMark())
            {
                return;
            }

            string text = (string.IsNullOrEmpty(context) ? "" : (context + " "));
            text = text + "Query commands must contain question-marks. Sent Query: '" + query.Trim() + "'";
            throw new RsFswException(resourceName, text);
        }
    }
}
