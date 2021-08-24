using CitaMedica.EN;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitaMedica.DAL
{
    public class CitaMedicaDAL
    {
        public string InsertCitaMedica(CitaMedicaEN pCitaMedica)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpInsertCitaMedica", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorID", pCitaMedica.DoctorID);
                cmd.Parameters.AddWithValue("@PacienteID", pCitaMedica.PacienteID);
                cmd.Parameters.AddWithValue("@FechaCita", pCitaMedica.FechaCita);
                cmd.Parameters.AddWithValue("@FechaRegistro", pCitaMedica.FechaRegistro);
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
        public string UpdateCitaMedica(CitaMedicaEN pCitaMedica)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpUpdateCitaMedica", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CitaMedicaID", pCitaMedica.CitaMedicaID);
                cmd.Parameters.AddWithValue("@DoctorID", pCitaMedica.DoctorID);
                cmd.Parameters.AddWithValue("@PacienteID", pCitaMedica.PacienteID);
                cmd.Parameters.AddWithValue("@FechaCita", pCitaMedica.FechaCita);
                cmd.Parameters.AddWithValue("@FechaRegistro", pCitaMedica.FechaRegistro);
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
        public int DeleteCitaMedica(int CitaMedicaID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpDeleteCitaMedica", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CitaMedicaID", CitaMedicaID);
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
        public List<CitaMedicaEN> GetCitaMedica()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<CitaMedicaEN> CitaMedica = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpGetCitaMedica", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                CitaMedica = new List<CitaMedicaEN>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CitaMedicaEN cobj = new CitaMedicaEN();
                    cobj.CitaMedicaID = Convert.ToInt32(ds.Tables[0].Rows[i]["CitaMedicaID"].ToString());
                    cobj.DoctorID = Convert.ToInt32(ds.Tables[0].Rows[i]["Nombre"].ToString());
                    cobj.PacienteID = Convert.ToInt32(ds.Tables[0].Rows[i]["Apellido"].ToString());
                    cobj.FechaCita = Convert.ToDateTime(ds.Tables[0].Rows[i]["EspecialidadID"].ToString());
                    cobj.FechaRegistro = Convert.ToDateTime(ds.Tables[0].Rows[i]["Estado"].ToString());

                    CitaMedica.Add(cobj);
                }
                return CitaMedica;
            }
            catch
            {
                return CitaMedica;
            }
            finally
            {
                con.Close();
            }
        }

        public CitaMedicaEN SearchCitaMedica(string searchType, string search)
        {
            SqlConnection con = null;
            DataSet ds = null;
            CitaMedicaEN cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpSearchCitaMedica", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@search", search);
                cmd.Parameters.AddWithValue("@searchType", searchType);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new CitaMedicaEN();
                    cobj.CitaMedicaID = Convert.ToInt32(ds.Tables[0].Rows[i]["CitaMedicaID"].ToString());
                    cobj.DoctorID = Convert.ToInt32(ds.Tables[0].Rows[i]["Nombre"].ToString());
                    cobj.PacienteID = Convert.ToInt32(ds.Tables[0].Rows[i]["Apellido"].ToString());
                    cobj.FechaCita = Convert.ToDateTime(ds.Tables[0].Rows[i]["EspecialidadID"].ToString());
                    cobj.FechaRegistro = Convert.ToDateTime(ds.Tables[0].Rows[i]["Estado"].ToString());

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
