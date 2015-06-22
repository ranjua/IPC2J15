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

        public bool VerificarFecha(string mayor, string menor)
        {
            DateTime date_mayor = Convert.ToDateTime(mayor);
            DateTime date_menor = Convert.ToDateTime(menor);
            if(date_mayor.CompareTo(date_menor)>0)
            {
                return true;
            }
            return false;
        }
        public string getCodLote(string cod_sucursal)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            WebSProyectoIPC2.ProyectoIPC2 Ws = new WebSProyectoIPC2.ProyectoIPC2();
            string fecha_lote = "";
            string fecha_paquete = Ws.Fecha();
            string cod_lote = "";
            tabla = base_de_datos.FillTableData("select cod_lote, fecha_salida from ProyectoIPC2.dbo.Lotes where cod_sucursal=" + cod_sucursal + " order by fecha_salida asc ;");
            foreach (DataRow drtabla in tabla.Rows)
            {
                fecha_lote = drtabla[1].ToString();
                cod_lote = drtabla[0].ToString();
                if (VerificarFecha(fecha_lote, fecha_paquete))
                {
                    return cod_lote;
                }
            }
            
                return "0";
        }

        public bool Registrar(int impuesto, int casilla, double peso, double precio )
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            string DPI ="", cod_sucursal="";
            tabla = base_de_datos.FillTableData("select DPI, cod_sucursal from ProyectoIPC2.dbo.Clientes where casilla = '" + casilla + "'");
            foreach(DataRow drtabla in tabla.Rows)
            {
                DPI = drtabla[0].ToString();
                cod_sucursal = drtabla[1].ToString();
            }
            string lote = getCodLote(cod_sucursal);
            bool correcto = base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Paquetes values('" + precio + "', '" + peso + "', EEUU"
                + ", '" + DPI + "', " + HttpContext.Current.Session["Cod_Empleado"] + ", " + impuesto + ", NULL, " + lote + " )");
            if(correcto)
            {
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
                    Registrar(impuesto, Convert.ToInt32(values[1]), Convert.ToDouble(values[2]), Convert.ToDouble(values[3]));
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}