using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Clases
{
    public class Verificar_usuario
    {

        //Verifica el usuario y registra el Login
        public bool Verificacion(string usuario, string password)
        {
            bool Sesion_aceptada = false;
            Base_de_Datos registro = new Base_de_Datos();
            DataTable tabla = new DataTable();
            try
            {
                //Verificacion de usuarios-contraseña
                tabla = registro.FillTableData("Select pass from ProyectoIPC2.dbo.Usuarios where usuario = '" + usuario + "'");
                if (tabla.Rows.Count == 1)
                {
                    DataRow drtabla = tabla.Rows[0];
                    if(password.Equals(drtabla[0].ToString()))
                    {
                        Sesion_aceptada = true;
                    }
                }

            }
            catch
            {
            }
            if (Sesion_aceptada == true)
            {
                /*
                 * Empleados
                 * 104 Registro
                 * 105 Bodega 
                 * 111 Servicio Al Cliente
                 * Directores
                 * 103 Registro
                 * 108 Bodega 
                 * 107 Servicio Al Cliente
                 */
                HttpContext.Current.Session["Cod_Empleado"] = "";
                HttpContext.Current.Session["Cod_Suc_Dep"] = "";
                HttpContext.Current.Session["DPI"] = "";
                HttpContext.Current.Session["Cod_Rol_Usuario"] = registro.SelectUnValorQry("Select cod_rol from ProyectoIPC2.dbo.Usuarios where usuario = '" + usuario + "'");
                int op = Convert.ToInt32(HttpContext.Current.Session["Cod_Rol_Usuario"]);
                switch(op)
                {
                    case 1:
                        //Administrador
                        
                        break;
                    case 2:
                        //Director
                    case 3:
                        //Empleado
                        tabla = registro.FillTableData("Select cod_suc_dep " +
                        " from ProyectoIPC2.dbo.Empleados where cod_empleado = '" + usuario + "'");
                        foreach (DataRow drtabla in tabla.Rows)
                        {
                            HttpContext.Current.Session["Cod_Empleado"] = usuario;
                            HttpContext.Current.Session["Cod_Suc_Dep"] = drtabla[0].ToString();
                        }
                        break;
                    case 4:
                        //Cliente
                        int cod_usu = Convert.ToInt32(registro.SelectUnValorQry("Select cod_usuario from ProyectoIPC2.dbo.Usuarios where usuario = '" + usuario + "'"));
                        tabla = registro.FillTableData("Select DPI, cod_autorizador " +
                        " from ProyectoIPC2.dbo.Clientes where cod_usuario = '" + cod_usu + "'");
                        foreach (DataRow drtabla in tabla.Rows)
                        {
                            if(drtabla[1].ToString().Equals("0"))
                            {
                                return false;
                            }
                            HttpContext.Current.Session["DPI"] = drtabla[0].ToString();
                            
                        }
                        break;
                }


            }

            return Sesion_aceptada;
        }

        public bool Registrar(string DPI, string NIT, string tarjeta, string nombre, string apellido, string telefono, int cod_sucursal, string correo, string domicilio)
        {
            WebSProyectoIPC2.ProyectoIPC2 ws = new WebSProyectoIPC2.ProyectoIPC2();
            return ws.Registrar(DPI, NIT, tarjeta, nombre, apellido, telefono, cod_sucursal, correo, domicilio);
        }
        
        
        
        //Registra el Logout del usuario
        public void Logout()
        {
            HttpContext.Current.Session["Cod_Usuario"] = null;
            HttpContext.Current.Session["Usuario"] = null;
            HttpContext.Current.Session["Cod_Rol_Usuario"] = null;
            HttpContext.Current.Session["Cod_Empleado"] = null;
            HttpContext.Current.Session["Cod_Suc_Dep"] = null;
        }

        public bool VerificacionPass(string usuario, string password)
        {
            WebSProyectoIPC2.ProyectoIPC2 ws = new WebSProyectoIPC2.ProyectoIPC2();
            return ws.VerificacionPass(usuario, password);
        }
    }
}