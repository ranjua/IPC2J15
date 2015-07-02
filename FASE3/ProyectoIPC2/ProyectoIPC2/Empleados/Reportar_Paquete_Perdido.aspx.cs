using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Empleados
{
    public partial class Reportar_Paquete_Perdido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Registrar_Click(object sender, EventArgs e)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            string lote = base_de_Datos.SelectUnValorQry("select cod_lote from ProyectoIPC2.dbo.Paquetes where cod_paquete="+ Txt_Perdido.Text);
            base_de_Datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Perdidos values("+Txt_Perdido.Text+", " + lote + " ,  ,)");
        }

        protected void Btn_Cargar_CSV_Click(object sender, EventArgs e)
        {

        }
    }
}