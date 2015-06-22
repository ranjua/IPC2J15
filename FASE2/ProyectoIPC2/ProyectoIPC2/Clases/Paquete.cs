using System;
using System.Collections.Generic;
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

            return false;
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
            string lote = "";

            base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Paquetes values('"+precio+"', '"+peso+"', 1"
                + ", " + DPI + ", " + HttpContext.Current.Session["Cod_Empleado"] + ", " + impuesto + ", NULL, " + lote + " )");
            return false;
        }

        public bool VerificarPaquete(string ruta)
        {
            try
            {
                StreamReader streamreader = new StreamReader(ruta);
                while (!streamreader.EndOfStream)
                {
                    var line = streamreader.ReadLine();
                    var values = line.Split(',');
                    Base_de_Datos base_de_datos = new Base_de_Datos();
                    base_de_datos.SelectUnValorQry("select cod_impuesto from ProyectoIPC2.dbo.Impuestos where categoria = '" + values[0] + "'");
                    base_de_datos.SelectUnValorQry("select DPI from ProyectoIPC2.dbo.Clientes where casilla = '" + values[1] + "'");
                    return true;
                }
            }
            catch
            {
                return false;
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