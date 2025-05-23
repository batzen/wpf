﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace System.Windows.Automation.Peers
{
    ///
    public class RadioButtonAutomationPeer : ToggleButtonAutomationPeer, ISelectionItemProvider
    {
        ///
        public RadioButtonAutomationPeer(RadioButton owner): base(owner)
        {}

        ///
        protected override string GetClassNameCore()
        {
            return "RadioButton";
        }

        ///
        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.RadioButton;
        }

        ///
        public override object GetPattern(PatternInterface patternInterface)
        {
            if (patternInterface == PatternInterface.SelectionItem)
            {
                return this;
            }
            else if(patternInterface == PatternInterface.SynchronizedInput)
            {
                return base.GetPattern(patternInterface);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the current element as the selection
        /// This clears the selection from other elements in the container
        /// </summary>
        void ISelectionItemProvider.Select()
        {
            if (!IsEnabled())
                throw new ElementNotEnabledException();

            ((RadioButton)Owner).SetCurrentValueInternal(RadioButton.IsCheckedProperty, MS.Internal.KnownBoxes.BooleanBoxes.TrueBox);
        }


        /// <summary>
        /// Adds current element to selection
        /// </summary>
        void ISelectionItemProvider.AddToSelection()
        {
            if (((RadioButton)Owner).IsChecked != true)
                throw new InvalidOperationException(SR.UIA_OperationCannotBePerformed);
        }


        /// <summary>
        /// Removes current element from selection
        /// </summary>
        void ISelectionItemProvider.RemoveFromSelection()
        {
            // If RadioButton is checked - RemoveFromSelection is invalid operation
            if (((RadioButton)Owner).IsChecked == true)
                throw new InvalidOperationException(SR.UIA_OperationCannotBePerformed);
        }


        /// <summary>
        /// Check whether an element is selected
        /// </summary>
        /// <value>returns true if the element is selected</value>
        bool ISelectionItemProvider.IsSelected
        {
            get
            {
                return ((RadioButton)Owner).IsChecked == true;
            }
        }


        /// <summary>
        /// The logical element that supports the SelectionPattern for this Item
        /// </summary>
        /// <value>returns an IRawElementProviderSimple</value>
        IRawElementProviderSimple ISelectionItemProvider.SelectionContainer
        {
            get
            {
                return null;
            }
        }

        // BUG 1555137: Never inline, as we don't want to unnecessarily link the automation DLL
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        internal override void RaiseToggleStatePropertyChangedEvent(bool? oldValue, bool? newValue)
        {
            RaisePropertyChangedEvent(
                SelectionItemPatternIdentifiers.IsSelectedProperty,
                oldValue == true,
                newValue == true);
        }
    }
}

