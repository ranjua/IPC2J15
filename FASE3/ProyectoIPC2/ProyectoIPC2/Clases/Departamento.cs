using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Clases
{
    public class Departamento
    {

        public Departamento ()
        {
            string Pagina_Actual = HttpContext.Current.Request.Url.AbsolutePath;
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            Boolean incorrecto = false;
            Empleado empleado = new Empleado();
            int cod_departamento = empleado.getDepartamento(Convert.ToInt32(HttpContext.Current.Session["Cod_Suc_Dep"]));
                    string dep = base_de_Datos.SelectUnValorQry("Select nombre from ProyectoIPC2.dbo.Departamentos where cod_departamento=" + cod_departamento);
            switch(Pagina_Actual)
            {
                case "/Empleados/Registro_de_Paquetes.aspx":
                    if (!dep.Equals("Registro"))
                        incorrecto = true;
                    break;
                case "/Empleados/Reportar_Paquete_Perdido.aspx":
                case "/Empleados/Agregar_Precio.aspx":
                case "/Director/Autorizar_Precio.aspx":
                    if (!dep.Equals("Bodega"))
                        incorrecto = true;
                    break;
                case "/Empleados/Autorizacion.aspx":
                case "/Empleados/Devolucion.aspx":
                case "/Empleados/Facturacion.aspx":
                    if (!dep.Equals("Servicio al Cliente"))
                        incorrecto = true;
                    break;

            }
            if(incorrecto)
            {
                int op = Convert.ToInt32(HttpContext.Current.Session["Cod_Rol_Usuario"]);
                switch (op)
                {
                    case 1:
                        //Administrador
                        HttpContext.Current.Response.Redirect("~/Administrador/Gestion_Cobros.aspx");
                        break;
                    case 2:
                        //Director
                        HttpContext.Current.Response.Redirect("~/Director/Consultar_Equipo.aspx");
                        break;
                    case 3:
                        //Empleado
                        HttpContext.Current.Response.Redirect("~/Empleados/Portada.aspx");
                        break;
                    case 4:
                        //Cliente
                        HttpContext.Current.Response.Redirect("~/Cliente/Info_Paquetes.aspx");
                        break;
                }
            }
            
        }
    }
}