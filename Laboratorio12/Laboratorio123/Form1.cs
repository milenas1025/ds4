using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio123
{
    public partial class Form1 : Form
    {
        CalculosTriangulo obj = new CalculosTriangulo();
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label5.Text = "Área:";
            textBox2.Focus();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double l1, l2, l3;
            if (double.TryParse(textBox1.Text, out l1) &&
                double.TryParse(textBox2.Text, out l2) &&
                double.TryParse(textBox3.Text, out l3))
            {
                obj.setLados(l1, l2, l3);

                double semiperimetro = obj.getSemiperimetro();
                textBox4.Text = semiperimetro.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Ingrese valores numéricos válidos para los lados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double l1, l2, l3;
            if (double.TryParse(textBox1.Text, out l1) &&
                double.TryParse(textBox2.Text, out l2) &&
                double.TryParse(textBox3.Text, out l3))
            {
                obj.setLados(l1, l2, l3);

                double area = obj.getArea();
                textBox5.Text = area.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Ingrese valores numéricos válidos para los lados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
