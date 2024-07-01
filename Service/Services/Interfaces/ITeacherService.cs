using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAllAsync();
        Task CreateAsync(TeacherCreateDto model);
        Task<TeacherDto> GetByIdAsync(int? id);
        Task EditAsync(int? id, TeacherEditDto model);
        Task DeleteAsync(int? id);
        Task AddGroupAsync(TeacherGroupAddDto data);
        Task DeleteGroupAsync(int groupTeacherId);
        Task<IEnumerable<TeacherDto>> SearchAsync(string query);
        Task<IEnumerable<TeacherDto>> SortAsync(string sortBy);
    }
}
