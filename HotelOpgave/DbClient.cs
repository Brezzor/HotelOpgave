using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpgave
{
    public static class DbClient
    {
        public static void GetAll<T>(SqlConnection con) where T : class
        {
            string quary = $"SELECT * FROM {typeof(T).Name}";
            DataSet ds = new DataSet();

            using (SqlCommand command = new SqlCommand(quary, con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);                

                foreach (DataTable tables in ds.Tables)
                {
                    foreach (DataRow rows in tables.Rows)
                    {
                        foreach (DataColumn col in tables.Columns)
                        {
                            Console.WriteLine($"{col}: {rows[col]}");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }        

        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            sqlConnectionStringBuilder.DataSource = "(localdb)\\MSSQLLocalDB";
            sqlConnectionStringBuilder.InitialCatalog = "HotelDatabase";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            sqlConnectionStringBuilder.ConnectTimeout = 30;
            sqlConnectionStringBuilder.Encrypt = false;
            sqlConnectionStringBuilder.TrustServerCertificate = false;
            sqlConnectionStringBuilder.ApplicationIntent = ApplicationIntent.ReadWrite;
            sqlConnectionStringBuilder.MultiSubnetFailover = false;

            return sqlConnectionStringBuilder.ConnectionString;
        }
    }
}
