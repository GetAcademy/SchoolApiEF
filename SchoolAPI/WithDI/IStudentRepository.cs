using SchoolAPI.Model;

namespace SchoolAPI.WithDI
{
    public interface IStudentRepository
    {
        // CRUD 

        // Read (all)
        List<Student> GetAll();

        // Read (en)
        Student? GetById(int id);

        // Create
        Student Create(string name, int age);

        // Delete

        // Update
    }
}
