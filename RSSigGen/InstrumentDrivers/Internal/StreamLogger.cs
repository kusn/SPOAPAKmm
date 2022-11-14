using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class StreamLogger
    {
        //
        // Сводка:
        //     List of streams
        private readonly List<Stream> _loggers;

        //
        // Сводка:
        //     Timer for measuring the durations
        private readonly Stopwatch _stopWatch;

        //
        // Сводка:
        //     Logging blocker.
        private bool _blocking;

        //
        // Сводка:
        //     Last line source logged
        private int _previousLoggedLine;

        //
        // Сводка:
        //     Last line source logged
        private DateTime _loggingLastLineTime = DateTime.MinValue;

        //
        // Сводка:
        //     Maximum size of the binary data before they are truncated
        internal int MaxBinEntryLength { get; set; }

        //
        // Сводка:
        //     Maximum size of the ASCII data before they are truncated
        internal int MaxAsciiEntryLength { get; set; }

        //
        // Сводка:
        //     This sets or gets logging state
        internal bool LoggingEnabled { get; set; }

        //
        // Сводка:
        //     This sets or gets logging with source state
        internal bool LoggingDebugEnabled { get; set; }

        //
        // Сводка:
        //     Constructor for the Logger class
        internal StreamLogger()
        {
            _loggers = new List<Stream>();
            _stopWatch = new Stopwatch();
            MaxBinEntryLength = 1024;
            MaxAsciiEntryLength = 2048;
            _blocking = false;
        }

        //
        // Сводка:
        //     Creates new log line with time stamp and the info / log message
        //
        // Параметры:
        //   infoMessage:
        //
        //   logMessage:
        private string _ComposeLogString(string infoMessage, string logMessage)
        {
            string text = string.Format(CultureInfo.InvariantCulture, "{0}\t{1:F6}\t", DateTime.Now.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture), (double)_stopWatch.ElapsedTicks / (double)Stopwatch.Frequency);
            if (string.IsNullOrEmpty(infoMessage))
            {
                return text + logMessage + "\n";
            }

            return text + string.Format(CultureInfo.InvariantCulture, "{0}\t{1}\n", infoMessage, logMessage);
        }

        //
        // Сводка:
        //     Replaces the white-space characters with escape characters and truncates the
        //     response to a maximum of _maxAsciiDataSize (2048) bytes
        //
        // Параметры:
        //   response:
        //     Response to correct
        //
        // Возврат:
        //     Corrected response
        private string _ResponseStringToLogEntry(string response)
        {
            if (response.Length > MaxAsciiEntryLength)
            {
                response = response.Substring(0, MaxAsciiEntryLength / 2) + " ........... " + response.Substring(response.Length - MaxAsciiEntryLength / 2);
            }

            response = response.TrimEnd().Replace("\n", "\\n").Replace("\r", "\\r")
                .Replace("\t", "\\t");
            return response;
        }

        //
        // Сводка:
        //     Blocks the next Log/LogBinaryData entry
        internal void BlockNextLogEntry()
        {
            _blocking = true;
        }

        //
        // Сводка:
        //     Add new StreamWriter listener
        internal void Add(Stream sw)
        {
            _loggers.Add(sw);
        }

        //
        // Сводка:
        //     Remove StreamWriter listener
        internal void Remove(Stream sw)
        {
            _loggers.Remove(sw);
        }

        //
        // Сводка:
        //     Starts the timer what will be later used by the Log() method for calculating
        //     the duration
        internal void TimerStart()
        {
            if (!_blocking)
            {
                _stopWatch.Restart();
            }
        }

        //
        // Сводка:
        //     Logging of a query or read: "sent -> received" or "-> received" with the received
        //     string adjusted
        //
        // Параметры:
        //   infoMessage:
        //
        //   sent:
        //     Sent command/query
        //
        //   received:
        //     Response
        internal void Log(string infoMessage, string sent, string received)
        {
            string text = "-> " + _ResponseStringToLogEntry(received);
            if (!string.IsNullOrEmpty(sent))
            {
                text = sent.Trim() + " " + text;
            }

            Log(infoMessage, text);
        }

        //
        // Сводка:
        //     Logging of an array query: "sent -> Size %d: received" with the received string
        //     adjusted
        //
        // Параметры:
        //   infoMessage:
        //
        //   sent:
        //     Sent command/query
        //
        //   size:
        //     Response size or number of array elements
        //
        //   received:
        //     Response
        internal void Log(string infoMessage, string sent, int size, string received)
        {
            Log(infoMessage, $"{sent.Trim()} -> Array size {size}: {_ResponseStringToLogEntry(received)}");
        }

        //
        // Сводка:
        //     Writes a binary data to all log streams in hexadecimal format
        //
        // Параметры:
        //   infoMessage:
        //     Specifies the type of message, usually "viWrite" or "viRead"
        //
        //   sent:
        //     Sent command/query
        //
        //   binaryData:
        //     Binary data
        internal void LogBinaryData(string infoMessage, string sent, byte[] binaryData)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (binaryData.Length <= MaxBinEntryLength)
            {
                for (int i = 0; i < binaryData.Length; i++)
                {
                    stringBuilder.AppendFormat("{0:X2} ", binaryData[i]);
                }

                string logMessage = $"{sent} Data size {binaryData.Length} bytes: {stringBuilder}";
                Log(infoMessage, logMessage);
                return;
            }

            int num = MaxBinEntryLength / 2;
            for (int j = 0; j < num; j++)
            {
                stringBuilder.AppendFormat("{0:X2} ", binaryData[j]);
            }

            stringBuilder.Append("  .....  ");
            for (int k = binaryData.Length - num; k < binaryData.Length; k++)
            {
                stringBuilder.AppendFormat("{0:X2} ", binaryData[k]);
            }

            string logMessage2 = $"{sent} Data size {binaryData.Length} bytes, first and last {num} bytes: {stringBuilder}";
            Log(infoMessage, logMessage2);
        }

        //
        // Сводка:
        //     Writes a message to all log streams
        //
        // Параметры:
        //   infoMessage:
        //     Specifies the type of message, usually "viWrite" or "viRead"
        //
        //   logMessage:
        //     Logging message
        internal void Log(string infoMessage, string logMessage)
        {
            if (_blocking)
            {
                _blocking = false;
                return;
            }

            _stopWatch.Stop();
            if (_loggers.Count == 0)
            {
                return;
            }

            string text = null;
            if (LoggingDebugEnabled)
            {
                StackTrace stackTrace = new StackTrace(0, fNeedFileInfo: true);
                StackFrame[] frames = stackTrace.GetFrames();
                MethodBase method = stackTrace.GetFrame(0)!.GetMethod();
                StackFrame[] array = frames;
                foreach (StackFrame stackFrame in array)
                {
                    if (!(stackFrame.GetMethod()!.Module.Name != method.Module.Name))
                    {
                        continue;
                    }

                    int fileLineNumber = stackFrame.GetFileLineNumber();
                    if (_previousLoggedLine == fileLineNumber)
                    {
                        break;
                    }

                    _previousLoggedLine = fileLineNumber;
                    string? fileName = stackFrame.GetFileName();
                    if (string.IsNullOrEmpty(fileName))
                    {
                        throw new ArgumentException("Logger source file name is empty.");
                    }

                    using (TextReader textReader = File.OpenText(fileName))
                    {
                        int num = 0;
                        DateTime now = DateTime.Now;
                        while (textReader.ReadLine() != null && ++num != fileLineNumber - 1)
                        {
                        }

                        double value = (DateTime.Now - now).TotalMilliseconds * -1.0;
                        if (_loggingLastLineTime != DateTime.MinValue)
                        {
                            text = string.Format(arg0: (DateTime.Now.AddMilliseconds(value) - _loggingLastLineTime).ToString("hh\\:mm\\:ss\\.fff", CultureInfo.InvariantCulture), provider: CultureInfo.InvariantCulture, format: "Overall time: {0}{1}", arg1: "\n\n---------------------------------------------------\n\n");
                        }

                        _loggingLastLineTime = DateTime.Now;
                        text += string.Format(CultureInfo.InvariantCulture, "{0}\tLine {1}\t{2}\n", _loggingLastLineTime.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture), fileLineNumber, textReader.ReadLine()!.Trim());
                    }

                    break;
                }
            }

            string text2 = _ComposeLogString(infoMessage, logMessage);
            foreach (Stream logger in _loggers)
            {
                bool flag = false;
                if (LoggingDebugEnabled && !string.IsNullOrEmpty(text))
                {
                    logger.Write(Encoding.ASCII.GetBytes(text), 0, text.Length);
                    flag = true;
                }

                if (!string.IsNullOrEmpty(text2))
                {
                    logger.Write(Encoding.ASCII.GetBytes(text2), 0, text2.Length);
                    flag = true;
                }

                if (flag)
                {
                    logger.Flush();
                }
            }
        }
    }
}
