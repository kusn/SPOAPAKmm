using System;
using System.IO;

namespace RSSigGen.RS
{
    public class InstrSegmentEventArgs : BaseInstrEventArgs
    {
        //
        // Сводка:
        //     Total size of the data. If unknown, the value is set to -1
        public long TotalSize;

        //
        // Сводка:
        //     Size of the data transferred so far
        public long TransferredSize;

        //
        // Сводка:
        //     Actual number of the segment (1-based)
        public int SegmentIx;

        //
        // Сводка:
        //     Size of one data segment
        public int SegmentSize;

        //
        // Сводка:
        //     For Query operations, this field contains the actual stream used to read the
        //     values
        public Stream DataStream;

        //
        // Сводка:
        //     Offset in the DataStream where the current segment data start
        public long SegmentDataOffset;

        //
        // Сводка:
        //     Signals true, if the transfer is finished
        public bool Finished;

        //
        // Сводка:
        //     Remaining size to transfer
        public long RemainingSize
        {
            get
            {
                if (TotalSize <= -1)
                {
                    return -1L;
                }

                return TotalSize - TransferredSize;
            }
        }

        //
        // Сводка:
        //     Initializes a new instance of the InstrChunkEventArgs class.
        public InstrSegmentEventArgs(string resourceName, DateTime startTimestamp)
            : base(resourceName)
        {
            base.StartTimestamp = startTimestamp;
            SetDuration();
        }

        //
        // Сводка:
        //     String representation of the class
        public override string ToString()
        {
            string text = base.ToString() + $", Segment {SegmentIx}: {SegmentSize} bytes, transferred total: {TransferredSize} bytes";
            if (TotalSize > 0)
            {
                text += $", remaining: {RemainingSize} bytes";
            }

            return text;
        }
    }
}
