using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Students;
using Service.DTOs.Educations;
using Service.Services;
using Service.Services.Interfaces;

namespace ClassApiProject.Controllers.Admin
{
   
    public class StudentController : BaseController
    {
        private readonly IStudentSevice _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentSevice studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentCreateDto request)
        {
            try
            {

                await _studentService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data succesfully created" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddGroup([FromBody] StudentGroupAddDto request)
        {
            await _studentService.AddGroupAsync(request);

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Country GetAll is working ");
                return Ok(await _studentService.GetAllAsync());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCourse([FromQuery] int? groupStudentId)
        {
            if (groupStudentId is null) return BadRequest();

            await _studentService.DeleteGroupAsync((int)groupStudentId);

            return Ok();
        }
    }
}
