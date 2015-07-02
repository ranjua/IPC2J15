using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Clases
{
    public class Fecha_Hora
    {
        public Fecha_Hora ()
        {

        }

        public string Fecha()
        {
            WebSProyectoIPC2.ProyectoIPC2 WS = new WebSProyectoIPC2.ProyectoIPC2();
            return WS.Fecha();
        }

        public string Hora()
        {
            return "" + ((Convert.ToInt32(DateTime.Now.Hour.ToString()) < 10) ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + ":"
                        + ((Convert.ToInt32(DateTime.Now.Minute.ToString()) < 10) ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) + ":"
                        + ((Convert.ToInt32(DateTime.Now.Second.ToString()) < 10) ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
        }

    }
}