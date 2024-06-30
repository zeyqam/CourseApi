using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.DTOs.Admin.Rooms;
using Service.DTOs.Educations;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });
            services.AddScoped<IValidator<RoomCreateDto>, RoomCreateDtoValidator>();
            services.AddScoped<IValidator<RoomEditDto>, RoomEditDtoValidator>();
            services.AddScoped < IValidator<EducationCreateDto>, EducationCreateDtoValidator>();
            services.AddScoped<IValidator<EducationEditDto>, EducationEditDtoValidator>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IEducationService, EducationService>();

            return services;
        }
    }
}
