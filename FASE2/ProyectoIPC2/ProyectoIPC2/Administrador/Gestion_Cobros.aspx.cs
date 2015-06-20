using ProyectoIPC2.Administrador.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Administrador
{
    public partial class Gestion_Cobros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
            foreach (var itemlist in impuestos)
            {
                ListItem Newitem = new ListItem();
                Newitem.Value = ""+itemlist.cod_impuesto;
                Newitem.Text = itemlist.nombre;
                if (x == 1)
                {
                    Newitem.Selected = true;
                    x++;
                }
                Ddl_Tipo_Impuesto.Items.Add(Newitem);
            }
            Txt_Impuesto_Porcentaje.Text = ""+Convert.ToDouble(Ddl_Tipo_Impuesto.SelectedValue)*100.00;
            Txt_Comision_Porcentaje.Text = ""+cobro.comision*100.00;
            Txt_Peso_Cobro.Text = ""+cobro.cobro_Libra*100.00;
        }


        protected void Btn_Modificar_Click(object sender, EventArgs e)
        {
            Cobro cobro = new Cobro();
            Impuesto impuesto = new Impuesto(Convert.ToInt32(Ddl_Tipo_Impuesto.SelectedValue), Convert.ToDouble(Txt_Impuesto_Porcentaje.Text) / 100.00, Cbx_Impuesto_DHab.Checked);
            Comision_Libra peso = new Comision_Libra(Convert.ToDouble(Txt_Peso_Cobro.Text) / 100.00, Cbx_Peso_DHab.Checked);
            Comision_Libra comision = new Comision_Libra(Convert.ToDouble(Txt_Comision_Porcentaje.Text) / 100.00,Cbx_Comision_DHab.Checked);
            cobro.Actualizar_Cobro(impuesto, peso, comision);
        }

        protected void Btn_Agregar_Impuesto_Click(object sender, EventArgs e)
        {
            if (Txt_Impuesto_Porcentaje.Text != "" && Txt_Nombre_Impuesto.Text != "")
            {
                Cobro cobro = new Cobro();
                Impuesto impuesto = new Impuesto(Txt_Nombre_Impuesto.Text, Convert.ToDouble(Txt_Porcentaje_Nuevo_Impuesto.Text) / 100.00);
                cobro.Agregar_Impuestos(impuesto);
            }
        }

        protected void Ddl_Tipo_Impuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_Impuesto_Porcentaje.Text = "" + Convert.ToDouble(Ddl_Tipo_Impuesto.SelectedValue) * 100.00;
        }
    }
}