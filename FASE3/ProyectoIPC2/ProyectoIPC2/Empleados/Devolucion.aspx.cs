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
    public partial class Devolucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LLenar();
            }
        }

        protected void Btn_Devolver_Click(object sender, EventArgs e)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            Fecha_Hora FH = new Fecha_Hora();
            base_de_Datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Paquetes set estado = 'Devuelto' where cod_paquete = " + Ddl_Paquetes.SelectedValue);
            base_de_Datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Historial_P values(" + Ddl_Paquetes.SelectedValue +
                    ", " + HttpContext.Current.Session["Cod_Empleado"].ToString() + ", 'Devuelto', '" + FH.Fecha() + "', '" + FH.Hora() + "' ) ");
            LLenar();
        }

        private void LLenar()
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("Select p.cod_paquete, c.casilla from ProyectoIPC2.dbo.Paquetes p, " +
                " ProyectoIPC2.dbo.Clientes c where c.DPI = p.cod_cliente and p.estado = 'Devolucion'");
            int x = 1;
            Ddl_Paquetes.Items.Clear();
            try
            {
                foreach (DataRow drtabla in tabla.Rows)
                {
                    System.Web.UI.WebControls.ListItem Newitem = new System.Web.UI.WebControls.ListItem();
                    Newitem.Value = drtabla[0].ToString();
                    Newitem.Text = "Casilla:" + drtabla[1].ToString() + " Codigo de Paquete: " + drtabla[0].ToString();
                    if (x == 1)
                    {
                        Newitem.Selected = true;
                        x++;
                    }
                    Ddl_Paquetes.Items.Add(Newitem);
                    Ddl_Paquetes.Visible = true;
                }
            }
            catch
            { }
        }
    }
}