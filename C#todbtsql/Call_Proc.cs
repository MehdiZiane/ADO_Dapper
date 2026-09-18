using Microsoft.Data.SqlClient;
using System.Data;

namespace C_todbtsql
{
     public static class Call_Proc
    {
        public static void AddPersonnProc()
        {
            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = @"Server=GOS-VDI410\TFTIC;Database=db_slide;Trusted_connection=True;TrustServerCertificate=True";

                string login = "ziane";

                using(SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "AddPerson";
                    cmd.CommandType = CommandType.StoredProcedure;



                }
            }
        }
    }
}
