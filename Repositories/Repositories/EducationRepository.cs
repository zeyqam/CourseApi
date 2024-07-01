﻿using Domain.Entities;
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
    public class EducationRepository : BaseRepository<Education>, IEducationRepository
    {
        public EducationRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<IEnumerable<Education>> SearchByNameAsync(string name)
        {
            return await _context.Educations
                .Where(e => e.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<IEnumerable<Education>> GetAllSortedAsync()
        {
            return await _context.Educations
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

    }

}
