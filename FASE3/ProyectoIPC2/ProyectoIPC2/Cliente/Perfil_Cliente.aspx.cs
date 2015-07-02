using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Cliente
{
    public partial class Perfil_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Llenar_datos();
                
            }
        }

        private void Llenar_datos()
        {
            Cliente cliente = new Cliente();
            cliente = cliente.GetCliente(Session["DPI"].ToString());
            Lbl_Usuario.Text = cliente.DPI;
            Txt_NIT.Text = cliente.NIT;
            Txt_Tarjeta.Text = cliente.tarjeta;
            Txt_DPI_Entrega.Text = cliente.DPI_Entrega;
            Txt_Nombre.Text = cliente.nombre;
            Txt_Apellido.Text = cliente.apellido;
            Txt_Telefono.Text = cliente.telefono;
            Txt_correo.Text = cliente.correo;
            Txt_Domicilio.Text = cliente.domicilio;
            Sucursales(cliente.cod_sucursal);
        }

        public void Sucursales(int cod_sucursal)
        {
            Base_de_Datos usuario = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = usuario.FillTableData("select cod_sucursal, nombre from ProyectoIPC2.dbo.Sucursales where sede='Guatemala' order by nombre asc");
            Ddl_Sucursal.Items.Clear();
            foreach (DataRow rtabla in tabla.Rows)
            {
                ListItem Newitem = new ListItem();
                Newitem.Value = rtabla[0].ToString();
                Newitem.Text = rtabla[1].ToString();
                if(cod_sucursal.ToString() == rtabla[0].ToString())
                {
                    Newitem.Selected = true;
                }
                Ddl_Sucursal.Items.Add(Newitem);
            }
        }

        protected void Btn_Cambio_Pass_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            if(cliente.cambioPass(Lbl_Usuario.Text, Txt_Actual.Text, Txt_Nueva.Text))
            {
                lbl_mensaje.Text = "Actualizada";
            }
        }
        
        protected void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(Lbl_Usuario.Text, Txt_NIT.Text,Txt_Tarjeta.Text,Txt_Nombre.Text,Txt_Apellido.Text,Txt_Telefono.Text,
                Convert.ToInt32(Ddl_Sucursal.SelectedValue),Txt_correo.Text, Txt_Domicilio.Text,Txt_DPI_Entrega.Text);

            if(cliente.ActualizarCliente(cliente))
            {
                lbl_mensaje.Text = "Actualizado";
            }
        }


        
    }
}