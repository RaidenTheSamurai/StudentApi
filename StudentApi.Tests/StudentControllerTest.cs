using Microsoft.AspNetCore.Mvc;
using StudentApi.Controllers;
using StudentApi.Dtos;

namespace StudentApi.Tests;

public class StudentsControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOk_WithStudents()
    {
        // Arrange
        var service = new FakeStudentService
        {
            Students =
            [
                new StudentResponse { Id = 1, Name = "John", Age = 20 },
                new StudentResponse { Id = 2, Name = "Anna", Age = 22 }
            ]
        };

        var controller = new StudentsController(service);

        // Act
        var result = await controller.GetAllStudents();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var students =
            Assert.IsType<List<StudentResponse>>(okResult.Value);

        Assert.Equal(2, students.Count);
    }

    [Fact]
    public async Task GetById_ReturnsOk_WhenStudentExists()
    {
        var service = new FakeStudentService
        {
            Students =
            [
                new StudentResponse { Id = 1, Name = "John", Age = 20 }
            ]
        };

        var controller = new StudentsController(service);

        var result = await controller.GetStudentById(1);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var student =
            Assert.IsType<StudentResponse>(okResult.Value);

        Assert.Equal(1, student.Id);
        Assert.Equal("John", student.Name);
    }

    [Fact]
    public async Task GetById_ReturnsNotFoundObjectResult_WhenStudentDoesNotExist()
    {
        var service = new FakeStudentService();
        var controller = new StudentsController(service);

        var result = await controller.GetStudentById(999);

        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public async Task Create_ReturnsCreatedAtAction_WithCreatedStudent()
    {
        var service = new FakeStudentService();
        var controller = new StudentsController(service);

        var request = new CreateStudentRequest
        {
            Name = "Serhii",
            Age = 23
        };

        var result = await controller.AddStudent(request);

        var createdResult =
            Assert.IsType<CreatedAtActionResult>(result.Result);

        var student =
            Assert.IsType<StudentResponse>(createdResult.Value);

        Assert.Equal("Serhii", student.Name);
        Assert.Equal(23, student.Age);
        Assert.Equal(nameof(controller.GetStudentById),
            createdResult.ActionName);
    }

    [Fact]
    public async Task Update_ReturnsNoContent_WhenStudentExists()
    {
        var service = new FakeStudentService
        {
            Students =
            [
                new StudentResponse { Id = 1, Name = "John", Age = 20 }
            ]
        };

        var controller = new StudentsController(service);

        var request = new UpdateStudentRequest
        {
            Name = "Mike",
            Age = 25
        };

        var result = await controller.UpdateStudent(1, request);

        Assert.IsType<NoContentResult>(result);
        Assert.Equal("Mike", service.Students[0].Name);
        Assert.Equal(25, service.Students[0].Age);
    }

    [Fact]
    public async Task Update_ReturnsNotFoundObjectResult_WhenStudentDoesNotExist()
    {
        var service = new FakeStudentService();
        var controller = new StudentsController(service);

        var request = new UpdateStudentRequest
        {
            Name = "Mike",
            Age = 25
        };

        var result = await controller.UpdateStudent(999, request);

        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNoContent_WhenStudentExists()
    {
        var service = new FakeStudentService
        {
            Students =
            [
                new StudentResponse { Id = 1, Name = "John", Age = 20 }
            ]
        };

        var controller = new StudentsController(service);

        var result = await controller.DeleteStudent(1);

        Assert.IsType<NoContentResult>(result);
        Assert.Empty(service.Students);
    }

    [Fact]
    public async Task Delete_ReturnsNotFoundObjectResult_WhenStudentDoesNotExist()
    {
        var service = new FakeStudentService();
        var controller = new StudentsController(service);

        var result = await controller.DeleteStudent(999);

        Assert.IsType<NotFoundObjectResult>(result);
    }
}