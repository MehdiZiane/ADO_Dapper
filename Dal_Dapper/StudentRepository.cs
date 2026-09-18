using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace Dal_Dapper
{
    public class StudentRepository
    {
        string connectionString = @"Server=GOS-VDI410\TFTIC;Database=db_slide;Trusted_connection=True;TrustServerCertificate=True";
        public IEnumerable<Student> GetStudent()
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            return connection.Query<Student>("SELECT * FROM student");
        }

        public Student? GetById(int student_id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            return connection.QueryFirstOrDefault<Student>($"select * from student where student_id = @student_id", new { student_id = student_id });
        }
    }
}
