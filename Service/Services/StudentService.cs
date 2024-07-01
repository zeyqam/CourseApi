using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Students;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentSevice
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;
        public StudentService(IStudentRepository studentRepository, 
                               IMapper mapper, 
                                ILogger<StudentService> logger)
        {
            _studentRepo = studentRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task AddGroupAsync(StudentGroupAddDto data)
        {
            var groupStudent = _mapper.Map<StudentGroup>(data);
            await _studentRepo.AddGroupAsync(groupStudent);
        }

        public async Task CreateAsync(StudentCreateDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var exists = await _studentRepo.FindBy(e => e.Name == model.Name).AnyAsync();
            if (exists)
            {
                throw new InvalidOperationException("Group with this name already exists");
            }

            await _studentRepo.CreateAsync(_mapper.Map<Student>(model));
        }

        public Task DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteGroupAsync(int groupStudentId)
        {
            await _studentRepo.DeleteGroupAsync(groupStudentId);
        }

        public Task EditAsync(int? id, StudentEditDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _studentRepo.GetAllAsync());
        }

        public Task<StudentDto> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
