using Service.DTOs.Educations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEducationService
    {
        Task<IEnumerable<EducationDto>> GetAllAsync();
        Task CreateAsync(EducationCreateDto model);
        Task<EducationDto> GetByIdAsync(int? id);
        Task EditAsync(int? id, EducationEditDto model);
        Task DeleteAsync(int? id);

    }
}
