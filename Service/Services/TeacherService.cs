using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Teachers;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<TeacherService> _logger;
        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper, ILogger<TeacherService> logger)
        {
            _teacherRepo = teacherRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddGroupAsync(TeacherGroupAddDto data)
        {
            var groupTeacher = _mapper.Map<TeacherGroup>(data);
            await _teacherRepo.AddGroupAsync(groupTeacher);
        }

        public async Task CreateAsync(TeacherCreateDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var exists = await _teacherRepo.FindBy(e => e.Name == model.Name).AnyAsync();
            if (exists)
            {
                throw new InvalidOperationException("Education with this name already exists");
            }

            await _teacherRepo.CreateAsync(_mapper.Map<Teacher>(model));
        }

        public Task DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteGroupAsync(int groupTeacherId)
        {
            await _teacherRepo.DeleteGroupAsync(groupTeacherId);
        }

        public Task EditAsync(int? id, TeacherEditDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TeacherDto>>(await _teacherRepo.GetAllAsync());
        }

        public Task<TeacherDto> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeacherDto>> SearchAsync(string query)
        {
            var teachers = _teacherRepo.FindBy(
                t => t.Name.Contains(query) || t.Surname.Contains(query)
            );

            var teacherDtos = _mapper.Map<IEnumerable<TeacherDto>>(await teachers.ToListAsync());
            return teacherDtos;
        }

        public async Task<IEnumerable<TeacherDto>> SortAsync(string sortBy)
        {
            IQueryable<Teacher> teachers = (await _teacherRepo.GetAllAsync()).AsQueryable();

            switch (sortBy.ToLower())
            {
                case "name":
                    teachers = teachers.OrderBy(t => t.Name);
                    break;
                case "salary":
                    teachers = teachers.OrderBy(t => t.Salary);
                    break;
                case "age":
                    teachers = teachers.OrderBy(t => t.Age);
                    break;
                default:
                    throw new ArgumentException("Invalid sort parameter");
            }

            var teacherDtos = _mapper.Map<IEnumerable<TeacherDto>>(await teachers.ToListAsync());
            return teacherDtos;
        }
    }
}
