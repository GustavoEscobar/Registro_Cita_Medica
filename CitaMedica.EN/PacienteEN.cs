﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitaMedica.EN
{
    public class PacienteEN
    {
        public int PacienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Correo { get; set; }
        public string DUI { get; set; }
    }
}
