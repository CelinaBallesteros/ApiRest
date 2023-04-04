using Pokemon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon
{
    public partial class Form1 : Form
    {
        ApiRequest api = new ApiRequest();

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public void cargarDatos()
        {
            flowLayoutPanel1.Controls.Clear();

            PokeLista pokemon = new PokeLista();

            pokemon = api.ObtenerLista();

            foreach(var item in pokemon.listaPokemones)
            {
                flowLayoutPanel1.Controls.Add(new PokeVista(item.nombrePokemon, item.GetImagen()));

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
