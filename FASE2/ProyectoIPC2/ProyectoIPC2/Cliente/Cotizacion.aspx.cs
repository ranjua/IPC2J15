using ProyectoIPC2.Administrador;
using ProyectoIPC2.Administrador.Clases;
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
    public partial class Cotizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                obtenerDatos();
            }
        }

        private void obtenerDatos()
        {
            Cobro cobro = new Cobro();
            cobro.ObtenerCobro();
            List<Impuesto> impuestos = cobro.lista_Impuesto;
            int x = 1;
            Ddl_Tipo_Impuesto.Items.Clear();
            try
            {
                foreach (var itemlist in impuestos)
                {
                    ListItem Newitem = new ListItem();
                    Newitem.Value = "" + itemlist.cod_impuesto;
                    Newitem.Text = itemlist.nombre  + "-" + itemlist.porcentaje*100.00;
                    if (x == 1)
                    {
                        Newitem.Selected = true;
                        x++;
                    }
                    Ddl_Tipo_Impuesto.Items.Add(Newitem);
                }
            }
            catch (Exception e)
            { }
        }

        public double GetImpuesto()
        {
            Impuesto impuesto = new Impuesto();
            return impuesto.GetVimpuesto(Convert.ToInt32(Ddl_Tipo_Impuesto.SelectedValue));

        }
        protected void Btn_Cotizar_Click(object sender, EventArgs e)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            double costo_libra= 0;
            double comision = 0;
            tabla = base_de_Datos.FillTableData("Select costo_lb, comision, hcosto_lb, hcomision from ProyectoIPC2.dbo.Sucursales where cod_sucursal = 1");
            foreach (DataRow drtabla in tabla.Rows)
            {
                if (Convert.ToBoolean(drtabla[2].ToString()))
                {
                    costo_libra = Convert.ToDouble(drtabla[0].ToString());
                }
                if (Convert.ToBoolean(drtabla[3].ToString()))
                {
                    comision = Convert.ToDouble(drtabla[1].ToString());
                }
            }
            double t = Convert.ToDouble(Txt_Precio.Text) * (GetImpuesto()/100.00);
            double total = (t) + (Convert.ToDouble(Txt_Libras.Text) * costo_libra) + (Convert.ToDouble(Txt_Precio.Text) * comision);
            Txt_Total.Text = "Q."+total+"";
        }
    }
}