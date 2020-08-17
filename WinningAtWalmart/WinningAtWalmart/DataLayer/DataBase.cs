using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WinningAtWalmart.Models;
using System.Data;

namespace WinningAtWalmart.DataLayer
{
    public class DataBase
    {
        #region Variables
        private readonly string _server = "etechenterprises.database.windows.net";
        private readonly string _userId = "Ravenone1";
        private readonly string _password = "supersix5!";
        private readonly string _database = "ldb";
        private readonly string _procedureName="dbo.WinningAtWalmart_CRUD";
        #endregion
        #region Properties
        public SqlConnection DbConnection { get; set; }
        public string ConnectionString { get; set; }
        public string ProcedureCRUD { get { return _procedureName; } }
        #endregion
        #region Constructor
        public DataBase()
        {
            SetConnectionString();
            SetDbConnection();
        }
        #endregion

        #region Functions
        public void SetDbConnection()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.InitialCatalog = _database;
            sqlConnectionStringBuilder.UserID = _userId;
            sqlConnectionStringBuilder.Password = _password;
            sqlConnectionStringBuilder.DataSource = _server;
            try 
            { 
            DbConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void SetConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.InitialCatalog = _database;
            sqlConnectionStringBuilder.UserID = _userId;
            sqlConnectionStringBuilder.Password = _password;
            sqlConnectionStringBuilder.DataSource = _server;
            ConnectionString = sqlConnectionStringBuilder.ConnectionString;

        }

        public string Create(Worker worker)
        {
            #region Variables
            int queryCode = 1;
            string result = string.Empty;
            SqlCommand command = new SqlCommand(ProcedureCRUD, DbConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            #endregion
            #region AddParameter
            command.Parameters.AddWithValue("@firstname", worker.FirstName);
            command.Parameters.AddWithValue("@lastname", worker.LastName);
            command.Parameters.AddWithValue("@email", worker.Email);
            command.Parameters.AddWithValue("@password", worker.Password);
            command.Parameters.AddWithValue("@query", queryCode);
            #endregion
            #region TryExecuteCatch
            try
            {
                DbConnection.Open();
                result = command.ExecuteScalar().ToString();
                return result;

            }
            catch (Exception e)
            {
                result = e.Message;
                return result;
            }
            finally
            {
                DbConnection.Close();
            }
            #endregion
            
        }
        public List<Worker> RetrieveAll()
        {
            #region Variables
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection;
            cmd.CommandText = ProcedureCRUD;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            int queryCode = 4;
            string result = string.Empty;
            List<Worker> workers = new List<Worker>();
           
            #endregion
            #region SetParameters
            cmd.Parameters.AddWithValue("@query", queryCode);
            #endregion
            #region ExecuteTryCatchFinally
            try
            {
                DbConnection.Open();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataSet);

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Worker worker = new Worker();
                    worker.Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
                    worker.FirstName=dataSet.Tables[0].Rows[i]["FirstName"].ToString();
                    worker.LastName = dataSet.Tables[0].Rows[i]["LastName"].ToString();
                    worker.Email = dataSet.Tables[0].Rows[i]["Email"].ToString();
                    worker.Password = dataSet.Tables[0].Rows[i]["psword"].ToString();



                    workers.Add(worker); 

                }

                return workers;
            }
            catch (Exception e)
            {
                return result = e.Messag
            }
            finally
            {
                DbConnection.Close();
            }
            #endregion
        }
        public string RetrieveById(int id)
        {
            #region Variables
            int queryCode = 5;
            string result = string.Empty;
            SqlCommand cmd = new SqlCommand(ProcedureCRUD, DbConnection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            #endregion
        }
        public string Update(Worker worker)
        {
            #region Variables
            SqlCommand cmd = new SqlCommand(ProcedureCRUD, DbConnection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            string result = string.Empty;
            int queryCode = 2;
            #endregion
            throw new NotImplementedException();
        }
        public string Delete(int id)
        {
            #region Variables
            int queryCode = 3;
            #endregion
            throw new NotImplementedException();
        }
       


        #endregion
    }
}
