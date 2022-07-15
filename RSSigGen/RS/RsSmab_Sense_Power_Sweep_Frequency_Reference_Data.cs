using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Frequency_Reference_Data commands group definition
    //     Sub-classes count: 0
    //     Commands count: 4
    //     Total commands count: 4
    public class RsSmab_Sense_Power_Sweep_Frequency_Reference_Data
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:REFerence:DATA:POINts
        //     Queries the number of points from the reference curve in "Frequency" measurement.
        //     points: integer Range: 10 to 1000
        public int Points => _grpBase.IO.QueryInt32("SENSe:POWer:SWEep:FREQuency:REFerence:DATA:POINts?");

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:REFerence:DATA:XVALues
        //     Sets or queries the x values of the two reference points, i.e. "Frequency X (Point
        //     A) " and "Frequency X (Point B) " in "Frequency" measurement.
        //     xvalues: string
        public List<double> Xvalues
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SENSe:POWer:SWEep:FREQuency:REFerence:DATA:XVALues?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:FREQuency:REFerence:DATA:XVALues " + value.ToCsvString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:REFerence:DATA:YVALues
        //     Sets or queries the y values of the two reference points, i.e."Pow Y (Point A)
        //     " and "Power Y (Point B) " in "Frequency" measurement.
        //     yvalues: string
        public List<double> Yvalues
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SENSe:POWer:SWEep:FREQuency:REFerence:DATA:YVALues?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:FREQuency:REFerence:DATA:YVALues " + value.ToCsvString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Frequency_Reference_Data(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Data", core, parent);
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:REFerence:DATA:COPY
        //     Generates a reference curve for "Frequency" measurement.
        public void Copy()
        {
            _grpBase.IO.Write("SENSe:POWer:SWEep:FREQuency:REFerence:DATA:COPY");
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:REFerence:DATA:COPY
        //     Same as Copy, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void CopyAndWait()
        {
            CopyAndWait(-1);
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:REFerence:DATA:COPY
        //     Same as Copy, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void CopyAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SENSe:POWer:SWEep:FREQuency:REFerence:DATA:COPY", opcTimeoutMs);
        }
    }
}
