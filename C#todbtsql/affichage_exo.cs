using System.Data;
using Microsoft.Data.SqlClient;


namespace C_todbtsql
{
    public static class affichage_exo
    {
        public static void ExecuterExercice1()
        {
            DataTable dtsection = new DataTable();
            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = @"Server=GOS-VDI410\TFTIC;Database=db_slide;Trusted_connection=True;TrustServerCertificate=True";

                string q = "select section_id, section_name from section";
                SqlDataAdapter sqlad = new SqlDataAdapter(q, c);
                sqlad.Fill(dtsection);
            }

            foreach (DataRow row in dtsection.Rows)
            {
                int id = Convert.ToInt32(row["section_id"]);
                string nom = row["section_name"].ToString();
                Console.WriteLine($"{id} {nom}");
            }
        }
    }
}
