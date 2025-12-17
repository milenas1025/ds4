using SemestralMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace SemestralMS.Controllers
{
    public class ReportesController : ApiController
    {
        private string conexion = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        // =========================
        // GET: api/reportes/porfecha?desde=2025-12-01&hasta=2025-12-31
        // =========================
        [HttpGet]
        [Route("api/reportes/porfecha")]
        public IHttpActionResult GetCitasPorFecha(DateTime desde, DateTime hasta)
        {
            List<CitaReporte> lista = new List<CitaReporte>();

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteCitasPorFecha", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = desde;
                    cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = hasta;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new CitaReporte
                        {
                            IdCita = Convert.ToInt32(dr["IdCita"]),
                            NombrePaciente = dr["Paciente"].ToString(),
                            NombreMedico = dr["Medico"].ToString(),
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
        // GET: api/reportes/porpaciente/{id}
        // =========================
        [HttpGet]
        [Route("api/reportes/porpaciente/{id}")]
        public IHttpActionResult GetCitasPorPaciente(int id)
        {
            List<CitaReporte> lista = new List<CitaReporte>();

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteCitasPorPaciente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = id;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new CitaReporte
                        {
                            IdCita = Convert.ToInt32(dr["IdCita"]),
                            NombrePaciente = dr["Paciente"].ToString(),
                            NombreMedico = dr["Medico"].ToString(),
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
        // GET: api/reportes/pormedico/{id}
        // =========================
        [HttpGet]
        [Route("api/reportes/pormedico/{id}")]
        public IHttpActionResult GetCitasPorMedico(int id)
        {
            List<CitaReporte> lista = new List<CitaReporte>();

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteCitasPorMedico", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdMedico", SqlDbType.Int).Value = id;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new CitaReporte
                        {
                            IdCita = Convert.ToInt32(dr["IdCita"]),
                            NombrePaciente = dr["Paciente"].ToString(),
                            NombreMedico = dr["Medico"].ToString(),
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
        // GET: api/reportes/porestado?estado=Pendiente
        // =========================
        [HttpGet]
        [Route("api/reportes/porestado")]
        public IHttpActionResult GetCitasPorEstado(string estado)
        {
            List<CitaReporte> lista = new List<CitaReporte>();

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteCitasPorEstado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = estado;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new CitaReporte
                        {
                            IdCita = Convert.ToInt32(dr["IdCita"]),
                            NombrePaciente = dr["Paciente"].ToString(),
                            NombreMedico = dr["Medico"].ToString(),
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
    }
}
