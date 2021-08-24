using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitaMedica.EN
{
    public class DoctorEN
    {
        public int DoctorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int EspecialidadID { get; set; }
        public int Estado { get; set; }
    }
}
