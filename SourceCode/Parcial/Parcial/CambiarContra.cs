using System;
using System.Windows.Forms;


namespace Parcial
{
    public partial class CambiarContra : Form
    {
        public CambiarContra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta = $"select password from appuser where username='{textBox1.Text}'";
            var dt = Conexion.realizarConsulta(consulta);
            var dr = dt.Rows[0];
            var contra = Convert.ToString(dr[0].ToString());

            if (contra.Equals(textBox2.Text))
            {
                try
                {
                    string accion = $"update appuser set password = '{textBox3.Text}'" +
                                    $" where username = '{textBox1.Text}'";
                    Conexion.realizarAccion(accion);
                    
                    MessageBox.Show("Cambios guardados");
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
    }
}