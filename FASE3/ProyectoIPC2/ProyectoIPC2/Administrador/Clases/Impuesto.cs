using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Administrador.Clases
{
    public class Impuesto
    {
        public int cod_impuesto { get; set; }
        public string nombre{ get; set; }
        public double porcentaje{ get; set; }
        public bool habilitado { get; set; }

        public Impuesto(int cod_impuesto, string nombre, double porcentaje, bool habilitado)
        {
            this.cod_impuesto = cod_impuesto;
            this.nombre = nombre;
            this.porcentaje = porcentaje;
            this.habilitado = habilitado;
        }

        public Impuesto(string nombre, double porcentaje)
        {
            this.nombre = nombre;
            this.porcentaje = porcentaje;
        }
        public Impuesto(int cod_impuesto, double porcentaje, bool habilitado)
        {
            this.cod_impuesto = cod_impuesto;
            this.porcentaje = porcentaje;
            this.habilitado = habilitado;
        }
        public Impuesto()
        {

        }

        public bool GetHimpuesto(int cod_impuesto)
        {
            Base_de_Datos base_De_Datos = new Base_de_Datos();
            return Convert.ToBoolean( base_De_Datos.SelectUnValorQry("select habilitado from ProyectoIPC2.dbo.Impuestos where cod_impuesto = " + cod_impuesto));

        }
        public double GetVimpuesto(int cod_impuesto)
        {
            Base_de_Datos base_De_Datos = new Base_de_Datos();
            string porcentaje = base_De_Datos.SelectUnValorQry("select porcentaje from ProyectoIPC2.dbo.Impuestos where cod_impuesto = " + cod_impuesto);
            return 100.00 * double.Parse(porcentaje,System.Globalization.CultureInfo.InvariantCulture);

        }
    }
}