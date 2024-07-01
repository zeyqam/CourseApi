using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Educations;
using Service.Services.Interfaces;

namespace ClassApiProject.Controllers.Admin
{
    
    public class EducationController : BaseController
    {
        private readonly IEducationService _educationService;
        private readonly ILogger<EducationController> _logger;
        private readonly IMapper _mapper;

        public EducationController(IEducationService educationService,
                                 ILogger<EducationController> logger ,IMapper mapper)
        {
            _educationService = educationService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Country GetAll is working ");
                return Ok(await _educationService.GetAllAsync());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EducationCreateDto request)
        {
            try
            {
               
                await _educationService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data succesfully created" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {

                var country = await _educationService.GetByIdAsync(id);
                if (country == null) return NotFound();
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EducationEditDto request)
        {
            try
            {
                await _educationService.EditAsync(id, request);
                return Ok(new { response = "Data successfully updated" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Country not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _educationService.DeleteAsync(id);
                return Ok(new { response = "Data successfully deleted" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Country not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            try
            {
                var educations = await _educationService.SearchByNameAsync(name);
                return Ok(_mapper.Map<IEnumerable<EducationDto>>(educations));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Search method");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        [HttpGet("sort")]
        public async Task<IActionResult> Sort()
        {
            try
            {
                var educations = await _educationService.GetAllSortedAsync();
                return Ok(_mapper.Map<IEnumerable<EducationDto>>(educations));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Sort method");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
