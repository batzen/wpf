// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace MS.Internal
{
    internal abstract class SystemXmlLinqExtensionMethods
    {
        // return true if the item is an XElement
        internal abstract bool IsXElement(object item);

        // return a string of the form "{http://my.namespace}TagName"
        internal abstract string GetXElementTagName(object item);

        // XLinq exposes two synthetic properties - Elements and Descendants -
        // on XElement that return IEnumerable<XElement>.  We handle these specially
        // to work around problems involving identity and change notifications
        internal abstract bool IsXLinqCollectionProperty(PropertyDescriptor pd);

        // XLinq exposes several properties on XElement that create new objects
        // every time the getter is called.
        internal abstract bool IsXLinqNonIdempotentProperty(PropertyDescriptor pd);
    }
}
