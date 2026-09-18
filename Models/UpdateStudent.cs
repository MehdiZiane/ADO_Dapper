using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class UpdateStudent
    {
        public UpdateStudent(string firstName, string lastName, DateTime birthDate, string login, int sectionId, int yearResult, string courseId)
        {
            this.first_name = firstName;
            this.last_name = lastName;
            this.birth_date = birthDate;
            this.login = login;
            this.section_id = sectionId;
            this.year_result = yearResult;
            this.course_id = courseId;
        }

        // Propriétés de l'étudiant à mettre à jour
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public string login { get; set; }
        public int section_id { get; set; }
        public int year_result { get; set; }
        public string course_id { get; set; }
    }
}
