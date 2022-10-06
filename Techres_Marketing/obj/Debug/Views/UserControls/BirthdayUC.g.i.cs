﻿#pragma checksum "..\..\..\..\Views\UserControls\BirthdayUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E96B10E5182816BE8ED70B4F38F6736C58167299B95E840344C5A540A702C9AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
using FontAwesome.Sharp;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Techres_Marketing.Views.UserControls;


namespace Techres_Marketing.Views.UserControls {
    
    
    /// <summary>
    /// BirthdayUC
    /// </summary>
    public partial class BirthdayUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Techres_Marketing.Views.UserControls.BirthdayUC birthDayUserControl;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFontTitle;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTest;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement VideoPlayer;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement mePlayer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Techres_Marketing;component/views/usercontrols/birthdayuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.birthDayUserControl = ((Techres_Marketing.Views.UserControls.BirthdayUC)(target));
            return;
            case 2:
            this.cbFontTitle = ((System.Windows.Controls.ComboBox)(target));
            
            #line 46 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
            this.cbFontTitle.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.cbFontTitle_TextChanged));
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 49 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbTest = ((System.Windows.Controls.ComboBox)(target));
            
            #line 82 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
            this.cbTest.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.cbTest_TextChanged));
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 85 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 114 "..\..\..\..\Views\UserControls\BirthdayUC.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 7:
            this.VideoPlayer = ((System.Windows.Controls.MediaElement)(target));
            return;
            case 8:
            this.mePlayer = ((System.Windows.Controls.MediaElement)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
