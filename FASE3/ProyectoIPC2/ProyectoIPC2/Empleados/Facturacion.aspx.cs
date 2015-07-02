using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class Facturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (!Txt_Casilla.Text.Equals(""))
            {
                Ddl_Paquetes.Visible = false;
                Btn_Facturar.Visible = false;
                Base_de_Datos base_de_datos = new Base_de_Datos();
                DataTable tabla = new DataTable();
                tabla = base_de_datos.FillTableData("Select p.cod_paquete, p.costo, i.categoria  from ProyectoIPC2.dbo.Paquetes p, " +
                    " ProyectoIPC2.dbo.Clientes c, ProyectoIPC2.dbo.Impuestos i where c.DPI = p.cod_cliente and i.cod_impuesto = p.cod_impuesto " +
                    " and c.casilla = " + Txt_Casilla.Text + " and p.estado = 'Guatemala'");
                int x = 1;
                Ddl_Paquetes.Items.Clear();
                try
                {
                    foreach (DataRow drtabla in tabla.Rows)
                    {
                        System.Web.UI.WebControls.ListItem Newitem = new System.Web.UI.WebControls.ListItem();
                        Newitem.Value = drtabla[0].ToString();
                        Newitem.Text = "Q." + drtabla[1].ToString() + " - " + drtabla[2].ToString();
                        if (x == 1)
                        {
                            Newitem.Selected = true;
                            x++;
                        }
                        Ddl_Paquetes.Items.Add(Newitem);
                        Ddl_Paquetes.Visible = true;
                        Btn_Facturar.Visible = true;
                    }
                }
                catch
                { }
            }
        }

        protected void Btn_Facturar_Click(object sender, EventArgs e)
        {
            Factura factura = new Factura(Ddl_Paquetes.SelectedValue);
            Btn_Facturar.Visible = false;
            Ddl_Paquetes.Visible = false;
            factura.A_PDF(factura);
            
        }

        
    }
}