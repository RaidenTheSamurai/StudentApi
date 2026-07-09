using StudentApi.Models;
namespace StudentApi.Services
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<Student> AddStudentAsync(Student student);
        public Task<Student> UpdateStudentAsync(int id, Student student);
        public Task<Student?> DeleteStudentAsync(int id);
    }
}
