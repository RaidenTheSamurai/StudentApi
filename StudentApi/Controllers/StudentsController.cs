using Microsoft.AspNetCore.Mvc;
using StudentApi.Dtos;
using StudentApi.Services;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IStudentService service) : ControllerBase
    {

        [HttpGet]

        public async Task<ActionResult<List<StudentResponse>>> GetAllStudents()
            => Ok(await service.GetAllStudentsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponse>> GetStudentById(int id)
        {
            var student = await service.GetStudentByIdAsync(id);
            if (student is null)
                return NotFound("Student in given Id is not found");
            return Ok(student);
        }

        [HttpPost]

        public async Task<ActionResult<StudentResponse>> AddStudent(CreateStudentRequest student)
        {
            var addedStudent = await service.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = addedStudent.Id }, addedStudent);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateStudent(int id, UpdateStudentRequest student)
        {
            var isUpdated = await service.UpdateStudentAsync(id, student);
            if (!isUpdated)
                return NotFound("Student in given Id is not found");
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteStudent(int id)
        {
            var deletedStudent = await service.DeleteStudentAsync(id);
            if (deletedStudent == false)
                return NotFound("Student in given Id is not found");
            return NoContent();
        }
    }
}
