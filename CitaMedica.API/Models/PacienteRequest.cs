using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitaMedica.API.Models
{
    public class PacienteRequest
    {
        public int PacienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string DUI { get; set; }
    }
}