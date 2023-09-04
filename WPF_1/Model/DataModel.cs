using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace WPF_1.Model
{
    public class DataModel
    {

        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }
            public DbSet<Customer> Customers { get; set; }

        }

        private void LoadData()
        {
            var customers = _context.Set<Customer>().ToList();
        }


        private SqlConnection connection;
        public DataModel()
        {
            string connectionString = DBConnection.Connection;
            connection = new SqlConnection(connectionString);

        }

        public DataTable GetTableData(string query)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();

            return table;
        }

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public int PhoneNumber { get; set; }

        }

    }
}