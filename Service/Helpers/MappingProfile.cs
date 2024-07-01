using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Rooms;
using Service.DTOs.Admin.Students;
using Service.DTOs.Admin.Teachers;
using Service.DTOs.Educations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomCreateDto, Room>();
            CreateMap<Room, RoomDto>();
            CreateMap<RoomEditDto, Room>();

            CreateMap<EducationCreateDto, Education>();
            CreateMap<Education, EducationDto>();
            CreateMap<EducationEditDto, Education>();

            CreateMap<Teacher, TeacherDto>();

            CreateMap<TeacherCreateDto, Teacher>();
            CreateMap<TeacherGroupAddDto, TeacherGroup>();

            CreateMap<GroupCreateDto, Group>();
            CreateMap<Group, GroupDto>().ForMember(d => d.Room, opt => opt.MapFrom(s => s.Room.Name));
            CreateMap<Group, GroupAdminDto>().ForMember(d => d.Education, opt => opt.MapFrom(s => s.Education.Name))
                .ForMember(d => d.Room, opt => opt.MapFrom(s => s.Room.Name));
            CreateMap<Student, StudentDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentGroupAddDto, StudentGroup>();



        }
    }
}
