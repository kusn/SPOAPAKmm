using RohdeSchwarz.RsFsw;
//using RohdeSchwarz.RsSmab;
using System;
using System.Collections.Generic;
using RSSigGen.RS;

namespace TestConsoleApp
{
    internal class Program
    { 
        public static void Main(String[] args)
        {
            //StartSpecAn();
            StartSignalGenerator();
        }

        private static void StartSpecAn()
        {
            var fsw = new RsFsw("GPIB0::20::INSTR", true, true);
            //var fsw = new RsFsw("TCPIP::192.168.1.102::INSTR", true, true, "SelectVisa=RsVisa"); // Forcing R&S VISA
            //var fsw = new RsFsw("TCPIP::192.168.1.102::5025::SOCKET", true, true, "SelectVisa=SocketIo"); // No VISA installation needed
            Console.WriteLine("Driver Info: " + fsw.Utilities.Identification.DriverVersion);
            Console.WriteLine("Instrument: " + fsw.Utilities.Identification.IdnString);
            Console.WriteLine("Instrument options: " + string.Join(",", fsw.Utilities.Identification.InstrumentOptions));

            // Driver's instrument status checking ( SYST:ERR? ) after each command (default value is true):
            fsw.Utilities.InstrumentStatusChecking = true;

            //  SYSTem:DISPlay:UPDate ON
            fsw.System.Display.Update.Set(true);

            //  INITiate:CONTinuous OFF
            fsw.Initiate.Continuous.Set(false);
            Console.WriteLine("Always work in single-sweep mode.");

            //  SENSe.FREQuency:STARt 100000000
            fsw.Sense.Frequency.Start.Set(100E6);

            //  SENSe.FREQuency:STOP 200000000
            fsw.Sense.Frequency.Stop.Set(200E6);

            //  DISPlay:WINDow:TRACe:Y:SCALe:RLEVel -20.0
            fsw.Display.Window.Trace.Y.Scale.RefLevel.Set(-20.0);

            //  DISPlay:WINDow:SUBWindow:TRACe:Y:SCALe 60.0
            fsw.Display.Window.Subwindow.Trace.Y.Scale.Set(60.0);

            //  DISPlay1:WINDow:SUBWindow:TRACe1:MODE MAXHold
            fsw.Display.Window.Subwindow.Trace.Mode.Set(TraceModeCenum.MAXHold, WindowRepCap.Nr1, SubWindowRepCap.Default, RohdeSchwarz.RsFsw.TraceRepCap.Tr1);

            //  DISPlay1:WINDow:SUBWindow:TRACe2:MODE MINHold
            fsw.Display.Window.Subwindow.Trace.Mode.Set(TraceModeCenum.MINHold, WindowRepCap.Nr1, SubWindowRepCap.Default, RohdeSchwarz.RsFsw.TraceRepCap.Tr2);

            //  SENSe:SWEep:POINts 10001
            fsw.Sense.Sweep.Points.Set(10001);

            //  INITiate:IMMediate (with timeout 3000 ms)
            fsw.Initiate.ImmediateAndWait(3000);

            //                        TRACe1:DATA?
            List<double> trace1 = fsw.Trace.Data.Get(TraceNumberEnum.TRACe1);

            //                        TRACe2:DATA?
            List<double> trace2 = fsw.Trace.Data.Get(TraceNumberEnum.TRACe2);

            //  CALCulate1:MARKer1:TRACe 1
            fsw.Calculate.Marker.Trace.Set(1, WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);

            //  CALCulate1:MARKer1:MAXimum:PEAK
            fsw.Calculate.Marker.Maximum.Peak.Set(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);
            //               CALCulate1:MARKer1:X?
            double m1x = fsw.Calculate.Marker.X.Get(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);

            //               CALCulate1:MARKer1:Y?
            double m1y = fsw.Calculate.Marker.Y.Get(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);

            Console.WriteLine($"Trace 1 points: {trace1.Count}");
            Console.WriteLine($"Trace 1 Marker 1: {m1x} Hz, {m1y:F2} dBm");

            //  CALCulate1:MARKer2:TRACe 2
            fsw.Calculate.Marker.Trace.Set(2, WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr2);

            //  CALCulate1:MARKer2:MINimum:PEAK
            fsw.Calculate.Marker.Minimum.Peak.Set(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr2);

            //               CALCulate2:MARKer2:X?
            double m2x = fsw.Calculate.Marker.X.Get(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr2);

            //               CALCulate2:MARKer2:Y?
            double m2y = fsw.Calculate.Marker.Y.Get(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr2);

            Console.WriteLine($"Trace 2 points: {trace2.Count}");
            Console.WriteLine($"Trace 2 Marker 2: {m2x} Hz, {m2y:F2} dBm");

            // Close the session
            fsw.Dispose();

            Console.WriteLine("\nPress any key");
            Console.ReadKey();
        }

        private static void StartSignalGenerator()
        {
            var smab = new RsSmab("GPIB1::28::INSTR", true, true);
            //var smab = new RsSmab("TCPIP::10.112.1.73::INSTR", true, true, "SelectVisa=RsVisa"); // Forcing R&S VISA
            //var smab = new RsSmab("TCPIP::10.112.1.73::5025::SOCKET", true, true, "SelectVisa=SocketIo"); // No VISA needed
            Console.WriteLine("Driver Info: " + smab.Utilities.Identification.DriverVersion);
            Console.WriteLine($"Selected Visa: {smab.Utilities.Identification.VisaManufacturer}, DLL: {smab.Utilities.Identification.VisaDllName}");
            Console.WriteLine("Instrument: " + smab.Utilities.Identification.IdnString);
            Console.WriteLine("Instrument options: " + string.Join(",", smab.Utilities.Identification.InstrumentOptions));

            // Driver's instrument status checking ( SYST:ERR? ) after each command (default value is true):
            smab.Utilities.InstrumentStatusChecking = true;
            smab.Utilities.Reset();

            // Set the output -21.3 dBm, 224 MHz
            smab.Output.State.Value = true;
            smab.Source.Power.Level.Immediate.Amplitude = -21.3;
            smab.Source.Frequency.Fixed.Value = 234E6;
            smab.Output.State.Value = false;

            // Direct SCPI interface:
            var response = smab.Utilities.QueryString("*IDN?");
            Console.WriteLine($"Direct SCPI response on *IDN?: {response}");

            // Closing the session
            smab.Dispose();

            Console.Write("\n\nPress any key...");
            Console.ReadKey();
        }
    }
}
