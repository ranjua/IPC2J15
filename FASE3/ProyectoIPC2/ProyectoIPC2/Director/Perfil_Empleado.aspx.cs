using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Director
{
    public partial class Perfil_Empleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LlenarCampos(Session["Empleado"].ToString());
            }
        }

        private void LlenarCampos(string cod_cliente)
        {
            Empleado empleado = new Empleado();
            Base_de_Datos base_de_Datos =new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_Datos.FillTableData("select u.usuario, u.nombre, u.apellidos, u.telefono, u.correo, u.domicilio, e.cod_suc_dep, e.sueldo " +
                                                " from ProyectoIPC2.dbo.Usuarios u, ProyectoIPC2.dbo.Empleados e " +
                                                " where e.cod_usuario=u.cod_usuario and e.cod_empleado= " + cod_cliente);
            foreach (DataRow drtabla in tabla.Rows)
            {
                Lbl_Usuario.Text = "Usuario: " + drtabla[0].ToString();
                Lbl_Nombre.Text = "Nombres: " + drtabla[1].ToString();
                Lbl_Apellido.Text = "Apellidos: " + drtabla[2].ToString();
                Lbl_Telefono.Text = "Telefono: " + drtabla[3].ToString();
                Lbl_Correo.Text = "Correo: " + drtabla[4].ToString();
                Lbl_Domicilio.Text = "Domicilio: " + drtabla[5].ToString();
                Lbl_Sucursal.Text = "Sucursal: " + base_de_Datos.SelectUnValorQry("select nombre from ProyectoIPC2.dbo.Sucursales where cod_sucursal= " + empleado.getSucursal(Convert.ToInt32(drtabla[6].ToString())));
                Lbl_Departamento.Text = "Departamento: " + base_de_Datos.SelectUnValorQry("select nombre from ProyectoIPC2.dbo.Departamentos where cod_departamento= " + empleado.getDepartamento(Convert.ToInt32(drtabla[6].ToString()))); ;
                Lbl_Sueldo.Text = "Q." + drtabla[7].ToString();
                Historial_Empleado(cod_cliente);
            }
        }

        private void Historial_Empleado(string cod_Empleado)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_Datos.FillTableData("select he.cod_empleado as Empleado, he.cod_director as Director, he.sueldo as Sueldo, " + 
                " s.nombre as Sucursal, d.nombre as Departamento, he.fecha as Fecha, he.hora as Hora from ProyectoIPC2.dbo.Historial_E he, ProyectoIPC2.dbo.Departamentos d, "+
                " ProyectoIPC2.dbo.Sucursales s, ProyectoIPC2.dbo.SucDep sd where d.cod_departamento=sd.cod_departamento and " + 
                " s.cod_sucursal=sd.cod_sucursal and sd.cod_Suc_Dep = he.cod_suc_dep and he.cod_empleado = " + cod_Empleado);

            GridView Gdv = new GridView();
            Gdv.DataSource = tabla;
            Gdv.DataBind();
            Pnl_Historial.Controls.Add(Gdv);

        }
    }
}