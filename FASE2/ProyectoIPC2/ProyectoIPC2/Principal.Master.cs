using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lbl_Usuario.Focus();
            if (!IsPostBack)
            {
                if (Session["Cod_Rol_Usuario"] != null)
                {
                    //Llena Menu
                    Base_de_Datos Estado = new Base_de_Datos();
                    //Obtiene botones nivel 0
                    DataTable dtmenu = new DataTable();
                    dtmenu = Estado.FillTableData("SELECT b.cod_botones, b.texto, b.pag_dest, b.tool_tip FROM ProyectoIPC2.dbo.botones b, ProyectoIPC2.dbo.BotonRol BR" +
                        " where b.cod_padre=0 and b.nivel=0 and BR.cod_Boton = b.cod_botones and BR.cod_Rol = " + Session["Cod_Rol_Usuario"].ToString() + " order by num_orden asc;");
                    foreach (DataRow drMenuP in dtmenu.Rows)
                    {
                        int x = Int32.Parse("0" + drMenuP[0]);
                        MenuItem menuItem = new MenuItem();
                        menuItem.Text = drMenuP[1].ToString();
                        menuItem.NavigateUrl = drMenuP[2].ToString();
                        menuItem.ToolTip = drMenuP[3].ToString();
                        //Obtiene botones nivel 2
                        dtmenu = Estado.FillTableData("SELECT b.cod_botones, b.texto, b.pag_dest, b.tool_tip FROM ProyectoIPC2.dbo.botones b, ProyectoIPC2.dbo.BotonRol BR" +
                            " where b.cod_padre=" + x + " and b.nivel=1 and BR.cod_Boton = b.cod_botones and BR.cod_Rol = " + Session["Cod_Rol_Usuario"].ToString() + " order by num_orden asc;");
                        foreach (DataRow drMenuPp in dtmenu.Rows)
                        {
                            if ((drMenuPp[2].ToString() != "Administrador/f_partidos.aspx") && (drMenuPp[2].ToString() != "f_equipos.aspx"))
                            {
                                int y = Int32.Parse("0" + drMenuPp[0]);
                                MenuItem submenuItem = new MenuItem();
                                submenuItem.Text = drMenuPp[1].ToString();
                                submenuItem.NavigateUrl = drMenuPp[2].ToString();
                                submenuItem.ToolTip = drMenuPp[3].ToString();
                                menuItem.ChildItems.Add(submenuItem);

                                //Obtiene botones nivel 3
                                dtmenu = Estado.FillTableData("SELECT b.cod_botones, b.texto, b.pag_dest, b.tool_tip FROM ProyectoIPC2.dbo.botones b, ProyectoIPC2.dbo.BotonRol BR" +
                                    " where b.cod_padre=" + y + " and b.nivel=2 and BR.cod_Boton = b.cod_botones and BR.cod_Rol = " + Session["Cod_Rol_Usuario"].ToString() + " order by num_orden asc;");
                                foreach (DataRow dr1MenuPp in dtmenu.Rows)
                                {
                                    MenuItem sub1menuItem = new MenuItem();
                                    sub1menuItem.Text = dr1MenuPp[0].ToString();
                                    sub1menuItem.NavigateUrl = dr1MenuPp[1].ToString();
                                    sub1menuItem.ToolTip = dr1MenuPp[2].ToString();
                                    submenuItem.ChildItems.Add(sub1menuItem);
                                }
                            }
                        }

                        Mnu_P.Items.Add(menuItem);
                    }
                    if(Session["Cod_Rol_Usuario"].Equals("3"))
                    {
                        Base_de_Datos base_de_Datos = new Base_de_Datos();
                        DataTable tabla = new DataTable();
                        tabla = base_de_Datos.FillTableData("select u.usuario, u.nombre, u.apellidos, d.nombre, s.nombre, s.sede from ProyectoIPC2.dbo.Departamentos d, "+
                        " ProyectoIPC2.dbo.Sucursales s, ProyectoIPC2.dbo.Usuarios u, ProyectoIPC2.dbo.Empleados e, ProyectoIPC2.dbo.SucDep sd " + 
                        " where e.cod_usuario = u.cod_usuario and e.cod_suc_dep=sd.cod_Suc_Dep and sd.cod_departamento=d.cod_departamento " + 
                        " and sd.cod_sucursal=s.cod_sucursal and e.cod_empleado= " + Session["Cod_Empleado"] );
                        foreach(DataRow drtabla in tabla.Rows)
                        {
                            Lbl_Usuario.Text = "ID:"+drtabla[0].ToString()+" " + drtabla[1] +" "+ drtabla[2]+"<br/>"+
                                drtabla[4]+","+drtabla[5]+"<br/>" + drtabla[3];
                        }
                    }
                    else
                    {
                       Lbl_Usuario.Text = Session["Cod_Empleado"].ToString() + Session["DPI"].ToString();
                    }
                    if (Session["Cod_Rol_Usuario"] == null)
                    {
                        Btn_Login_out.Text = "Login";
                    }
                    else
                    {
                        Btn_Login_out.Text = "Logout";
                    }
                }
            }
        }






        protected void Btn_Login_out_Click(object sender, EventArgs e)
        {
            Logout();
        }
        public void Logout()
        {
            if  (Session["Cod_Rol_Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Verificar_usuario Log = new Verificar_usuario();
                Log.Logout();
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}