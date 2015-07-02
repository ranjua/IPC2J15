using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoIPC2.Clases;
using System.Data;
namespace ProyectoIPC2.Empleados
{
    public partial class Autorizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Llenar_Ddl();
            }
        }

        protected void Btn_Autorizar_Click(object sender, EventArgs e)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("update ProyectoIPC2.dbo.Clientes set cod_autorizador = " + Session["Cod_Empleado"].ToString() +
                " where DPI = '" + Ddl_Cliente.SelectedValue + "'");
            Llenar_Ddl();
        }

        protected void Ddl_Cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarCampos(Ddl_Cliente.SelectedValue);
            
        }

        private void LlenarCampos(string cod_cliente)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            Cliente.Cliente cliente = new Cliente.Cliente();
            cliente = cliente.GetCliente(cod_cliente);
            Lbl_Usuario.Text = "Usuario: " + cliente.DPI;
            Lbl_NIT.Text = "NIT: " + cliente.NIT;
            Lbl_Tarjeta.Text = "Tarjeta: " + cliente.tarjeta;
            Lbl_DPI_Entrega.Text = "DPI para Entrega: " + cliente.DPI_Entrega;
            Lbl_Nombre.Text = "Nombres: " + cliente.nombre;
            Lbl_Apellido.Text = "Apellidos: " + cliente.apellido;
            Lbl_Telefono.Text = "Telefono: " + cliente.telefono;
            Lbl_Correo.Text = "Correo: " + cliente.correo;
            Lbl_Domicilio.Text = "Domicilio: " + cliente.domicilio;
            if (cliente.cod_sucursal != 0)
            {
                Lbl_Sucursal.Text = "Sucursal: " + base_de_datos.SelectUnValorQry("select nombre from ProyectoIPC2.dbo.Sucursales where cod_sucursal= " + cliente.cod_sucursal);
            }
        }

        private void Llenar_Ddl()
        {
            Ddl_Cliente.Visible = false;
            Btn_Autorizar.Visible = false;
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("select DPI from ProyectoIPC2.dbo.Clientes where cod_autorizador=0");
            int x = 1;
            Ddl_Cliente.Items.Clear();
            try
            {
                foreach (DataRow drtabla in tabla.Rows)
                {
                    System.Web.UI.WebControls.ListItem Newitem = new System.Web.UI.WebControls.ListItem();
                    Newitem.Value = drtabla[0].ToString();
                    Newitem.Text = drtabla[0].ToString();
                    if (x == 1)
                    {
                        Newitem.Selected = true;
                        x++;
                    }
                    Ddl_Cliente.Items.Add(Newitem);
                    Ddl_Cliente.Visible = true;
                    Btn_Autorizar.Visible = true;
                }
                LlenarCampos(Ddl_Cliente.SelectedValue);

            }
            catch
            { }
        }
    }
}