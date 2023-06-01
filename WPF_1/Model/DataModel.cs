using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Data;




namespace WPF_1.Model
{
    public class DataModel
    {
        private SqlConnection connection;

        public DataModel()
        {
            string connectionString = DBConnection.Connection;
            connection = new SqlConnection(connectionString);
        }

        public DataTable GetTableData()
        {
            DataTable table = new DataTable();

            string query = "SELECT * FROM dbo.Klienci";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();

            return table;
        }

    }
}