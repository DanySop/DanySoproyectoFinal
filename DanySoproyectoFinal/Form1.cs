using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanySoproyectoFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( textBox1.Text == "Dany" && double.Parse(textBox2.Text) == 1010)
            {
                this.Hide();
                Administrador2 form2 = new Administrador2();
                form2.Show();
            }
            else
            {
                MessageBox.Show("NO VALIDO");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Dany" && double.Parse(textBox2.Text) == 1010)
            {
                this.Hide();
                Cajero2 form2 = new Cajero2();
                form2.Show();
            }
            else
            {
                MessageBox.Show("NO VALIDO");
            }
        }
    }
}
