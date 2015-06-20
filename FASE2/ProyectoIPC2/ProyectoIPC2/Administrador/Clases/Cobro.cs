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
        public double cobro_Libra { get; set; }
        public double comision {get;set;}

        public Cobro (List<Impuesto> lista_Impuesto, double cobro_Libra, double comision )
        {
            this.lista_Impuesto = lista_Impuesto;
            this.cobro_Libra = cobro_Libra;
            this.comision = comision;
        }

        public Cobro()
        {
           
        }
        public Cobro(string ruta)
        {
            StreamReader streamreader = new StreamReader(ruta);
            while (!streamreader.EndOfStream)
            {
                string rstreamreader = streamreader.ReadLine().Trim();
                if (rstreamreader.Length > 0)
                {
                    string porcentaje = rstreamreader[1].ToString().Trim(new Char[] { ' ', '%'});
                    Impuesto impuesto = new Impuesto(rstreamreader[0].ToString(),
                        Convert.ToDouble(porcentaje)/100.00  );
                    Agregar_Impuestos(impuesto);

                }
            }
        }

        public void ObtenerCobro ()
        {
            Base_de_Datos base_De_Datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_De_Datos.FillTableData("");
            foreach (DataRow drtabla in tabla.Rows)
            {
                Impuesto impuesto = new Impuesto(Convert.ToInt32(drtabla[0]), drtabla[1].ToString(), Convert.ToDouble(drtabla[2].ToString()));
                this.lista_Impuesto.Add(impuesto);
            }
            tabla = base_De_Datos.FillTableData("");
            DataRow dtrtabla = tabla.Rows[0];
            this.cobro_Libra = Convert.ToDouble(dtrtabla[0].ToString());
            this.comision = Convert.ToDouble(dtrtabla[1].ToString());
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
            base_De_Datos.Upd_New_DelUnValorQry("");
            //Actuliza Comision y Cobro por libra
            base_De_Datos.Upd_New_DelUnValorQry("");
            return true;
        }

        public bool Agregar_Impuestos(Impuesto impuesto)
        {
            Base_de_Datos base_De_Datos = new Base_de_Datos();
            base_De_Datos.Upd_New_DelUnValorQry("Insert into ProyectoIPC2.dbo.impuestos values( '"+impuesto.nombre+"', " + impuesto.porcentaje + " )");
            return true;
        }

    }
}