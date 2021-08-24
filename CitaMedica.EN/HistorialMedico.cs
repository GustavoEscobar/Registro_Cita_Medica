using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitaMedica.EN
{
    public class HistorialMedico
    {
        public int HistorialMedicoID { get; set; }
        public int PacienteID { get; set; }
        public int DoctorID { get; set; }
        public string Diagnostico { get; set; }
        public string Receta { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
