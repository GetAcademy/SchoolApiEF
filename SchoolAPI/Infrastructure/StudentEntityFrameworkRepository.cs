using DbModels;
using DbStudent = DbModels.Student;
using DomainStudent = SchoolAPI.Model.Student;

namespace SchoolAPI.Infrastructure
{
    public class StudentEntityFrameworkRepository : WithDI.IStudentRepository
    {
        private ApiContext _apiContext;

        public StudentEntityFrameworkRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }
        public List<DomainStudent> GetAll()
        {
            return _apiContext.Students
                .Select(s => new DomainStudent(s.Id, s.Name, s.Age))
                .ToList();
        }

        public DomainStudent GetById(int id)
        {
            var student = _apiContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return null;
            return new DomainStudent(student.Id, student.Name, student.Age);
        }

        public DomainStudent Create(string name, int age)
        {
            var dbStudent = new DbStudent{Name = name, Age = age};
            _apiContext.Students.Add(dbStudent);
            _apiContext.SaveChanges();
            return new DomainStudent(dbStudent.Id, dbStudent.Name, dbStudent.Age);
        }
    }
}
