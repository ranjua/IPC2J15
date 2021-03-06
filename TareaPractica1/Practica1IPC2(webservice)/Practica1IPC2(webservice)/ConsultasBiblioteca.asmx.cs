﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Data;

namespace Practica1IPC2_webservice_
{
    /// <summary>
    /// Summary description for ConsultasBiblioteca
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ConsultasBiblioteca : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetContact(string id)
        {
            var json = "";
            var contact = "randy"+id;

            JavaScriptSerializer jss = new JavaScriptSerializer();
            json = jss.Serialize(contact);

            return json;
        }

        [WebMethod]
        public Boolean Agregar_Libro(int cod_libro, int cod_autor,string titulo,int pags,string tema)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            return base_de_Datos.Upd_New_DelUnValorQry("Insert into Practica1IPC2.dbo.libros (cod_libro, nombre, paginas, tema, estado, cod_autor) " +
                " values (" + cod_libro + ",'" + titulo + "'," + pags + ", '" + tema + "','Disponible'," + cod_autor + ") ");
            
        }
        [WebMethod]
        public Boolean Agregar_Autor(string nombre, string apellido)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            return base_de_Datos.Upd_New_DelUnValorQry("Insert into Practica1IPC2.dbo.autores (nombre, apellido) " +
                " values ('" + nombre + "', '" + apellido + "') ");
        }
        [WebMethod]
        public long Agregar_Miembro(string nombre, long DPI, string direccion, long telefono)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            Boolean correcto = base_de_Datos.Upd_New_DelUnValorQry("Insert into Practica1IPC2.dbo.clientes (nombre, DPI, direccion, telefono) " +
                " values ('" + nombre + "'," + DPI + ", '" + direccion + "', " + telefono + ") ");
            if(correcto)
            {
                return Convert.ToInt64(base_de_Datos.SelectUnValorQry("select carnet from Practica1IPC2.dbo.clientes where DPI = " + DPI + " and nombre = '" + nombre + "'"));
            }
            return -1;
        }
        [WebMethod]
        public Boolean Agregar_Reserva(int cod_miembro, int cod_libro)
        {
            if (Miembro_Exist(cod_miembro))
            {
                Base_de_Datos base_de_Datos = new Base_de_Datos();
                return base_de_Datos.Upd_New_DelUnValorQry("Insert into Practica1IPC2.dbo.reservas (cod_libro, cod_cliente) " +
                    " values (" + cod_libro + ", " + cod_miembro + ") ");
            }
            return false;
        }
        [WebMethod]
        public Boolean Agregar_prestamo(string fecha, int cod_miembro, int cod_registro_libro)
        {
            if (Miembro_Exist(cod_miembro))
            {
                Base_de_Datos base_de_Datos = new Base_de_Datos();
                bool correcto = base_de_Datos.Upd_New_DelUnValorQry("Insert into Practica1IPC2.dbo.prestamos (fecha_prestamo, cod_cliente, cod_registro_libro, devuelto) " +
                    " values ('" + fecha + "', " + cod_miembro + ", " + cod_registro_libro + ", 0) ");
                if (correcto)
                {
                    base_de_Datos.Upd_New_DelUnValorQry("Delete from Practica1IPC2.dbo.reservas where cod_cliente = " + cod_miembro + " and cod_libro= " + 
                        base_de_Datos.SelectUnValorQry("select cod_libro from Practica1IPC2.dbo.libros where cod_registro = "+ cod_registro_libro) );
                    return base_de_Datos.Upd_New_DelUnValorQry("update Practica1IPC2.dbo.libros set estado = 'Prestado' where cod_registro = " + cod_registro_libro);
                }
                return false;
            }
            return false;
        }
        [WebMethod]
        public string Lista_Autores()
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            DataTable tabla = base_de_Datos.FillTableData(" Select * from Practica1IPC2.dbo.autores");
            return DataTableToJSON(tabla);
        }
        [WebMethod]
        public string Lista_libros_disponibles()
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            DataTable tabla = base_de_Datos.FillTableData(" Select * from Practica1IPC2.dbo.libros where estado = 'Disponible'");
            return DataTableToJSON(tabla);
        }
        [WebMethod]
        public string Lista_libros_Prestados()
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            DataTable tabla = base_de_Datos.FillTableData(" Select * from Practica1IPC2.dbo.libros where estado = 'Prestado'");
            return DataTableToJSON(tabla);
        }
        [WebMethod]
        public int Max_Lista_libros()
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            DataTable tabla = base_de_Datos.FillTableData(" Select MAX(cod_libro) from Practica1IPC2.dbo.libros ");
            foreach (DataRow drtabla in tabla.Rows)
            {
                try
                {
                    return Convert.ToInt32(drtabla[0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }
        [WebMethod]
        public string Consulta(String nombre)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            DataTable tabla = base_de_Datos.FillTableData("Select Top 1 lm.cod_libro, lm.nombre as Titulo_de_Libro, (a.nombre + a.apellido) as Autor, " + 
            " (Select COUNT(l.estado) from Practica1IPC2.dbo.libros l where l.estado = 'Disponible' and lm.cod_libro=l.cod_libro) as Disponibles , "+
            " (Select COUNT(l.estado) from Practica1IPC2.dbo.libros l where l.estado = 'Prestado' and lm.cod_libro=l.cod_libro) as Prestados, "+
            " (Select COUNT(r.cod_libro) from Practica1IPC2.dbo.reservas r " +
            " where r.cod_libro = lm.cod_libro)  as Reservados " +
            " from Practica1IPC2.dbo.autores a, Practica1IPC2.dbo.libros lm where a.cod_autor=lm.cod_autor and lm.nombre = '" + nombre + "' ");
            return DataTableToJSON(tabla);
        }
        [WebMethod]
        public string Reporte()
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            DataTable tabla = base_de_Datos.FillTableData("Select cod_libro as Codigo, nombre as Titulo, COUNT(cod_libro) as Cantidad from Practica1IPC2.dbo.prestamos p, Practica1IPC2.dbo.libros l " +
            " where l.cod_registro=p.cod_registro_libro  group by l.cod_libro, l.nombre order by Cantidad desc");

            return DataTableToJSON(tabla);
        }
        [WebMethod]
        public Boolean Devolucion(string fecha, int cod_miembro, int cod_registro_libro)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            string cod_miembro_real = base_de_Datos.SelectUnValorQry("Select cod_cliente from Practica1IPC2.dbo.prestamos where cod_registro_libro=" + cod_registro_libro + " and devuelto='False';");
            if(cod_miembro_real!=cod_miembro.ToString())
            {
                return false;
            }
            bool correcto = base_de_Datos.Upd_New_DelUnValorQry("update Practica1IPC2.dbo.libros set estado = 'Disponible'"+
                " where cod_registro = " + cod_registro_libro);
            if(correcto)
            {
                return base_de_Datos.Upd_New_DelUnValorQry("update Practica1IPC2.dbo.prestamos set devuelto = 'True', fecha_entrega='" + fecha + 
                    "' where  cod_cliente = " + cod_miembro + " and cod_registro_libro = " + cod_registro_libro);
            }
            return false;
        }
        [WebMethod]
        public Boolean Max_Miembro(int cod_miembro)
        {
            if (Miembro_Exist(cod_miembro))
            {
                Base_de_Datos base_de_Datos = new Base_de_Datos();
                int cantidad = Convert.ToInt32(base_de_Datos.SelectUnValorQry("select (COUNT(cod_cliente) + (select COUNT(cod_cliente) from Practica1IPC2.dbo.prestamos "+
                    " where  cod_cliente = " + cod_miembro + " and devuelto = 'false')) from Practica1IPC2.dbo.reservas where cod_cliente = " + cod_miembro));
                if (cantidad == 5)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        private bool Miembro_Exist(int cod_miembro)
        {
            try
            {
                Base_de_Datos base_de_Datos = new Base_de_Datos();
                base_de_Datos.SelectUnValorQry("select carnet from Practica1IPC2.dbo.clientes where carnet= " + cod_miembro);
                return true;
            }
            catch
            {
                return false;
            }
        }



        private string DataTableToJSON(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(list);
        }
        

    }



    
}
