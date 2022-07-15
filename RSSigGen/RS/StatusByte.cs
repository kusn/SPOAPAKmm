using System;

namespace RSSigGen.RS
{
    public enum StatusByte
    {
        //
        // Сводка:
        //     Null value
        None = 0x0,
        //
        // Сводка:
        //     Signals that the instrument's error queue contains at least one entry
        ErrorQueueNotEmpty = 0x4,
        //
        // Сводка:
        //     Summary of Questionable Status register
        QuestionableStatusReg = 0x8,
        //
        // Сводка:
        //     Instrument's output IO buffer is not empty
        MessageAvailable = 0x10,
        //
        // Сводка:
        //     Summary bit of Event Status Register filtered through the ESE byte
        EventStatusByte = 0x20,
        //
        // Сводка:
        //     Service request was triggered
        RequestService = 0x40,
        //
        // Сводка:
        //     Summary of Operation Status register
        OperationStatusReg = 0x80
    }
}
