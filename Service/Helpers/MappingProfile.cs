using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Rooms;
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

        }
    }
}
