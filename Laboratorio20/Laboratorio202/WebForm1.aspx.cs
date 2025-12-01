using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio202
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(txtN.Text, out n) && n > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<table border='1'>");
                for (int f = 0; f < n; f++)
                {
                    sb.AppendLine("<tr>");
                    for (int c = 0; c < n; c++)
                    {
                        if (c == n - f - 1)
                            sb.AppendLine("<td>1</td>");
                        else
                            sb.AppendLine("<td>0</td>");
                    }
                    sb.AppendLine("</tr>");
                }
                sb.AppendLine("</table>");
                litMatriz.Text = sb.ToString();
            }
            else
            {
                litMatriz.Text = "Ingrese un número válido mayor que 0.";
            }
        }
    }
}