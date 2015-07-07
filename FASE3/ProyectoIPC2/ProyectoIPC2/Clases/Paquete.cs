using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Clases
{
    public class Paquete
    {


        public Paquete ()
        {

        }

        
        public string getCodLote(string cod_sucursal)
        {
            WebSProyectoIPC2.ProyectoIPC2 ws = new WebSProyectoIPC2.ProyectoIPC2();
            return ws.getCodLote(cod_sucursal);
        }

        public bool Registrar(int impuesto, int casilla,string peso, string precio )
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            string DPI ="", cod_sucursal="", Estado = "EEUU";
            tabla = base_de_datos.FillTableData("select DPI, cod_sucursal from ProyectoIPC2.dbo.Clientes where casilla = '" + casilla + "'");
            foreach(DataRow drtabla in tabla.Rows)
            {
                DPI = drtabla[0].ToString();
                cod_sucursal = drtabla[1].ToString();
            }
            string lote = getCodLote(cod_sucursal);
            if (precio.Equals(""))
            {
                Estado = "Sin Precio";
                lote = "0";
            }
            bool correcto = base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Paquetes values('" + precio + "', '" + peso + "', '"+Estado+"'"
                        + ", '" + DPI + "', " + HttpContext.Current.Session["Cod_Empleado"] + ", " + impuesto + ", NULL, " + lote + ",'','','','' )");
            if(correcto)
            {
                Fecha_Hora FH = new Fecha_Hora();
                string cod_paquete = base_de_datos.SelectUnValorQry("select MAX(cod_paquete) from ProyectoIPC2.dbo.Paquetes where cod_lote = " + lote);
                base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Historial_P values(" +cod_paquete +
                        ", " + HttpContext.Current.Session["Cod_Empleado"].ToString() + ", '"+Estado+"', '" + FH.Fecha() + "', '" + FH.Hora() + "' ) ");
                return true;
            }
            return false;
        }

        public bool VerificarPaquete(string ruta)
        {

            StreamReader streamreader = new StreamReader(ruta);
            while (!streamreader.EndOfStream)
            {
                var line = streamreader.ReadLine();
                var values = line.Split(',');
                Base_de_Datos base_de_datos = new Base_de_Datos();
                try
                {
                    string impuesto = base_de_datos.SelectUnValorQry("select cod_impuesto from ProyectoIPC2.dbo.Impuestos where categoria = '" + values[0] + "'");
                    string dpi = base_de_datos.SelectUnValorQry("select DPI from ProyectoIPC2.dbo.Clientes where casilla = '" + values[1] + "'");
                    if(impuesto.Equals("")|| dpi.Equals(""))
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
                return true;
            }

            return false;
        }

        public bool CSVPaquete(string ruta)
        {
            if (VerificarPaquete(ruta))
            {
                StreamReader streamreader = new StreamReader(ruta);
                while (!streamreader.EndOfStream)
                {
                    var line = streamreader.ReadLine();
                    var values = line.Split(',');

                    Base_de_Datos base_de_datos = new Base_de_Datos();
                    int impuesto = Convert.ToInt32(base_de_datos.SelectUnValorQry("select cod_impuesto from ProyectoIPC2.dbo.Impuestos where categoria = '" + values[0] + "'"));
                    Registrar(impuesto, Convert.ToInt32(values[1]), values[2], values[3]);
                }
                streamreader.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}