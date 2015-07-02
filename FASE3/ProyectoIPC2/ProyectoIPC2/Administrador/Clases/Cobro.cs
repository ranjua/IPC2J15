using ProyectoIPC2.Administrador.Clases;
using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Administrador
{
    public class Cobro
    {
        public List<Impuesto> lista_Impuesto { get; set; }
        public Comision_Libra cobro_Libra { get; set; }
        public Comision_Libra comision { get; set; }

        public Cobro(List<Impuesto> lista_Impuesto, Comision_Libra cobro_Libra, Comision_Libra comision)
        {
            this.lista_Impuesto = lista_Impuesto;
            this.cobro_Libra = cobro_Libra;
            this.comision = comision;
        }

        public Cobro()
        {
            this.lista_Impuesto = new List<Impuesto>();
        }
        public Cobro(string ruta)
        {
            StreamReader streamreader = new StreamReader(ruta);
            while (!streamreader.EndOfStream)
            {
                var line = streamreader.ReadLine();
                var values = line.Split(',');
                string porcentaje = values[1].Trim(new Char[] { ' ', '%'});
                Impuesto impuesto = new Impuesto(values[0],
                    Convert.ToDouble(porcentaje)/100.00);
                Agregar_Impuestos(impuesto);
            }
        }

        public void ObtenerCobro ()
        {
            Base_de_Datos base_De_Datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_De_Datos.FillTableData("select cod_impuesto, categoria, porcentaje, habilitado from ProyectoIPC2.dbo.Impuestos");
            foreach (DataRow drtabla in tabla.Rows)
            {
                Impuesto impuesto = new Impuesto(Convert.ToInt32(drtabla[0]), drtabla[1].ToString(), 
                    double.Parse(drtabla[2].ToString(),System.Globalization.CultureInfo.InvariantCulture),Convert.ToBoolean(drtabla[3].ToString()) );
                this.lista_Impuesto.Add(impuesto);
            }
            tabla = base_De_Datos.FillTableData("Select costo_lb, hcosto_lb, comision, hcomision from ProyectoIPC2.dbo.Sucursales");
            DataRow dtrtabla = tabla.Rows[0];
            this.cobro_Libra = new Comision_Libra(double.Parse(dtrtabla[0].ToString(), System.Globalization.CultureInfo.InvariantCulture), Convert.ToBoolean(dtrtabla[1].ToString()));
            this.comision = new Comision_Libra(double.Parse(dtrtabla[2].ToString(),System.Globalization.CultureInfo.InvariantCulture), Convert.ToBoolean(dtrtabla[3].ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="impuesto">impuesto</param>
        /// <param name="cobro_Libra">cobro por libra</param>
        /// <param name="comision">cobro por comision</param>
        /// <returns></returns>
        public bool Actualizar_Cobro(Impuesto impuesto, Comision_Libra cobro_Libra, Comision_Libra comision)
        {
            Base_de_Datos base_De_Datos = new Base_de_Datos();
            //Actualiza impuestos
            base_De_Datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Impuestos set porcentaje = '" + impuesto.porcentaje.ToString().Replace(',', '.') + "', habilitado = '" + impuesto.habilitado + 
                "' where cod_impuesto = " + impuesto.cod_impuesto + "");
            //Actuliza Comision y Cobro por libra

            return base_De_Datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Sucursales set comision = '" + (comision.porcentaje / 100).ToString().Replace(',', '.') +
                "', costo_lb = '" + cobro_Libra.porcentaje.ToString().Replace(',', '.') + "', hcomision = '" + comision.habilitado + "', hcosto_lb = '" + cobro_Libra.habilitado + "'");
        }

        public bool Agregar_Impuestos(Impuesto impuesto)
        {
            Base_de_Datos base_De_Datos = new Base_de_Datos();
            base_De_Datos.Upd_New_DelUnValorQry("Insert into ProyectoIPC2.dbo.Impuestos values( '" + impuesto.nombre + "', '" +
                impuesto.porcentaje.ToString().Replace(',', '.') + "','True' )");
            return true;
        }

    }
}