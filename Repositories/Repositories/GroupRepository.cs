using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Group>> GetAllForUIAsync()
        {
            return await _context.Groups


                .Include(m => m.Room)
            .Include(m => m.Education)
            .Include(m => m.StudentGroups)
            .ThenInclude(sg => sg.Student)
            .Include(m => m.TeacherGroups)
            .ThenInclude(tg => tg.Teacher)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetAllWithIncludesAsync()
        {
             return await _context.Groups
                    .Include(m => m.Room)
                    .Include(m => m.Education)
                    .AsNoTracking()
                    .ToListAsync();
            
        }
    }
}
