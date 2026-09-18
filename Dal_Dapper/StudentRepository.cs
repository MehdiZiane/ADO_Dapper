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

        public Student? AddStudent(CreateStudent newStudent)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO student (first_name, last_name, birth_date, year_result, section_id) " +
                         "OUTPUT INSERTED.student_id " +
                         "VALUES (@FirstName, @LastName, @BirthDate, @YearResult, @SectionId)";
            int result = conn.ExecuteScalar<int>(sql, newStudent);

            Student? studentCreate = GetById(result);

            return studentCreate;
        }

        public Student? UpdateStudent(UpdateStudent updatedStudent, int student_id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            string sql = "UPDATE student SET first_name = @FirstName, last_name = @LastName, " +
                         "birth_date = @BirthDate, year_result = @YearResult, section_id = @SectionId " +
                         "WHERE student_id = @StudentId";

            int rows = conn.Execute(sql, new
            {
                FirstName = updatedStudent.first_name,
                LastName = updatedStudent.last_name,
                BirthDate = updatedStudent.birth_date,
                YearResult = updatedStudent.year_result,
                SectionId = updatedStudent.section_id,
                StudentId = student_id
            });

            if (rows != 0)
            {
                return GetById(student_id);
            }

            return null;
        }

        // Supprimer un étudiant
        public bool DeleteStudent(int student_id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            int rows = conn.Execute("DELETE FROM student WHERE student_id = @student_id", new { student_id = student_id });

            return rows > 0;
        }
    }
}
