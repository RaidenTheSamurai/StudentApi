using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Services;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService service) : ControllerBase
    {

        [HttpGet]

        public async Task<ActionResult<List<Student>>> GetAllStudents()
            => Ok(await service.GetAllStudentsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await service.GetStudentByIdAsync(id);
            if (student is null)
                return NotFound("Student in given Id is not found");
            return Ok(student);
        }
    }
}
