using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Parcial3
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPreguntas();
            }
        }

        private void CargarPreguntas()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Pregunta FROM MS_PreguntasRespuestas", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                RepeaterPreguntas.DataSource = dt;
                RepeaterPreguntas.DataBind();
            }
        }

        protected void btnPregunta_Click(object sender, EventArgs e)
        {
            var boton = (System.Web.UI.WebControls.Button)sender;
            int id = int.Parse(boton.CommandArgument);
            MostrarRespuesta(id);
        }

        private void MostrarRespuesta(int id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Respuesta FROM MS_PreguntasRespuestas WHERE Id=@Id", conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                object resultado = cmd.ExecuteScalar();

                LabelRespuesta.Text = resultado?.ToString() ?? "No hay respuesta.";
            }
        }
    }
}
