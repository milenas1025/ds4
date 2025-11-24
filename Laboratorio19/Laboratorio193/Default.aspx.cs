using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio193
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

       
        protected void btnCargarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "https://localhost:44345/api/values/get"; 

                using (WebClient client = new WebClient())
                {
                    string result = client.DownloadString(url);
                    string[] data = new string[] { result }; 
                    GridDatos.DataSource = data;
                    GridDatos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

    
        protected void btnCargarID2_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "https://localhost:44345/api/values/get/2"; 

                using (WebClient client = new WebClient())
                {
                    string result = client.DownloadString(url);
                    string[] data = new string[] { result };
                    GridDatos.DataSource = data;
                    GridDatos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}