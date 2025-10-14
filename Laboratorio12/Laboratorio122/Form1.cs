using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio122
{
    public partial class Form1 : Form
    {
        CalculoPromedio obj = new CalculoPromedio();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        // Botón Calcular promedio
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double nota1 = Convert.ToDouble(textBox1.Text);
                double nota2 = Convert.ToDouble(textBox2.Text);
                double nota3 = Convert.ToDouble(textBox3.Text);

                obj.setNotas(nota1, nota2, nota3);

                double promedio = obj.CalcularPromedio();

                textBox4.Text = promedio.ToString("0.00");
            }
            catch
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para las notas.");
            }
        }

        // Botón Limpiar
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        // Botón Salir
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}