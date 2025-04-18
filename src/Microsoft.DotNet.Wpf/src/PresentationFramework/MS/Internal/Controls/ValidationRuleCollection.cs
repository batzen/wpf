// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

//
// Description: 
//     ValidationRulesCollection is a collection of ValidationRule
//     instances on either a Binding or a MultiBinding.  Each of the rules
//     is checked for validity on update
//
// See specs at Specs/Validation.mht
//


using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace MS.Internal.Controls
{
    /// <summary>
    ///     ValidationRulesCollection is a collection of ValidationRule
    ///     instances on either a Binding or a MultiBinding.  Each of the rules
    ///     is checked for validity on update
    /// </summary>
    internal class ValidationRuleCollection : Collection<ValidationRule>
    {
        //------------------------------------------------------
        //
        //  Protected Methods
        //
        //------------------------------------------------------

        #region Protected Methods

        /// <summary>
        /// called by base class Collection&lt;T&gt; when an item is added to list;
        /// raises a CollectionChanged event to any listeners
        /// </summary>
        protected override void InsertItem(int index, ValidationRule item)
        {
            ArgumentNullException.ThrowIfNull(item);
            base.InsertItem(index, item);
        }

        /// <summary>
        /// called by base class Collection&lt;T&gt; when an item is added to list;
        /// raises a CollectionChanged event to any listeners
        /// </summary>
        protected override void SetItem(int index, ValidationRule item)
        {
            ArgumentNullException.ThrowIfNull(item);
            base.SetItem(index, item);
        }

        #endregion Protected Methods
    }
}

