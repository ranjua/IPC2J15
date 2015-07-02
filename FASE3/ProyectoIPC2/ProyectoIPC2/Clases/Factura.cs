using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;


namespace ProyectoIPC2.Clases
{
    public class Factura
    {
        public string cod_factura { get; set; }
        public int cod_paquete { get; set; }
        public double comision { get; set; }
        public double costo_libra { get; set; }
        public double impuesto { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int cod_facturador { get; set; }
        public string NIT { get; set; }
        public double precio { get; set; }
        public int libras { get; set; }

        public Factura(string cod_paquete)
        {
            Base_de_Datos base_de_Datos = new Base_de_Datos();
            Fecha_Hora FH = new Fecha_Hora();

            this.cod_paquete = Convert.ToInt32(cod_paquete);
            this.fecha = FH.Fecha();
            this.hora = FH.Hora(); 
            DataTable tabla = new DataTable();
            tabla = base_de_Datos.FillTableData("select s.comision, s.costo_lb, i.porcentaje, c.NIT, p.costo, p.libras " +
            " from ProyectoIPC2.dbo.Paquetes p, ProyectoIPC2.dbo.Sucursales s, ProyectoIPC2.dbo.Impuestos i, ProyectoIPC2.dbo.Clientes c " +
            " where c.cod_sucursal=s.cod_sucursal and c.DPI=p.cod_cliente and p.cod_impuesto=i.cod_impuesto and cod_paquete = " + cod_paquete);
            foreach (DataRow drtabla in tabla.Rows)
            {
                this.comision = Convert.ToDouble(drtabla[0].ToString());
                this.costo_libra = Convert.ToDouble(drtabla[1].ToString());
                this.impuesto = Convert.ToDouble(drtabla[2].ToString());
                this.NIT = drtabla[3].ToString();
                this.precio = Convert.ToDouble(drtabla[4].ToString());
                this.libras = Convert.ToInt32(drtabla[5].ToString());
            }

            base_de_Datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Facturas values('" + comision + "','" + costo_libra + "','" + impuesto + "'," +
                "'" + fecha + "','" + hora + "'," + this.cod_paquete + "," + HttpContext.Current.Session["Cod_Empleado"].ToString() + ")");
            this.cod_factura = base_de_Datos.SelectUnValorQry("select Max(cod_factura) from ProyectoIPC2.dbo.Facturas");
            base_de_Datos.Upd_New_DelUnValorQry("update ProyectoIPC2.dbo.Paquetes set estado = 'Facturado' where cod_paquete = " + cod_paquete);
            
            base_de_Datos.Upd_New_DelUnValorQry("insert into ProyectoIPC2.dbo.Historial_P values(" + cod_paquete +
                    ", " + HttpContext.Current.Session["Cod_Empleado"].ToString() + ", 'Facturado', '" + FH.Fecha() + "', '" + FH.Hora() + "' ) ");
           
        }

        public void A_PDF(Factura factura)
        {
            Document doc = new Document(PageSize.LETTER, 10f, 10f, 42f, 35f);
            PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);

            doc.Open();
            PdfPTable tabla = new PdfPTable(2);
            PdfPCell cell = new PdfPCell(new Paragraph("Factura"));
            cell.Colspan = 2; cell.HorizontalAlignment=Element.ALIGN_CENTER;
            tabla.AddCell(cell);
            tabla.AddCell("Codigo de Factura"); tabla.AddCell("" + factura.cod_factura);
            tabla.AddCell("Fecha"); tabla.AddCell("" + factura.fecha);
            tabla.AddCell("Hora"); tabla.AddCell("" + factura.hora);
            tabla.AddCell("NIT"); tabla.AddCell("" + factura.NIT);
            tabla.AddCell("Precio de producto"); tabla.AddCell("Q." + factura.precio);
            tabla.AddCell("Cantidad de libras"); tabla.AddCell("" + factura.libras+" lb");
            tabla.AddCell("Costo por Libra: "); tabla.AddCell("Q" + factura.costo_libra + " - Q." + (factura.costo_libra * factura.libras));
            tabla.AddCell("Impuesto: "); tabla.AddCell("%" + (factura.impuesto * 100) + " - Q." + (factura.precio * factura.impuesto));
            tabla.AddCell("Comision: "); tabla.AddCell("%" + (factura.comision * 100) + " - Q." + (factura.precio * factura.comision));
            tabla.AddCell("Total: "); tabla.AddCell("Q."+((factura.precio * factura.comision) + (factura.precio * factura.impuesto) + (factura.costo_libra * factura.libras)));
            doc.Add(tabla);
            doc.Close();
            
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AppendHeader("content-disposition", "attachment;filename=Factura" + factura.cod_factura + ".pdf");
            HttpContext.Current.Response.Write(doc);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
            
        }
        

    }
}