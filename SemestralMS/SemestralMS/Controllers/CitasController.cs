using SemestralMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace SemestralMS.Controllers
{
    public class CitasController : ApiController
    {
        private string conexion = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        // =========================
        // GET: api/citas?estado=Pendiente
        // =========================
        [HttpGet]
        [Route("api/citas")]
        public IHttpActionResult Get(string estado = null)
        {
            List<Cita> lista = new List<Cita>();

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarCitas", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Pasamos el estado como parámetro opcional
                    cmd.Parameters.AddWithValue("@Estado", (object)estado ?? DBNull.Value);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new Cita
                        {
                            IdCita = Convert.ToInt32(dr["IdCita"]),
                            IdPaciente = Convert.ToInt32(dr["IdPaciente"]),
                            IdMedico = Convert.ToInt32(dr["IdMedico"]),
                            Paciente = dr["Paciente"].ToString(),
                            Medico = dr["Medico"].ToString(),
                            Fecha = Convert.ToDateTime(dr["Fecha"]),
                            Estado = dr["Estado"].ToString()
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
        // POST: api/citas
        // =========================
        [HttpPost]
        [Route("api/citas")]
        public IHttpActionResult Post([FromBody] Cita cita)
        {
            if (cita == null)
                return BadRequest("La cita no puede ser nula.");

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarCita", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = cita.IdPaciente;
                    cmd.Parameters.Add("@IdMedico", SqlDbType.Int).Value = cita.IdMedico;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = cita.Fecha;
                    cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = cita.Estado ?? "";

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Cita agregada correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // =========================
        // PUT: api/citas/{id}
        // =========================
        [HttpPut]
        [Route("api/citas/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Cita cita)
        {
            if (cita == null)
                return BadRequest("La cita no puede ser nula.");

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarCita", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdCita", id);
                    cmd.Parameters.AddWithValue("@IdPaciente", cita.IdPaciente);
                    cmd.Parameters.AddWithValue("@IdMedico", cita.IdMedico);
                    cmd.Parameters.AddWithValue("@Fecha", cita.Fecha);
                    cmd.Parameters.AddWithValue("@Estado", cita.Estado);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Cita actualizada correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // =========================
        // DELETE: api/citas/{id}
        // =========================
        [HttpDelete]
        [Route("api/citas/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarCita", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCita", id);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Cita eliminada correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
