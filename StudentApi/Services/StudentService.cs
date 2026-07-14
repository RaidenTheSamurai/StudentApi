using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Dtos;
using StudentApi.Models;
namespace StudentApi.Services
{
    public class StudentService(AppDbContext context) : IStudentService
    {



        public async Task<StudentResponse> AddStudentAsync(CreateStudentRequest student)
        {
            var newStudent = new Student
            {
                Name = student.Name,
                Age = student.Age,
            };
            context.Students.Add(newStudent);
            await context.SaveChangesAsync();

            return new StudentResponse
            {
                Id = newStudent.Id,
                Name = newStudent.Name,
                Age = newStudent.Age,
            };
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var studentToDelete = await context.Students.FindAsync(id);
            if (studentToDelete is null)
                return false;

           context.Students.Remove(studentToDelete);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<StudentResponse>> GetAllStudentsAsync()
            => await context.Students.Select(s => new StudentResponse {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
            }).ToListAsync();

        public async Task<StudentResponse?> GetStudentByIdAsync(int id)
        {
            var result = await context.Students
                .Where(s => s.Id == id)
                .Select(s => new StudentResponse
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
            } ).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateStudentAsync(int id, UpdateStudentRequest student)
        {
            var studentToUpdate = await context.Students.FindAsync(id);
            if (studentToUpdate is null) 
                return false;

            studentToUpdate.Name = student.Name;
            studentToUpdate.Age= student.Age;

            await context.SaveChangesAsync();
            
            return true;
        }
    }
}