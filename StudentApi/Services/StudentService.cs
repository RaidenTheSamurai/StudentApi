using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Dtos;
using StudentApi.Models;
namespace StudentApi.Services
{
    public class StudentService(AppDbContext context) : IStudentService
    {



        public async Task<StudentResponse> AddStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentResponse?> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentResponse>> GetAllStudentsAsync()
            => await context.Students.Select(s => new StudentResponse {

                Name = s.Name,
                Age = s.Age,
            }).ToListAsync();

        public async Task<StudentResponse?> GetStudentByIdAsync(int id)
        {
            var result = await context.Students
                .Where(s => s.Id == id)
                .Select(s => new StudentResponse
            {
                Name = s.Name,
                Age = s.Age,
            } ).FirstOrDefaultAsync();
            return result;
        }

        public async Task<StudentResponse> UpdateStudentAsync(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}