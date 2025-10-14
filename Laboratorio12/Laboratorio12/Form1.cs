using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laboratorio12
{
    public partial class Form1 : Form
    {
        CalculoDistancia obj = new CalculoDistancia();

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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

        // Botón Calcular
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double velocidad = Convert.ToDouble(txtVelocidad.Text);
                double tiempo = Convert.ToDouble(txtTiempo.Text);

                obj.setVelocidad(velocidad);
                obj.setTiempo(tiempo);

                double distancia = obj.CalcularDistancia();

                txtResultado.Text = distancia.ToString("0.00") + " km";
            }
            catch
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos.");
            }
        }

        // Botón Limpiar
        private void button2_Click(object sender, EventArgs e)
        {
            txtVelocidad.Clear();
            txtTiempo.Clear();
            txtResultado.Clear();
            txtVelocidad.Focus();
        }

        // Botón Salir
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}