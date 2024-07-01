using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task AddGroupAsync(StudentGroup data);
        Task DeleteGroupAsync(int groupStudentId);
    }
}
