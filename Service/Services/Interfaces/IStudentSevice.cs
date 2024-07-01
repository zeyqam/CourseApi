using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Students;
using Service.DTOs.Educations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentSevice
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task CreateAsync(StudentCreateDto model);
        Task<StudentDto> GetByIdAsync(int? id);
        Task EditAsync(int? id, StudentEditDto model);
        Task DeleteAsync(int? id);
        Task AddGroupAsync(StudentGroupAddDto data);
        Task DeleteGroupAsync(int groupStudentId);
    }
}
