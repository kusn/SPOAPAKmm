using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class VisaC
    {
        internal delegate int DelViOpenDefaultRm(out int rmSession);

        internal delegate int DelViFindRsrc(int rmSession, string expr, out int vi, out int retCount, StringBuilder desc);

        internal delegate int DelViFindNext(int rmSession, StringBuilder desc);

        internal delegate int DelViOpen(int rmSession, string resource, uint accessMode, uint timeOut, out int session);

        internal delegate int DelViClose(int session);

        internal delegate int DelViGetAttributeInt(int session, uint attrName, out UIntPtr attrValue);

        internal delegate int DelViGetAttributeString(int session, uint attrName, StringBuilder attrValue);

        internal delegate int DelViClear(int session);

        internal delegate int DelViWrite(int session, byte[] buffer, uint length, out uint written);

        internal delegate int DelViRead(int session, byte[] buffer, uint length, out uint read);

        internal delegate int DelViReadStb(int session, out uint status);

        internal delegate int DelViSetAttribute(int session, uint attrName, UIntPtr attrValue);

        internal delegate int DelViStatusDesc(int session, int status, byte[] buffer);

        internal delegate int DelViEnableEvent(int session, uint eventType, short mechanism, int context);

        internal delegate int DelViDisableEvent(int session, uint eventType, short mechanism);

        internal delegate int DelViDiscardEvents(int session, uint eventType, short mechanism);

        internal delegate int DelViWaitOnEvent(int session, uint inEventType, int timeout, out int outEventType, IntPtr outEventContext);

        internal delegate int DelViInstallHandler(int session, uint inEventType, EventHandler inHandler, int inUserHandle);

        internal delegate int DelViUninstallHandler(int vi, uint inEventType, EventHandler inHandler, int inUserHandle);

        internal delegate int EventHandler(int vi, uint inEventType, int inContext, int inUserHandle);

        //
        // Сводка:
        //     Wrapper for C - based Default VISA 32-bit
        internal static class VisaNative32
        {
            //
            // Сводка:
            //     VISA-C handler prototype
            internal const string VisaDllName = "Visa32.dll";

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viOpenDefaultRM(out int rmSession);

            [DllImport("Visa32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viFindRsrc(int rmSession, [MarshalAs(UnmanagedType.LPStr)] string expr, out int vi, out int retCount, StringBuilder desc);

            [DllImport("Visa32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viFindNext(int rmSession, StringBuilder desc);

            [DllImport("Visa32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viParseRsrcEx(int rmSession, [MarshalAs(UnmanagedType.LPStr)] string desc, out ushort intfType, out ushort intfNum, StringBuilder rsrcClass, StringBuilder expandedUnaliasedName, StringBuilder aliasIfExists);

            [DllImport("Visa32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viOpen(int rmSession, [MarshalAs(UnmanagedType.LPStr)] string resource, uint accessMode, uint timeOut, out int session);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viClose(int session);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viClear(int session);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viWrite(int session, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer, uint length, out uint written);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viRead(int session, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer, uint length, out uint read);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viReadSTB(int session, out uint status);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viSetAttribute(int session, uint attrName, UIntPtr attrValue);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viGetAttribute(int session, uint attrName, out UIntPtr attrValue);

            [DllImport("Visa32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ExactSpelling = true, ThrowOnUnmappableChar = true)]
            internal static extern int viGetAttribute(int session, uint attrName, [MarshalAs(UnmanagedType.LPStr)] StringBuilder attrValue);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viStatusDesc(int session, int status, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viEnableEvent(int session, uint eventType, short mechanism, int context);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viDisableEvent(int session, uint eventType, short mechanism);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viDiscardEvents(int session, uint eventType, short mechanism);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viWaitOnEvent(int session, uint inEventType, int timeout, out int outEventType, IntPtr outEventContext);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viInstallHandler(int session, uint inEventType, EventHandler inHandler, int inUserHandle);

            [DllImport("Visa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viUninstallHandler(int vi, uint inEventType, EventHandler inHandler, int inUserHandle);
        }

        //
        // Сводка:
        //     Wrapper for C - based Default VISA 64-bit
        internal static class VisaNative64
        {
            //
            // Сводка:
            //     VISA-C handler prototype
            internal const string VisaDllName = "Visa64.dll";

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viOpenDefaultRM(out int rmSession);

            [DllImport("Visa64.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viFindRsrc(int rmSession, [MarshalAs(UnmanagedType.LPStr)] string expr, out int vi, out int retCount, StringBuilder desc);

            [DllImport("Visa64.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viFindNext(int rmSession, StringBuilder desc);

            [DllImport("Visa64.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viParseRsrcEx(int rmSession, [MarshalAs(UnmanagedType.LPStr)] string desc, out ushort intfType, out ushort intfNum, StringBuilder rsrcClass, StringBuilder expandedUnaliasedName, StringBuilder aliasIfExists);

            [DllImport("Visa64.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viOpen(int rmSession, [MarshalAs(UnmanagedType.LPStr)] string resource, uint accessMode, uint timeOut, out int session);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viClose(int session);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viClear(int session);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viWrite(int session, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer, uint length, out uint written);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viRead(int session, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer, uint length, out uint read);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viReadSTB(int session, out uint status);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viSetAttribute(int session, uint attrName, UIntPtr attrValue);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viGetAttribute(int session, uint attrName, out UIntPtr attrValue);

            [DllImport("Visa64.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ExactSpelling = true, ThrowOnUnmappableChar = true)]
            internal static extern int viGetAttribute(int session, uint attrName, [MarshalAs(UnmanagedType.LPStr)] StringBuilder attrValue);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viStatusDesc(int session, int status, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viEnableEvent(int session, uint eventType, short mechanism, int context);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viDisableEvent(int session, uint eventType, short mechanism);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viDiscardEvents(int session, uint eventType, short mechanism);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viWaitOnEvent(int session, uint inEventType, int timeout, out int outEventType, IntPtr outEventContext);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viInstallHandler(int session, uint inEventType, EventHandler inHandler, int inUserHandle);

            [DllImport("Visa64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viUninstallHandler(int vi, uint inEventType, EventHandler inHandler, int inUserHandle);
        }

        //
        // Сводка:
        //     Wrapper for C - based RohdeSchwarz Visa 32/64-bit
        internal static class RsVisaNative
        {
            //
            // Сводка:
            //     VISA-C handler prototype
            internal const string VisaDllName = "RsVisa32.dll";

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int Dummy();

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viOpenDefaultRM(out int rmSession);

            [DllImport("RsVisa32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viFindRsrc(int rmSession, [MarshalAs(UnmanagedType.LPStr)] string expr, out int vi, out int retCount, StringBuilder desc);

            [DllImport("RsVisa32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viFindNext(int rmSession, StringBuilder desc);

            [DllImport("RsVisa32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viParseRsrcEx(int rmSession, [MarshalAs(UnmanagedType.LPStr)] string desc, out ushort intfType, out ushort intfNum, StringBuilder rsrcClass, StringBuilder expandedUnaliasedName, StringBuilder aliasIfExists);

            [DllImport("RsVisa32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ThrowOnUnmappableChar = true)]
            internal static extern int viOpen(int rmSession, [MarshalAs(UnmanagedType.LPStr)] string resource, uint accessMode, uint timeOut, out int session);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viClose(int session);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viClear(int session);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viWrite(int session, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer, uint length, out uint written);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viRead(int session, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer, uint length, out uint read);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viReadSTB(int session, out uint status);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viSetAttribute(int session, uint attrName, UIntPtr attrValue);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viGetAttribute(int session, uint attrName, out UIntPtr attrValue);

            [DllImport("RsVisa32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ExactSpelling = true, ThrowOnUnmappableChar = true)]
            internal static extern int viGetAttribute(int session, uint attrName, [MarshalAs(UnmanagedType.LPStr)] StringBuilder attrValue);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viStatusDesc(int session, int status, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viEnableEvent(int session, uint eventType, short mechanism, int context);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viDisableEvent(int session, uint eventType, short mechanism);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viDiscardEvents(int session, uint eventType, short mechanism);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viWaitOnEvent(int session, uint inEventType, int timeout, out int outEventType, IntPtr outEventContext);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viInstallHandler(int session, uint inEventType, EventHandler inHandler, int inUserHandle);

            [DllImport("RsVisa32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
            internal static extern int viUninstallHandler(int vi, uint inEventType, EventHandler inHandler, int inUserHandle);
        }

        internal DelViOpenDefaultRm OpenDefaultRm;

        internal DelViFindRsrc FindRsrc;

        internal DelViFindNext FindNext;

        internal DelViOpen Open;

        internal DelViClose Close;

        internal DelViGetAttributeInt GetAttributeInt;

        internal DelViGetAttributeString GetAttributeString;

        internal DelViClear Clear;

        internal DelViWrite Write;

        internal DelViRead Read;

        internal DelViReadStb ReadStb;

        internal DelViSetAttribute SetAttribute;

        internal DelViStatusDesc StatusDesc;

        internal DelViEnableEvent EnableEvent;

        internal DelViDisableEvent DisableEvent;

        internal DelViDiscardEvents DiscardEvents;

        internal DelViWaitOnEvent WaitOnEvent;

        internal DelViInstallHandler InstallHandler;

        internal DelViUninstallHandler UninstallHandler;

        //
        // Сводка:
        //     Returns the currently selected VISA plugin
        internal VisaPlugin SelectedPlugin { get; private set; }

        //
        // Сводка:
        //     Returns loaded VISA library name
        internal string VisaDllName { get; private set; }

        //
        // Сводка:
        //     Prepares native VISA to use If plugin is non-null, the VISA plugin is used instead
        //     of the VISA implementation This allows for no underlying VISA-C installation
        //     Supported plugins: - NativeVisa (default) - RsVisa - force RsVisa use. If not
        //     found, throw exception - PreferRsVisa - prefer RsVisa use. If not found, switch
        //     to NativeVisa - SocketIo
        internal VisaC(VisaPlugin plugin)
        {
            switch (plugin)
            {
                case VisaPlugin.RsVisa:
                    SelectRsVisa();
                    break;
                case VisaPlugin.RsVisaPrio:
                    if (RsVisaExist())
                    {
                        SelectRsVisa();
                    }
                    else
                    {
                        SelectNativeVisa();
                    }

                    break;
                case VisaPlugin.SocketIo:
                    SelectSocketIo();
                    break;
                default:
                    SelectNativeVisa();
                    break;
            }
        }

        public override string ToString()
        {
            return VisaDllName;
        }

        //
        // Сводка:
        //     Returns true, if the RsVisa is available (installed)
        internal bool RsVisaExist()
        {
            bool result = true;
            try
            {
                RsVisaNative.Dummy();
                return result;
            }
            catch (DllNotFoundException)
            {
                return false;
            }
            catch (EntryPointNotFoundException)
            {
                return result;
            }
        }

        //
        // Сводка:
        //     Selects VisaNative assembly either 32-bit or 64-bit
        internal void SelectNativeVisa()
        {
            SelectedPlugin = VisaPlugin.NativeVisa;
            if (Environment.Is64BitProcess)
            {
                VisaDllName = "Visa64.dll (64-bit)";
                OpenDefaultRm = VisaNative64.viOpenDefaultRM;
                FindRsrc = VisaNative64.viFindRsrc;
                FindNext = VisaNative64.viFindNext;
                Open = VisaNative64.viOpen;
                Close = VisaNative64.viClose;
                GetAttributeInt = VisaNative64.viGetAttribute;
                GetAttributeString = VisaNative64.viGetAttribute;
                Clear = VisaNative64.viClear;
                Write = VisaNative64.viWrite;
                Read = VisaNative64.viRead;
                ReadStb = VisaNative64.viReadSTB;
                SetAttribute = VisaNative64.viSetAttribute;
                StatusDesc = VisaNative64.viStatusDesc;
                EnableEvent = VisaNative64.viEnableEvent;
                DisableEvent = VisaNative64.viDisableEvent;
                DiscardEvents = VisaNative64.viDiscardEvents;
                WaitOnEvent = VisaNative64.viWaitOnEvent;
                InstallHandler = VisaNative64.viInstallHandler;
                UninstallHandler = VisaNative64.viUninstallHandler;
            }
            else
            {
                VisaDllName = "Visa32.dll (32-bit)";
                OpenDefaultRm = VisaNative32.viOpenDefaultRM;
                FindRsrc = VisaNative32.viFindRsrc;
                FindNext = VisaNative32.viFindNext;
                Open = VisaNative32.viOpen;
                Close = VisaNative32.viClose;
                GetAttributeInt = VisaNative32.viGetAttribute;
                GetAttributeString = VisaNative32.viGetAttribute;
                Clear = VisaNative32.viClear;
                Write = VisaNative32.viWrite;
                Read = VisaNative32.viRead;
                ReadStb = VisaNative32.viReadSTB;
                SetAttribute = VisaNative32.viSetAttribute;
                StatusDesc = VisaNative32.viStatusDesc;
                EnableEvent = VisaNative32.viEnableEvent;
                DisableEvent = VisaNative32.viDisableEvent;
                DiscardEvents = VisaNative32.viDiscardEvents;
                WaitOnEvent = VisaNative32.viWaitOnEvent;
                InstallHandler = VisaNative32.viInstallHandler;
                UninstallHandler = VisaNative32.viUninstallHandler;
            }
        }

        //
        // Сводка:
        //     Selects RsVisa assembly
        internal void SelectRsVisa()
        {
            SelectedPlugin = VisaPlugin.RsVisa;
            if (Environment.Is64BitProcess)
            {
                VisaDllName = "RsVisa32.dll (64-bit)";
            }
            else
            {
                VisaDllName = "RsVisa32.dll (32-bit)";
            }

            OpenDefaultRm = RsVisaNative.viOpenDefaultRM;
            FindRsrc = RsVisaNative.viFindRsrc;
            FindNext = RsVisaNative.viFindNext;
            Open = RsVisaNative.viOpen;
            Close = RsVisaNative.viClose;
            GetAttributeInt = RsVisaNative.viGetAttribute;
            GetAttributeString = RsVisaNative.viGetAttribute;
            Clear = RsVisaNative.viClear;
            Write = RsVisaNative.viWrite;
            Read = RsVisaNative.viRead;
            ReadStb = RsVisaNative.viReadSTB;
            SetAttribute = RsVisaNative.viSetAttribute;
            StatusDesc = RsVisaNative.viStatusDesc;
            EnableEvent = RsVisaNative.viEnableEvent;
            DisableEvent = RsVisaNative.viDisableEvent;
            DiscardEvents = RsVisaNative.viDiscardEvents;
            WaitOnEvent = RsVisaNative.viWaitOnEvent;
            InstallHandler = RsVisaNative.viInstallHandler;
            UninstallHandler = RsVisaNative.viUninstallHandler;
        }

        internal void SelectSocketIo()
        {
            SelectedPlugin = VisaPlugin.SocketIo;
            VisaDllName = "SocketIO";
            OpenDefaultRm = SocketIo.viOpenDefaultRM;
            FindRsrc = SocketIo.viFindRsrc;
            FindNext = SocketIo.viFindNext;
            Open = SocketIo.viOpen;
            Close = SocketIo.viClose;
            SetAttribute = SocketIo.viSetAttribute;
            StatusDesc = SocketIo.viStatusDesc;
            GetAttributeInt = SocketIo.viGetAttribute;
            GetAttributeString = SocketIo.viGetAttribute;
            Clear = SocketIo.viClear;
            Write = SocketIo.viWrite;
            Read = SocketIo.viRead;
            ReadStb = null;
            EnableEvent = null;
            DisableEvent = null;
            DiscardEvents = null;
            WaitOnEvent = null;
            InstallHandler = null;
            UninstallHandler = null;
        }

        //
        // Сводка:
        //     Converts Visa plugin string to the plugin enum
        internal static VisaPlugin StringToPlugin(string visaPlugin)
        {
            if (string.IsNullOrEmpty(visaPlugin))
            {
                return VisaPlugin.NativeVisa;
            }

            switch (visaPlugin.ToLower())
            {
                case "socketio":
                    return VisaPlugin.SocketIo;
                case "rsvisa":
                    return VisaPlugin.RsVisa;
                case "rsvisaprio":
                    return VisaPlugin.RsVisaPrio;
                case "undefined":
                    return VisaPlugin.Undefined;
                case "nativevisa":
                case "default":
                case "defaultvisa":
                    return VisaPlugin.NativeVisa;
                default:
                    return VisaPlugin.Unknown;
            }
        }
    }
}
