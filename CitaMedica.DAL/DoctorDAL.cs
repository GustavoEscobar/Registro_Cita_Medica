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
    public class DoctorDAL
    {
        public string InsertDoctor(DoctorEN pDoctor)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpInsertDoctor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", pDoctor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", pDoctor.Apellido);
                cmd.Parameters.AddWithValue("@EspecialidadID", pDoctor.EspecialidadID);
                cmd.Parameters.AddWithValue("@Estado", pDoctor.Estado);
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
        public string UpdateDoctor(DoctorEN pDoctor)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpUpdateDoctor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorID", pDoctor.DoctorID);
                cmd.Parameters.AddWithValue("@Nombre", pDoctor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", pDoctor.Apellido);
                cmd.Parameters.AddWithValue("@EspecialidadID", pDoctor.EspecialidadID);
                cmd.Parameters.AddWithValue("@Estado", pDoctor.Estado);
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
        public int DeleteDoctor(int DoctorID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpDeleteDoctor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
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
        public List<DoctorEN> GetDoctor()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<DoctorEN> doctor = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpGetDoctor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                doctor = new List<DoctorEN>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DoctorEN cobj = new DoctorEN();
                    cobj.DoctorID = Convert.ToInt32(ds.Tables[0].Rows[i]["DoctorID"].ToString());
                    cobj.Nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();
                    cobj.Apellido = ds.Tables[0].Rows[i]["Apellido"].ToString();
                    cobj.EspecialidadID = Convert.ToInt32(ds.Tables[0].Rows[i]["EspecialidadID"].ToString());
                    cobj.Estado = Convert.ToInt32(ds.Tables[0].Rows[i]["Estado"].ToString());

                    doctor.Add(cobj);
                }
                return doctor;
            }
            catch
            {
                return doctor;
            }
            finally
            {
                con.Close();
            }
        }

        public DoctorEN SearchDoctor(string searchType, string search)
        {
            SqlConnection con = null;
            DataSet ds = null;
            DoctorEN cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpSearchDoctor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@search", search);
                cmd.Parameters.AddWithValue("@searchType", searchType);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new DoctorEN();
                    cobj.DoctorID = Convert.ToInt32(ds.Tables[0].Rows[i]["PacienteID"].ToString());
                    cobj.Nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();
                    cobj.Apellido = ds.Tables[0].Rows[i]["Apellido"].ToString();
                    cobj.EspecialidadID = Convert.ToInt32(ds.Tables[0].Rows[i]["EspecialidadID"].ToString());
                    cobj.Estado = Convert.ToInt32(ds.Tables[0].Rows[i]["Estado"].ToString());
                    
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
