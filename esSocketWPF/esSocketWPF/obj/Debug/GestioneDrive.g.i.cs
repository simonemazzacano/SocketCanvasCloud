﻿#pragma checksum "..\..\GestioneDrive.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DE617014FB9CBBDF8BA6E0B87A2891F646D956B8AA5774CE411A559B2E7BA813"
//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

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
using esSocketWPF;


namespace esSocketWPF {
    
    
    /// <summary>
    /// GestioneDrive
    /// </summary>
    public partial class GestioneDrive : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\GestioneDrive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstCaricati;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\GestioneDrive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCaricaCanvas;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\GestioneDrive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUsaSelezionato;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\GestioneDrive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNomeCanvas;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\GestioneDrive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkPersonalizza;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\GestioneDrive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/esSocketWPF;component/gestionedrive.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GestioneDrive.xaml"
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
            
            #line 8 "..\..\GestioneDrive.xaml"
            ((esSocketWPF.GestioneDrive)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.w_Chiusura);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lstCaricati = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.btnCaricaCanvas = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\GestioneDrive.xaml"
            this.btnCaricaCanvas.Click += new System.Windows.RoutedEventHandler(this.btnCaricaCanvas_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnUsaSelezionato = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\GestioneDrive.xaml"
            this.btnUsaSelezionato.Click += new System.Windows.RoutedEventHandler(this.btnUsaSelezionato_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtNomeCanvas = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.chkPersonalizza = ((System.Windows.Controls.CheckBox)(target));
            
            #line 18 "..\..\GestioneDrive.xaml"
            this.chkPersonalizza.Checked += new System.Windows.RoutedEventHandler(this.chkPersonalizza_Checked);
            
            #line default
            #line hidden
            
            #line 18 "..\..\GestioneDrive.xaml"
            this.chkPersonalizza.Unchecked += new System.Windows.RoutedEventHandler(this.chkPersonalizza_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnInfo = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\GestioneDrive.xaml"
            this.btnInfo.Click += new System.Windows.RoutedEventHandler(this.btnInfo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

