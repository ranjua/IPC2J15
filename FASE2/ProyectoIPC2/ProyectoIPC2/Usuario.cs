using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPC2
{
    interface Usuario
    {
        public int cod_usuario { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public long telefono { get; set; }
        public string correo  { get; set; }
        public string domicilio  { get; set; }
        public int rol { get; set; }




    }
}

