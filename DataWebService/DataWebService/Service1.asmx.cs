using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataWebService
{
    /// <summary>
    /// Сводное описание для Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        
        public void connectDB(out SqlConnection connection)
        {
            SqlConnection conn = new
                SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            try
            {
                conn.Open();
                connection = conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet loadDataFromDB(string procName, SqlCommand command)
        {
            SqlConnection connection = new SqlConnection();
            connectDB(out connection);
            command.CommandText = procName;
            command.Connection = connection;
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            command.CommandType = CommandType.StoredProcedure;
            try
            {
                connectDB(out connection);
                adapter.SelectCommand = command;
                adapter.Fill(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return data;
        }

        [WebMethod]
        public bool getBranchList(out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_BRANCH", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool getReasonAppealList(out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_REASON_APPEAL", command);
            return loadData.Tables[0].Rows.Count > 0; 
        }

        [WebMethod]
        public bool getTypeErrorList(out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_TYPE_ERROR", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool getPriorityList(out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_PRIORITY", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool getStatusList(out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_TASKS_STATUS", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool getSystemList(out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_SYSTEM", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool getSubSystemList(string system_name, out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@system_name", system_name);
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_SUBSYSTEM", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool getFormsList(string subsystem_name, out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@subsystem_name", subsystem_name);
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_FORMS", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool getSectionFormsList(string forms_name, out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@forms_name", forms_name);
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_SECTION_FORMS", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool getTypeAppealList(out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_TYPE_APPEAL", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool createNewTask(int[] intItems, string[] stringItems)
        {
            SqlConnection connection = new SqlConnection();
            connectDB(out connection);
            
            List<SqlParameter> parametrs = new List<SqlParameter>();
            int i = 1;

            foreach (string item in stringItems)
            {
                parametrs.Add(new SqlParameter("@parametr" + i.ToString(), item));
                i++;
            }

            foreach (int item in intItems)
            {
                 parametrs.Add(new SqlParameter("@parametr" + i.ToString(), item));
                 i++;
            }
                
            SqlCommand command = new SqlCommand("CREATE_TASK", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parametrs.ToArray<SqlParameter>());
            int status = 0;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                status = Convert.ToInt16(reader["status"].ToString());
                return status.Equals(1);
             }
             catch (Exception ex)
             {
                throw ex;
             }
             finally
             {
                connection.Close();
             }
        }

        [WebMethod]
        public bool createNewAtachments(string fileName, byte[] file, string data)
        {
            SqlConnection connection = new SqlConnection();
            connectDB(out connection);
            
            SqlCommand command = new SqlCommand("CREATE_NEW_ATACHMENTS", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@data", data);
            command.Parameters.AddWithValue("@filename", fileName);
            command.Parameters.Add("@file", SqlDbType.Image, file.Length).Value = file;
            int status = 0;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                status = Convert.ToInt16(reader["status"].ToString());
                return status.Equals(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        [WebMethod]
        public bool searchData(string date1, string date2, int[] items, out DataSet loadData)
        {

            List<SqlParameter> parametrs = new List<SqlParameter>();
            int i = 3;

            parametrs.Add(new SqlParameter("@parametr1", date1));

            parametrs.Add(new SqlParameter("@parametr2", date2));

            foreach (int item in items)
            {
                parametrs.Add(new SqlParameter("@parametr" + i.ToString(), item));
                i++;
            }
            SqlCommand command = new SqlCommand();
            command.Parameters.AddRange(parametrs.ToArray<SqlParameter>());
            loadData = new DataSet();
            loadData = loadDataFromDB("SEARCH_TASK", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool createAction(string[] stringItems, int[] intItems)
        {
            SqlConnection connection = new SqlConnection();
            connectDB(out connection);

            List<SqlParameter> parametrs = new List<SqlParameter>();
            int i = 1;

            foreach (string item in stringItems)
            {
                parametrs.Add(new SqlParameter("@parametr" + i.ToString(), item));
                i++;
            }

            foreach (int item in intItems)
            {
                parametrs.Add(new SqlParameter("@parametr" + i.ToString(), item));
                i++;
            }

            SqlCommand command = new SqlCommand("CREATE_ACTION", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parametrs.ToArray<SqlParameter>());
            int status = 0;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                status = Convert.ToInt16(reader["status"].ToString());
                return status.Equals(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        [WebMethod]
        public bool getUserList(out DataSet loadData)
        {
            SqlCommand command = new SqlCommand();
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_USER", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool getEndAction(out DataSet loadData, int id)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@tasks_id", id);
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_END_ACTION", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public bool getAtachmentsList(out DataSet loadData, int id)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@task_id", id);
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_ATACHMENTS", command);
            return loadData.Tables[0].Rows.Count > 0;
        }

        [WebMethod]
        public void deleteAtachment(int id, string filename)
        {
            SqlConnection connection = new SqlConnection();
            connectDB(out connection);
            SqlCommand command = new SqlCommand("DELETE_ATACHMENTS", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@task_id", id);
            command.Parameters.AddWithValue("@filename", filename);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        [WebMethod]
        public bool getActionList(out DataSet loadData, int id)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@tasks_id", id);
            loadData = new DataSet();
            loadData = loadDataFromDB("GET_ACTION", command);
            return loadData.Tables[0].Rows.Count > 0;
        }
    }
}