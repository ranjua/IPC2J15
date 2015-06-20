using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Administrador.Clases
{
    public class Comision_Libra
    {
        public double porcentaje{get;set;}
        public bool habilitado{get;set;}

        public Comision_Libra(double porcentaje, bool habilitado)
        {
            this.porcentaje = porcentaje;
            this.habilitado = habilitado;
        }
    }
}