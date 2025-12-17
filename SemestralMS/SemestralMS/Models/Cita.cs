using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemestralMS.Models
{
    public class Cita
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }

        public string Paciente { get; set; }
        public string Medico { get; set; }

        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}