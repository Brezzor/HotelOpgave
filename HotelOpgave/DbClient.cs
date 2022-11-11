using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HotelOpgave
{
    public static class DbClient
    {
        private const string Select = "SELECT * FROM";
        private const string Delete = "DELETE FROM";
        private const string Insert = "INSERT INTO";
        private const string Update = "UDATE";
        public static void GetAllFacilities(SqlConnection con)
        {
            string quary = $"{Select} Facilities";
            DataSet ds = new DataSet();
            ds = GetData(con, quary);

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
        public static void GetAllHotelFacilities(SqlConnection con)
        {
            string quary = $"{Select} HotelFacilities";
            DataSet ds = new DataSet();
            ds = GetData(con, quary);

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
        public static void DeleteFacility(SqlConnection con)
        {
            Console.WriteLine("Choose the Facility Id of the facility you want to delete...");
            Console.Write("Facility Id: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                string quary = $"{Delete} Facilities WHERE Fac_Id = {id}";
                DeleteCommand(con, quary);
            }
        }
        public static void DeleteHotelFacility(SqlConnection con)
        {
            Console.WriteLine("Choose the Hotel Number of the Hotelfacility you want to delete...");
            Console.Write("Hotel Number: ");
            string input1 = Console.ReadLine();
            Console.WriteLine("Choose the Facility Id of the Hotelfacility you want to delete...");
            Console.Write("Facility Id: ");
            string input2 = Console.ReadLine();
            if (int.TryParse(input1, out int num) && int.TryParse(input2, out int id))
            {
                string quary = $"{Delete} HotelFacilities WHERE Fac_Id = {id} AND Hotel_No = {num}";
                DeleteCommand(con, quary);
            }
        }
        public static void InsertFacility(SqlConnection con)
        {
            Console.WriteLine("Choose a name for the Facility...");
            Console.Write("Facility Name: ");
            string input = Console.ReadLine();
            string quary = $"{Insert} Facilities VALUES ('{input}')";
            InsertCommand(con, quary);
        }
        public static void InsertHotelFacility(SqlConnection con)
        {
            Console.WriteLine("Choose the Hotel Number of the Hotelfacility you want...");
            Console.Write("Hotel Number: ");
            string input1 = Console.ReadLine();
            Console.WriteLine("Choose the Facility Id of the Hotelfacility you want...");
            Console.Write("Facility Id: ");
            string input2 = Console.ReadLine();
            if (int.TryParse(input1, out int num) && int.TryParse(input2, out int id))
            {
                string quary = $"{Insert} HotelFacilities VALUES ('{id}','{num}')";
                InsertCommand(con, quary);
            }
        }
        public static void UpdateFacility(SqlConnection con)
        {
            Console.WriteLine("Choose a Facility Id for the Facility you want to update...");
            Console.Write("Facility Id: ");
            string input1 = Console.ReadLine();
            if (int.TryParse(input1, out int id))
            {
                Console.WriteLine("Choose a Name for the Facility...");
                Console.Write("Facility Name: ");
                string name = Console.ReadLine();
                string quary = $"{Update} Facilities SET Name = '{name}' WHERE Fac_Id = {id}";
                UpdateCommand(con, quary);
            }
        }
        private static DataSet GetData(SqlConnection con, string quary)
        {
            DataSet ds = new DataSet();

            using (SqlCommand command = new SqlCommand(quary, con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
            }

            return ds;
        }
        private static void DeleteCommand(SqlConnection con, string quary)
        {
            try
            {
                SqlCommand command = new SqlCommand(quary, con);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
        private static void InsertCommand(SqlConnection con, string quary)
        {
            try
            {
                SqlCommand command = new SqlCommand(quary, con);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
        private static void UpdateCommand(SqlConnection con, string quary)
        {
            try
            {
                SqlCommand command = new SqlCommand(quary, con);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                throw;
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
