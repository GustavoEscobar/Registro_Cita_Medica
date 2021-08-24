using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitaMedica.DAL;
using CitaMedica.EN;

namespace CitaMedica.BL
{
    public class DoctorBL
    {
        DoctorDAL doctorDal = new DoctorDAL();

        public string InsertDoctor(DoctorEN pDoctor)
        {
            var result = doctorDal.InsertDoctor(pDoctor);
            return result;
        }

        public string UpdateDoctor(DoctorEN pDoctor)
        {
            var result = doctorDal.UpdateDoctor(pDoctor);
            return result;
        }

        public int DeleteDoctor(int doctorID)
        {
            var result = doctorDal.DeleteDoctor(doctorID);
            return result;
        }

        public List<DoctorEN> GetDoctor()
        {
            var result = doctorDal.GetDoctor();
            return result;
        }

        public DoctorEN SearchDoctor(string searchType, string search)
        {
            var result = doctorDal.SearchDoctor(searchType,search);
            return result;
        }
    }
}
