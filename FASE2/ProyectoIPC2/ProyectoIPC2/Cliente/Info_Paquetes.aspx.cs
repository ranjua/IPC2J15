using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Cliente
{
    public partial class Info_Paquetes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LlenarGrd();
            }
        }

        public void LlenarGrd()
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            Grd_Paquetes.DataSource = base_de_Datos.FillTableData("Select p.cod_paquete, i.categoria, p.estado from ProyectoIPC2.dbo.Impuestos i"+
                " , ProyectoIPC2.dbo.Paquetes p where p.cod_impuesto=i.cod_impuesto and p.cod_cliente='" + Session["DPI"].ToString() + "'");
            Grd_Paquetes.DataBind();
        }

        protected void Btn_Mas_Detalles_Click(object sender, EventArgs e)
        {
            if(!Txt_Cod_Paquete.Text.Equals(""))
            {
                Session["Paquete"] = Txt_Cod_Paquete.Text;
                Response.Redirect("Info_Paquete.aspx");
            }
        }
    }
}