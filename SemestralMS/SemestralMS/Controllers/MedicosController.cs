using SemestralMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace SemestralMS.Controllers
{
    public class MedicosController : ApiController
    {
        // Cadena de conexión desde Web.config
        private string conexion = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        // =========================
        // GET: api/medicos?especialidad=Neurología
        // =========================
        [HttpGet]
        [Route("api/medicos")]
        public IHttpActionResult Get([FromUri] string especialidad = "")
        {
            List<Medico> lista = new List<Medico>();

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarMedicos", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Solo agregar el parámetro si se envía especialidad
                    if (!string.IsNullOrEmpty(especialidad))
                        cmd.Parameters.Add("@Especialidad", SqlDbType.VarChar, 50).Value = especialidad;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new Medico
                        {
                            IdMedico = Convert.ToInt32(dr["IdMedico"]),
                            Nombre = dr["Nombre"].ToString(),
                            Especialidad = dr["Especialidad"].ToString()
                        });
                    }
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // =========================
        // POST: api/medicos
        // =========================
        [HttpPost]
        [Route("api/medicos")]
        public IHttpActionResult Post([FromBody] Medico medico)
        {
            if (medico == null)
                return BadRequest("El médico no puede ser nulo.");

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarMedico", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = medico.Nombre ?? "";
                    cmd.Parameters.Add("@Especialidad", SqlDbType.VarChar, 100).Value = medico.Especialidad ?? "";

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Médico agregado correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // =========================
        // PUT: api/medicos/{id}
        // =========================
        [HttpPut]
        [Route("api/medicos/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Medico medico)
        {
            if (medico == null)
                return BadRequest("El médico no puede ser nulo.");

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarMedico", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdMedico", id);
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = medico.Nombre ?? "";
                    cmd.Parameters.Add("@Especialidad", SqlDbType.VarChar, 100).Value = medico.Especialidad ?? "";

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Médico actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // =========================
        // DELETE: api/medicos/{id}
        // =========================
        [HttpDelete]
        [Route("api/medicos/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarMedico", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdMedico", id);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Médico eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
