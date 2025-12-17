using SemestralMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace SemestralMS.Controllers
{
    public class PacientesController : ApiController
    {
        private string conexion = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        // GET: api/pacientes
      
        [HttpGet]
        [Route("api/pacientes")]
        public IHttpActionResult Get()
        {
            List<Paciente> lista = new List<Paciente>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarPacientes", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new Paciente
                        {
                            IdPaciente = Convert.ToInt32(dr["IdPaciente"]),
                            Cedula = dr["Cedula"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
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
        // GET: api/pacientes/{id}
        // =========================
        [HttpGet]
        [Route("api/pacientes/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerPacientePorId", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPaciente", id);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        var paciente = new Paciente
                        {
                            IdPaciente = Convert.ToInt32(dr["IdPaciente"]),
                            Cedula = dr["Cedula"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        };
                        return Ok(paciente);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // =========================
        // POST: api/pacientes
        // =========================
        [HttpPost]
        [Route("api/pacientes")]
        public IHttpActionResult Post([FromBody] Paciente paciente)
        {
            if (paciente == null)
                return BadRequest("El paciente no puede ser nulo.");

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarPaciente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Cedula", SqlDbType.VarChar, 20).Value = paciente.Cedula ?? "";
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = paciente.Nombre ?? "";
                    cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = paciente.Telefono ?? "";
                    cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = paciente.Correo ?? "";

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Paciente agregado correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // =========================
        // PUT: api/pacientes/{id}
        // =========================
        [HttpPut]
        [Route("api/pacientes/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Paciente paciente)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarPaciente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPaciente", id);
                    cmd.Parameters.AddWithValue("@Cedula", paciente.Cedula);
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", paciente.Correo);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Paciente actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // =========================
        // DELETE: api/pacientes/{id}
        // =========================
        [HttpDelete]
        [Route("api/pacientes/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarPaciente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPaciente", id);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Paciente eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
