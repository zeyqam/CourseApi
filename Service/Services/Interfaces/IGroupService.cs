using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupAdminDto>> GetAllAsync();
        Task CreateAsync(GroupCreateDto model);
        Task<GroupDto> GetByIdAsync(int? id);
        
        Task DeleteAsync(int? id);
        Task<IEnumerable<GroupDto>> GetAllForUIAsync();
    }
}
