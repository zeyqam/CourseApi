using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Educations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<EducationService> _logger;
        public EducationService(IEducationRepository educationRepository,IMapper mapper,ILogger<EducationService> logger)
        {
            _educationRepo = educationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreateAsync(EducationCreateDto model)
        {
            if (model == null) throw new ArgumentNullException();

            await _educationRepo.CreateAsync(_mapper.Map<Education>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }
            var existCountry = await _educationRepo.GetByIdAsync((int)id);
            if (existCountry == null)
            {
                _logger.LogWarning("Data not found ");
                throw new NullReferenceException();
            }
            await _educationRepo.DeleteAsync(existCountry);
        }
        public async Task EditAsync(int? id, EducationEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));
            var existCountry = await _educationRepo.GetByIdAsync((int)id);
            if (existCountry == null) throw new KeyNotFoundException("Country not found");

            _mapper.Map(model, existCountry);
            await _educationRepo.UpdateAsync(existCountry);
        }

        public async Task<IEnumerable<EducationDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EducationDto>>(await _educationRepo.GetAllAsync());

        }

        public async Task<EducationDto> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();
            var existCountry = await _educationRepo.GetByIdAsync((int)id);
            if (existCountry == null) throw new NullReferenceException();
            return _mapper.Map<EducationDto>(existCountry);
        }
    }
}
