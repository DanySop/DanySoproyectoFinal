using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DanySoproyectoFinal
{
    public partial class Cajero2 : Form
    {
        static List<caja1> lcaja = new List<caja1>();
        static List<Comprador1> lcomprador = new List<Comprador1>();
        static int posicionmodificar;
        public Cajero2()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\usuario\source\repos\DanySoproyectoFinal\DanySoproyectoFinal\bin\Debug\cajero.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Se cargan los datos del archivo a la lista de cajero
            while (reader.Peek() > -1)
            {
                //Leer los datos y guardarlos en un temporal
                Comprador1 comptemp = new Comprador1();
                comptemp.Nit1 = reader.ReadLine();
                comptemp.Nombre1 = reader.ReadLine();
                comptemp.Apellido1 = reader.ReadLine();
                comptemp.Direccion1 = reader.ReadLine();

                //Agregar a la lista el temporal
                lcomprador.Add(comptemp);
            }

            reader.Close();


            //Se recorre la lista de cajero
            for (int i = 0; i < lcomprador.Count; i++)
            {
                //Si es el dato a buscar es igual al dato de la lista mostrarlo en los textbox
                if (lcomprador[i].Nit1 == textBox1.Text)//busca los datos
                {
                    textBox2.Text = lcomprador[i].Nombre1;
                    textBox3.Text = lcomprador[i].Apellido1;
                    textBox4.Text = lcomprador[i].Direccion1;

                    //Guardar en que posicion se encontró el dato para utilizarla mas adelante al momento de modificar
                    posicionmodificar = i;
                }
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //codigo de multiplicacion de canidad y precio
            textBox14.Text = (Convert.ToInt32(textBox11.Text) * Convert.ToInt32(textBox12.Text)).ToString();
            textBox13.Text = (Convert.ToInt32(textBox11.Text) * Convert.ToInt32(textBox12.Text)).ToString();
            textBox13.Text = (Convert.ToInt32(textBox11.Text) * Convert.ToInt32(textBox12.Text)).ToString();
            //temporal
            caja1 cajatemp = new caja1();
            cajatemp.Nombreproduc = textBox9.Text;
            cajatemp.Categoria = textBox10.Text;
            cajatemp.Cantidad1 = textBox11.Text;
            cajatemp.Precio1 = textBox12.Text;
            cajatemp.SubTotal = textBox13.Text;
            cajatemp.Total1 = textBox14.Text;

            // el objeto temporal guardarlo en la lista 
            lcaja.Add(cajatemp);

            //mostrar la lista del datagridview

            dataGridView1.DataSource = null;
            dataGridView1.Refresh(); //es para refrescar el datagridviw
            dataGridView1.DataSource = lcaja;
            dataGridView1.Refresh();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
