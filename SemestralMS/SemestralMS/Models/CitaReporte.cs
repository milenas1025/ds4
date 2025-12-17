using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemestralMS.Models
{
    public class CitaReporte
    {
        public int IdCita { get; set; }
        public string NombrePaciente { get; set; }
        public string NombreMedico { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}