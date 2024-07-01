using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Groups;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<GroupService> _logger;
        public GroupService(IGroupRepository groupRepository, IMapper mapper, ILogger<GroupService> logger)
        {
            _groupRepo = groupRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task CreateAsync(GroupCreateDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var exists = await _groupRepo.FindBy(e => e.Name == model.Name).AnyAsync();
            if (exists)
            {
                throw new InvalidOperationException("Group with this name already exists");
            }

            await _groupRepo.CreateAsync(_mapper.Map<Group>(model));
        }

        public Task DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupAdminDto>> GetAllAsync()
        {
            var groups = await _groupRepo.GetAllWithIncludesAsync();
            return _mapper.Map<IEnumerable<GroupAdminDto>>(groups);
        }

        public async Task<IEnumerable<GroupDto>> GetAllForUIAsync()
        {
            var groups = await _groupRepo.GetAllForUIAsync();
            return _mapper.Map<IEnumerable<GroupDto>>(groups);
        }

        public Task<GroupDto> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
