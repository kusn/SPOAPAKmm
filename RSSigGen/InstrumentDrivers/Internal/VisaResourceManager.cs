using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSigGen.RS;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class VisaResourceManager
    {
        [Flags]
        protected enum TcpIpFindResourceModes
        {
            None = 0x0,
            ViConfig = 0x1,
            ViVxi11 = 0x2,
            ViMdns = 0x4
        }

        private readonly string _resourceName;

        //
        // Сводка:
        //     Resource Manager handle
        internal int Handle { get; private set; }

        //
        // Сводка:
        //     Visa Plugin
        internal VisaC Visac { get; private set; }

        //
        // Сводка:
        //     Visa Manufacturer String
        internal string VisaManufacturer { get; private set; }

        //
        // Сводка:
        //     Resource Manager is valid
        internal bool Valid => Handle > 0;

        internal bool Simulate { get; }

        //
        // Сводка:
        //     Standard Resource Manager
        //
        // Параметры:
        //   resourceName:
        //
        //   visaC:
        internal VisaResourceManager(string resourceName, VisaC visaC)
        {
            _resourceName = resourceName;
            Visac = visaC;
            Handle = 0;
            Simulate = false;
        }

        //
        // Сводка:
        //     Simulation Resource Manager
        internal VisaResourceManager(string resourceName, string visaManufacturer)
        {
            _resourceName = resourceName;
            VisaManufacturer = visaManufacturer;
            Visac = null;
            Handle = 1;
            Simulate = true;
        }

        //
        // Сводка:
        //     Direct Resource Manager, already openened
        internal VisaResourceManager(string resourceName, VisaC visaC, int handle)
            : this(resourceName, visaC)
        {
            Handle = handle;
            VisaManufacturer = _GetVisaManufacturer();
        }

        public override string ToString()
        {
            if (Simulate)
            {
                return "Visa Resource Manager (Simulation)";
            }

            return $"Visa Resource Manager Handle {Handle} (plugin {Visac.SelectedPlugin})";
        }

        //
        // Сводка:
        //     Opens the resource Manager and sets the: - Handle - VisaManufacturer
        internal void Open()
        {
            int rmSession;
            int status = Visac.OpenDefaultRm(out rmSession);
            _ThrowOnError(status, "Opening the Default VISA Resource Manager -");
            Handle = rmSession;
            VisaManufacturer = _GetVisaManufacturer();
        }

        //
        // Сводка:
        //     Closes the Resource Manager
        internal void Close()
        {
            Visac.Close(Handle);
        }

        //
        // Сводка:
        //     Error handler for all the VISA Exceptions
        //
        // Параметры:
        //   status:
        //     Return value from VISA functions
        //
        //   context:
        //     Additional optional text
        private void _ThrowOnError(int status, string context = "")
        {
            if (status >= 0)
            {
                return;
            }

            string text = context.Trim();
            text += $" VISA Resource Manager error: VISA manufacturer: {VisaManufacturer}, DLL: {Visac.VisaDllName}, error code 0x{status:X}: {_GetVISAStatusDesc(status)}";
            text = text.Trim();
            throw new VisaException(_resourceName, text);
        }

        //
        // Сводка:
        //     Sets new RmHandle
        //
        // Параметры:
        //   handle:
        internal void SetHandle(int handle)
        {
            Handle = handle;
        }

        //
        // Сводка:
        //     Converts the status code into human-readable message
        //
        // Параметры:
        //   status:
        //     Status code from VISA functions
        private string _GetVISAStatusDesc(int status)
        {
            byte[] array = new byte[256];
            Visac.StatusDesc(Handle, status, array);
            return Encoding.ASCII.GetString(array).TrimEnd('\0');
        }

        //
        // Сводка:
        //     Returns VISA manufacturer of the current Resource Manager
        private string _GetVisaManufacturer()
        {
            StringBuilder stringBuilder = new StringBuilder(256);
            int status = Visac.GetAttributeString(Handle, 3221160308u, stringBuilder);
            _ThrowOnError(status, "Get VISA Resource Manager Manufacturer Name -");
            return stringBuilder.ToString();
        }

        //
        // Сводка:
        //     Find all the resources fitting the search expression
        internal IEnumerable<string> FindResources(string expr, bool vxi11, bool lxi)
        {
            StringBuilder stringBuilder = new StringBuilder(1024);
            List<string> list = new List<string>();
            int vi = 0;
            TcpIpFindResourceModes tcpIpFindResourceModes = TcpIpFindResourceModes.ViConfig;
            tcpIpFindResourceModes |= (vxi11 ? TcpIpFindResourceModes.ViVxi11 : TcpIpFindResourceModes.None);
            tcpIpFindResourceModes |= (lxi ? TcpIpFindResourceModes.ViMdns : TcpIpFindResourceModes.None);
            int num = Visac.SetAttribute(Handle, 263127042u, (UIntPtr)(ulong)tcpIpFindResourceModes);
            if (num == -1073807331)
            {
                num = 0;
            }

            _ThrowOnError(num);
            try
            {
                num = Visac.FindRsrc(Handle, expr, out vi, out var retCount, stringBuilder);
                if (num == -1073807343)
                {
                    num = 0;
                    retCount = 0;
                }

                _ThrowOnError(num, "VISA Find Resource -");
                if (retCount > 0)
                {
                    list.Add(stringBuilder.ToString());
                }

                if (retCount > 1)
                {
                    while (retCount > 1)
                    {
                        StringBuilder stringBuilder2 = new StringBuilder(1024);
                        _ThrowOnError(Visac.FindNext(vi, stringBuilder2), "VISA Find Next Resource -");
                        list.Add(stringBuilder2.ToString());
                        retCount--;
                    }
                }

                Visac.Close(vi);
            }
            catch (VisaException)
            {
                if (vi > 0)
                {
                    Visac.Close(vi);
                }

                throw;
            }

            return list.Distinct().ToList();
        }
    }
}
