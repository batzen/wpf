// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable

using System.Reflection;

namespace System.Xaml
{
    public class XamlReaderSettings
    {
        public bool AllowProtectedMembersOnRoot { get; set; }
        public bool ProvideLineInfo { get; set; }
        public Uri BaseUri { get; set; }
        public Assembly LocalAssembly { get; set; }
        public bool IgnoreUidsOnPropertyElements { get; set; }
        public bool ValuesMustBeString { get; set; }

        public XamlReaderSettings()
        {
            InitializeProvideLineInfo();
        }

        public XamlReaderSettings(XamlReaderSettings settings) : this()
        {
            if (settings is not null)
            {
                AllowProtectedMembersOnRoot = settings.AllowProtectedMembersOnRoot;
                ProvideLineInfo = settings.ProvideLineInfo;
                BaseUri = settings.BaseUri;
                LocalAssembly = settings.LocalAssembly;
                IgnoreUidsOnPropertyElements = settings.IgnoreUidsOnPropertyElements;
                ValuesMustBeString = settings.ValuesMustBeString;
            }
        }

        private void InitializeProvideLineInfo()
        {
            // By default, _provideLineInfo is true if the currently executing process is running in debug mode
            if (Debugger.IsAttached)
            {
                ProvideLineInfo = true;
            }
            else
            {
                ProvideLineInfo = false;
            }
        }
    }
}
