using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitaMedica.EN;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CitaMedica.DAL
{
    public class PacienteDAL
    {  
        public string InsertPaciente(PacienteEN pPaciente)    
        {    
            SqlConnection con = null;    
    
            string result = "";    
            try    
            {    
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());    
                SqlCommand cmd = new SqlCommand("SpInsertPaciente", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
                //cmd.Parameters.AddWithValue("@CustomerID", 0);    
                cmd.Parameters.AddWithValue("@Nombre", pPaciente.Nombre);    
                cmd.Parameters.AddWithValue("@Apellido", pPaciente.Apellido);    
                cmd.Parameters.AddWithValue("@Edad", pPaciente.Edad);    
                cmd.Parameters.AddWithValue("@Correo", pPaciente.Correo);
                con.Open();    
                result = cmd.ExecuteScalar().ToString();    
                return result;    
            }    
            catch    
            {    
                return result = "";    
            }    
            finally    
            {    
                con.Close();    
            }    
        }    
        public string UpdatePaciente(PacienteEN pPaciente)    
        {    
            SqlConnection con = null;    
            string result = "";    
            try    
            {    
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());    
                SqlCommand cmd = new SqlCommand("SpUpdatePaciente", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@PacienteID", pPaciente.PacienteID);    
                cmd.Parameters.AddWithValue("@Nombre", pPaciente.Nombre);    
                cmd.Parameters.AddWithValue("@Apellido", pPaciente.Apellido);    
                cmd.Parameters.AddWithValue("@Edad", pPaciente.Edad);    
                cmd.Parameters.AddWithValue("@Correo", pPaciente.Correo);
                cmd.Parameters.AddWithValue("@DUI", pPaciente.DUI); 
                con.Open();    
                result = cmd.ExecuteScalar().ToString();    
                return result;    
            }    
            catch    
            {    
                return result = "";    
            }    
            finally    
            {    
                con.Close();    
            }    
        }    
        public int DeletePaciente(int PacienteID)    
        {    
            SqlConnection con = null;    
            int result;    
            try    
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());    
                SqlCommand cmd = new SqlCommand("SpDeletePaciente", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@PacienteID", PacienteID);
                con.Open();    
                result = cmd.ExecuteNonQuery();    
                return result;    
            }    
            catch    
            {    
                return result = 0;    
            }    
            finally    
            {    
                con.Close();    
            }    
        }    
        public List<PacienteEN> GetPaciente()    
        {    
            SqlConnection con = null;    
            DataSet ds = null;    
            List<PacienteEN> Paciente = null;    
            try    
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());    
                SqlCommand cmd = new SqlCommand("SpGetPaciente", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
                con.Open();    
                SqlDataAdapter da = new SqlDataAdapter();    
                da.SelectCommand = cmd;    
                ds = new DataSet();    
                da.Fill(ds);    
                Paciente = new List<PacienteEN>();    
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)    
                {    
                    PacienteEN cobj = new PacienteEN();    
                    cobj.PacienteID = Convert.ToInt32(ds.Tables[0].Rows[i]["PacienteID"].ToString());    
                    cobj.Nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();    
                    cobj.Apellido = ds.Tables[0].Rows[i]["Apellido"].ToString();    
                    cobj.Correo = ds.Tables[0].Rows[i]["Correo"].ToString();    
                    cobj.Edad = Convert.ToInt32(ds.Tables[0].Rows[i]["Edad"].ToString());    
                    cobj.FechaRegistro = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthdate"].ToString());    
    
                    Paciente.Add(cobj);    
                }    
                return Paciente;    
            }    
            catch    
            {    
                return Paciente;    
            }    
            finally    
            {    
                con.Close();    
            }    
        }    
    
        public PacienteEN SearchPaciente(string searchType, string search)    
        {    
            SqlConnection con = null;    
            DataSet ds = null;    
            PacienteEN cobj = null;    
            try    
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());    
                SqlCommand cmd = new SqlCommand("SpSearchPaciente", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@search", search);    
                cmd.Parameters.AddWithValue("@searchType", searchType);      
                SqlDataAdapter da = new SqlDataAdapter();    
                da.SelectCommand = cmd;    
                ds = new DataSet();    
                da.Fill(ds);    
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)    
                {    
                    cobj = new PacienteEN();    
                    cobj.PacienteID = Convert.ToInt32(ds.Tables[0].Rows[i]["PacienteID"].ToString());    
                    cobj.Nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();    
                    cobj.Apellido = ds.Tables[0].Rows[i]["Apellido"].ToString();    
                    cobj.Edad = Convert.ToInt32(ds.Tables[0].Rows[i]["Edad"].ToString());    
                    cobj.Correo = ds.Tables[0].Rows[i]["Correo"].ToString();    
                    cobj.FechaRegistro = Convert.ToDateTime(ds.Tables[0].Rows[i]["FechaRegistro"].ToString());    
    
                }    
                return cobj;    
            }    
            catch    
            {    
                return cobj;    
            }    
            finally    
            {    
                con.Close();    
            }    
        }  
    
    }
}
