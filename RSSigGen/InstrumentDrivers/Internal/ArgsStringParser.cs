using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class ArgsStringParser
    {
        internal string[] Elements { get; }

        internal int Position { get; private set; }

        internal int Count { get; }

        internal int Remaining => Count - Position;

        internal ArgsStringParser(string value)
        {
            Elements = value.Split(',');
            Count = Elements.Length;
        }

        //
        // Сводка:
        //     Parses the current element to a scalar argument
        //
        // Параметры:
        //   arg:
        internal void ToScalarValue(IArgConvertible arg)
        {
            if (Position >= Elements.Length)
            {
                throw new DataException($"Cannot parse a scalar value to the argument '{arg.Name}'. Response contains too few elements ({Count}). Argument's position: {Position + 1}");
            }

            if (arg.Type == DataType.Integer || arg.Type == DataType.IntegerExt)
            {
                arg.Value = Elements[Position++].ToInt32();
                return;
            }

            if (arg.Type == DataType.Integer64)
            {
                arg.Value = Elements[Position++].ToInt64();
                return;
            }

            if (arg.Type == DataType.Boolean)
            {
                arg.Value = Elements[Position++].ToBoolean();
                return;
            }

            if (arg.Type == DataType.Float || arg.Type == DataType.FloatExt)
            {
                arg.Value = Elements[Position++].ToDouble();
                return;
            }

            if (arg.Type == DataType.String)
            {
                arg.Value = Elements[Position++].TrimStringResponse();
                return;
            }

            if (arg.Type == DataType.RawString)
            {
                arg.Value = Elements[Position++].TrimStringResponse(StringExtensionMethods.TrimStringMode.WhiteCharsOnly);
                return;
            }

            if (arg.Type == DataType.Enum)
            {
                Type enumType = arg.EnumType;
                string text = Elements[Position++];
                string text2 = text.ScpiStringToEnumString(enumType);
                if (text2 != null)
                {
                    arg.Value = Enum.Parse(enumType, text2);
                    return;
                }

                text = text.TrimStringResponse();
                if (!RsDrvFormat.SpecialValuesToInt32(text, out var value))
                {
                    throw new DataException($"String '{text}' can not be converted to an enum {arg.EnumType} element");
                }

                arg.Value = Enum.ToObject(enumType, value);
                return;
            }

            throw new DataException($"Parsing of the scalar data type '{arg.Type}' is not supported");
        }

        //
        // Сводка:
        //     Parses the current element to an array argument If the incrPosition is true,
        //     the Parser's internal index counter increases by the number or parsed elements
        internal void ToArrayValue(IArgConvertible arg, bool incrPosition, int offset, int count, int period, int cycles)
        {
            if (cycles < 0)
            {
                cycles = Remaining / period;
            }

            if (Position >= Count)
            {
                throw new DataException($"Cannot parse an array value to the argument '{arg.Name}', because the element position {Position} is over the parsed array length {Count}");
            }

            if (Position + offset + count > Count)
            {
                throw new DataException($"Cannot parse the whole array value to the argument '{arg.Name}', because the element position {Position} plus the argument offset {offset} and argument length {count} would be over the parsed array length {Count}");
            }

            if (arg.Type == DataType.IntegerArray || arg.Type == DataType.IntegerExtArray)
            {
                List<int> list = new List<int>(count * cycles);
                for (int i = 0; i < cycles; i++)
                {
                    int num = Position + i * period + offset;
                    for (int j = num; j < num + count; j++)
                    {
                        list.Add(Elements[j].ToInt32());
                    }
                }

                if (incrPosition)
                {
                    Position += count;
                }

                arg.Value = list;
                return;
            }

            if (arg.Type == DataType.Integer64Array)
            {
                List<long> list2 = new List<long>(count * cycles);
                for (int k = 0; k < cycles; k++)
                {
                    int num2 = Position + k * period + offset;
                    for (int l = num2; l < num2 + count; l++)
                    {
                        list2.Add(Elements[l].ToInt64());
                    }
                }

                if (incrPosition)
                {
                    Position += count;
                }

                arg.Value = list2;
                return;
            }

            if (arg.Type == DataType.BooleanArray)
            {
                List<bool> list3 = new List<bool>(count * cycles);
                for (int m = 0; m < cycles; m++)
                {
                    int num3 = Position + m * period + offset;
                    for (int n = num3; n < num3 + count; n++)
                    {
                        list3.Add(Elements[n].ToBoolean());
                    }
                }

                if (incrPosition)
                {
                    Position += count;
                }

                arg.Value = list3;
                return;
            }

            if (arg.Type == DataType.FloatArray || arg.Type == DataType.FloatExtArray)
            {
                List<double> list4 = new List<double>(count * cycles);
                for (int num4 = 0; num4 < cycles; num4++)
                {
                    int num5 = Position + num4 * period + offset;
                    for (int num6 = num5; num6 < num5 + count; num6++)
                    {
                        list4.Add(Elements[num6].ToDouble());
                    }
                }

                if (incrPosition)
                {
                    Position += count;
                }

                arg.Value = list4;
                return;
            }

            if (arg.Type == DataType.StringArray || arg.Type == DataType.RawStringArray)
            {
                StringExtensionMethods.TrimStringMode mode = ((arg.Type != DataType.StringArray) ? StringExtensionMethods.TrimStringMode.WhiteCharsOnly : StringExtensionMethods.TrimStringMode.WhiteCharsAllQuotes);
                List<string> list5 = new List<string>(count * cycles);
                for (int num7 = 0; num7 < cycles; num7++)
                {
                    int num8 = Position + num7 * period + offset;
                    for (int num9 = num8; num9 < num8 + count; num9++)
                    {
                        list5.Add(Elements[num9].TrimStringResponse(mode));
                    }
                }

                if (incrPosition)
                {
                    Position += count;
                }

                arg.Value = list5;
                return;
            }

            if (arg.Type == DataType.EnumArray)
            {
                Type enumType = arg.EnumType;
                object obj = Activator.CreateInstance(typeof(List<>).MakeGenericType(enumType), count * cycles);
                MethodInfo method = obj.GetType().GetMethod("Add");
                for (int num10 = 0; num10 < cycles; num10++)
                {
                    int num11 = Position + num10 * period + offset;
                    for (int num12 = num11; num12 < num11 + count; num12++)
                    {
                        string text = Elements[num12];
                        string text2 = text.ScpiStringToEnumString(enumType);
                        if (text2 != null)
                        {
                            object obj2 = Enum.Parse(enumType, text2);
                            method.Invoke(obj, new object[1] { obj2 });
                            continue;
                        }

                        text = text.TrimStringResponse();
                        if (!RsDrvFormat.SpecialValuesToInt32(text, out var value))
                        {
                            throw new DataException($"String '{text}' can not be converted to an enum {arg.EnumType} element");
                        }

                        object obj3 = Enum.ToObject(enumType, value);
                        method.Invoke(obj, new object[1] { obj3 });
                    }
                }

                if (incrPosition)
                {
                    Position += count;
                }

                arg.Value = obj;
                return;
            }

            throw new DataException($"Parsing of the array data type '{arg.Type}' is not supported");
        }
    }
}
