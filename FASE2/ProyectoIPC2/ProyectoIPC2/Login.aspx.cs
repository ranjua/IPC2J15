using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Sucursales();
            }
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            Verificar_usuario verificar_usuario = new Verificar_usuario();
            if(verificar_usuario.Verificacion(Txt_Correo.Text,Txt_Pass.Text))
            {
                int op = Convert.ToInt32(HttpContext.Current.Session["Cod_Rol_Usuario"]);
                switch (op)
                {
                    case 1:
                        //Administrador
                        Response.Redirect("Administrador/Gestion_Cobros.aspx");
                        break;
                    case 2:
                        //Director
                        Response.Redirect("Director/Contratacion.aspx");
                        break;
                    case 3:
                        //Empleado
                        Response.Redirect("Empleados/Facturacion.aspx");
                        break;
                    case 4:
                        //Cliente
                        Response.Redirect("Cliente/Info_Paquetes.aspx");
                        break;
                }
            }
            else
            {
                Lbl_Mensaje_Error.Text = "Usuario o contraseña incorrectos.\n O aun no esta autorizado en el sistema";
                Lbl_Mensaje_Error.Visible = true;
            }
        }

        protected void Btn_Registrarse_Click(object sender, EventArgs e)
        {
            Verificar_usuario Registrar = new Verificar_usuario();
            bool correcto = Registrar.Registrar(Txt_DPI.Text,Txt_NIT.Text,Txt_Tarjeta.Text,Txt_Nombre.Text,Txt_Apellido.Text,Txt_Telefono.Text,
                Convert.ToInt32(Ddl_Sucursal.SelectedValue),Txt_NCorreo.Text,Txt_Domicilio.Text);
            if(correcto)
            {
                Lbl_Mensaje.Text = "Registro Exitos, aguarde por autorizacion para ingresar";
                Lbl_Mensaje.Visible = true;
            }
            else
            {
                Lbl_Mensaje.Text = "Datos Incorrectos";
                Lbl_Mensaje.Visible = true;
            }
        }

        public void Sucursales()
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
                Ddl_Sucursal.Items.Add(Newitem);
            }
        }

      
        
    }
}