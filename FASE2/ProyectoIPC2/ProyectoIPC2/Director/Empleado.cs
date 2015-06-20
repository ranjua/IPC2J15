using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProyectoIPC2.Director 
{
    public class Empleado : Usuario
    {
        public int cod_empleado { get; set; }
        public string puesto { get; set; }
        public double sueldo { get; set; }
        public int cod_Suc_Dep { get; set; }

        public Empleado(string puesto, double sueldo, int cod_Suc_Dep)
        {
            this.puesto = puesto;
            this.sueldo = sueldo;
            this.cod_Suc_Dep = cod_Suc_Dep;
        }

        public Empleado()
        {
            
        }


        public int getSucursal()
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            return Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_sucursal from ProyectoIPC2.dbo.SucDep,"+
                "  where cod_Suc_Dep= " + cod_Suc_Dep));
        }
        public int getDepartamento()
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            return Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_departamento from ProyectoIPC2.dbo.SucDep," +
                "  where cod_Suc_Dep= " + cod_Suc_Dep));
        }
        public int getSucursal(int cod_Suc_Dep)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            return Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_sucursal from ProyectoIPC2.dbo.SucDep," +
                "  where cod_Suc_Dep= " + cod_Suc_Dep));
        }
        public int getDepartamento(int cod_Suc_Dep)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            return Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_departamento from ProyectoIPC2.dbo.SucDep," +
                "  where cod_Suc_Dep= " + cod_Suc_Dep));
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




    }
}