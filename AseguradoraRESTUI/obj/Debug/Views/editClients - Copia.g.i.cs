﻿#pragma checksum "..\..\..\Views\editClients - Copia.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "13DAAB351ACF7074FA9D8296E6E22A23"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AseguradoraRESTUI.Views;
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


namespace AseguradoraRESTUI.Views {
    
    
    /// <summary>
    /// editClients
    /// </summary>
    public partial class editClients : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Views\editClients - Copia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblID;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Views\editClients - Copia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboxID;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\editClients - Copia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDNI;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\editClients - Copia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDNI;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\editClients - Copia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblName;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\editClients - Copia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\editClients - Copia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAceptar;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\editClients - Copia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBorrar;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\editClients - Copia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/AseguradoraRESTUI;component/views/editclients%20-%20copia.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\editClients - Copia.xaml"
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
            
            #line 8 "..\..\..\Views\editClients - Copia.xaml"
            ((AseguradoraRESTUI.Views.editClients)(target)).Initialized += new System.EventHandler(this.editClient_initializated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblID = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.cboxID = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\Views\editClients - Copia.xaml"
            this.cboxID.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cboxIDChange);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblDNI = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txtDNI = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.lblName = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnAceptar = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Views\editClients - Copia.xaml"
            this.btnAceptar.Click += new System.Windows.RoutedEventHandler(this.btnAceptar_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnBorrar = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Views\editClients - Copia.xaml"
            this.btnBorrar.Click += new System.Windows.RoutedEventHandler(this.btnBorrar_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Views\editClients - Copia.xaml"
            this.btnCancelar.Click += new System.Windows.RoutedEventHandler(this.btnCancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

