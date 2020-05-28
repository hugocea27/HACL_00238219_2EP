using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial
{
    public partial class Principal : Form
    {
        private static string usuarioActual = Consultas.usuarioActual;
        
        public Principal()
        {
            InitializeComponent();
            if (Consultas.obtenerRango() == false)
            {
                tabControl1.TabPages[1].Parent = null;
                tabControl1.TabPages[1].Parent = null;
                tabControl1.TabPages[1].Parent = null;
                tabControl1.TabPages[2].Parent = null;
            }
            actualizarControles();
        }

        public void actualizarControles()
        {
            var business = Conexion.realizarConsulta("SELECT name FROM business");
            var businnesCombobox = new List<string>();

            foreach (DataRow dr in business.Rows)
            {
                businnesCombobox.Add(dr[0].ToString());
            }

            comboBox2.DataSource = businnesCombobox;
            comboBox3.DataSource = businnesCombobox;
            comboBox4.DataSource = businnesCombobox;
            comboBox5.DataSource = businnesCombobox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string accion =
                $"INSERT INTO ADDRESS(idUser, address) VALUES({Consultas.obtenerId()}, '{textBox1.Text}')";
            Conexion.realizarAccion(accion);
            string consulta = $"select ad.idAddress, ad.address from address ad where idUser = {Consultas.obtenerId()}";
            var dt=Conexion.realizarConsulta(consulta);
            dataGridView1.DataSource = dt;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = $"select ad.idAddress, ad.address from address ad where idUser = {Consultas.obtenerId()}";
                var dt=Conexion.realizarConsulta(consulta);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string accion = $"update address set address = '{textBox3.Text}' where idAddress = '{textBox2.Text}'";
            Conexion.realizarAccion(accion);
            string consulta = $"select ad.idAddress, ad.address from address ad where idUser = {Consultas.obtenerId()}";
            var dt=Conexion.realizarConsulta(consulta);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string accion = $"insert into BUSINESS(name, description) VALUES ('{textBox8.Text}', '{textBox9.Text}')";
            Conexion.realizarAccion(accion);
            string consulta = $"SELECT * FROM BUSINESS";
            var dt = Conexion.realizarConsulta(consulta);
            dataGridView2.DataSource = dt;
            actualizarControles();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string accion = $"DELETE FROM BUSINESS WHERE idBusiness = '{textBox10.Text}'";
            Conexion.realizarAccion(accion);
            string consulta = $"SELECT * FROM BUSINESS";
            var dt = Conexion.realizarConsulta(consulta);
            dataGridView2.DataSource = dt;
            actualizarControles();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string consulta = $"SELECT * FROM BUSINESS";
            var dt = Conexion.realizarConsulta(consulta);
            dataGridView2.DataSource = dt;
            actualizarControles();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string consulta = $"SELECT idBusiness FROM business WHERE name = '{comboBox2.SelectedItem.ToString()}'";
            
            var dt = Conexion.realizarConsulta(consulta);
            var drw = dt.Rows[0];
            var idBusiness = Convert.ToInt32(drw[0].ToString());

            string accion = $"INSERT INTO Product(idBusiness, name) VALUES(" +
                              $"{idBusiness},'{textBox11.Text}')";
                    
            Conexion.realizarAccion(accion);
            actualizarControles();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string consulta = $"SELECT idBusiness FROM business WHERE name = '{comboBox3.SelectedItem.ToString()}'";
            
            var dt = Conexion.realizarConsulta(consulta);
            var drw = dt.Rows[0];
            var idBusiness = Convert.ToInt32(drw[0].ToString());

            string accion = $"DELETE FROM product where idProduct = '{textBox12.Text}'";

            Conexion.realizarAccion(accion);
            actualizarControles();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string consulta = $"SELECT idBusiness FROM business WHERE name = '{comboBox3.SelectedItem.ToString()}'";
            var dt = Conexion.realizarConsulta(consulta);
            var drw = dt.Rows[0];
            var idBusiness = Convert.ToInt32(drw[0].ToString());
            string consulta2 = $"SELECT p.idProduct, p.name FROM PRODUCT p WHERE idBusiness = {idBusiness}";
            var dt2=Conexion.realizarConsulta(consulta2);
            dataGridView3.DataSource = dt2;
            actualizarControles();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string accion =
                    $"INSERT INTO APPUSER(fullname, username, password, userType) " +
                    $" VALUES('{textBox14.Text}', '{textBox13.Text}', '{textBox16.Text}', false)";
                Conexion.realizarAccion(accion);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string accion = $"DELETE FROM APPUSER WHERE idUser = '{textBox15.Text}'";
            Conexion.realizarAccion(accion);
        }
        
        private void button12_Click(object sender, EventArgs e)
        {
            string consulta = $"SELECT * FROM APPUSER";
            var dt = Conexion.realizarConsulta(consulta);
            dataGridView4.DataSource = dt;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string consulta = $"SELECT idBusiness FROM business WHERE name = '{comboBox5.SelectedItem.ToString()}'";
            var dt = Conexion.realizarConsulta(consulta);
            var drw = dt.Rows[0];
            var idBusiness = Convert.ToInt32(drw[0].ToString());
            string consulta2 = $"SELECT p.idProduct, p.name FROM PRODUCT p WHERE idBusiness = {idBusiness}";
            var dt2=Conexion.realizarConsulta(consulta2);
            dataGridView5.DataSource = dt2;
            actualizarControles();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string accion = $"INSERT INTO APPORDER(idProduct, idAddress) VALUES('{textBox17.Text}', '{textBox18.Text}')";
            Conexion.realizarAccion(accion);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string accion = $"DELETE FROM APPORDER WHERE idOrder = '{textBox19.Text}'";
            Conexion.realizarAccion(accion);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var dt = Conexion.realizarConsulta(
                $"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address " +
            "FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au " + 
            "WHERE ao.idProduct = pr.idProduct " +
            "AND ao.idAddress = ad.idAddress " +
            "AND ad.idUser = au.idUser "+
            $"AND au.idUser = '{Consultas.obtenerId()}' ");
            dataGridView6.DataSource = dt;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var dt = Conexion.realizarConsulta("SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address "+
            "FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au "+
            "WHERE ao.idProduct = pr.idProduct "+
            "AND ao.idAddress = ad.idAddress "+
            "AND ad.idUser = au.idUser;");

            dataGridView7.DataSource = dt;
        }
    }
} 