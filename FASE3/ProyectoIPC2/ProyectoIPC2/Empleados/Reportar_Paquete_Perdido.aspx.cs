using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (!IsPostBack)
            {
                Departamento dep = new Departamento();
            }
        }

        protected void Btn_Registrar_Click(object sender, EventArgs e)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            base_de_Datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Paquetes set estado = 'Perdido' where cod_paquete="+ Txt_Perdido.Text);
        }

        protected void Btn_Cargar_CSV_Click(object sender, EventArgs e)
        {
            if ((Flu_Archivo.PostedFile != null) && (Flu_Archivo.PostedFile.ContentLength > 0))
            {
               // string SaveLocation = Server.MapPath("~/Archivos") + "\\" + System.IO.Path.GetFileName(Flu_Archivo.PostedFile.FileName);
                try
                {
                    StreamReader streamreader = new StreamReader(Flu_Archivo.PostedFile.InputStream);
                    Buscar_Perdidos(streamreader);
                }
                catch (Exception ex)
                {
                    Lbl_Mensaje.Text = "Error : " + ex.Message;
                    //Nota: Exception.Message devuelve un mensaje detallado que describe la excepción actual. 
                    //Por motivos de seguridad, no se recomienda devolver Exception.Message a los usuarios finales de 
                    //entornos de producción. Sería más aconsejable poner un mensaje de error genérico. 
                }
            }
            else
            {
                Lbl_Mensaje.Text = "Seleccione un archivo que cargar.";
            }
        }

        public void Buscar_Perdidos(StreamReader streamreader)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            bool x = true;
            while (!streamreader.EndOfStream)
            {
                var line = streamreader.ReadLine();
                var values = line.Split(',');
                if (x)
                {
                    base_de_Datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Paquetes set estado='Perdido' where cod_lote = " + values[0]);
                    x = false;
                }
                
                base_de_Datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Paquetes set estado='Guatemala' where cod_lote = " + values[0] +
            " and cod_impuesto = (select cod_impuesto from ProyectoIPC2.dbo.Impuestos where categoria='" + values[1] + "') and " +
            " cod_cliente = (select cod_cliente from ProyectoIPC2.dbo.Clientes where casilla = " + values[2] + ") and " +
            " libras = '" + values[3] + "' and costo = '" + values[4] + "';");
            }
            streamreader.Close();
        }
    }
}