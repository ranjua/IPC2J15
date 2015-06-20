using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Director
{
    public partial class Consultar_Equipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                getEmpleados();
            }
        }

        public void getEmpleados()
        {

        }

        public void getEmpleados(int departamento)
        {

        }

        protected void Btn_Ver_Todos_Click(object sender, EventArgs e)
        {
            getEmpleados();
        }

        protected void Ddl_Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            getEmpleados(Convert.ToInt32(Ddl_Departamento.SelectedValue));
        }
    }
}