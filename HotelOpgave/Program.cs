using HotelOpgave;
using HotelOpgave.Models;
using Microsoft.Data.SqlClient;

using (SqlConnection con = new SqlConnection(DbClient.GetConnectionString()))
{
    con.Open();
    DbClient.GetAll<Hotel>(con);
    DbClient.GetAll<Room>(con);
    DbClient.GetAll<Guest>(con);
    DbClient.GetAll<Booking>(con);
}