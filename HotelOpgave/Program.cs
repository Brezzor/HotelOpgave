using HotelOpgave;
using Microsoft.Data.SqlClient;

/* Making the connection to the SQL Server */
using (SqlConnection con = new SqlConnection(DbClient.GetConnectionString()))
{
    /* Opening the connection to the SQL Server */
    con.Open();

    /* Reading and Writing all Facilities */
    Console.WriteLine("Writing all facilities...\n");
    DbClient.GetAllFacilities(con);

    /* Inserting a new Facility */
    DbClient.InsertFacility(con);
    
    /* Updating the new Facility */
    DbClient.UpdateFacility(con);

    Console.WriteLine("Writing all facilities...\n");
    DbClient.GetAllFacilities(con);
    DbClient.DeleteFacility(con);
    Console.WriteLine("Writing all facilities...\n");
    DbClient.GetAllFacilities(con);

    Console.WriteLine("Writing all hotelFacilities...\n");
    DbClient.GetAllHotelFacilities(con);

    DbClient.InsertHotelFacility(con);    

    Console.WriteLine("Writing all hotelFacilities...\n");
    DbClient.GetAllHotelFacilities(con);
    DbClient.DeleteHotelFacility(con);
    Console.WriteLine("Writing all hotelFacilities...\n");
    DbClient.GetAllHotelFacilities(con);
}