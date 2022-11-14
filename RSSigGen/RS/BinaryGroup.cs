using System.IO;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class BinaryGroup
    {
        private readonly Core _core;

        //
        // Сводка:
        //     Defines the coding of instrument's floating-point numbers in binary data Swapped
        //     means the endianness of the instrument is different from endianness of the Control
        //     PC
        public InstrBinaryFloatNumbersFormat FloatNumbersFormat
        {
            get
            {
                return _core.IO.BinFloatNumbersFormat;
            }
            set
            {
                _core.IO.BinFloatNumbersFormat = value;
            }
        }

        //
        // Сводка:
        //     Defines the coding of instrument's integer numbers in binary data Swapped means
        //     the endianness of the instrument is different from endianness of the Control
        //     PC
        public InstrBinaryIntegerNumbersFormat IntegerNumbersFormat
        {
            get
            {
                return _core.IO.BinIntegerNumbersFormat;
            }
            set
            {
                _core.IO.BinIntegerNumbersFormat = value;
            }
        }

        internal BinaryGroup(Core core)
        {
            _core = core;
        }

        //
        // Сводка:
        //     Writes all the data as binary data to the instrument It sends the entered command,
        //     followed by the constructed binary data header and the binaryData
        //     Exceptions: VisaException, VisaTimeoutException, InstrumentStatusException
        public void WriteData(string command, byte[] binaryData)
        {
            _core.IO.WriteBinaryData(command, binaryData);
        }

        //
        // Сводка:
        //     Writes all the data as binary data to the instrument It sends the entered command,
        //     followed by the constructed binary data header and the binary data from the stream
        //     Exceptions: VisaException, VisaTimeoutException, InstrumentStatusException
        public void WriteData(string command, Stream stream)
        {
            _core.IO.WriteBinaryData(command, stream);
        }

        //
        // Сводка:
        //     Queries binary data and returns it in the entered Stream
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public void QueryData(string query, Stream stream)
        {
            _core.IO.QueryBinaryData(query, stream);
        }

        //
        // Сводка:
        //     Queries binary data and returns it as byte array
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public byte[] QueryData(string query)
        {
            return _core.IO.QueryBinaryData(query);
        }

        //
        // Сводка:
        //     Query binary data with OPC synchronization. If timeoutMs is null, -1 or 0, the
        //     current Opc Timeout is used.
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, RsSmabException,
        //     InstrumentStatusException
        public byte[] QueryDataWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryBinaryDataWithOpc(query, timeoutMs);
        }

        //
        // Сводка:
        //     Query binary data with OPC synchronization and writes it to the provided stream.
        //     If timeoutMs is null, -1 or 0, the current Opc Timeout is used.
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, RsSmabException,
        //     InstrumentStatusException
        public void QueryDataWithOpc(string query, Stream stream, int? timeoutMs = null)
        {
            _core.IO.QueryBinaryDataWithOpc(query, stream, timeoutMs);
        }

        //
        // Сводка:
        //     Queries an array of floating-point numbers that can be returned in ASCII format
        //     or in binary format. The array is always returned as the most-universal double
        //     array.
        //     Exceptions: VisaException, VisaTimeoutException, InstrumentStatusException
        public double[] QueryBinOrAsciiFloatArray(string query)
        {
            return _core.IO.QueryBinaryOrAsciiFloatArray(query);
        }

        //
        // Сводка:
        //     Queries an array of floating-point numbers with OPC sync. If timeoutMs is null,
        //     -1 or 0, the current Opc Timeout is used. The numbers can be returned in ASCII
        //     format or in binary format. The array is always returned as the most-universal
        //     double array.
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, InstrumentStatusException
        public double[] QueryBinOrAsciiFloatArrayWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryBinaryOrAsciiFloatArrayWithOpc(query, timeoutMs);
        }

        //
        // Сводка:
        //     Queries an array of single floating-point numbers that can be returned in ASCII
        //     format or in binary format. The array is always returned as single float array.
        //     If the BinaryFloatNumbersFormat is Double8Bytes or Double8BytesSwapped, the method
        //     throws an exception.
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public float[] QueryBinOrAsciiSingleFloatArray(string query)
        {
            return _core.IO.QueryBinaryOrAsciiSingleFloatArray(query);
        }

        //
        // Сводка:
        //     Queries an array of single floating-point numbers with OPC sync. If timeoutMs
        //     is null, -1 or 0, the current Opc Timeout is used. The numbers can be returned
        //     in ASCII format or in binary format. The array is always returned as single float
        //     array. If the BinaryFloatNumbersFormat is Double8Bytes or Double8BytesSwapped,
        //     the method throws an exception.
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, RsSmabException,
        //     InstrumentStatusException
        public float[] QueryBinOrAsciiSingleFloatArrayWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryBinaryOrAsciiSingleFloatArrayWithOpc(query, timeoutMs);
        }

        //
        // Сводка:
        //     Queries an array of integer numbers that can be returned in ASCII format or in
        //     binary format. The array is always returned as the most-universal int32 array.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryIntegerNumbersFormat,
        //     usually int 32-bit (FORM INT,32).
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public int[] QueryBinOrAsciiIntegerArray(string query)
        {
            return _core.IO.QueryBinaryOrAsciiIntegerArray(query);
        }

        //
        // Сводка:
        //     Queries an array of integer numbers with OPC synchronization. If timeoutMs is
        //     null, -1 or 0, the current Opc Timeout is used. The numbers can be returned in
        //     ASCII format or in binary format. The array is always returned as the most-universal
        //     int32 array.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryIntegerNumbersFormat,
        //     usually int 32-bit (FORM INT,32).
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, RsSmabException,
        //     InstrumentStatusException
        public int[] QueryBinOrAsciiIntergerArrayWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryBinaryOrAsciiIntegerArrayWithOpc(query, timeoutMs);
        }
    }
}
