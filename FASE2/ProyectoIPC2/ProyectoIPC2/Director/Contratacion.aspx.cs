using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Director
{
    public partial class Contratacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Contratar_CSV_Click(object sender, EventArgs e)
        {
            string fn = System.IO.Path.GetFileName(Flu_Archivo.PostedFile.FileName);
            string SaveLocation = Server.MapPath("~/Archivos") + "\\" + fn;
            try
            {
                Flu_Archivo.PostedFile.SaveAs(SaveLocation);
                Lbl_Mensaje.Text = "El archivo se ha cargado.";

                Empleado empleado = new Empleado();
                if (!empleado.CSVEmpleado(SaveLocation))
                {
                    Lbl_Mensaje.Text = "El archivo tiene datos inexistentes";
                }
            }
            catch (Exception ex)
            {
                Lbl_Mensaje.Text = "Error : " + ex.Message;
                //Nota: Exception.Message devuelve un mensaje detallado que describe la excepción actual. 
                //Por motivos de seguridad, no se recomienda devolver Exception.Message a los usuarios finales de 
                //entornos de producción. Sería más aconsejable poner un mensaje de error genérico. 
            }
        }

        protected void Btn_Contratar_Click1(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado(Txt_Apellido.Text, Txt_Nombre.Text, Convert.ToDouble(Txt_Sueldo.Text), Convert.ToInt32(Session["Cod_Suc_Dep"].ToString()));
            empleado.Agregar_Empleado(empleado);
        }
    }
}