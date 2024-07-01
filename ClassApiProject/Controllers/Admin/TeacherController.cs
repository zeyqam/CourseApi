using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Teachers;
using Service.DTOs.Educations;
using Service.Services;
using Service.Services.Interfaces;

namespace ClassApiProject.Controllers.Admin
{
  
    public class TeacherController : BaseController
    {
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ITeacherService teacherService,
                                 ILogger<TeacherController> logger)
        {
            _teacherService = teacherService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherCreateDto request)
        {
            try
            {

                await _teacherService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data succesfully created" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var result = await _teacherService.SearchAsync(query);
            return Ok(result);
        }

        [HttpGet("Sort")]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> SortTeachers([FromQuery] string sortBy)
        {
            try
            {
                var validator = new SortParameterValidator();
                var validationResult = validator.Validate(sortBy);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new { Success = false, Message = validationResult.Errors.First().ErrorMessage });
                }

                var teachers = await _teacherService.SortAsync(sortBy);
                return Ok(teachers);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Success = false, Message = "Internal server error!" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Country GetAll is working ");
                return Ok(await _teacherService.GetAllAsync());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddGroup([FromBody] TeacherGroupAddDto request)
        {
            await _teacherService.AddGroupAsync(request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroup([FromQuery] int? groupTeacherId)
        {
            if (groupTeacherId is null) return BadRequest();

            await _teacherService.DeleteGroupAsync((int)groupTeacherId);

            return Ok();
        }
    }
}
