using Microsoft.EntityFrameworkCore;
using NetConf2024StudentV1.Data;
using NetConf2024StudentV1.DTO;
using NetConf2024StudentV1.Models;

namespace NetConf2024StudentV1.Services
{
    /// <summary>
    /// Service for managing student-related operations.
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StudentService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="logger">The logger instance.</param>
        public StudentService(ApplicationDbContext context, ILogger<StudentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>A list of student DTOs.</returns>
        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            try
            {
                var students = await _context.Students.ToListAsync();
                return students.Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Age = s.Age,
                    Email = s.Email
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all students");
                return Enumerable.Empty<StudentDto>();
            }
        }

        /// <summary>
        /// Gets a student by the specified identifier.
        /// </summary>
        /// <param name="id">The student identifier.</param>
        /// <returns>The student DTO with the specified identifier.</returns>
        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            try
            {
                var getStudent = await _context.Students.FindAsync(id);
                if (getStudent == null)
                {
                    _logger.LogError($"Student with id: {id} not found");
                    return null;
                }

                _logger.LogInformation($"Student with id: {id} found");
                return new StudentDto
                {
                    Id = getStudent.Id,
                    Name = getStudent.Name,
                    Age = getStudent.Age,
                    Email = getStudent.Email
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching student with id: {id}");
                return null;
            }
        }

        /// <summary>
        /// Creates a new student.
        /// </summary>
        /// <param name="createStudentDto">The student data transfer object.</param>
        /// <returns>The created student DTO.</returns>
        public async Task<StudentDto> CreateStudentAsync(CreateStudentDto createStudentDto)
        {
            try
            {
                var student = new Student
                {
                    Name = createStudentDto.Name,
                    Age = createStudentDto.Age,
                    Email = createStudentDto.Email
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Student with id: {student.Id} created successfully");
                return new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    Age = student.Age,
                    Email = student.Email
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new student");
                return null;
            }
        }

        /// <summary>
        /// Updates the student with the specified identifier.
        /// </summary>
        /// <param name="id">The student identifier.</param>
        /// <param name="updateStudentDto">The student data transfer object.</param>
        /// <returns>The updated student DTO.</returns>
        public async Task<StudentDto> UpdateStudentAsync(int id, UpdateStudentDto updateStudentDto)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    _logger.LogError($"Student with id: {id} not found");
                    return null;
                }

                student.Name = updateStudentDto.Name;
                student.Age = updateStudentDto.Age;
                student.Email = updateStudentDto.Email;

                _context.Students.Update(student);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Student with id: {student.Id} updated successfully");
                return new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    Age = student.Age,
                    Email = student.Email
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating student with id: {id}");
                return null;
            }
        }

        /// <summary>
        /// Deletes the student with the specified identifier.
        /// </summary>
        /// <param name="id">The student identifier.</param>
        /// <returns>True if the student was deleted successfully; otherwise, false.</returns>
        public async Task<bool> DeleteStudentAsync(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    _logger.LogError($"Student with id: {id} not found");
                    return false;
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Student with id: {id} deleted successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting student with id: {id}");
                return false;
            }
        }
    }
}
