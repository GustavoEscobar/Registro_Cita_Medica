using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitaMedica.DAL;
using CitaMedica.EN;

namespace CitaMedica.BL
{
    public class EspecialidadBL
    {
        EspecialidadDAL especialidadDal = new EspecialidadDAL();
        public string InsertEspecialidad(EspecialidadEN pEspecialidad)
        {
            var result = especialidadDal.InsertEspecialidad(pEspecialidad);
            return result;
        }

        public string UpdateEspecialidad(EspecialidadEN pEspecialidad)
        {
            var result = especialidadDal.UpdateEspecialidad(pEspecialidad);
            return result;
        }

        public int DeleteEspecialidad(int EspecialidadID)
        {
            var result = especialidadDal.DeleteEspecialidad(EspecialidadID);
            return result;
        }

        public List<EspecialidadEN> GetEspecialidad()
        {
            var result = especialidadDal.GetEspecialidad();
            return result;
        }

        public EspecialidadEN SearchEspecialidad(string search)
        {
            var result = especialidadDal.SearchEspecialidad(search);
            return result;
        }
    }
}
