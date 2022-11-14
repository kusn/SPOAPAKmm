using System;
using System.Globalization;

namespace RSSigGen.RS
{
    public class BaseInstrEventArgs : EventArgs
    {
        //
        // Сводка:
        //     Resource name of the session that generated the event
        public string ResourceName { get; }

        //
        // Сводка:
        //     Context of the event. Usually the sent SCPI command.
        public string Context { get; set; }

        //
        // Сводка:
        //     Time of beginning of the operation
        public DateTime StartTimestamp { get; set; }

        //
        // Сводка:
        //     Duration of the operation
        public TimeSpan Duration { get; private set; }

        //
        // Сводка:
        //     Initializes a new instance of the InstrEventArgs class.
        internal BaseInstrEventArgs(string resourceName)
        {
            ResourceName = resourceName;
            Duration = TimeSpan.Zero;
        }

        //
        // Сводка:
        //     String representation of the class
        public override string ToString()
        {
            string text = "EventArgs '" + ResourceName + "'";
            if (Context != null)
            {
                text = text + ", context: " + Context;
            }

            if (Duration != TimeSpan.Zero)
            {
                text += string.Format(CultureInfo.InvariantCulture, ", duration: {0:F4} secs", Duration.TotalSeconds);
            }

            return text;
        }

        //
        // Сводка:
        //     Sets duration of the event operation as TimeSpan
        public void SetDuration(TimeSpan duration)
        {
            Duration = duration;
        }

        //
        // Сводка:
        //     Sets duration of the event operation by calculating it from the entered time
        //     and the StartTimestamp
        public void SetDuration(DateTime time)
        {
            Duration = time - StartTimestamp;
        }

        //
        // Сводка:
        //     Sets duration of the event operation by calculating it from the time now and
        //     the StartTimestamp
        public void SetDuration()
        {
            Duration = DateTime.Now - StartTimestamp;
        }
    }
}
