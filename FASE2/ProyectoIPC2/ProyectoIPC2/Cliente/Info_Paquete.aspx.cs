using ProyectoIPC2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2.Cliente
{
    public partial class Info_Paquete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                LlenarGrd(Session["Paquete"].ToString());
            
        }
        
        protected void Devolucion(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            base_de_Datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Paquetes set estado = 'Devolucion' where cod_paquete = " + btn.ID);
            LlenarGrd(Session["Paquete"].ToString());
        }

        public void LlenarGrd(string cod_paquete)
        {
            try
            {
                Pnl_Detalles.Controls.Clear();
                Panel pnl_cod = new Panel();
                pnl_cod.CssClass = "pnl_track";
                Label lbl_cod = new Label();
                lbl_cod.Text = "Codigo de Paquete";
                lbl_cod.CssClass = "lbl_track";
                pnl_cod.Controls.Add(lbl_cod);
                Label lbl_cod_P = new Label();
                lbl_cod_P.Text = Session["Paquete"].ToString();
                lbl_cod_P.CssClass = "lbl_P_track";
                pnl_cod.Controls.Add(lbl_cod_P);
                Pnl_Detalles.Controls.Add(pnl_cod);

                Base_de_Datos base_de_Datos = new Base_de_Datos();
                DataTable tabla = new DataTable();
                tabla = base_de_Datos.FillTableData("Select p.costo, i.categoria, p.libras, p.estado, p.cod_lote from ProyectoIPC2.dbo.Impuestos i," + 
                    " ProyectoIPC2.dbo.Paquetes p where p.cod_impuesto=i.cod_impuesto and p.cod_paquete= " + Session["Paquete"].ToString());
                foreach (DataRow drtabla in tabla.Rows)
                {
                    Panel pnl_costo = new Panel();
                    pnl_costo.CssClass = "pnl_track";
                    Label lbl_costo = new Label();
                    lbl_costo.Text = "Precio de Producto";
                    lbl_costo.CssClass = "lbl_track";
                    pnl_costo.Controls.Add(lbl_costo);
                    Label lbl_costo_P = new Label();
                    lbl_costo_P.Text = drtabla[0].ToString();
                    lbl_costo_P.CssClass = "lbl_P_track";
                    pnl_costo.Controls.Add(lbl_costo_P);

                    Panel pnl_imp = new Panel();
                    pnl_imp.CssClass = "pnl_track";
                    Label lbl_imp = new Label();
                    lbl_imp.Text = "Categoria de Impuesto";
                    lbl_imp.CssClass = "lbl_track";
                    pnl_imp.Controls.Add(lbl_imp);
                    Label lbl_imp_P = new Label();
                    lbl_imp_P.Text = drtabla[1].ToString();
                    lbl_imp_P.CssClass = "lbl_P_track";
                    pnl_imp.Controls.Add(lbl_imp_P);

                    Panel pnl_peso = new Panel();
                    pnl_peso.CssClass = "pnl_track";
                    Label lbl_peso = new Label();
                    lbl_peso.Text = "Peso en libras";
                    lbl_peso.CssClass = "lbl_track";
                    pnl_peso.Controls.Add(lbl_peso);
                    Label lbl_peso_P = new Label();
                    lbl_peso_P.Text = drtabla[2].ToString();
                    lbl_peso_P.CssClass = "lbl_P_track";
                    pnl_peso.Controls.Add(lbl_peso_P);

                    Pnl_Detalles.Controls.Add(pnl_costo);
                    Pnl_Detalles.Controls.Add(pnl_imp);
                    Pnl_Detalles.Controls.Add(pnl_peso);

                    if (drtabla[3].ToString().Equals("EEUU") || drtabla[3].ToString().Equals("Aduana") ||
                        drtabla[3].ToString().Equals("Guatemala") || drtabla[3].ToString().Equals("Facturado") ||
                        drtabla[3].ToString().Equals("Devolucion") || drtabla[3].ToString().Equals("Devuelto"))
                    {
                        DataTable Stabla = new DataTable();
                        Stabla = base_de_Datos.FillTableData("Select fecha_salida from ProyectoIPC2.dbo.Lotes where cod_lote= " + drtabla[4].ToString());
                        foreach (DataRow drStabla in Stabla.Rows)
                        {
                            Panel pnl_EEUU = new Panel();
                            pnl_EEUU.CssClass = "pnl_track";
                            Label lbl_EEUU = new Label();
                            lbl_EEUU.Text = "Salida de EEUU";
                            lbl_EEUU.CssClass = "lbl_track";
                            pnl_EEUU.Controls.Add(lbl_EEUU);
                            Label lbl_EEUU_P = new Label();
                            lbl_EEUU_P.Text = drStabla[0].ToString();
                            lbl_EEUU_P.CssClass = "lbl_P_track";
                            pnl_EEUU.Controls.Add(lbl_EEUU_P);
                            Pnl_Detalles.Controls.Add(pnl_EEUU);
                        }
                    }
                    if (drtabla[3].ToString().Equals("Aduana") || drtabla[3].ToString().Equals("Guatemala") || drtabla[3].ToString().Equals("Facturado") ||
                        drtabla[3].ToString().Equals("Devolucion") || drtabla[3].ToString().Equals("Devuelto"))
                    {
                        DataTable Stabla = new DataTable();
                        Stabla = base_de_Datos.FillTableData("Select fecha_aduana from ProyectoIPC2.dbo.Lotes where cod_lote= " + drtabla[4].ToString());
                        foreach (DataRow drStabla in Stabla.Rows)
                        {
                            Panel pnl_Aduana = new Panel();
                            pnl_Aduana.CssClass = "pnl_track";
                            Label lbl_Aduana = new Label();
                            lbl_Aduana.Text = "Llegada a Aduana";
                            lbl_Aduana.CssClass = "lbl_track";
                            pnl_Aduana.Controls.Add(lbl_Aduana);
                            Label lbl_Aduana_P = new Label();
                            lbl_Aduana_P.Text = drStabla[0].ToString();
                            lbl_Aduana_P.CssClass = "lbl_P_track";
                            pnl_Aduana.Controls.Add(lbl_Aduana_P);
                            Pnl_Detalles.Controls.Add(pnl_Aduana);
                        }
                    }
                    if (drtabla[3].ToString().Equals("Guatemala") || drtabla[3].ToString().Equals("Facturado")||
                        drtabla[3].ToString().Equals("Devolucion") || drtabla[3].ToString().Equals("Devuelto"))
                    {
                        DataTable Stabla = new DataTable();
                        Stabla = base_de_Datos.FillTableData("Select fecha_llegada from ProyectoIPC2.dbo.Lotes where cod_lote= " + drtabla[4].ToString());
                        foreach (DataRow drStabla in Stabla.Rows)
                        {
                            Panel pnl_Guatemala = new Panel();
                            pnl_Guatemala.CssClass = "pnl_track";
                            Label lbl_Guatemala = new Label();
                            lbl_Guatemala.Text = "Llegada a Guatemala";
                            lbl_Guatemala.CssClass = "lbl_track";
                            pnl_Guatemala.Controls.Add(lbl_Guatemala);
                            Label lbl_Guatemala_P = new Label();
                            lbl_Guatemala_P.Text = drStabla[0].ToString();
                            lbl_Guatemala_P.CssClass = "lbl_P_track";
                            pnl_Guatemala.Controls.Add(lbl_Guatemala_P);
                            Pnl_Detalles.Controls.Add(pnl_Guatemala);
                        }
                    }
                    if (drtabla[3].ToString().Equals("Facturado"))
                    {
                        Panel pnl_Guatemala = new Panel();
                        pnl_Guatemala.CssClass = "pnl_track";
                        Label lbl_Guatemala = new Label();
                        lbl_Guatemala.Text = "Facturado";
                        lbl_Guatemala.CssClass = "lbl_track";
                        Button btn = new Button();
                        btn.Text = "Solicitar Devolucion";
                        btn.ID = ""+cod_paquete;
                        btn.Click += new EventHandler(Devolucion);
                        btn.CssClass = "lbl_P_track";
                        pnl_Guatemala.Controls.Add(btn);
                        pnl_Guatemala.Controls.Add(lbl_Guatemala);
                        Pnl_Detalles.Controls.Add(pnl_Guatemala);
                    }
                    if (drtabla[3].ToString().Equals("Devolucion"))
                    {
                        Panel pnl_Guatemala = new Panel();
                        pnl_Guatemala.CssClass = "pnl_track";
                        Label lbl_Guatemala = new Label();
                        lbl_Guatemala.Text = "En Proceso de Devolucion";
                        lbl_Guatemala.CssClass = "lbl_Ctrack";
                        pnl_Guatemala.Controls.Add(lbl_Guatemala);
                        Pnl_Detalles.Controls.Add(pnl_Guatemala);
                    }
                    if (drtabla[3].ToString().Equals("Devuelto"))
                    {
                        Panel pnl_Guatemala = new Panel();
                        pnl_Guatemala.CssClass = "pnl_track";
                        Label lbl_Guatemala = new Label();
                        lbl_Guatemala.Text = "Devuelto a sede EEUU";
                        lbl_Guatemala.CssClass = "lbl_Ctrack";
                        pnl_Guatemala.Controls.Add(lbl_Guatemala);
                        Pnl_Detalles.Controls.Add(pnl_Guatemala);
                    }

                }

                Label lbl_espacio = new Label();
                lbl_espacio.Text = "<br/><br/>";
                Pnl_Detalles.Controls.Add(lbl_espacio);
            }
            catch(Exception e)
            {
                Response.Redirect("Info_Paquetes.aspx");
            }
        }
    }
}