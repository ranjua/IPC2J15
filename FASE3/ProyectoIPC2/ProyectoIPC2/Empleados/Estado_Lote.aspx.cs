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

        private void LLenar()
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("Select l.cod_lote,  l.fecha_salida, l.cod_sucursal, p.estado "+
                                            " from ProyectoIPC2.dbo.Lotes l, ProyectoIPC2.dbo.Paquetes p "+
                                            " where l.cod_lote=p.cod_lote and (p.estado='Aduana' or p.estado='EEUU')  group by l.cod_lote, l.fecha_salida, l.cod_sucursal, p.estado ");
            int x = 1;
            Ddl_lote.Items.Clear();
            try
            {
                foreach (DataRow drtabla in tabla.Rows)
                {
                    System.Web.UI.WebControls.ListItem Newitem = new System.Web.UI.WebControls.ListItem();
                    Newitem.Value = drtabla[0].ToString();
                    Newitem.Text = "(" + drtabla[2].ToString() + ") " + drtabla[1].ToString() + " en " + drtabla[3].ToString();
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

        protected void Btn_Siguiente_Estado_Click(object sender, EventArgs e)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            //Selecciona estado de paquetes del lote seleccionado en Ddl
            string estado_actual = base_de_datos.SelectUnValorQry("select estado from ProyectoIPC2.dbo.Paquetes where cod_lote=" + 
                Ddl_lote.SelectedValue );
            string estado_Nuevo = "";
            switch(estado_actual)
            {
                case "EEUU":
                    estado_Nuevo = "Aduana";
                    tabla = base_de_datos.FillTableData("select cod_paquete, cod_impuesto from ProyectoIPC2.dbo.Paquetes where cod_lote="+Ddl_lote.SelectedValue);
                    foreach (DataRow drtabla in tabla.Rows)
                    {
                        string impuesto = base_de_datos.SelectUnValorQry("select porcentaje from ProyectoIPC2.dbo.Impuestos where cod_impuesto=" + drtabla[1].ToString());
                        base_de_datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Paquetes set impuesto = '" + impuesto + "'  where cod_paquete=" + drtabla[0]);
                    }
                    break;
                case "Aduana":
                    estado_Nuevo = "Guatemala";
                    break;
                default:
                    return;
            }
            base_de_datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Paquetes set estado = '" + estado_Nuevo + 
                "' where cod_lote=" + Ddl_lote.SelectedValue);
            WebSProyectoIPC2.ProyectoIPC2 WS = new WebSProyectoIPC2.ProyectoIPC2();
            string fecha = WS.Fecha();
            string hora = "" + ((Convert.ToInt32(DateTime.Now.Hour.ToString()) < 10) ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + ":"
                        + ((Convert.ToInt32(DateTime.Now.Minute.ToString()) < 10) ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + ":"
                        + ((Convert.ToInt32(DateTime.Now.Second.ToString()) < 10) ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
            tabla = new DataTable();
            tabla = base_de_datos.FillTableData("select cod_paquete from ProyectoIPC2.dbo.Paquetes where cod_lote="+Ddl_lote.SelectedValue);
            foreach (DataRow drtabla in tabla.Rows)
            {
                base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Historial_P values(" + drtabla[0].ToString() +
                    ", " + Session["Cod_Empleado"].ToString() + ", '" + estado_Nuevo + "', '" + fecha + "', '" + hora + "' ) ");
            }
            LLenar();
        }
    }
}