using Dal_Dapper;
using Models;


StudentRepository repo = new StudentRepository();

bool exit = false;

while (!exit)
{
    Console.Clear();
    Console.WriteLine("tache 1");
    Console.WriteLine("tache 2");

    string response = Console.ReadLine();

    switch (response)
    {
        case "1":
            IEnumerable<Student> students = repo.GetStudent();
            Console.WriteLine("--------------------------");

            foreach (Student s in students)
            {
                Console.WriteLine($"id : {s.student_id} -prenom {s.first_name}");
            }
            Console.WriteLine("--------------------------");
            Console.ReadLine();
            break;
        case "2":
            IEnumerable<Student> studentForDetails = repo.GetStudent();
            Console.WriteLine("---------------------------");

            foreach(Student s in studentForDetails)
            {
                Console.WriteLine($"id : {s.student_id} - nom : {s.last_name} - prenom : {s.first_name}");
            }
            Console.WriteLine("----------------------------");
            
            Console.WriteLine("entré l id : ");
            int id = int.Parse( Console.ReadLine() );

            Student student = repo.GetById(id);
            
            if(student is not null)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"prenom : {student.first_name}");
                Console.WriteLine($"nom : {student.last_name}");
                Console.WriteLine($"date de naissance : {student.birth_date}");
                Console.WriteLine($"résultat : {student.year_result}");
            }

            else
            {
                Console.WriteLine($"aucun etudiant avec pour id : {id}");
            }
            Console.ReadLine() ;
            break;
        case "3":
            CreateStudent newstudent = CreateNewStudent();

            Student? studentcreate = repo.AddStudent(newstudent);

            if(studentcreate is not null)
            {
                Console.WriteLine($"nouveau etudiant : id : {studentcreate.student_id} - prenom : {studentcreate.first_name}");
            }
            Console.ReadLine();
            break;
    }

}

CreateStudent CreateNewStudent()
{
    CreateStudent newStudent = new();

    return newStudent;
}
/*
IEnumerable<Student> students = repo.GetStudent();

foreach (Student t in students)
{
    Console.WriteLine($"id : {t.student_id} - prenom : {t.first_name}");
}
*/