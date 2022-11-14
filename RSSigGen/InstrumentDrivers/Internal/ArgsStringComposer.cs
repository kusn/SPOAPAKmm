using System;
using System.Collections;
using System.Collections.Generic;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class ArgsStringComposer
    {
        internal string FromScalarArg(IArgConvertible arg)
        {
            return arg.Type switch
            {
                DataType.Integer => ((int)arg.Value).ToString(),
                DataType.IntegerExt => ((int)arg.Value).ToInt32ExtString(),
                DataType.Integer64 => ((long)arg.Value).ToString(),
                DataType.Boolean => ((bool)arg.Value).ToBooleanString(),
                DataType.Float => ((double)arg.Value).ToDoubleString(),
                DataType.FloatExt => ((double)arg.Value).ToDoubleExtString(),
                DataType.String => ((string)arg.Value).EncloseByQuotes(),
                DataType.RawString => (string)arg.Value,
                DataType.Enum => arg.EnumType.EnumValueToScpiString(arg.Value),
                _ => throw new NotSupportedException(),
            };
        }

        //
        // Сводка:
        //     Returns one csv-string from an array argument with all the items remaining in
        //     the argument array
        internal string FromArrayArg(IArgConvertible arg)
        {
            return FromArrayArg(arg, 0, -1);
        }

        //
        // Сводка:
        //     Returns one csv-string from an array argument with specific items count
        internal string FromArrayArg(IArgConvertible arg, int startIndex, int itemsCount)
        {
            switch (arg.Type)
            {
                case DataType.IntegerArray:
                    {
                        List<int> list = (List<int>)arg.Value;
                        if (startIndex == 0 && itemsCount < 0)
                        {
                            return list.ToCsvString();
                        }

                        itemsCount = ((itemsCount >= 0) ? itemsCount : (list.Count - startIndex));
                        return list.GetRange(startIndex, itemsCount).ToCsvString();
                    }
                case DataType.Integer64Array:
                    {
                        List<long> list6 = (List<long>)arg.Value;
                        if (startIndex == 0 && itemsCount < 0)
                        {
                            return list6.ToCsvString();
                        }

                        itemsCount = ((itemsCount >= 0) ? itemsCount : (list6.Count - startIndex));
                        return list6.GetRange(startIndex, itemsCount).ToCsvString();
                    }
                case DataType.IntegerExtArray:
                    {
                        List<int> list7 = (List<int>)arg.Value;
                        if (startIndex == 0 && itemsCount < 0)
                        {
                            return list7.IntExtToCsvString();
                        }

                        itemsCount = ((itemsCount >= 0) ? itemsCount : (list7.Count - startIndex));
                        return list7.GetRange(startIndex, itemsCount).IntExtToCsvString();
                    }
                case DataType.BooleanArray:
                    {
                        List<bool> list5 = (List<bool>)arg.Value;
                        if (startIndex == 0 && itemsCount < 0)
                        {
                            return list5.ToCsvString();
                        }

                        itemsCount = ((itemsCount >= 0) ? itemsCount : (list5.Count - startIndex));
                        return list5.GetRange(startIndex, itemsCount).ToCsvString();
                    }
                case DataType.FloatArray:
                    {
                        List<double> list3 = (List<double>)arg.Value;
                        if (startIndex == 0 && itemsCount < 0)
                        {
                            return list3.ToCsvString();
                        }

                        itemsCount = ((itemsCount >= 0) ? itemsCount : (list3.Count - startIndex));
                        return list3.GetRange(startIndex, itemsCount).ToCsvString();
                    }
                case DataType.FloatExtArray:
                    {
                        List<double> list2 = (List<double>)arg.Value;
                        if (startIndex == 0 && itemsCount < 0)
                        {
                            return list2.DoubleExtToCsvString();
                        }

                        itemsCount = ((itemsCount >= 0) ? itemsCount : (list2.Count - startIndex));
                        return list2.GetRange(startIndex, itemsCount).DoubleExtToCsvString();
                    }
                case DataType.StringArray:
                    {
                        List<string> list8 = (List<string>)arg.Value;
                        if (startIndex == 0 && itemsCount < 0)
                        {
                            return list8.ToCsvString();
                        }

                        itemsCount = ((itemsCount >= 0) ? itemsCount : (list8.Count - startIndex));
                        return list8.GetRange(startIndex, itemsCount).ToCsvString();
                    }
                case DataType.RawStringArray:
                    {
                        List<string> list4 = (List<string>)arg.Value;
                        if (startIndex == 0 && itemsCount < 0)
                        {
                            return list4.ToCsvRawString();
                        }

                        itemsCount = ((itemsCount >= 0) ? itemsCount : (list4.Count - startIndex));
                        return list4.GetRange(startIndex, itemsCount).ToCsvRawString();
                    }
                case DataType.EnumArray:
                    {
                        ICollection collection = (ICollection)arg.Value;
                        int num = 0;
                        if (startIndex == 0 && itemsCount < 0)
                        {
                            string[] array = new string[collection.Count];
                            foreach (object item in collection)
                            {
                                array[num++] = arg.EnumType.EnumValueToScpiString(item);
                            }

                            return array.ToCsvString();
                        }

                        itemsCount = ((itemsCount >= 0) ? itemsCount : (collection.Count - startIndex));
                        string[] array2 = new string[itemsCount];
                        int num2 = 0;
                        foreach (object item2 in collection)
                        {
                            if (num2 >= startIndex && num < itemsCount)
                            {
                                array2[num++] = arg.EnumType.EnumValueToScpiString(item2);
                            }

                            num2++;
                        }

                        return array2.ToCsvString();
                    }
                default:
                    throw new NotSupportedException();
            }
        }

        //
        // Сводка:
        //     Returns array size of the argument assumming it is an array If the argument is
        //     not an array, the method returns -1
        internal int GetArgArraySize(IArgConvertible arg)
        {
            DataType type = arg.Type;
            if ((uint)(type - 9) <= 8u)
            {
                return ((ICollection)arg.Value).Count;
            }

            return -1;
        }
    }
}
