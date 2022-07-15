using System;
using System.Collections.Generic;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class InternalLinker
    {
        //
        // Сводка:
        //     Callback is called for all the linked parameters The Core has one callback handler
        //     added - c_ReturnArgSuppressed() that based on the linking name calls a specific
        //     callback further.
        internal EventHandler<Instrument.ReturnArgLinkedEventArgs> Callback { get; set; }

        //
        // Сводка:
        //     Takes the string 'response', removes the suppressed argument value from it and
        //     returns the rest. The cut out part is sent via callback if the internal linking
        //     exists
        //
        // Параметры:
        //   arg:
        //
        //   response:
        //
        //   contextForLinkedArg:
        internal string CutFromResponseString(ArgSuppressed arg, string response, string contextForLinkedArg)
        {
            string result = "";
            if (arg.ArgumentIndex != 0)
            {
                throw new ArgumentException("Only arguments with the index 0 can be suppressed");
            }

            if (arg.IsOpenList)
            {
                throw new ArgumentException("OpenList arguments cannot be suppressed");
            }

            int num = 0;
            int num2 = 0;
            for (int i = 0; i < response.Length; i++)
            {
                if (response[i] == ',')
                {
                    num++;
                }

                if (num == arg.Repetition)
                {
                    break;
                }

                num2++;
            }

            string value = response.Substring(0, num2);
            num2++;
            if (num2 < response.Length)
            {
                result = response.Substring(num2);
            }

            InvokeInternalLinking(arg, contextForLinkedArg, value);
            return result;
        }

        //
        // Сводка:
        //     Invokes the Callback, if the entered suppressed argument has an internal linking
        //
        // Параметры:
        //   arg:
        //
        //   contextForLinkedArg:
        //
        //   value:
        internal void InvokeInternalLinking(ArgSuppressed arg, string contextForLinkedArg, string value)
        {
            if (arg.InternalLinking != null)
            {
                Instrument.ReturnArgLinkedEventArgs e = new Instrument.ReturnArgLinkedEventArgs
                {
                    Context = contextForLinkedArg,
                    Name = arg.InternalLinking,
                    TimeStamp = DateTime.Now,
                    Value = value
                };
                Callback(this, e);
            }
        }

        //
        // Сводка:
        //     Invokes the Callback, if the entered argument has an internal linking
        internal void InvokeInternalLinking(ArgSingle arg, string contextForLinkedArg, string value)
        {
            if (arg.InternalLinking != null)
            {
                Instrument.ReturnArgLinkedEventArgs e = new Instrument.ReturnArgLinkedEventArgs
                {
                    Context = contextForLinkedArg,
                    Name = arg.InternalLinking,
                    TimeStamp = DateTime.Now,
                    Value = value
                };
                Callback(this, e);
            }
        }

        //
        // Сводка:
        //     Invokes the Callback for each of the arguments that have internal linking
        internal void InvokeInternalLinking(Dictionary<int, ArgAttribute> args, string contextForLinkedArg)
        {
            DateTime now = DateTime.Now;
            foreach (KeyValuePair<int, ArgAttribute> arg in args)
            {
                if (arg.Value.InternalLinking != null)
                {
                    Instrument.ReturnArgLinkedEventArgs e = new Instrument.ReturnArgLinkedEventArgs
                    {
                        Context = contextForLinkedArg,
                        Name = arg.Value.InternalLinking,
                        TimeStamp = now,
                        Value = arg.Value.Value
                    };
                    Callback(this, e);
                }
            }
        }
    }
}
