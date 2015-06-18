using ProyectoIPC2.Administrador.Clases;
using System;
using System.Collections.Generic;
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

        public bool Actualizar_Cobro(List<Impuesto> lista_Impuesto, double cobro_Libra, double comision )
        {

            return true;
        }



    }
}