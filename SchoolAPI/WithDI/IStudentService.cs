using SchoolAPI.Model;

namespace SchoolAPI.WithDI;

public interface IStudentService
{
    StudentsWithCount GetAll();
    Student? GetById(int id);
    Student Create(string name, int age);
}