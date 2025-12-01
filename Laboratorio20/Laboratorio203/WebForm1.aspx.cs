using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio203
{
    public partial class WebForm1 : Page
    {
        // lee la cadena desde Web.config
        private readonly string connString = ConfigurationManager.ConnectionStrings["ProductosConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        // Guardar (inserta)
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones simples
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('Complete todos los campos.');", true);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(connString))
            {
                string query = "INSERT INTO Productos (Codigo, Nombre, Precio) VALUES (@Codigo, @Nombre, @Precio)";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Precio", txtPrecio.Text.Trim());

                    conexion.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('Guardado correctamente.');", true);
                    }
                    catch (SqlException ex)
                    {
                        // Manejo simple de error (p. ej. PK duplicada)
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", $"alert('Error SQL: {ex.Message}');", true);
                    }
                }
            }

            LimpiarCampos();
            CargarProductos();
        }

        // Nuevo (limpia campos para ingreso)
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtCodigo.Focus();
        }

        // Cancelar (limpia y no hace nada)
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Eliminar por código actual (txtCodigo)
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('Ingrese el código a eliminar.');", true);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(connString))
            {
                string query = "DELETE FROM Productos WHERE Codigo = @Codigo";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text.Trim());
                    conexion.Open();
                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('Eliminado correctamente.');", true);
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('No se encontró el producto.');", true);
                }
            }

            LimpiarCampos();
            CargarProductos();
        }

        // Buscar por txtBuscar (o por txtCodigo si prefieres)
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigoBuscado = txtBuscar?.Text.Trim();
            if (string.IsNullOrWhiteSpace(codigoBuscado))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('Ingrese código a buscar.');", true);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(connString))
            {
                string query = "SELECT Codigo, Nombre, Precio FROM Productos WHERE Codigo = @Codigo";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigoBuscado);
                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtCodigo.Text = dr["Codigo"].ToString();
                            txtNombre.Text = dr["Nombre"].ToString();
                            txtPrecio.Text = dr["Precio"].ToString();
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('Producto cargado.');", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('Producto no encontrado.');", true);
                        }
                    }
                }
            }
        }

        // Carga todos los productos en el GridView
        private void CargarProductos()
        {
            using (SqlConnection conexion = new SqlConnection(connString))
            {
                string query = "SELECT Codigo, Nombre, Precio FROM Productos";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    gvProductos.DataSource = cmd.ExecuteReader();
                    gvProductos.DataBind();
                }
            }
        }

        // Evento del Grid (opcional - si quieres seleccionar fila y cargar en los campos)
        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si el GridView tiene selección, puedes hacer:
            if (gvProductos.SelectedRow != null)
            {
                var row = gvProductos.SelectedRow;
                txtCodigo.Text = row.Cells[1].Text; // Cells[0] puede ser checkbox/selector si hay
                txtNombre.Text = row.Cells[2].Text;
                txtPrecio.Text = row.Cells[3].Text;
            }
        }

        // Helper: limpiar campos
        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            if (txtBuscar != null) txtBuscar.Text = "";
        }
    }
}