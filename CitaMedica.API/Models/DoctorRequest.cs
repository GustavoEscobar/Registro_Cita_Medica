using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitaMedica.API.Models
{
    public class DoctorRequest
    {
        public int DoctorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Estado { get; set; }
        public int EspecialidadID { get; set; }
    }
}