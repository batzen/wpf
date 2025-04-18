// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;

namespace MS.Internal
{
    /// <summary>
    /// General utility class for macro-type functions.
    /// </summary>
    internal static class Utilities
    {
        private static readonly Version _osVersion = Environment.OSVersion.Version;

        internal static bool IsOSVistaOrNewer
        {
            get { return _osVersion >= new Version(6, 0); }
        }

        internal static bool IsOSWindows7OrNewer
        {
            get { return _osVersion >= new Version(6, 1); }
        }

        internal static bool IsOSWindows8OrNewer
        {
            get { return _osVersion >= new Version(6, 2); }
        }
        
        internal static bool IsCompositionEnabled
        {
            get
            {
                if (!IsOSVistaOrNewer)
                {
                    return false;
                }

                PInvoke.DwmIsCompositionEnabled(out BOOL isDesktopCompositionEnabled).ThrowOnFailure();
                return isDesktopCompositionEnabled;
            }
        }

        internal static void SafeDispose<T>(ref T disposable) where T : IDisposable
        {
            // Dispose can safely be called on an object multiple times.
            IDisposable t = disposable;
            disposable = default(T);
            t?.Dispose();
        }
        
        internal static void SafeRelease<T>(ref T comObject) where T : class
        {
            T t = comObject;
            comObject = default(T);
            if (null != t)
            {
                Debug.Assert(Marshal.IsComObject(t));
                Marshal.ReleaseComObject(t);
            }
        }
    }
}
