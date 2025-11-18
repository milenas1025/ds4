using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio154
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(TextBox1.Text);
            double num2 = Convert.ToDouble(TextBox2.Text);

            // Sumar
            double suma = num1 + num2;

            // Mostrar resultado
            Label1.Text = "La suma es: " + suma;

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}