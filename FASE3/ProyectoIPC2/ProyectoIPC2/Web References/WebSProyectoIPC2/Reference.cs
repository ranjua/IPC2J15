﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34209
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.34209.
// 
#pragma warning disable 1591

namespace ProyectoIPC2.WebSProyectoIPC2 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ProyectoIPC2Soap", Namespace="http://tempuri.org/")]
    public partial class ProyectoIPC2 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback FechaOperationCompleted;
        
        private System.Threading.SendOrPostCallback RegistrarOperationCompleted;
        
        private System.Threading.SendOrPostCallback VerificacionPassOperationCompleted;
        
        private System.Threading.SendOrPostCallback getCodLoteOperationCompleted;
        
        private System.Threading.SendOrPostCallback Agregar_EmpleadoOperationCompleted;
        
        private System.Threading.SendOrPostCallback Reporte_Paquete_ImpuestoOperationCompleted;
        
        private System.Threading.SendOrPostCallback Reporte_Paquete_SucursalOperationCompleted;
        
        private System.Threading.SendOrPostCallback Reporte_EmpleadosOperationCompleted;
        
        private System.Threading.SendOrPostCallback Reporte_EmpleadosDepOperationCompleted;
        
        private System.Threading.SendOrPostCallback Reporte_Top5_ImpuestosOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ProyectoIPC2() {
            this.Url = global::ProyectoIPC2.Properties.Settings.Default.ProyectoIPC2_ProyectoIPC2_ProyectoIPC2;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event FechaCompletedEventHandler FechaCompleted;
        
        /// <remarks/>
        public event RegistrarCompletedEventHandler RegistrarCompleted;
        
        /// <remarks/>
        public event VerificacionPassCompletedEventHandler VerificacionPassCompleted;
        
        /// <remarks/>
        public event getCodLoteCompletedEventHandler getCodLoteCompleted;
        
        /// <remarks/>
        public event Agregar_EmpleadoCompletedEventHandler Agregar_EmpleadoCompleted;
        
        /// <remarks/>
        public event Reporte_Paquete_ImpuestoCompletedEventHandler Reporte_Paquete_ImpuestoCompleted;
        
        /// <remarks/>
        public event Reporte_Paquete_SucursalCompletedEventHandler Reporte_Paquete_SucursalCompleted;
        
        /// <remarks/>
        public event Reporte_EmpleadosCompletedEventHandler Reporte_EmpleadosCompleted;
        
        /// <remarks/>
        public event Reporte_EmpleadosDepCompletedEventHandler Reporte_EmpleadosDepCompleted;
        
        /// <remarks/>
        public event Reporte_Top5_ImpuestosCompletedEventHandler Reporte_Top5_ImpuestosCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Fecha", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Fecha() {
            object[] results = this.Invoke("Fecha", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void FechaAsync() {
            this.FechaAsync(null);
        }
        
        /// <remarks/>
        public void FechaAsync(object userState) {
            if ((this.FechaOperationCompleted == null)) {
                this.FechaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFechaOperationCompleted);
            }
            this.InvokeAsync("Fecha", new object[0], this.FechaOperationCompleted, userState);
        }
        
        private void OnFechaOperationCompleted(object arg) {
            if ((this.FechaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FechaCompleted(this, new FechaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Registrar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Registrar(string DPI, string NIT, string tarjeta, string nombre, string apellido, string telefono, int cod_sucursal, string correo, string domicilio) {
            object[] results = this.Invoke("Registrar", new object[] {
                        DPI,
                        NIT,
                        tarjeta,
                        nombre,
                        apellido,
                        telefono,
                        cod_sucursal,
                        correo,
                        domicilio});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void RegistrarAsync(string DPI, string NIT, string tarjeta, string nombre, string apellido, string telefono, int cod_sucursal, string correo, string domicilio) {
            this.RegistrarAsync(DPI, NIT, tarjeta, nombre, apellido, telefono, cod_sucursal, correo, domicilio, null);
        }
        
        /// <remarks/>
        public void RegistrarAsync(string DPI, string NIT, string tarjeta, string nombre, string apellido, string telefono, int cod_sucursal, string correo, string domicilio, object userState) {
            if ((this.RegistrarOperationCompleted == null)) {
                this.RegistrarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegistrarOperationCompleted);
            }
            this.InvokeAsync("Registrar", new object[] {
                        DPI,
                        NIT,
                        tarjeta,
                        nombre,
                        apellido,
                        telefono,
                        cod_sucursal,
                        correo,
                        domicilio}, this.RegistrarOperationCompleted, userState);
        }
        
        private void OnRegistrarOperationCompleted(object arg) {
            if ((this.RegistrarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegistrarCompleted(this, new RegistrarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VerificacionPass", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool VerificacionPass(string usuario, string password) {
            object[] results = this.Invoke("VerificacionPass", new object[] {
                        usuario,
                        password});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void VerificacionPassAsync(string usuario, string password) {
            this.VerificacionPassAsync(usuario, password, null);
        }
        
        /// <remarks/>
        public void VerificacionPassAsync(string usuario, string password, object userState) {
            if ((this.VerificacionPassOperationCompleted == null)) {
                this.VerificacionPassOperationCompleted = new System.Threading.SendOrPostCallback(this.OnVerificacionPassOperationCompleted);
            }
            this.InvokeAsync("VerificacionPass", new object[] {
                        usuario,
                        password}, this.VerificacionPassOperationCompleted, userState);
        }
        
        private void OnVerificacionPassOperationCompleted(object arg) {
            if ((this.VerificacionPassCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.VerificacionPassCompleted(this, new VerificacionPassCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getCodLote", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getCodLote(string cod_sucursal) {
            object[] results = this.Invoke("getCodLote", new object[] {
                        cod_sucursal});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getCodLoteAsync(string cod_sucursal) {
            this.getCodLoteAsync(cod_sucursal, null);
        }
        
        /// <remarks/>
        public void getCodLoteAsync(string cod_sucursal, object userState) {
            if ((this.getCodLoteOperationCompleted == null)) {
                this.getCodLoteOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetCodLoteOperationCompleted);
            }
            this.InvokeAsync("getCodLote", new object[] {
                        cod_sucursal}, this.getCodLoteOperationCompleted, userState);
        }
        
        private void OngetCodLoteOperationCompleted(object arg) {
            if ((this.getCodLoteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getCodLoteCompleted(this, new getCodLoteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Agregar_Empleado", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Agregar_Empleado(int cod_Suc_Dep, string nombre, string apellido, double sueldo) {
            object[] results = this.Invoke("Agregar_Empleado", new object[] {
                        cod_Suc_Dep,
                        nombre,
                        apellido,
                        sueldo});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void Agregar_EmpleadoAsync(int cod_Suc_Dep, string nombre, string apellido, double sueldo) {
            this.Agregar_EmpleadoAsync(cod_Suc_Dep, nombre, apellido, sueldo, null);
        }
        
        /// <remarks/>
        public void Agregar_EmpleadoAsync(int cod_Suc_Dep, string nombre, string apellido, double sueldo, object userState) {
            if ((this.Agregar_EmpleadoOperationCompleted == null)) {
                this.Agregar_EmpleadoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAgregar_EmpleadoOperationCompleted);
            }
            this.InvokeAsync("Agregar_Empleado", new object[] {
                        cod_Suc_Dep,
                        nombre,
                        apellido,
                        sueldo}, this.Agregar_EmpleadoOperationCompleted, userState);
        }
        
        private void OnAgregar_EmpleadoOperationCompleted(object arg) {
            if ((this.Agregar_EmpleadoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Agregar_EmpleadoCompleted(this, new Agregar_EmpleadoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Reporte_Paquete_Impuesto", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Reporte_Paquete_Impuesto() {
            object[] results = this.Invoke("Reporte_Paquete_Impuesto", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Reporte_Paquete_ImpuestoAsync() {
            this.Reporte_Paquete_ImpuestoAsync(null);
        }
        
        /// <remarks/>
        public void Reporte_Paquete_ImpuestoAsync(object userState) {
            if ((this.Reporte_Paquete_ImpuestoOperationCompleted == null)) {
                this.Reporte_Paquete_ImpuestoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReporte_Paquete_ImpuestoOperationCompleted);
            }
            this.InvokeAsync("Reporte_Paquete_Impuesto", new object[0], this.Reporte_Paquete_ImpuestoOperationCompleted, userState);
        }
        
        private void OnReporte_Paquete_ImpuestoOperationCompleted(object arg) {
            if ((this.Reporte_Paquete_ImpuestoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Reporte_Paquete_ImpuestoCompleted(this, new Reporte_Paquete_ImpuestoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Reporte_Paquete_Sucursal", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Reporte_Paquete_Sucursal() {
            object[] results = this.Invoke("Reporte_Paquete_Sucursal", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Reporte_Paquete_SucursalAsync() {
            this.Reporte_Paquete_SucursalAsync(null);
        }
        
        /// <remarks/>
        public void Reporte_Paquete_SucursalAsync(object userState) {
            if ((this.Reporte_Paquete_SucursalOperationCompleted == null)) {
                this.Reporte_Paquete_SucursalOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReporte_Paquete_SucursalOperationCompleted);
            }
            this.InvokeAsync("Reporte_Paquete_Sucursal", new object[0], this.Reporte_Paquete_SucursalOperationCompleted, userState);
        }
        
        private void OnReporte_Paquete_SucursalOperationCompleted(object arg) {
            if ((this.Reporte_Paquete_SucursalCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Reporte_Paquete_SucursalCompleted(this, new Reporte_Paquete_SucursalCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Reporte_Empleados", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Reporte_Empleados() {
            object[] results = this.Invoke("Reporte_Empleados", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Reporte_EmpleadosAsync() {
            this.Reporte_EmpleadosAsync(null);
        }
        
        /// <remarks/>
        public void Reporte_EmpleadosAsync(object userState) {
            if ((this.Reporte_EmpleadosOperationCompleted == null)) {
                this.Reporte_EmpleadosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReporte_EmpleadosOperationCompleted);
            }
            this.InvokeAsync("Reporte_Empleados", new object[0], this.Reporte_EmpleadosOperationCompleted, userState);
        }
        
        private void OnReporte_EmpleadosOperationCompleted(object arg) {
            if ((this.Reporte_EmpleadosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Reporte_EmpleadosCompleted(this, new Reporte_EmpleadosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Reporte_EmpleadosDep", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Reporte_EmpleadosDep() {
            object[] results = this.Invoke("Reporte_EmpleadosDep", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Reporte_EmpleadosDepAsync() {
            this.Reporte_EmpleadosDepAsync(null);
        }
        
        /// <remarks/>
        public void Reporte_EmpleadosDepAsync(object userState) {
            if ((this.Reporte_EmpleadosDepOperationCompleted == null)) {
                this.Reporte_EmpleadosDepOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReporte_EmpleadosDepOperationCompleted);
            }
            this.InvokeAsync("Reporte_EmpleadosDep", new object[0], this.Reporte_EmpleadosDepOperationCompleted, userState);
        }
        
        private void OnReporte_EmpleadosDepOperationCompleted(object arg) {
            if ((this.Reporte_EmpleadosDepCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Reporte_EmpleadosDepCompleted(this, new Reporte_EmpleadosDepCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Reporte_Top5_Impuestos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Reporte_Top5_Impuestos() {
            object[] results = this.Invoke("Reporte_Top5_Impuestos", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Reporte_Top5_ImpuestosAsync() {
            this.Reporte_Top5_ImpuestosAsync(null);
        }
        
        /// <remarks/>
        public void Reporte_Top5_ImpuestosAsync(object userState) {
            if ((this.Reporte_Top5_ImpuestosOperationCompleted == null)) {
                this.Reporte_Top5_ImpuestosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReporte_Top5_ImpuestosOperationCompleted);
            }
            this.InvokeAsync("Reporte_Top5_Impuestos", new object[0], this.Reporte_Top5_ImpuestosOperationCompleted, userState);
        }
        
        private void OnReporte_Top5_ImpuestosOperationCompleted(object arg) {
            if ((this.Reporte_Top5_ImpuestosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Reporte_Top5_ImpuestosCompleted(this, new Reporte_Top5_ImpuestosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void FechaCompletedEventHandler(object sender, FechaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FechaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FechaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void RegistrarCompletedEventHandler(object sender, RegistrarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegistrarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegistrarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void VerificacionPassCompletedEventHandler(object sender, VerificacionPassCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VerificacionPassCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal VerificacionPassCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void getCodLoteCompletedEventHandler(object sender, getCodLoteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getCodLoteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getCodLoteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void Agregar_EmpleadoCompletedEventHandler(object sender, Agregar_EmpleadoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Agregar_EmpleadoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Agregar_EmpleadoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void Reporte_Paquete_ImpuestoCompletedEventHandler(object sender, Reporte_Paquete_ImpuestoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Reporte_Paquete_ImpuestoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Reporte_Paquete_ImpuestoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void Reporte_Paquete_SucursalCompletedEventHandler(object sender, Reporte_Paquete_SucursalCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Reporte_Paquete_SucursalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Reporte_Paquete_SucursalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void Reporte_EmpleadosCompletedEventHandler(object sender, Reporte_EmpleadosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Reporte_EmpleadosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Reporte_EmpleadosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void Reporte_EmpleadosDepCompletedEventHandler(object sender, Reporte_EmpleadosDepCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Reporte_EmpleadosDepCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Reporte_EmpleadosDepCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void Reporte_Top5_ImpuestosCompletedEventHandler(object sender, Reporte_Top5_ImpuestosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Reporte_Top5_ImpuestosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Reporte_Top5_ImpuestosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591