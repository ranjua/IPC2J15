using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService_ProyectoIPC2_
{
    /// <summary>
    /// Summary description for ProyectoIPC2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProyectoIPC2 : System.Web.Services.WebService
    {
        [WebMethod]
        public string Fecha()
        {
            return "26/08/2015";
        }

        //Verificar_usuairo.cs
        [WebMethod]
        //Verifica el usuario y registra el Login
        public bool Registrar(string DPI, string NIT, string tarjeta, string nombre, string apellido, string telefono, int cod_sucursal, string correo, string domicilio)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            bool correcto = base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Usuarios values('" + DPI + "','" + DPI + "', '" + nombre +
                "','" + apellido + "', " + telefono + ",'" + correo + "','" + domicilio + "',4 )");
            if (correcto)
            {
                return base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Clientes values(" + DPI + ", '" + NIT + "', " + tarjeta + ", " + DPI +
                    ", (select MAX(cod_usuario) from ProyectoIPC2.dbo.Usuarios), 0, " + cod_sucursal + ")");
            }
            return false;
        }
        [WebMethod]
        public bool VerificacionPass(string usuario, string password)
        {
            Base_de_Datos registro = new Base_de_Datos();
            DataTable tabla = new DataTable();
            try
            {
                //Verificacion de usuarios-contraseña
                tabla = registro.FillTableData("Select pass from ProyectoIPC2.dbo.Usuarios where usuario = '" + usuario + "'");
                if (tabla.Rows.Count == 1)
                {
                    DataRow drtabla = tabla.Rows[0];
                    if (password.Equals(drtabla[0].ToString()))
                    {
                        return true;
                    }
                }

            }
            catch
            {
                return false;
            }
            return false;
        }


        //Paquete.cs
        [WebMethod]
        public string getCodLote(string cod_sucursal)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            string fecha_lote = "";
            string fecha_paquete = Fecha();
            string cod_lote = "";
            tabla = base_de_datos.FillTableData("select cod_lote, fecha_salida from ProyectoIPC2.dbo.Lotes where cod_sucursal=" + cod_sucursal + " order by fecha_salida asc ;");
            foreach (DataRow drtabla in tabla.Rows)
            {
                fecha_lote = drtabla[1].ToString();
                cod_lote = drtabla[0].ToString();
                if (VerificarFecha(fecha_lote, fecha_paquete))
                {
                    return cod_lote;
                }
            }

            return "0";
        }

        public bool VerificarFecha(string mayor, string menor)
        {
            DateTime date_mayor = Convert.ToDateTime(mayor);
            DateTime date_menor = Convert.ToDateTime(menor);
            if (date_mayor.CompareTo(date_menor) > 0)
            {
                return true;
            }
            return false;
        }


        //Empleado.cs
        [WebMethod]
        public bool Agregar_Empleado(int cod_Suc_Dep, string nombre, string apellido, double sueldo)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("select * from ProyectoIPC2.dbo.Usuarios u, ProyectoIPC2.dbo.Empleados e where e.cod_usuario=u.cod_usuario and u.cod_rol=2 and e.cod_suc_dep = " + cod_Suc_Dep);

            if (tabla.Rows.Count == 0)
            {
                base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Usuarios values('','empleado','" + nombre +
                    "','" + apellido + "',0000000,'correo','Guatemala',2 )");
            }
            else
            {
                base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Usuarios values('','empleado','" + nombre +
                    "','" + apellido + "',0000000,'correo','Guatemala',3 )");
            }
            base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Empleados values('" + sueldo +
                "', " + cod_Suc_Dep + ", (select MAX(cod_usuario) from ProyectoIPC2.dbo.Usuarios))");
            base_de_datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Usuarios set usuario = (Select cod_empleado from ProyectoIPC2.dbo.Empleados where cod_usuario = (select MAX(cod_usuario) from ProyectoIPC2.dbo.Usuarios)) where cod_usuario = (select MAX(cod_usuario) from ProyectoIPC2.dbo.Usuarios)");
            return true;
        }
    }

}
