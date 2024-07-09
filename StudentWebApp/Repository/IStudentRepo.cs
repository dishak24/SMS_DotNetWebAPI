using StudentWebApp.Entity;

namespace StudentWebApp.Repository
{
    public interface IStudentRepo
    {
        List<Student> GetStudents();

    }
}
