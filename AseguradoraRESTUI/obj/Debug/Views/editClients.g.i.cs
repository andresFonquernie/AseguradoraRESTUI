﻿#pragma checksum "..\..\..\Views\editClients.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2E3271A6650AEBDD5F1EA33825F2723C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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


namespace AseguradoraRESTUI {
    
    
    /// <summary>
    /// EditClients
    /// </summary>
    public partial class EditClients : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Views\editClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblId;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\editClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CboxId;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\editClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblDni;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Views\editClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtDni;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Views\editClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblName;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\editClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtName;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\editClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAceptar;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\editClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBorrar;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views\editClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/AseguradoraRESTUI;component/views/editclients.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\editClients.xaml"
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
            
            #line 7 "..\..\..\Views\editClients.xaml"
            ((AseguradoraRESTUI.EditClients)(target)).Initialized += new System.EventHandler(this.editClient_initializated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LblId = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.CboxId = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\..\Views\editClients.xaml"
            this.CboxId.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CboxIdChange);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LblDni = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.TxtDni = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.LblName = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.TxtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.BtnAceptar = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Views\editClients.xaml"
            this.BtnAceptar.Click += new System.Windows.RoutedEventHandler(this.btnAceptar_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnBorrar = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Views\editClients.xaml"
            this.BtnBorrar.Click += new System.Windows.RoutedEventHandler(this.btnBorrar_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Views\editClients.xaml"
            this.BtnCancelar.Click += new System.Windows.RoutedEventHandler(this.btnCancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

