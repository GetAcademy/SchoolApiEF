using SchoolAPI.Model;

namespace SchoolAPI.WithDI
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = [];
        private int _nextId = 1;

        public List<Student> GetAll() => _students;

        public Student? GetById(int id)
            => _students.SingleOrDefault(s => s.Id == id);

        public Student Create(string name, int age)
        {
            var student = new Student(_nextId++, name, age);
            _students.Add(student);
            return student;
        }
    }
}
