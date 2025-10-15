using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Laboratorio13
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=.\sqlexpress;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT ProductName FROM [dbo].[Products]", conexion);
                SqlDataReader lector = comando.ExecuteReader();
                listBox1.Items.Clear();
                while (lector.Read())
                {
                    listBox1.Items.Add(lector["ProductName"].ToString());
                }
                lector.Close();
                MessageBox.Show("Productos cargados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}