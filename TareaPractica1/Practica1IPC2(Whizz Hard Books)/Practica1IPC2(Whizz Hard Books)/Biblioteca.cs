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
        }

        private void btn_Dev_Click(object sender, EventArgs e)
        {
            WSS.Devolucion(DateTime.Now.Date.ToString(), Convert.ToInt32(txt_dev_carnet.Text), Convert.ToInt32(txt_dev_cod_reg_lib.Text));
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            WSS.Agregar_Miembro(txt_reg_nombre.Text, Convert.ToInt32(txt_reg_dpi.Text), txt_reg_dir.Text, Convert.ToInt32(txt_reg_tel.Text));
        }


        


    }
}
