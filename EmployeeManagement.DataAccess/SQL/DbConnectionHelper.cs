using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace EmployeeManagement.DataAccess.SQL
{
    public class DbConnectionHelper
    {
        private readonly string _connetionstring;

        public DbConnectionHelper(IConfiguration configuration)
        {
            _connetionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connetionstring);
        }

    }
}
