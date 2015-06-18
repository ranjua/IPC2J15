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
        public bool Verificacion(string usuario, string email, string password)
        {
            bool Sesion_aceptada = false;
            Base_de_Datos registro = new Base_de_Datos();
            DataTable tabla = new DataTable();
            try
            {
                //Verificacion de usuarios-contraseña
                tabla = registro.FillTableData("Select password from quinielas.dbo.usuarios where usuario = '" + usuario + "' or email= '" + email + "';");
                if (tabla.Rows.Count == 1)
                {
                    Cifrado Contraseña = new Cifrado();
                    string ArrarB = Contraseña.StringB(Contraseña.Encriptar(password, "IPC2PROYECTO"));
                    DataRow rtabla = tabla.Rows[0];
                    string ArrayA = rtabla[0].ToString();
                    Sesion_aceptada = Contraseña.CompareByteArray(ArrayA, ArrarB);
                }

            }
            catch
            {
            }
            if (Sesion_aceptada == true)
            {

                tabla = registro.FillTableData("Select cod_usuario, usuario, nombre, apellido, cod_rol, email, estado, bloqueado" +
                " from quinielas.dbo.usuarios where usuario = '" + usuario + "' or email= '" + email + "';");
                foreach (DataRow drtabla in tabla.Rows)
                {
                    HttpContext.Current.Session["Cod_Usuario"] = drtabla[0].ToString();
                    HttpContext.Current.Session["Usuario"] = drtabla[1].ToString();
                    HttpContext.Current.Session["Cod_Rol_Usuario"] = drtabla[4].ToString();
                    HttpContext.Current.Session["Nombre"] = drtabla[2].ToString() + " " + drtabla[3].ToString();
                    HttpContext.Current.Session["Email"] = drtabla[5].ToString();

                    //Actualizacion
                    /*HttpContext.Current.Session["Actualizacion"] = "0";
                    tabla = registro.FillTableData("Select cod_usuario from quinielas.dbo.Actualizacionusuario where cod_act= 1 and cod_usuario=" + HttpContext.Current.Session["Cod_Usuario"]);
                    foreach (DataRow drtablaa in tabla.Rows)
                    {
                        //Actualización
                        HttpContext.Current.Session["Actualizacion"] = "1";
                    }*/

                }

                registro.Upd_New_DelUnValorQry("Insert into quinielas.dbo.ControlUsuarios (cod_Usuario, estatus, fechahora, IPCliente) values( " +
                    HttpContext.Current.Session["Cod_Usuario"] + ", 'Activo', '" + DateTime.Now.ToString() + "', '" + HttpContext.Current.Request.UserHostAddress + "' )");
            }

            return Sesion_aceptada;
        }
        //Cookies
        public void ObtenerDatos(int cod)
        {
            Base_de_Datos registro = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = registro.FillTableData("Select cod_usuario, usuario, nombre, apellido, cod_rol, email, estado, bloqueado" +
            " from quinielas.dbo.usuarios where cod_usuario=" + cod);
            foreach (DataRow drtabla in tabla.Rows)
            {
                HttpContext.Current.Session["Cod_Usuario"] = drtabla[0].ToString();
                HttpContext.Current.Session["Usuario"] = drtabla[1].ToString();
                HttpContext.Current.Session["Cod_Rol_Usuario"] = drtabla[4].ToString();
                HttpContext.Current.Session["Nombre"] = drtabla[2].ToString() + " " + drtabla[3].ToString();
                HttpContext.Current.Session["Email"] = drtabla[5].ToString();
            }

            registro.Upd_New_DelUnValorQry("Insert into quinielas.dbo.ControlUsuarios (cod_Usuario, estatus, fechahora, IPCliente) values( " +
                    HttpContext.Current.Session["Cod_Usuario"] + ", 'Activo', '" + DateTime.Now.ToString() + "', '" + HttpContext.Current.Request.UserHostAddress + "' )");
        }
        //Crea password con el usuario
        public string CreaPassword(string nombre)
        {
            string clave = "";
            nombre = nombre.Replace(" ", String.Empty);
            Random ran = new Random();

            for (int x = 0; x < nombre.Length; x++)
            {
                clave = clave + nombre.Substring(x, 1) + ran.Next(10); ;
            }
            if (clave.Length > 6)
            {
                clave = clave.Substring(0, 5);
            }
            return clave;
        }


        //Registra el Logout del usuario
        public void Logout()
        {
            Base_de_Datos registro = new Base_de_Datos();
            registro.Upd_New_DelUnValorQry("Insert into quinielas.dbo.ControlUsuarios (cod_Usuario, estatus, fechahora, IPCliente) values( " +
                   HttpContext.Current.Session["Cod_Usuario"] + ", 'Inactivo', '" + DateTime.Now.ToString() + "', '" + HttpContext.Current.Request.UserHostAddress + "')");

            HttpContext.Current.Session["Cod_Usuario"] = null;
            HttpContext.Current.Session["Usuario"] = null;
            HttpContext.Current.Session["Cod_Rol_Usuario"] = null;
            HttpContext.Current.Session["Quiniela"] = null;
            HttpContext.Current.Session["Nombre"] = null;
        }


    }
}