using CitaMedica.DAL;
using CitaMedica.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitaMedica.BL
{
    public class PacienteBL
    {
        PacienteDAL pacienteDal = new PacienteDAL();

        public string InsertPaciente(PacienteEN pPaciente)
        {
            var result = pacienteDal.InsertPaciente(pPaciente);
            return result;
        }

        public string UpdatePaciente(PacienteEN pPaciente)
        {
            var result = pacienteDal.UpdatePaciente(pPaciente);
            return result;
        }

        public int DeletePaciente(int PacienteID)
        {
            var result = pacienteDal.DeletePaciente(PacienteID);
            return result;
        }

        public List<PacienteEN> GetPaciente()
        {
            var result = pacienteDal.GetPaciente();
            return result;
        }

        public PacienteEN SearchPaciente(string searchType, string search)
        {
            var result = pacienteDal.SearchPaciente(searchType,search);
            return result;
        }
    }
}
