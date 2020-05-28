using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Consultas.usuarioActual = textBox2.Text;
            string contra = Consultas.obtenerContra();

            if (contra.Equals(textBox3.Text))
            {
                try
                {
                    MessageBox.Show("Logeado!");

                    Principal ventana = new Principal();
                    ventana.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Incorrecta");
            }
        }

        private void CambiarContra_Click(object sender, EventArgs e)
        {
            CambiarContra ventana = new CambiarContra();
            ventana.Show();
            this.Hide();
        }
    }
}