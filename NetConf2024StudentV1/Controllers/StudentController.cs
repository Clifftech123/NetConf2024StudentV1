using Microsoft.AspNetCore.Mvc;
using NetConf2024StudentV1.DTO;
using NetConf2024StudentV1.Services;

namespace NetConf2024StudentV1.Controllers
{
    /// <summary>
    /// Controller for managing student-related operations.
    /// </summary>
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentController"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>A list of students.</returns>
        [HttpGet("api/students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        /// <summary>
        /// Gets a student by the specified identifier.
        /// </summary>
        /// <param name="id">The student identifier.</param>
        /// <returns>The student with the specified identifier.</returns>
        [HttpGet("api/students/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        /// <summary>
        /// Creates a new student.
        /// </summary>
        /// <param name="createStudentDto">The student data transfer object.</param>
        /// <returns>The created student.</returns>
        [HttpPost("api/students")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto createStudentDto)
        {
            var student = await _studentService.CreateStudentAsync(createStudentDto);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        /// <summary>
        /// Updates the student with the specified identifier.
        /// </summary>
        /// <param name="id">The student identifier.</param>
        /// <param name="updateStudentDto">The student data transfer object.</param>
        /// <returns>The updated student.</returns>
        [HttpPut("api/students/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDto updateStudentDto)
        {
            var findStudent = await _studentService.GetStudentByIdAsync(id);
            if (findStudent == null)
            {
                return BadRequest();
            }

            var student = await _studentService.UpdateStudentAsync(id, updateStudentDto);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        /// <summary>
        /// Deletes the student with the specified identifier.
        /// </summary>
        /// <param name="id">The student identifier.</param>
        /// <returns>No content if the student was deleted successfully.</returns>
        [HttpDelete("api/students/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var isDeleted = await _studentService.DeleteStudentAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
