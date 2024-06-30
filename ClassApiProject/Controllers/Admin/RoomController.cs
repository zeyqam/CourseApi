using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Rooms;
using Service.Services.Interfaces;

namespace ClassApiProject.Controllers.Admin
{
    
    public class RoomController : BaseController
    {

        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IRoomService roomService, IMapper mapper, ILogger<RoomController> logger)
        {
            _roomService = roomService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            _logger.LogInformation("GetAll method is working");
            var rooms = await _roomService.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById([FromRoute]int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody]RoomCreateDto request)
        {
            await _roomService.CreateAsync(request);
            return CreatedAtAction(nameof(CreateRoom), new { response = "Data successfully created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRoom([FromRoute]int id,[FromBody] RoomEditDto request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _roomService.UpdateAsync(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteAsync(id);
            return NoContent();
        }
    }
}
