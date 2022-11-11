using HotelOpgave;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

/* Setting up appsettings.json file for connectionString */
var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
IConfiguration configuration = builder.Build();

/* Making the connection to the SQL Server */
using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("HotelDb")))
{
    /* Opening the connection to the SQL Server */
    con.Open();

    /* Reading and Writing all Facilities */
    Console.WriteLine("Writing all facilities...\n");
    DbClient.GetAllFacilities(con);

    /* Inserting a new Facility */
    DbClient.InsertFacility(con);

    /* Reading and Writing all Facilities */
    Console.WriteLine("Writing all facilities...\n");
    DbClient.GetAllFacilities(con);

    /* Updating Facility */
    DbClient.UpdateFacility(con);

    /* Reading and Writing all Facilities */
    Console.WriteLine("Writing all facilities...\n");
    DbClient.GetAllFacilities(con);

    /* Deleting Facility */
    DbClient.DeleteFacility(con);   
}