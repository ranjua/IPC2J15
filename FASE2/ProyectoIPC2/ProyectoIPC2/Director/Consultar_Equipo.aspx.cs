using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProyectoIPC2.Director
{
    public partial class Consultar_Equipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                getEmpleados();
            }
        }

        public void getEmpleados()
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("select e.cod_empleado as ID, u.nombre as Nombre, u.apellidos As Apellido, e.sueldo As Sueldo, d.nombre As Departamento, s.nombre As Sucursal, s.sede as Sede"+
            " from ProyectoIPC2.dbo.Empleados e, ProyectoIPC2.dbo.Usuarios u, "+
            " ProyectoIPC2.dbo.Departamentos d, ProyectoIPC2.dbo.Sucursales s ,  ProyectoIPC2.dbo.SucDep sd "+
            " where sd.cod_departamento = d.cod_departamento and sd.cod_sucursal=s.cod_sucursal and sd.cod_Suc_Dep=e.cod_suc_dep "+
            " and u.cod_usuario = e.cod_usuario");
            Grd_Empleados.DataSource = tabla;
            Grd_Empleados.DataBind();
        }

        public void getEmpleados(int sucdep)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("select e.cod_empleado as ID, u.nombre as Nombre, u.apellidos As Apellido, e.sueldo As Sueldo, d.nombre As Departamento, s.nombre As Sucursal, s.sede as Sede" +
            " from ProyectoIPC2.dbo.Empleados e, ProyectoIPC2.dbo.Usuarios u, " +
            " ProyectoIPC2.dbo.Departamentos d, ProyectoIPC2.dbo.Sucursales s ,  ProyectoIPC2.dbo.SucDep sd " +
            " where sd.cod_departamento = d.cod_departamento and sd.cod_sucursal=s.cod_sucursal and sd.cod_Suc_Dep=e.cod_suc_dep " +
            " and u.cod_usuario = e.cod_usuario and sd.cod_Suc_Dep = " + sucdep);
            Grd_Empleados.DataSource = tabla;
            Grd_Empleados.DataBind();
        }
        public void LlenarSucDep()
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("select sd.cod_Suc_Dep, d.nombre, s.nombre " +
            " from ProyectoIPC2.dbo.Departamentos d, ProyectoIPC2.dbo.Sucursales s ,  ProyectoIPC2.dbo.SucDep sd " +
            " where sd.cod_departamento = d.cod_departamento and sd.cod_sucursal=s.cod_sucursal ");
            Ddl_Departamento.Items.Clear();
            foreach(DataRow drtabla in tabla.Rows)
            {
                ListItem Newitem = new ListItem();
                Newitem.Value = drtabla[0].ToString();
                Newitem.Text = drtabla[1].ToString() + " " + drtabla[2].ToString();
                Ddl_Departamento.Items.Add(Newitem);
            }
            Ddl_Suc_Dep.Items.Clear();
            foreach (DataRow drtabla in tabla.Rows)
            {
                ListItem Newitem = new ListItem();
                Newitem.Value = drtabla[0].ToString();
                Newitem.Text = drtabla[1].ToString() + " " + drtabla[2].ToString();
                Ddl_Suc_Dep.Items.Add(Newitem);
            }
        }
        protected void Btn_Ver_Todos_Click(object sender, EventArgs e)
        {
            getEmpleados();
        }

        protected void Ddl_Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            getEmpleados(Convert.ToInt32(Ddl_Departamento.SelectedValue));
        }

        protected void Btn_Modificar_Click(object sender, EventArgs e)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            string suc_dep_dir = base_de_datos.SelectUnValorQry("select cod_suc_dep from ProyectoIPC2.dbo.Empleados where cod_empleado = " + Session["Cod_Empleado"]);
            string suc_dep_emp = base_de_datos.SelectUnValorQry("select cod_suc_dep from ProyectoIPC2.dbo.Empleados where cod_empleado = " + Txt_Cod_Empleado.Text);
            if (suc_dep_dir.Equals(suc_dep_emp))
            {
                base_de_datos.Upd_New_DelUnValorQry("update Proyecto.dbo.Empleados set sueldo = " + Txt_Sueldo.Text +
                    ", cod_suc_dep = " + Ddl_Suc_Dep.SelectedValue + " where cod_empleado = " + Txt_Cod_Empleado);
                getEmpleados();
            }
        }

        protected void Btn_Despedir_Click(object sender, EventArgs e)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            string suc_dep_dir = base_de_datos.SelectUnValorQry("select cod_suc_dep from ProyectoIPC2.dbo.Empleados where cod_empleado = " + Session["Cod_Empleado"]);
            string suc_dep_emp = base_de_datos.SelectUnValorQry("select cod_suc_dep from ProyectoIPC2.dbo.Empleados where cod_empleado = " + Txt_Cod_Empleado.Text);
            if (suc_dep_dir.Equals(suc_dep_emp))
            {
                base_de_datos.Upd_New_DelUnValorQry("Delete from Proyecto.dbo.Usuario where usuario = " + Txt_Cod_Empleado);
                base_de_datos.Upd_New_DelUnValorQry("Delete from Proyecto.dbo.Empleados where cod_empleado = " + Txt_Cod_Empleado);
                getEmpleados();
            }
        }
    }
}