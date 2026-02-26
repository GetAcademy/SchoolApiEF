using DbModels;
using SchoolAPI.Model;
using Student = DbModels.Student;

namespace SchoolAPI.Infrastructure
{
    public class StudentEntityFrameworkRepository : SchoolAPI.WithDI.IStudentRepository
    {
        private ApiContext _apiContext;

        public StudentEntityFrameworkRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }
        public List<SchoolAPI.Model.Student> GetAll()
        {
            return _apiContext.Students
                .Select(s => new SchoolAPI.Model.Student(s.Id, s.Name, s.Age))
                .ToList();
        }

        public SchoolAPI.Model.Student? GetById(int id)
        {
            var student = _apiContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return null;
            return new SchoolAPI.Model.Student(student.Id, student.Name, student.Age);
        }

        public Model.Student Create(string name, int age)
        {
            var dbStudent = new Student{Name = name, Age = age};
            _apiContext.Students.Add(dbStudent);
            _apiContext.SaveChanges();
            return new SchoolAPI.Model.Student(dbStudent.Id, dbStudent.Name, dbStudent.Age);
        }
    }
}
