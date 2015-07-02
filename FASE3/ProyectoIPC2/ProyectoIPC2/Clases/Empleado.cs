
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;


namespace ProyectoIPC2.Clases
{
    public class Empleado
    {
        public int cod_usuario { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int rol { get; set; }

        public int cod_empleado { get; set; }
        public double sueldo { get; set; }
        public int cod_Suc_Dep { get; set; }

        
        public Empleado(double sueldo, int cod_Suc_Dep)
        {
            this.sueldo = sueldo;
            this.cod_Suc_Dep = cod_Suc_Dep;
        }

        public Empleado(string apellido, string nombre, double sueldo, int cod_Suc_Dep)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.sueldo = sueldo;
            this.cod_Suc_Dep = cod_Suc_Dep;
        }

        public bool VerificarSuc_Dep(string ruta)
        {
            try
            {
                StreamReader streamreader = new StreamReader(ruta);
                while (!streamreader.EndOfStream)
                {
                    var line = streamreader.ReadLine();
                    var values = line.Split(',');
                    Base_de_Datos base_de_datos = new Base_de_Datos();
                    int suc = Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_sucursal from ProyectoIPC2.dbo.Sucursales where nombre = '" + values[3] + "'"));
                    int dep = Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_departamento from ProyectoIPC2.dbo.Departamentos where nombre = '" + values[4] + "'"));
                    base_de_datos.SelectUnValorQry("select cod_Suc_Dep from ProyectoIPC2.dbo.SucDep where cod_sucursal = '" +
                        suc + "' and cod_departamento = " + dep);
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public Empleado()
        {
            
        }

        public bool CSVEmpleado(string ruta)
        {
            if (VerificarSuc_Dep(ruta))
            {
                StreamReader streamreader = new StreamReader(ruta);
                while (!streamreader.EndOfStream)
                {
                    var line = streamreader.ReadLine();
                    var values = line.Split(',');
                    Base_de_Datos base_de_datos = new Base_de_Datos();
                    int suc = Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_sucursal from ProyectoIPC2.dbo.Sucursales where nombre = '" + values[3] + "'"));
                    int dep = Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_departamento from ProyectoIPC2.dbo.Departamentos where nombre = '" + values[4] + "'"));
                    int suc_dep = Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_Suc_Dep from ProyectoIPC2.dbo.SucDep where cod_sucursal = '" +
                        suc + "' and cod_departamento = " + dep));
                    Empleado empleado = new Empleado(values[0], values[1], Convert.ToInt32(values[2]), suc_dep);
                    Agregar_Empleado(empleado);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getSucursal()
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            return Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_sucursal from ProyectoIPC2.dbo.SucDep," +
                "  where cod_suc_dep= " + cod_Suc_Dep));
        }
        public int getDepartamento()
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            return Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_departamento from ProyectoIPC2.dbo.SucDep," +
                "  where cod_suc_dep= " + cod_Suc_Dep));
        }
        public int getSucursal(int cod_Suc_Dep)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            return Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_sucursal from ProyectoIPC2.dbo.SucDep," +
                "  where cod_suc_dep= " + cod_Suc_Dep));
        }
        public int getDepartamento(int cod_Suc_Dep)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            return Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_departamento from ProyectoIPC2.dbo.SucDep," +
                "  where cod_suc_dep= " + cod_Suc_Dep));
        }

        public bool actualizarEmpleado(int cod_empleado, string puesto, double sueldo, int cod_Departamento, int cod_Sucursal)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            int cod_Suc_Dep = Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_suc_dep from ProyectoIPC2.dbo.SucDep," +
                "  where cod_sucursal= " + cod_Sucursal + " and cod_departamento=" + cod_Departamento));
            base_de_datos.Upd_New_DelUnValorQry("Update ProyectoIPC2.dbo.SucDep set cod_sucursal =" + cod_Sucursal +
                ", cod_departamento=" + cod_Departamento + " where cod_empleado = " + cod_empleado);
            base_de_datos.Upd_New_DelUnValorQry("Update ProyectoIPC2.dbo.Empleado set puesto = " + puesto +
                ", sueldo=" + sueldo + " where cod_empleado = " + cod_empleado);
            return true;
        }

        public bool Agregar_Empleado(Empleado empleado)
        {
            WebSProyectoIPC2.ProyectoIPC2 ws = new WebSProyectoIPC2.ProyectoIPC2();
            return ws.Agregar_Empleado(empleado.cod_Suc_Dep, empleado.nombre, empleado.apellido, empleado.sueldo);
        }


    }
}