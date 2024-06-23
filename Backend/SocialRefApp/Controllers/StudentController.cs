using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialRefApp.Dtos.Student;
using SocialRefApp.Models;
using SocialRefApp.Services.StudentService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudyAppBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // [HttpGet]
        // public async Task<ActionResult<ServiceResponse<GetStudentResponseDto>>> Get()
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);

        //     return Ok(await _studentService.GetStudentByUserId(userId));
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<ServiceResponse<GetStudentResponseDto>>> GetByID(int id)
        // {
        //     return Ok(await _studentService.GetStudent(id));
        // }

        // [HttpGet("GetAll")]
        // public async Task<ActionResult<ServiceResponse<List<GetStudentResponseDto>>>> GetAllStudents()
        // {
        //     return Ok(await _studentService.GetAllStudents());
        // }

        // [HttpPost()]
        // public async Task<ActionResult<ServiceResponse<List<GetStudentResponseDto>>>> SaveNewStudent(AddStudentRequestDto newStudent)
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);

        //     return Ok(await _studentService.SaveNewStudent(newStudent,userId));
        // }

        // [HttpPut()]
        // public async Task<ActionResult<ServiceResponse<GetStudentResponseDto>>> UpdateStudent(UpdateStudentRequestDto updateStudent)
        // {
        //     return Ok(await _studentService.UpdateStudent(updateStudent));
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<ServiceResponse<List<GetStudentResponseDto>>>> DeleteStudent(int id)
        // {
        //     return Ok(await _studentService.DeleteStudent(id));
        // }

        // [HttpPut("UpdateSelectedCategory/{categoryId}")]
        // public async Task<ActionResult<ServiceResponse<List<GetStudentResponseDto>>>> UpdateSelectedCategoryById([FromRoute]int categoryId)
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);

        //     return Ok(await _studentService.UpdateSelectedCategory(categoryId, userId));
        // }

        // [HttpPut("UpdateEmailNewsletterPreference/{newsletterPreference}")]
        // public async Task<ActionResult<ServiceResponse<List<GetStudentResponseDto>>>> UpdateEmailNewsletterPreference([FromRoute] int newsletterPreference)
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);

        //     return Ok(await _studentService.UpdateEmailNewsletterPreference(newsletterPreference == 0 ? false : true, userId));
        // }

    }
}

