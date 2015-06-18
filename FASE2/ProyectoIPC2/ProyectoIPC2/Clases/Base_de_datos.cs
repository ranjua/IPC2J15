using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoIPC2.Clases
{
    public class Base_de_Datos
    {

        public SqlConnection connection;

        //String de Conexion
        public void Initialize()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["MySql_sisquinielas"].ConnectionString;
            connection = new SqlConnection(connectionString);

        }

        //Abre conexion a la base
        public bool OpenConnection()
        {
            Initialize();
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        //Obtiene tabla 
        public DataTable FillTableData(string pQuery)
        {
            DataTable DtResultado = new DataTable();

            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter(pQuery, connection);
                cmd.Fill(DtResultado);
            }
            catch
            {
                Initialize();

                SqlDataAdapter cmd = new SqlDataAdapter(pQuery, connection);
                try
                {
                    cmd.Fill(DtResultado);
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Session["Error"] = ex.Message;
                }

            }
            return DtResultado;
        }

        //Select statement
        public string SelectUnValorQry(string pQuery)
        {
            string valor = "";

            try
            {
                //Crea Command
                SqlCommand cmd = new SqlCommand(pQuery, connection);
                //Crea data reader y Execute command
                valor = cmd.ExecuteScalar().ToString();
                return valor;
            }
            catch
            {
                //Abre conexion
                OpenConnection();
                //Crea Command
                SqlCommand cmd = new SqlCommand(pQuery, connection);
                try
                {
                    //Crea data reader y Execute command
                    valor = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Session["Error"] = ex.Message;
                }
                return valor;
            }
        }

        //Update_New_Delete statment
        public void Upd_New_DelUnValorQry(string pQuery)
        {
            try
            {
                //Crea Command
                SqlCommand cmd = new SqlCommand(pQuery, connection);
                //Execute command
                cmd.ExecuteScalar();
            }
            catch
            {
                OpenConnection();
                //Crea Command
                SqlCommand cmd = new SqlCommand(pQuery, connection);
                //Execute command
                try
                {
                    cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Session["Error"] = ex.Message;
                }
            }
        }
        //Verificar existencia de dato en Base de Datos
        public bool Verify_Query(string pQuery)
        {
            try
            {
                //Crea Command
                SqlCommand cmd = new SqlCommand(pQuery, connection);
                //Ejecuta Command y verifica existencia
                cmd.ExecuteScalar();
                return true;
            }
            catch
            {
                //Abre conexion
                OpenConnection();
                //Crea Command
                SqlCommand cmd = new SqlCommand(pQuery, connection);
                //Ejecuta Command y verifica existencia
                try
                {
                    cmd.ExecuteScalar();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }

        //Verifica conexion
        public string TestConexion()
        {

            bool Test = OpenConnection();
            string resultado;
            if (Test == true)
            { resultado = "Conexion Exitosa"; }
            else
            { resultado = "Conexion Fallida"; }

            return resultado;
        }


    }
}