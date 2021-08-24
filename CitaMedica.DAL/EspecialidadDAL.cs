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
    public class EspecialidadDAL
    {
        public string InsertEspecialidad(EspecialidadEN pEspecialidad)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpInsertEspecialidad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CustomerID", 0);    
                cmd.Parameters.AddWithValue("@Nombre", pEspecialidad.Nombre);
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
        public string UpdateEspecialidad(EspecialidadEN pEspecialidad)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpUpdateEspecialidad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EspecialidadID", pEspecialidad.EspecialidadID);
                cmd.Parameters.AddWithValue("@Nombre", pEspecialidad.Nombre);
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
        public int DeleteEspecialidad(int EspecialidadID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpDeleteEspecialidad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EspecialidadID", EspecialidadID);
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
        public List<EspecialidadEN> GetEspecialidad()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<EspecialidadEN> Especialidad = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpGetEspecialidad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                Especialidad = new List<EspecialidadEN>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    EspecialidadEN cobj = new  EspecialidadEN();
                    cobj.EspecialidadID = Convert.ToInt32(ds.Tables[0].Rows[i]["PacienteID"].ToString());
                    cobj.Nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();

                    Especialidad.Add(cobj);
                }
                return Especialidad;
            }
            catch
            {
                return Especialidad;
            }
            finally
            {
                con.Close();
            }
        }

        public EspecialidadEN SearchEspecialidad(string search)
        {
            SqlConnection con = null;
            DataSet ds = null;
            EspecialidadEN cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SpSearchEspecialidad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@search", search);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new EspecialidadEN();
                    cobj.EspecialidadID = Convert.ToInt32(ds.Tables[0].Rows[i]["EspecialidadID"].ToString());
                    cobj.Nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();

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
