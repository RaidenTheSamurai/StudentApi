using StudentApi.Models;
namespace StudentApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new List<Student>();

        public async Task<Student> AddStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetAllStudentsAsync()
            => await Task.FromResult(_students);

        public async Task<Student?> GetStudentByIdAsync(int id)
            => await Task.FromResult(_students.FirstOrDefault(s => s.Id == id));

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}