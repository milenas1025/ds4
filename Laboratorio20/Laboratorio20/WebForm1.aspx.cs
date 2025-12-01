using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio20
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            int numero;
            if (int.TryParse(txtNumero.Text, out numero))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= 25; i++)
                {
                    sb.AppendLine($"{numero} x {i} = {numero * i}<br/>");
                }
                lblResultado.Text = sb.ToString();
            }
            else
            {
                lblResultado.Text = "Ingrese un número válido.";
            }
        }
    }
}