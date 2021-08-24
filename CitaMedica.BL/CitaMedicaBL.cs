using CitaMedica.DAL;
using CitaMedica.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitaMedica.BL
{
    public class CitaMedicaBL
    {
        CitaMedicaDAL CitaMedicaDal = new CitaMedicaDAL();

        public string InsertCitaMedica(CitaMedicaEN pCitaMedica)
        {
            var result = CitaMedicaDal.InsertCitaMedica(pCitaMedica);
            return result;

        }
    }
}
