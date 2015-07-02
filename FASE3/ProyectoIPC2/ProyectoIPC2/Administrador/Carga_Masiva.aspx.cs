using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Administrador
{
    public partial class Carga_Masiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Btn_Procesar_Click(object sender, EventArgs e)
        {
            if ((Flu_CSV.PostedFile != null) && (Flu_CSV.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(Flu_CSV.PostedFile.FileName);
                string SaveLocation = Server.MapPath("~/Archivos") + "\\" + fn;
                try
                {
                    Flu_CSV.PostedFile.SaveAs(SaveLocation);
                    Lbl_Mensaje.Text = "El archivo se ha cargado.";
                    if (Ddl_Tipo_Carga.SelectedValue == "1")
                    {
                        Cobro cobro = new Cobro(SaveLocation);
                    }
                    else
                    {
                        Empleado empleado = new Empleado();
                        if(!empleado.CSVEmpleado(SaveLocation))
                        {
                            Lbl_Mensaje.Text = "El archivo tiene datos inexistentes";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Lbl_Mensaje.Text ="Error : " + ex.Message;
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
    }
}