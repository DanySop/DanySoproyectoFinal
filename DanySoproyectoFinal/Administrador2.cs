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
    public partial class Administrador2 : Form
    {

        List<Ingreso1> lingresar = new List<Ingreso1>();
        List<busca1> lbuscar = new List<busca1>();
        static int posicionmodificar;
        public Administrador2()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ingreso1 ingresartemp = new Ingreso1();
            ingresartemp.Nomprodu = textBox1.Text;
            ingresartemp.Producto = textBox2.Text;
            ingresartemp.Precio = textBox3.Text;
            ingresartemp.Cantidad = textBox4.Text;

            lingresar.Add(ingresartemp);
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = lingresar;
            dataGridView1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = "codi.txt";

            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < lingresar.Count; i++)
            {
                writer.WriteLine(lingresar[i].Nomprodu);
                writer.WriteLine(lingresar[i].Producto);
                writer.WriteLine(lingresar[i].Precio);
                writer.WriteLine(lingresar[i].Cantidad);

            }
            writer.Close();
            MessageBox.Show("Guardado");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lingresar[posicionmodificar].Nomprodu = textBox1.Text;
            lingresar[posicionmodificar].Producto = textBox2.Text;
            lingresar[posicionmodificar].Precio = textBox3.Text;
            lingresar[posicionmodificar].Cantidad = textBox4.Text;

            string fileName = @"C:\Users\usuario\source\repos\DanySoproyectoFinal\DanySoproyectoFinal\bin\Debug\codi.txt";

            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < lingresar.Count; i++)
            {
                writer.WriteLine(lingresar[i].Nomprodu);
                writer.WriteLine(lingresar[i].Producto);
                writer.WriteLine(lingresar[i].Precio);
                writer.WriteLine(lingresar[i].Cantidad);

            }
            writer.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\usuario\source\repos\DanySoproyectoFinal\DanySoproyectoFinal\bin\Debug\buscar.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Se cargan los datos del archivo a la lista de clientes
            while (reader.Peek() > -1)
            {
                //Leer los datos y guardarlos en un temporal
                //osea la lista en meses
                busca1 productotemp = new busca1();
                productotemp.Nombre = reader.ReadLine();
                productotemp.Apellido = reader.ReadLine();
                productotemp.Nit= reader.ReadLine();
                productotemp.Direccion = reader.ReadLine();

                //Agregar a la lista el temporal
                lbuscar.Add(productotemp);
            }
            reader.Close();

            //Se recorre la lista de clientes
            for (int i = 0; i < lbuscar.Count; i++)
            {
                //Si se el dato a buscar es igual al dato de la lista mostrarlo en los textbox
                if (lbuscar[i].Nombre == textBox9.Text)
                {
                    textBox5.Text = lbuscar[i].Nombre;
                    textBox6.Text = lbuscar[i].Apellido;
                    textBox7.Text = lbuscar[i].Nit;
                    textBox8.Text = lbuscar[i].Direccion;
                    


                    //Guardar en que posicion se encontró el dato para utilizarla mas adelante al momento de modificar
                    posicionmodificar = i;

                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lbuscar[posicionmodificar].Nombre = textBox5.Text;
            lbuscar[posicionmodificar].Apellido = textBox6.Text;
            lbuscar[posicionmodificar].Nit = textBox7.Text;
            lbuscar[posicionmodificar].Direccion = textBox8.Text;

            string fileName = @"C:\Users\usuario\source\repos\DanySoproyectoFinal\DanySoproyectoFinal\bin\Debug\buscar.txt";

            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < lbuscar.Count; i++)
            {
                writer.WriteLine(lbuscar[i].Nombre);
                writer.WriteLine(lbuscar[i].Apellido);
                writer.WriteLine(lbuscar[i].Nit);
                writer.WriteLine(lbuscar[i].Direccion);

            }
            writer.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            busca1 ingresartemp = new busca1();
            ingresartemp.Nombre = textBox5.Text;
            ingresartemp.Apellido = textBox6.Text;
            ingresartemp.Nit = textBox7.Text;
            ingresartemp.Direccion = textBox8.Text;

            lbuscar.Add(ingresartemp);
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = lbuscar;
            dataGridView1.Refresh();

        }
    }
}
