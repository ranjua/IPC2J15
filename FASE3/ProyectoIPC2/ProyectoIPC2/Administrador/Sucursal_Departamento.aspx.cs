using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Administrador
{
    public partial class Sucursal_Departamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenar();
            }
        }
        private void LLenar()
        {
            Base_de_Datos base_de_datos = new Base_de_Datos();
            DataTable tabla = new DataTable();
            tabla = base_de_datos.FillTableData("Select cod_sucursal, nombre from ProyectoIPC2.dbo.Sucursales");
            int x = 1;
            Ddl_suc.Items.Clear();
            try
            {
                foreach (DataRow drtabla in tabla.Rows)
                {
                    System.Web.UI.WebControls.ListItem Newitem = new System.Web.UI.WebControls.ListItem();
                    Newitem.Value = drtabla[0].ToString();
                    Newitem.Text = ""+drtabla[1].ToString();
                    if (x == 1)
                    {
                        Newitem.Selected = true;
                        x++;
                    }
                    Ddl_suc.Items.Add(Newitem);
                    Ddl_suc.Visible = true;
                }
            }
            catch
            { }
        }
        protected void Btn_suc_Click(object sender, EventArgs e)
        {
            if (Txt_sede.Text != "" && Txt_suc.Text != "")
            {
                Base_de_Datos base_de_datos = new Base_de_Datos();
                base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Sucursales values('" + Txt_suc.Text +
                    "','" + Txt_sede.Text + "', 50000000,100,0,0,1,1)");
                LLenar();
            }
        }

        protected void Btn_dep_Click(object sender, EventArgs e)
        {
            if (Txt_dep.Text != "")
            {
                Base_de_Datos base_de_datos = new Base_de_Datos();
                base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Departamentos values('" + Txt_dep.Text +"')");
                string dep = base_de_datos.SelectUnValorQry("select MAX(cod_departamento) from ProyectoIPC2.dbo.Departamentos ");
                base_de_datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.SucDep values("+Ddl_suc.SelectedValue+","+dep+")");
                LLenar();
            }
        }
    }
}