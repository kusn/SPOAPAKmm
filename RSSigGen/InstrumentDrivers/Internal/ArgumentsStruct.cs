using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class ArgumentsStruct
    {
        internal const string RawDataPropName = "RawReturnData";

        private readonly object _structure;

        internal Dictionary<int, ArgAttribute> Args { get; }

        internal ArgumentsStruct(object structure)
        {
            _structure = structure;
            Args = _GetStructArgAttrs();
        }

        //
        // Сводка:
        //     Returns a dictionary with the structure members' attributes
        private Dictionary<int, ArgAttribute> _GetStructArgAttrs()
        {
            Dictionary<int, ArgAttribute> dictionary = new Dictionary<int, ArgAttribute>();
            PropertyInfo[] properties = _structure.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.Name != "RawReturnData")
                {
                    ArgAttribute argAttribute = (ArgAttribute)propertyInfo.GetCustomAttributes(inherit: false).FirstOrDefault();
                    argAttribute.Property = propertyInfo;
                    argAttribute.Parent = _structure;
                    dictionary[argAttribute.ArgumentIndex] = argAttribute;
                }
            }

            return dictionary;
        }

        //
        // Сводка:
        //     Fills the structure from the entered string content (command response)
        //
        // Параметры:
        //   content:
        internal void ParseFromCmdResponse(string content)
        {
            ArgsStringParser argsStringParser = new ArgsStringParser(content);
            _structure.GetType().GetProperties().FirstOrDefault((PropertyInfo x) => x.Name == "RawReturnData")?.SetValue(_structure, content, null);
            int count = Args.Count;
            int argIx;
            for (argIx = 0; argIx < count && !Args[argIx].IsOpenList; argIx++)
            {
                ArgAttribute argAttribute = Args[argIx];
                if (argAttribute.Repetition <= 1)
                {
                    argsStringParser.ToScalarValue(argAttribute);
                }
                else
                {
                    argsStringParser.ToArrayValue(argAttribute, incrPosition: true, 0, argAttribute.Repetition, argAttribute.Repetition, 1);
                }
            }

            if (argIx >= count || !Args[argIx].IsOpenList)
            {
                return;
            }

            if (argIx == count - 1)
            {
                argsStringParser.ToArrayValue(Args[argIx], incrPosition: true, 0, argsStringParser.Remaining, argsStringParser.Remaining, 1);
                return;
            }

            List<KeyValuePair<int, ArgAttribute>> list = Args.Where((KeyValuePair<int, ArgAttribute> x) => x.Key >= argIx).ToList();
            int num = list.Sum((KeyValuePair<int, ArgAttribute> x) => x.Value.Repetition);
            if (argsStringParser.Remaining % num != 0)
            {
                throw new DataException($"Arguments parsing is not aligned - source string elements remaining to parse {argsStringParser.Remaining} " + $"is not dividable by the summary Period {num} of all the open list arguments:\n" + string.Join("\n", list.Select((KeyValuePair<int, ArgAttribute> x) => $"{x}")));
            }

            int num2 = 0;
            foreach (KeyValuePair<int, ArgAttribute> item in list)
            {
                argsStringParser.ToArrayValue(item.Value, incrPosition: false, num2, item.Value.Repetition, num, -1);
                num2 += item.Value.Repetition;
            }
        }

        //
        // Сводка:
        //     Composes the string argument from the structure for sending to the instrument
        internal string ComposeCmdString()
        {
            ArgsStringComposer argsStringComposer = new ArgsStringComposer();
            List<string> list = new List<string>();
            int count = Args.Count;
            int i = 0;
            int num = -1;
            for (; i < count && !Args[i].IsOpenList; i++)
            {
                ArgAttribute argAttribute = Args[i];
                if (!argAttribute.HasValue)
                {
                    num = i;
                    break;
                }

                if (argAttribute.Repetition <= 1)
                {
                    list.Add(argsStringComposer.FromScalarArg(argAttribute));
                }
                else
                {
                    list.Add(argsStringComposer.FromArrayArg(argAttribute, 0, argAttribute.Repetition));
                }
            }

            if (num < 0 && i < count)
            {
                ArgAttribute argAttribute2 = Args[i];
                if (argAttribute2.IsOpenList)
                {
                    if (i == count - 1)
                    {
                        if (argAttribute2.HasValue)
                        {
                            list.Add(argsStringComposer.FromArrayArg(argAttribute2));
                        }
                        else
                        {
                            num = i;
                        }
                    }
                    else
                    {
                        int[] array = new int[count];
                        int[] array2 = new int[count];
                        bool flag = false;
                        int num2 = -1;
                        int[] array3 = new int[count];
                        bool flag2 = false;
                        for (int j = i; j < count; j++)
                        {
                            argAttribute2 = Args[j];
                            array[j] = argsStringComposer.GetArgArraySize(argAttribute2);
                            if (array[j] < 0)
                            {
                                throw new DataException($"Argument '{argAttribute2.Name}' has repetitions, therefore it must be declared as an array. Current Declaration: '{argAttribute2.Type}'");
                            }

                            if (argAttribute2.Repetition > array[j])
                            {
                                throw new DataException($"Argument '{argAttribute2.Name}' has repetitions {argAttribute2.Repetition}, but its array size is only {array[j]}");
                            }

                            array2[j] = array[j] / argAttribute2.Repetition;
                            if (num2 >= 0 && array2[j] != num2)
                            {
                                flag = true;
                            }

                            num2 = array2[j];
                            array3[j] = array[j] % argAttribute2.Repetition;
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
                                text += $"{array[k]} / {Args[k].Repetition}x = {array[k] / Args[k].Repetition}\n";
                            }

                            throw new DataException(text);
                        }

                        if (flag2)
                        {
                            string text2 = "At least one argument has an array size not dividable by the defined repetitions:\n";
                            for (int l = i; l < count; l++)
                            {
                                text2 += $" {l} [{array[l]}] modulo {Args[l].Repetition}x = {array[l] % Args[l].Repetition}\n";
                            }

                            throw new DataException(text2);
                        }

                        for (int m = 0; m < num2; m++)
                        {
                            for (int n = i; n < count; n++)
                            {
                                argAttribute2 = Args[n];
                                list.Add(argsStringComposer.FromArrayArg(argAttribute2, argAttribute2.Repetition * m, argAttribute2.Repetition));
                            }
                        }
                    }
                }
            }

            if (num >= 0)
            {
                string text3 = "";
                for (int num3 = num; num3 < count; num3++)
                {
                    if (Args[num3].HasValue)
                    {
                        text3 = text3 + " " + Args[num3].Name + ",";
                    }
                }

                if (text3 != "")
                {
                    text3 = "Optional Argument '" + Args[num].Name + "' has no value, but the further ones do. You can not skip only some optional arguments. Clear the values for the rest of the argument(s): " + text3.TrimEnd(',');
                    throw new DataException(text3);
                }
            }

            return string.Join(",", list);
        }
    }
}
