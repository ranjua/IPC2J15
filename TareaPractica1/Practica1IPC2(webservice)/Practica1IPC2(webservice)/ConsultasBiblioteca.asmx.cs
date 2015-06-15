using System;
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
            base_de_Datos.Upd_New_DelUnValorQry("Insert into Practica1IPC2.dbo.libros (cod_libro, nombre, paginas, tema, estado, cod_autor) " +
                " values (" + cod_libro + ",'" + titulo + "'," + pags + ", '" + tema + "','biblioteca'," + cod_autor + ") ");
            if (Session["Error"] != null)
            {
                if (Session["Error"].ToString() != "")
                {
                    return true;
                }
                else { return false; }
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public string Lista_Autores()
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            DataTable tabla = base_de_Datos.FillTableData(" Select * from Practica1IPC2.dbo.autores");
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
