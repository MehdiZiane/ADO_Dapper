using Microsoft.Data.SqlClient;

namespace C_todbtsql
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public int SectionId { get; set; }
        public int YearResult { get; set; }
        public string CourseId { get; set; }
    }

    public static class insertion
    {
        public static void ExecuterInsertion()
        {
            // 1. Instanciation de l'objet Student avec vos informations
            Student moi = new Student()
            {
                FirstName = "jean",
                LastName = "dupond",
                BirthDate = new DateTime(2000, 1, 1), // Remplacez par votre date
                Login = "jdupond",
                SectionId = 1010, // Mettez un ID de section valide existant dans votre table section
                YearResult = 15,  // Votre résultat annuel
                CourseId = "EG1010" // Mettez un ID de cours valide existant dans votre table course
            };

            string connectionString = @"Server=GOS-VDI410\TFTIC;Database=db_slide;Trusted_connection=True;TrustServerCertificate=True";

            // Requête SQL avec "OUTPUT INSERTED.student_id" pour récupérer l'ID auto-généré
            string query = @"INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) 
                             OUTPUT INSERTED.student_id 
                             VALUES (@FirstName, @LastName, @BirthDate, @Login, @SectionId, @YearResult, @CourseId);";

            using (SqlConnection c = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, c))
                {
                    // Passage des propriétés de l'objet aux paramètres SQL
                    cmd.Parameters.AddWithValue("@FirstName", moi.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", moi.LastName);
                    cmd.Parameters.AddWithValue("@BirthDate", moi.BirthDate);
                    cmd.Parameters.AddWithValue("@Login", moi.Login);
                    cmd.Parameters.AddWithValue("@SectionId", moi.SectionId);
                    cmd.Parameters.AddWithValue("@YearResult", moi.YearResult);
                    cmd.Parameters.AddWithValue("@CourseId", moi.CourseId);

                    try
                    {
                        c.Open();

                        // ExecuteScalar exécute la requête et renvoie la première colonne de la première ligne (l'ID)
                        int nouvelId = Convert.ToInt32(cmd.ExecuteScalar());

                        Console.WriteLine($"Insertion réussie ! Votre étudiant a été ajouté avec l'ID : {nouvelId}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Une erreur est survenue : {ex.Message}");
                    }
                }
            }
        }
    }
}
