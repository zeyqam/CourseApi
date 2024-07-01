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
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context):base(context) { }

        public async Task AddGroupAsync(StudentGroup data)
        {
            await _context.StudentGroups.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int groupStudentId)
        {
            var groupStudent = await _context.StudentGroups.AsNoTracking().FirstOrDefaultAsync(m => m.Id == groupStudentId);

            if (groupStudent != null)
            {
                _context.StudentGroups.Remove(groupStudent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
