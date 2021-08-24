using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitaMedica.API.Models
{
    public class CitaMedicaRequest
    {
        public int CitaMedicaID { get; set; }
        public int PacienteID { get; set; }
        public int DoctorID { get; set; }
        public DateTime FechaCita { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int EstadoCitaMedicaID { get; set; }
        public string Referencia { get; set; }
    }
}