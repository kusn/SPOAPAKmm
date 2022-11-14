using System;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class EventsGroup
    {
        private readonly Core _core;

        //
        // Сводка:
        //     Handler invoked when you read big data from the instrument. After each segment
        //     with the maximum size of RsSmab.IoSegmentSize the driver generates this event
        public EventHandler<InstrSegmentEventArgs> ReadSegmentHandler
        {
            set
            {
                _core.IO.ReadSegmentHandler = LocalReadSegmentHandler;
                void LocalReadSegmentHandler(object sender, InstrSegmentEventArgs e)
                {
                    value?.Invoke(_core.Owner, e);
                }
            }
        }

        //
        // Сводка:
        //     Handler invoked when you write big data to the instrument. After each segment
        //     with the maximum size of RsSmab.IoSegmentSize the driver generates this event
        public EventHandler<InstrSegmentEventArgs> WriteSegmentHandler
        {
            set
            {
                _core.IO.WriteSegmentHandler = LocalWriteSegmentHandler;
                void LocalWriteSegmentHandler(object sender, InstrSegmentEventArgs e)
                {
                    value?.Invoke(_core.Owner, e);
                }
            }
        }

        //
        // Сводка:
        //     Handler for the write with OPC events
        public EventHandler<InstrEventArgs> WriteWithOpcHandler { get; set; }

        //
        // Сводка:
        //     Handler for the query with OPC events
        public EventHandler<InstrEventArgs> QueryWithOpcHandler { get; set; }

        //
        // Сводка:
        //     Handler invoked when the instrument generates an error
        public EventHandler<InstrEventArgs> InstrumentErrorHandler
        {
            set
            {
                _core.IO.InstallSrqHandler(LocalErrorHandler, StatusByte.ErrorQueueNotEmpty);
                void LocalErrorHandler(object sender, InstrEventArgs e)
                {
                    e.Data = _core.IO.QueryErrorsAll();
                    value?.Invoke(_core.Owner, e);
                }
            }
        }

        //
        // Сводка:
        //     Handler invoked when the operation status register generates an event
        public EventHandler<InstrEventArgs> InstrumentOperationRegisterHandler
        {
            set
            {
                _core.IO.InstallSrqHandler(LocalOperStatRegHandler, StatusByte.OperationStatusReg);
                void LocalOperStatRegHandler(object sender, InstrEventArgs e)
                {
                    e.Data = _core.IO.QueryErrorsAll();
                    value?.Invoke(_core.Owner, e);
                }
            }
        }

        //
        // Сводка:
        //     Handler invoked when the questionable status register generates an event
        public EventHandler<InstrEventArgs> InstrumentQuestionableRegisterHandler
        {
            set
            {
                _core.IO.InstallSrqHandler(LocalQuestStatRegHandler, StatusByte.QuestionableStatusReg);
                void LocalQuestStatRegHandler(object sender, InstrEventArgs e)
                {
                    e.Data = _core.IO.QueryErrorsAll();
                    value?.Invoke(_core.Owner, e);
                }
            }
        }

        internal EventsGroup(Core core)
        {
            _core = core;
        }

        //
        // Сводка:
        //     Writes with opc event. Register the event with WriteWitOpcHandler
        public void WriteStringWithOpc(string command)
        {
            _core.IO.WriteWithOpcHandler = LocalHandler;
            _core.IO.WriteStringWithOpcEvent(command);
            void LocalHandler(object sender, InstrEventArgs e)
            {
                _core.IO.WriteWithOpcHandler = null;
                WriteWithOpcHandler?.Invoke(_core.Owner, e);
            }
        }

        //
        // Сводка:
        //     Queries the instrument and invokes the QueryWithOpcHandler when the operation
        //     has completed The response is available in the InstrEventArgs.Data
        public void QueryStringWithOpc(string query)
        {
            _core.IO.QueryWithOpcHandler = LocalHandler;
            _core.IO.QueryStringWithOpcEvent(query);
            void LocalHandler(object sender, InstrEventArgs e)
            {
                _core.IO.QueryWithOpcHandler = null;
                QueryWithOpcHandler?.Invoke(_core.Owner, e);
            }
        }

        //
        // Сводка:
        //     Queries the instrument for binary data and invokes the QueryWithOpcHandler when
        //     the operation has completed The response is available in the InstrEventArgs.Data
        public void QueryBinaryDataWithOpc(string query)
        {
            _core.IO.QueryWithOpcHandler = LocalHandler;
            _core.IO.QueryBinaryDataWithOpcEvent(query);
            void LocalHandler(object sender, InstrEventArgs e)
            {
                _core.IO.QueryWithOpcHandler = null;
                QueryWithOpcHandler?.Invoke(_core.Owner, e);
            }
        }

        //
        // Сводка:
        //     Queries an array of floating-point numbers with OPC sync. After the response
        //     arrives, the method invokes the QueryWithOpcHandler. The response is available
        //     in the InstrEventArgs.Data as double[] array Handler prototype: void EventHandler(object
        //     sender, InstrEventArgs args) The numbers can be returned in ASCII format or in
        //     binary format.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryFloatNumbersFormat,
        //     usually float 32-bit (FORM REAL,32).
        public void QueryBinaryOrAsciiFloatArrayWithOpc(string query)
        {
            _core.IO.QueryWithOpcHandler = LocalHandler;
            _core.IO.QueryBinaryOrAsciiFloatArrayWithOpcEvent(query);
            void LocalHandler(object sender, InstrEventArgs e)
            {
                _core.IO.QueryWithOpcHandler = null;
                QueryWithOpcHandler?.Invoke(_core.Owner, e);
            }
        }

        //
        // Сводка:
        //     Queries an array of single floating-point numbers with OPC sync. After the response
        //     arrives, the method invokes the QueryWithOpcHandler. The response is available
        //     in the InstrEventArgs.Data as float[] array Handler prototype: void EventHandler(object
        //     sender, InstrEventArgs args) The numbers can be returned in ASCII format or in
        //     binary format.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryFloatNumbersFormat,
        //     usually float 32-bit (FORM REAL,32).
        public void QueryBinaryOrAsciiSingleFloatArrayWithOpc(string query)
        {
            _core.IO.QueryWithOpcHandler = LocalHandler;
            _core.IO.QueryBinaryOrAsciiSingleFloatArrayWithOpcEvent(query);
            void LocalHandler(object sender, InstrEventArgs e)
            {
                _core.IO.QueryWithOpcHandler = null;
                QueryWithOpcHandler?.Invoke(_core.Owner, e);
            }
        }

        //
        // Сводка:
        //     Queries an array of int32 numbers with OPC sync. After the response arrives,
        //     the method invokes the QueryWithOpcHandler. The response is available in the
        //     InstrEventArgs.Data as int[] array Handler prototype: void EventHandler(object
        //     sender, InstrEventArgs args) The numbers can be returned in ASCII format or in
        //     binary format.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryIntegerNumbersFormat,
        //     usually int 32-bit (FORM INT,32).
        public void QueryBinaryOrAsciiIntgerArrayWithOpc(string query)
        {
            _core.IO.QueryWithOpcHandler = LocalHandler;
            _core.IO.QueryBinaryOrAsciiIntegerArrayWithOpcEvent(query);
            void LocalHandler(object sender, InstrEventArgs e)
            {
                _core.IO.QueryWithOpcHandler = null;
                QueryWithOpcHandler?.Invoke(_core.Owner, e);
            }
        }
    }
}
