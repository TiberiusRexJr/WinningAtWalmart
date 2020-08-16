using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WinningAtWalmart.DataLayer
{
    public class DataLayer
    {
        #region Variables
        private readonly string _server = "etechenterprises.database.windows.net";
        private readonly string _userId = "Ravenone1";
        private readonly string _password = "supersix5!";
        private readonly string _database = "ldb";
        private readonly string _procedureName = "dbo.CRUD";
        #endregion
        #region Properties
        private SqlConnection DbConnection { get; set; }
        #endregion
    }
}
