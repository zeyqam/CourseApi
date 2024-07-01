using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Groups
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int EducationId { get; set; }
        public int RoomId { get; set; }
    }
    public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name is required.")
                //.Matches(@"^[A-Za-z0-9\s]+$").WithMessage("Name format is wrong. Only letters, numbers, and spaces are allowed.")
                .MaximumLength(100).WithMessage("Name can be max 100 characters.");

            RuleFor(m => m.Capacity)
                .GreaterThan(0).WithMessage("Capacity must be a positive number.");

            RuleFor(m => m.EducationId)
                .GreaterThan(0).WithMessage("EducationId must be a positive number.");

            RuleFor(m => m.RoomId)
                .GreaterThan(0).WithMessage("RoomId must be a positive number.");
        }
    }
}
