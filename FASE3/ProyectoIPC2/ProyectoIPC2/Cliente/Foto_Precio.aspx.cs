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
    public partial class Foto_Precio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Llenar_Ddl();
            }
        }

        private void Llenar_Ddl()
        {
            Ddl_Paquetes.Visible = false;
            Btn_Agregar.Visible = false;
            Flu.Visible = false;
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("select p.cod_paquete, i.categoria from ProyectoIPC2.dbo.Paquetes p, ProyectoIPC2.dbo.Impuestos i "+
                                                " where i.cod_impuesto=p.cod_impuesto and p.estado='Sin Precio' and p.cod_cliente='" + HttpContext.Current.Session["DPI"].ToString()+"'");
            int x = 1;
            Ddl_Paquetes.Items.Clear();
            try
            {
                foreach (DataRow drtabla in tabla.Rows)
                {
                    System.Web.UI.WebControls.ListItem Newitem = new System.Web.UI.WebControls.ListItem();
                    Newitem.Value = drtabla[0].ToString();
                    Newitem.Text ="("+ drtabla[0].ToString() +") " + drtabla[1].ToString();
                    if (x == 1)
                    {
                        Newitem.Selected = true;
                        x++;
                    }
                    Ddl_Paquetes.Items.Add(Newitem);
                    Ddl_Paquetes.Visible = true;
                    Btn_Agregar.Visible = true;
                    Flu.Visible = true;
                }
            }
            catch
            { }
        }

        protected void Btn_Agregar_Click(object sender, EventArgs e)
        {
            if (Flu.HasFile)
            {
                if (Flu.PostedFile.ContentLength < 9900900)
                {
                    string Updfile = Server.MapPath("~/Img/" + Flu.FileName);
                    Flu.SaveAs(Updfile);
                    Base_de_Datos base_de_Datos = new Base_de_Datos();
                    bool correcto = base_de_Datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Paquetes set img = '" + "~/Img/" + Flu.FileName + "' where cod_paquete = " + Ddl_Paquetes.SelectedValue );
                    if(correcto)
                    {
                        Fecha_Hora FH = new Fecha_Hora();
                        base_de_Datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Historial_P values(" + Ddl_Paquetes.SelectedValue +
                                ", " + HttpContext.Current.Session["DPI"].ToString() + ", 'Foto Agregada', '" + FH.Fecha() + "', '" + FH.Hora() + "' ) ");
                        Mensaje.Text = "Imagen Cargada Correctamente";
                    }
                }
                else
                {
                    Mensaje.Text = "El archivo no puede ser mayor de 10 Mb";
                }
            }
            else
            {
                Mensaje.Text = "Carga un Archivo";
            }
        }
    }
}