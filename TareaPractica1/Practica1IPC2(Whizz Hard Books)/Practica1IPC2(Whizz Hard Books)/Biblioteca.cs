using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1IPC2_Whizz_Hard_Books_
{
    public partial class Biblioteca : Form
    {
        WebServiceSource.ConsultasBiblioteca WSS;
        public Biblioteca()
        {
            InitializeComponent();
            WSS = new WebServiceSource.ConsultasBiblioteca();
            Llenar_lista_Autores();
            Llenar_lista_libros_disponibles();
            Llenar_lista_libros_prestados();
        }

        private void Llenar_lista_Autores()
        {
            DataTable tabla = (DataTable)JsonConvert.DeserializeObject(WSS.Lista_Autores(), (typeof(DataTable)));
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            foreach(DataRow drtabla in tabla.Rows)
            {
                
                comboSource.Add(Convert.ToInt32(drtabla[0].ToString()), drtabla[1].ToString() + " " + drtabla[2].ToString());
                
            }
            Cmbx_Autores.DataSource = new BindingSource(comboSource, null);
            Cmbx_Autores.DisplayMember = "Value";
            Cmbx_Autores.ValueMember = "Key";
        }

        private void Llenar_lista_libros_disponibles()
        {
            DataTable tabla = (DataTable)JsonConvert.DeserializeObject(WSS.Lista_libros_disponibles(), (typeof(DataTable)));
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            foreach (DataRow drtabla in tabla.Rows)
            {

                comboSource.Add(Convert.ToInt32(drtabla[0].ToString()), drtabla[1].ToString() + " " + drtabla[2].ToString());

            }
            Cmbx_libros_disponibles.DataSource = new BindingSource(comboSource, null);
            Cmbx_libros_disponibles.DisplayMember = "Value";
            Cmbx_libros_disponibles.ValueMember = "Key";
        }
        private void Llenar_lista_libros_prestados()
        {
            DataTable tabla = (DataTable)JsonConvert.DeserializeObject(WSS.Lista_libros_Prestados(), (typeof(DataTable)));
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            foreach (DataRow drtabla in tabla.Rows)
            {

                comboSource.Add(Convert.ToInt32(drtabla[0].ToString()), drtabla[1].ToString() + " " + drtabla[2].ToString());

            }
            cmbx_prestados.DataSource = new BindingSource(comboSource, null);
            cmbx_prestados.DisplayMember = "Value";
            try
            {
                cmbx_prestados.ValueMember = "Key";
            }
            catch 
            {

            }
        }

        private bool Comprobar_Maximo_Miembro(int cod_Miembro)
        {
            return false;
        }

        private void Llenar_Grd_Consulta(string nombre)
        {
            DataTable tabla = (DataTable)JsonConvert.DeserializeObject(WSS.Consulta(nombre), (typeof(DataTable)));
            Grd_Consulta.DataSource = tabla;
        }

        private void btn_Agregar_Libro_Click(object sender, EventArgs e)
        {
            int cod_libro = 1 + WSS.Max_Lista_libros();
            for (int i = 0; i < num_cantidad.Value; i++ )
            {
                int value = ((KeyValuePair<int, string>)Cmbx_Autores.SelectedItem).Key;
                bool correcto = WSS.Agregar_Libro(cod_libro, value, txt_Titulo.Text, Convert.ToInt32(num_pag.Value.ToString()), txt_Tema.Text);
            }
        }

        private void btn_Agregar_Autor_Click(object sender, EventArgs e)
        {
            WSS.Agregar_Autor(txt_nombre_autor.Text, txt_apellido_autor.Text);
            Llenar_lista_Autores();
        }

        private void btn_Dev_Click(object sender, EventArgs e)
        {
            int value = ((KeyValuePair<int, string>)cmbx_prestados.SelectedItem).Key;
            WSS.Devolucion(DateTime.Now.Date.ToString(), Convert.ToInt32(txt_dev_carnet.Text), value);
            Llenar_lista_libros_disponibles();
            Llenar_lista_libros_prestados();
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            WSS.Agregar_Miembro(txt_reg_nombre.Text, Convert.ToInt32(txt_reg_dpi.Text), txt_reg_dir.Text, Convert.ToInt32(txt_reg_tel.Text));
        }

        private void btn_Prestamo_Click(object sender, EventArgs e)
        {
            int value = ((KeyValuePair<int, string>)Cmbx_libros_disponibles.SelectedItem).Key;
            WSS.Agregar_prestamo(DateTime.Now.Date.ToString(), Convert.ToInt32(txt_pres_carnet.Text), value);
            Llenar_lista_libros_disponibles();
            Llenar_lista_libros_prestados();
        }

        private void btn_Reservar_Click(object sender, EventArgs e)
        {
            
            WSS.Agregar_Reserva(Convert.ToInt32(txt_res_carnet.Text),0);
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            Llenar_Grd_Consulta(txt_bus_titulo.Text);
        }

      
    }
}
