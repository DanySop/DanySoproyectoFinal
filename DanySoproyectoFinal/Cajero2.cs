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
        List<cont> lcont = new List<cont>();
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
            textBox10.Text = (Convert.ToInt32(textBox7.Text) * Convert.ToInt32(textBox8.Text)).ToString();
            textBox9.Text = (Convert.ToInt32(textBox7.Text) * Convert.ToInt32(textBox8.Text)).ToString();
            textBox9.Text = (Convert.ToInt32(textBox7.Text) * Convert.ToInt32(textBox8.Text)).ToString();
            //temporal
            caja1 cajatemp = new caja1();
            cajatemp.Nompro1 = textBox5.Text;
            cajatemp.Producto1 = textBox6.Text;
            cajatemp.Cantidad1 = textBox7.Text;
            cajatemp.Precio1= textBox8.Text;
            cajatemp.Subtotal1 = textBox9.Text;
            cajatemp.Total1 = textBox10.Text;

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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //temporal
            Comprador1 personatemp = new Comprador1();
            personatemp.Nit1 = textBox11.Text;
            personatemp.Nombre1 = textBox12.Text;
            personatemp.Apellido1 = textBox13.Text;
            personatemp.Direccion1 = textBox14.Text;

            // el objeto temporal guardarlo en la lista 
            lcomprador.Add(personatemp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Nombre del archivo
            string fileName = @"C:\Users\usuario\source\repos\DanySoproyectoFinal\DanySoproyectoFinal\bin\Debug\cajero.txt";
            //Abrir el archivo
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            //Crear un objeto para escribir el archivo
            StreamWriter writer = new StreamWriter(stream);
            //Usar el objeto para escribir al archivo, WriteLine, escribie linea por linea
            //Write escribe en la misma linea.
            for (int i = 0; i < lcomprador.Count; i++)
            {
                writer.WriteLine(lcomprador[i].Nit1);
                writer.WriteLine(lcomprador[i].Nombre1);
                writer.WriteLine(lcomprador[i].Apellido1);
                writer.WriteLine(lcomprador[i].Direccion1);

            }
            //Cerrar el archivo
            writer.Close();
            MessageBox.Show("Guardado.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox16.Text = (Convert.ToInt32(textBox10.Text) - Convert.ToInt32(textBox15.Text)).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //el nombre del archivo donde tiene que buscar
            string fileName = @"C:\Users\usuario\source\repos\DanySoproyectoFinal\DanySoproyectoFinal\bin\Debug\invet.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Se cargan los datos del archivo a la lista de clientes
            while (reader.Peek() > -1)
            {
                //Leer los datos y guardarlos en un temporal
                cont productotemp = new cont();
                productotemp.Nombre = reader.ReadLine();
                productotemp.Sim = reader.ReadLine();

                //Agregar a la lista el temporal
                lcont.Add(productotemp);
            }
            reader.Close();

            //Se recorre la lista de clientes
            for (int i = 0; i < lcont.Count; i++)
            {
                //Si se el dato a buscar es igual al dato de la lista mostrarlo en los textbox
                if (lcont[i].Nombre == textBox17.Text)
                {
                    textBox18.Text = lcont[i].Sim;


                    //Guardar en que posicion se encontró el dato para utilizarla mas adelante al momento de modificar
                    posicionmodificar = i;

                }

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
