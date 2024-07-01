using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Rooms;
using Service.DTOs.Admin.Students;
using Service.DTOs.Admin.Teachers;
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
            services.AddScoped<IValidator<TeacherCreateDto>, TeacherCreateDtoValidator>();
            services.AddScoped<IValidator<TeacherEditDto>,TeacherEditDtoValidator>();
            services.AddScoped<IValidator<string>, SortParameterValidator>();
            services.AddScoped < IValidator<GroupCreateDto>, GroupCreateDtoValidator>();
            services.AddScoped<IValidator<StudentCreateDto>, StudentCreateDtoValidator>();
            services.AddScoped<IValidator<StudentEditDto>, StudentEditDtoValidator>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IStudentSevice,StudentService>();

            return services;
        }
    }
}
