using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Empleados
{
    public partial class Estado_Lote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenar();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void LLenar()
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("Select cod_lote, fecha_salida, cod_sucursal from ProyectoIPC2.dbo.Lotes");
            int x = 1;
            Ddl_lote.Items.Clear();
            try
            {
                foreach (DataRow drtabla in tabla.Rows)
                {
                    System.Web.UI.WebControls.ListItem Newitem = new System.Web.UI.WebControls.ListItem();
                    Newitem.Value = drtabla[0].ToString();
                    Newitem.Text = drtabla[2].ToString() + "" + drtabla[1].ToString();
                    if (x == 1)
                    {
                        Newitem.Selected = true;
                        x++;
                    }
                    Ddl_lote.Items.Add(Newitem);
                    Ddl_lote.Visible = true;
                }
            }
            catch
            { }
        }
    }
}