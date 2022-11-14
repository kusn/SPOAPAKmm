using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Power_Reference_Data commands group definition
    //     Sub-classes count: 0
    //     Commands count: 4
    //     Total commands count: 4
    public class RsSmab_Sense_Power_Sweep_Power_Reference_Data
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:REFerence:DATA:POINts
        //     Queries the number of points from the reference curve in "Power" measurement.
        //     points: integer Range: 10 to 1000
        public int Points => _grpBase.IO.QueryInt32("SENSe:POWer:SWEep:POWer:REFerence:DATA:POINts?");

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:REFerence:DATA:XVALues
        //     Sets or queries the x values of the two reference points, i.e. "Power X (Point
        //     A) " and "Power X (Point B) " in "Power" measurement.
        //     xvalues: string
        public List<double> Xvalues
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SENSe:POWer:SWEep:POWer:REFerence:DATA:XVALues?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:POWer:REFerence:DATA:XVALues " + value.ToCsvString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:REFerence:DATA:YVALues
        //     Sets or queries the y values of the two reference points, i.e. "Power Y (Point
        //     A) " and "Power Y (Point B) " in "Power" measurement.
        //     yvalues: string
        public List<double> Yvalues
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SENSe:POWer:SWEep:POWer:REFerence:DATA:YVALues?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:POWer:REFerence:DATA:YVALues " + value.ToCsvString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Power_Reference_Data(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Data", core, parent);
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:REFerence:DATA:COPY
        //     Generates a reference curve for "Power" measurement.
        public void Copy()
        {
            _grpBase.IO.Write("SENSe:POWer:SWEep:POWer:REFerence:DATA:COPY");
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:REFerence:DATA:COPY
        //     Same as Copy, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void CopyAndWait()
        {
            CopyAndWait(-1);
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:REFerence:DATA:COPY
        //     Same as Copy, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void CopyAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SENSe:POWer:SWEep:POWer:REFerence:DATA:COPY", opcTimeoutMs);
        }
    }
}
