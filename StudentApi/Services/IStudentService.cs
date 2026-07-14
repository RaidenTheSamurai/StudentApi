using StudentApi.Dtos;
using StudentApi.Models;
namespace StudentApi.Services
{
    public interface IStudentService
    {
        public Task<List<StudentResponse>> GetAllStudentsAsync();
        public Task<StudentResponse?> GetStudentByIdAsync(int id);
        public Task<StudentResponse> AddStudentAsync(CreateStudentRequest student);
        public Task<bool> UpdateStudentAsync(int id, UpdateStudentRequest student);
        public Task<StudentResponse?> DeleteStudentAsync(int id);
    }
}
