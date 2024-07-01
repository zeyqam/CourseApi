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
    public class TeacherRepository:BaseRepository<Teacher>,ITeacherRepository
    {
        public TeacherRepository(AppDbContext context):base(context)
        {
            
        }

        public async Task AddGroupAsync(TeacherGroup data)
        {
            await _context.TeacherGroups.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int groupTeacherId)
        {
            var groupTeacher = await _context.TeacherGroups.AsNoTracking().FirstOrDefaultAsync(m => m.Id == groupTeacherId);

            if (groupTeacher != null)
            {
                _context.TeacherGroups.Remove(groupTeacher);
                await _context.SaveChangesAsync();
            }
        }
    }
}
