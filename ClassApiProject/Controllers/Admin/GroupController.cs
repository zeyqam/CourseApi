using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Educations;
using Service.Services;
using Service.Services.Interfaces;

namespace ClassApiProject.Controllers.Admin
{
    
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IGroupService groupService,
                                 ILogger<GroupController> logger)
        {
            _groupService = groupService;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupCreateDto request)
        {
            try
            {

                await _groupService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data succesfully created" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Country GetAll is working ");
                return Ok(await _groupService.GetAllAsync());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
