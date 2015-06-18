using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Administrador.Clases
{
    public class Impuesto
    {
        public string nombre{ get; set; }
        public double porcentaje{ get; set; }

        public Impuesto(string nombre, double porcentaje)
        {
            this.nombre = nombre;
            this.porcentaje = porcentaje;
        }

    }
}