using StudentWebApp.Entity;
using StudentWebApp.Repository;

namespace StudentWebApp.Services
{
    public class StudentService: IStudentService
    {
        public List<Student> GetStudents()
        {
            IStudentRepo studentRepo = new StudentRepo();
            return studentRepo.GetStudents();
        }
    }
}
