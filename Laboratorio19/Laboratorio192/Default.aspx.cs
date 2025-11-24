using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Laboratorio192
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
           
            var task = System.Threading.Tasks.Task.Run(async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                   
                    string url = "https://localhost:44345/api/values/get";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsAsync<string[]>();
                        return data;
                    }
                    else
                    {
                        return new string[0];
                    }
                }
            });

           
            string[] valores = task.Result;

           
            GridDatos.DataSource = valores;
            GridDatos.DataBind();
        }
    }
}