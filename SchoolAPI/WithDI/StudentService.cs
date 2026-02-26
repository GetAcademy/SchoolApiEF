using SchoolAPI.Model;

namespace SchoolAPI.WithDI
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentsWithCount GetAll()
        {
            var students = _studentRepository.GetAll();
            return new StudentsWithCount(students.Count, students);
        }

        public Student? GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public Student Create(string name, int age)
        {
            return _studentRepository.Create(name, age);
        }
    }
}
