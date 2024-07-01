using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace ClassApiProject.Controllers.UI
{
    
    public class GroupController : BaseController
    {

        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUI()
        {
            return Ok(await _groupService.GetAllForUIAsync());
        }
    }
}
