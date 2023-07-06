using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio_de_sesión
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Boton1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "alexrosales") & (textBox2.Text == "alexzael00"))
            {
                Application.Restart();
            }
            else
            {
                MessageBox.Show("La contraseña o el usuario está incorrecto.");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "～";
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                checkBox1.Text = "👁";
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
