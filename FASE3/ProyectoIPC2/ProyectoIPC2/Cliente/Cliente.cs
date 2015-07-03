using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Cliente
{
    public class Cliente
    {
        public int cod_usuario { get; set; }
        public string DPI { get; set; }
        public string NIT { get; set; }
        public string tarjeta { get; set; }
        public string nombre  { get; set; }
        public string apellido  { get; set; }
        public string telefono { get; set; }
        public int cod_sucursal { get; set; }
        public string correo { get; set; }
        public string domicilio { get; set; }
        public string DPI_Entrega { get; set; }

        public Cliente ()
        {

        }

        public Cliente(string DPI, string NIT, string tarjeta, string nombre, string apellido, string telefono, int cod_sucursal, string correo, string domicilio, string DPI_Entrega)
        {
            this.DPI = DPI;
            this.NIT = NIT;
            this.tarjeta = tarjeta;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.cod_sucursal = cod_sucursal;
            this.correo = correo;
            this.domicilio = domicilio;
            this.DPI_Entrega = DPI_Entrega;
        }

        public Cliente GetCliente(string DPI)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            Cliente cliente = new Cliente();
            tabla = base_de_datos.FillTableData("select c.DPI, c.NIT, c.num_tarjeta_C_D, u.nombre, u.apellidos, u.telefono, c.cod_sucursal, u.correo, u.domicilio, c.DPI_entrega "
                    + " from ProyectoIPC2.dbo.Clientes c, ProyectoIPC2.dbo.Usuarios u where u.cod_usuario=c.cod_usuario and c.DPI='"+ DPI +"'");
            foreach (DataRow drtabla in tabla.Rows)
            {
                 cliente = new Cliente(drtabla[0].ToString(),drtabla[1].ToString(),drtabla[2].ToString(),drtabla[3].ToString(),
                     drtabla[4].ToString(),drtabla[5].ToString(), Convert.ToInt32(drtabla[6].ToString()), drtabla[7].ToString(),
                     drtabla[8].ToString(),drtabla[9].ToString());
            }
            return cliente;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            bool correcto = base_de_datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Clientes set NIT='" + cliente.NIT + "', num_tarjeta_C_D='" + cliente.tarjeta +
                "', cod_sucursal=" + cliente.cod_sucursal + ", DPI_entrega='" + cliente.DPI_Entrega+"' where DPI = '" + cliente.DPI+"'");
           if(correcto) 
           {
               return base_de_datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Usuarios set nombre = '" + cliente.nombre + "', apellidos='" + cliente.apellido +
                   "', telefono = '" + cliente.telefono + "', correo = '" + cliente.correo + "', domicilio = '" + cliente.domicilio + "' where usuario = '" + cliente.DPI + "'");
           }
               return false;
        }

        public bool cambioPass(string DPI, string actual, string nuevo)
        {

            Verificar_usuario verificar_usuario = new Verificar_usuario();
            if(verificar_usuario.VerificacionPass(DPI,actual))
            {
                Base_de_Datos base_de_datos = new Base_de_Datos();
                return base_de_datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Usuarios set pass ='" + nuevo + "' where usuario = '" + DPI + "'");
            }
            return false;
        }

    }
}