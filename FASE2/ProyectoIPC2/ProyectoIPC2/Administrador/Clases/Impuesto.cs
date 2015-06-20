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
            this.habilitado = habilitado;
        }
        public Impuesto(int cod_impuesto, double porcentaje, bool habilitado)
        {
            this.nombre = nombre;
            this.porcentaje = porcentaje;
            this.habilitado = habilitado;
        }
    }
}