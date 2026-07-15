using StudentApi.Dtos;
using StudentApi.Services;

namespace StudentApi.Tests;

public class FakeStudentService : IStudentService
{
    public List<StudentResponse> Students { get; set; } = [];

    public bool UpdateResult { get; set; } = true;
    public bool DeleteResult { get; set; } = true;

    public Task<List<StudentResponse>> GetAllStudentsAsync()
    {
        return Task.FromResult(Students);
    }

    public Task<StudentResponse?> GetStudentByIdAsync(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);

        return Task.FromResult(student);
    }

    public Task<StudentResponse> AddStudentAsync(CreateStudentRequest request)
    {
        var student = new StudentResponse
        {
            Id = Students.Count == 0 ? 1 : Students.Max(s => s.Id) + 1,
            Name = request.Name,
            Age = request.Age
        };

        Students.Add(student);

        return Task.FromResult(student);
    }

    public Task<bool> UpdateStudentAsync(
        int id,
        UpdateStudentRequest request)
    {
        if (!UpdateResult)
            return Task.FromResult(false);

        var student = Students.FirstOrDefault(s => s.Id == id);

        if (student is null)
            return Task.FromResult(false);

        student.Name = request.Name;
        student.Age = request.Age;

        return Task.FromResult(true);
    }

    public Task<bool> DeleteStudentAsync(int id)
    {
        if (!DeleteResult)
            return Task.FromResult(false);

        var student = Students.FirstOrDefault(s => s.Id == id);

        if (student is null)
            return Task.FromResult(false);

        Students.Remove(student);

        return Task.FromResult(true);
    }
}