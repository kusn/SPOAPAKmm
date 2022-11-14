using System.Collections.Generic;
using System.Data;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class ArgumentsSingleList
    {
        internal string ComposeCmdString(ArgSingle arg1)
        {
            return ComposeCmdString(new Dictionary<int, ArgSingle> { { arg1.ArgumentIndex, arg1 } });
        }

        internal string ComposeCmdString(ArgSingle arg1, ArgSingle arg2)
        {
            return ComposeCmdString(new Dictionary<int, ArgSingle>
            {
                { arg1.ArgumentIndex, arg1 },
                { arg2.ArgumentIndex, arg2 }
            });
        }

        internal string ComposeCmdString(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3)
        {
            return ComposeCmdString(new Dictionary<int, ArgSingle>
            {
                { arg1.ArgumentIndex, arg1 },
                { arg2.ArgumentIndex, arg2 },
                { arg3.ArgumentIndex, arg3 }
            });
        }

        internal string ComposeCmdString(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4)
        {
            return ComposeCmdString(new Dictionary<int, ArgSingle>
            {
                { arg1.ArgumentIndex, arg1 },
                { arg2.ArgumentIndex, arg2 },
                { arg3.ArgumentIndex, arg3 },
                { arg4.ArgumentIndex, arg4 }
            });
        }

        internal string ComposeCmdString(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4, ArgSingle arg5)
        {
            return ComposeCmdString(new Dictionary<int, ArgSingle>
            {
                { arg1.ArgumentIndex, arg1 },
                { arg2.ArgumentIndex, arg2 },
                { arg3.ArgumentIndex, arg3 },
                { arg4.ArgumentIndex, arg4 },
                { arg5.ArgumentIndex, arg5 }
            });
        }

        internal string ComposeCmdString(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4, ArgSingle arg5, ArgSingle arg6)
        {
            return ComposeCmdString(new Dictionary<int, ArgSingle>
            {
                { arg1.ArgumentIndex, arg1 },
                { arg2.ArgumentIndex, arg2 },
                { arg3.ArgumentIndex, arg3 },
                { arg4.ArgumentIndex, arg4 },
                { arg5.ArgumentIndex, arg5 },
                { arg6.ArgumentIndex, arg6 }
            });
        }

        internal string ComposeCmdString(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4, ArgSingle arg5, ArgSingle arg6, ArgSingle arg7)
        {
            return ComposeCmdString(new Dictionary<int, ArgSingle>
            {
                { arg1.ArgumentIndex, arg1 },
                { arg2.ArgumentIndex, arg2 },
                { arg3.ArgumentIndex, arg3 },
                { arg4.ArgumentIndex, arg4 },
                { arg5.ArgumentIndex, arg5 },
                { arg6.ArgumentIndex, arg6 },
                { arg7.ArgumentIndex, arg7 }
            });
        }

        internal string ComposeCmdString(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4, ArgSingle arg5, ArgSingle arg6, ArgSingle arg7, ArgSingle arg8)
        {
            return ComposeCmdString(new Dictionary<int, ArgSingle>
            {
                { arg1.ArgumentIndex, arg1 },
                { arg2.ArgumentIndex, arg2 },
                { arg3.ArgumentIndex, arg3 },
                { arg4.ArgumentIndex, arg4 },
                { arg5.ArgumentIndex, arg5 },
                { arg6.ArgumentIndex, arg6 },
                { arg7.ArgumentIndex, arg7 },
                { arg8.ArgumentIndex, arg8 }
            });
        }

        internal string ComposeCmdString(ArgSingle arg1, ArgSingle arg2, ArgSingle arg3, ArgSingle arg4, ArgSingle arg5, ArgSingle arg6, ArgSingle arg7, ArgSingle arg8, ArgSingle arg9)
        {
            return ComposeCmdString(new Dictionary<int, ArgSingle>
            {
                { arg1.ArgumentIndex, arg1 },
                { arg2.ArgumentIndex, arg2 },
                { arg3.ArgumentIndex, arg3 },
                { arg4.ArgumentIndex, arg4 },
                { arg5.ArgumentIndex, arg5 },
                { arg6.ArgumentIndex, arg6 },
                { arg7.ArgumentIndex, arg7 },
                { arg8.ArgumentIndex, arg8 },
                { arg9.ArgumentIndex, arg9 }
            });
        }

        //
        // Сводка:
        //     Composes the string argument from the list of arguments
        internal string ComposeCmdString(Dictionary<int, ArgSingle> args)
        {
            ArgsStringComposer argsStringComposer = new ArgsStringComposer();
            List<string> list = new List<string>();
            int count = args.Count;
            int i;
            for (i = 0; i < count && !args[i].IsOpenList; i++)
            {
                ArgSingle argSingle = args[i];
                if (args[i].Repetition <= 1)
                {
                    list.Add(argsStringComposer.FromScalarArg(argSingle));
                }
                else
                {
                    list.Add(argsStringComposer.FromArrayArg(argSingle, 0, argSingle.Repetition));
                }
            }

            if (i < count)
            {
                ArgSingle argSingle2 = args[i];
                if (argSingle2.IsOpenList)
                {
                    if (i == count - 1)
                    {
                        list.Add(argsStringComposer.FromArrayArg(argSingle2));
                    }
                    else
                    {
                        int[] array = new int[count];
                        int[] array2 = new int[count];
                        bool flag = false;
                        int num = -1;
                        int[] array3 = new int[count];
                        bool flag2 = false;
                        for (int j = i; j < count; j++)
                        {
                            argSingle2 = args[j];
                            array[j] = argsStringComposer.GetArgArraySize(argSingle2);
                            if (argSingle2.Repetition > array[j])
                            {
                                throw new DataException($"Argument {argSingle2} has repetitions {argSingle2.Repetition}, but its array size is only {array[j]}");
                            }

                            array2[j] = array[j] / argSingle2.Repetition;
                            if (num >= 0 && array2[j] != num)
                            {
                                flag = true;
                            }

                            num = array2[j];
                            array3[j] = array[j] % argSingle2.Repetition;
                            if (array3[j] != 0)
                            {
                                flag2 = true;
                            }
                        }

                        if (flag)
                        {
                            string text = "Arguments interleaving is not aligned - cycles must be the same. Actual cycles:\n";
                            for (int k = i; k < count; k++)
                            {
                                text += $"{array[k]} / {args[k].Repetition}x = {array[k] / args[k].Repetition}\n";
                            }

                            throw new DataException(text);
                        }

                        if (flag2)
                        {
                            string text2 = "At least one argument has array size not dividable by the defined repetitions:\n";
                            for (int l = i; l < count; l++)
                            {
                                text2 += $" {l} [{array[l]}] modulo {args[l].Repetition}x = {array[l] % args[l].Repetition}";
                            }

                            throw new DataException(text2);
                        }

                        for (int m = 0; m < num; m++)
                        {
                            for (int n = i; n < count; n++)
                            {
                                argSingle2 = args[n];
                                list.Add(argsStringComposer.FromArrayArg(argSingle2, argSingle2.Repetition * m, argSingle2.Repetition));
                            }
                        }
                    }
                }
            }

            return string.Join(",", list);
        }
    }
}
