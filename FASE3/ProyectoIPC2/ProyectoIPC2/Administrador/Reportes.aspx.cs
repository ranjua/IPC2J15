using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ProyectoIPC2.Clases;
using System.Data;
using System.Configuration;
using ProyectoIPC2.Administrador.CrystalReports;
using Newtonsoft.Json;

namespace ProyectoIPC2.Administrador
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        private void Reporte_Paquete_Impuesto()
        {
            WebSProyectoIPC2.ProyectoIPC2 WSS = new WebSProyectoIPC2.ProyectoIPC2();
            DataTable tabla = (DataTable)JsonConvert.DeserializeObject(WSS.Reporte_Paquete_Impuesto(), (typeof(DataTable))); 

            ExportPDFEXCWR(tabla, "Reporte de Paquete por Impuesto", "~/Administrador/CrystalReports/Paquete_por_Impuesto.rpt");
        }
        private void Reporte_Paquete_Sucursal()
        {
            WebSProyectoIPC2.ProyectoIPC2 WSS = new WebSProyectoIPC2.ProyectoIPC2();
            DataTable tabla = (DataTable)JsonConvert.DeserializeObject(WSS.Reporte_Paquete_Sucursal(), (typeof(DataTable)));

            ExportPDFEXCWR(tabla, "Reporte de Paquete por Sucursal", "~/Administrador/CrystalReports/Paquete_por_Sucursal.rpt");
        }
        private void Reporte_Empleado()
        {
            WebSProyectoIPC2.ProyectoIPC2 WSS = new WebSProyectoIPC2.ProyectoIPC2();
            DataTable tabla = (DataTable)JsonConvert.DeserializeObject(WSS.Reporte_Empleados(), (typeof(DataTable)));

            ExportPDFEXCWR(tabla, "Reporte de Empleados", "~/Administrador/CrystalReports/Empleado.rpt");
        }
        private void Reporte_Top5_Impuestos()
        {
            WebSProyectoIPC2.ProyectoIPC2 WSS = new WebSProyectoIPC2.ProyectoIPC2();
            DataTable tabla = (DataTable)JsonConvert.DeserializeObject(WSS.Reporte_Top5_Impuestos(), (typeof(DataTable)));

            ExportPDFEXCWR(tabla, "Reporte Top 5 Impuestos", "~/Administrador/CrystalReports/Top5_Impuestos.rpt");
        }


        private void ExportPDFEXCWR(DataTable tabla, string nombre, string ruta_rpt)
        {
            ReportDocument rpd = new ReportDocument();
            rpd.Load(Server.MapPath(ruta_rpt));
            rpd.SetDataSource(tabla);
            rpd.ExportToHttpResponse
            (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, nombre);
        }

        protected void Btn_Reporte_Click(object sender, EventArgs e)
        {
            switch(Ddl_Reporte.SelectedValue)
            {
                case "1":
                    Reporte_Paquete_Impuesto();
                    break;
                case "2" :
                    Reporte_Paquete_Sucursal();
                    break;
                case "3":
                    Reporte_Empleado();
                    break;
                case "4":
                    Reporte_Top5_Impuestos();
                    break;
            }
        }
    }
}