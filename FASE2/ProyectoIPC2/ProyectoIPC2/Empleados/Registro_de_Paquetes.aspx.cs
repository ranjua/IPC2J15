using ProyectoIPC2.Administrador;
using ProyectoIPC2.Administrador.Clases;
using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Empleados
{
    public partial class Registro_de_Paquetes : System.Web.UI.Page
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
                    Newitem.Text = itemlist.nombre + "-" + itemlist.porcentaje * 100.00;
                    if (x == 1)
                    {
                        Newitem.Selected = true;
                        x++;
                    }
                    Ddl_Tipo_Impuesto.Items.Add(Newitem);
                }
            }
            catch
            { }
        }

        public double GetImpuesto()
        {
            Impuesto impuesto = new Impuesto();
            return impuesto.GetVimpuesto(Convert.ToInt32(Ddl_Tipo_Impuesto.SelectedValue));

        }

        protected void Btn_Registrar_Click(object sender, EventArgs e)
        {

            Paquete paquete = new Paquete();
            if (paquete.Registrar(Convert.ToInt32(Ddl_Tipo_Impuesto.SelectedValue), Convert.ToInt32(Txt_Casilla.Text),
                Convert.ToDouble(Txt_Libras.Text), Convert.ToDouble(Txt_Precio.Text)))
            {
                Lbl_Mensaje.Text = "Registro Exitoso";
            }
            else
            {
                Lbl_Mensaje.Text = "Registro Incorrecto";
            }
        }

        protected void Btn_Cargar_CSV_Click(object sender, EventArgs e)
        {
            string fn = System.IO.Path.GetFileName(Flu_Archivo.PostedFile.FileName);
            string SaveLocation = Server.MapPath("~/Archivos") + "\\" + fn;
            try
            {
                Flu_Archivo.PostedFile.SaveAs(SaveLocation);
                Lbl_Mensaje.Text = "El archivo se ha cargado.";
                Paquete paquete = new Paquete();
                if (!paquete.CSVPaquete(SaveLocation))
                {
                    Lbl_Mensaje.Text = "El archivo tiene datos inexistentes";
                }
            }
            catch
            {
                Lbl_Mensaje.Text = "Error : Archivo no encontrado";
                //Nota: Exception.Message devuelve un mensaje detallado que describe la excepción actual. 
                //Por motivos de seguridad, no se recomienda devolver Exception.Message a los usuarios finales de 
                //entornos de producción. Sería más aconsejable poner un mensaje de error genérico. 
            }
        }
    }
}