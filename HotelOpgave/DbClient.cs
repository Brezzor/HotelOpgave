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
        public static void GetAllFacilities(SqlConnection con)
        {
            string quary = $"SELECT * FROM dbo.Facility";
            DataSet ds = new DataSet();
            ds = GetData(con, quary);

            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                foreach (DataColumn col in ds.Tables[0].Columns)
                {
                    Console.WriteLine($"{col}: {rows[col]}");
                }
                Console.WriteLine();
            }
        }
        
        public static void DeleteFacility(SqlConnection con)
        {
            Console.WriteLine("Choose the Facility Id of the Facility you want to delete...");
            Console.Write("Facility Id: ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                string quary = $"DELETE FROM Facility WHERE Id = {id}";
                DeleteCommand(con, quary);
            }
        }
        
        public static void InsertFacility(SqlConnection con)
        {
            Console.WriteLine("Choose a name for the Facility...");
            Console.Write("Facility Name: ");
            string? input = Console.ReadLine();
            string quary = $"INSERT INTO Facility VALUES ('{input}')";
            InsertCommand(con, quary);
        }
        
        public static void UpdateFacility(SqlConnection con)
        {
            Console.WriteLine("Choose a Facility Id for the Facility you want to update...");
            Console.Write("Facility Id: ");
            string? input1 = Console.ReadLine();
            if (int.TryParse(input1, out int id))
            {
                Console.WriteLine("Choose a Name for the Facility...");
                Console.Write("Facility Name: ");
                string? name = Console.ReadLine();
                string quary = $"UPDATE Facility SET Name = '{name}' WHERE Id = {id}";
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
    }
}
