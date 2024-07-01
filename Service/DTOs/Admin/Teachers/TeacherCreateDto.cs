using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Teachers
{
    public class TeacherCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
    }
    public class TeacherCreateDtoValidator : AbstractValidator<TeacherCreateDto>
    {
        public TeacherCreateDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                //.Matches(@"^(?i)[a-z]+[\ -].*[a-z]$")
                //.WithMessage(" Name format is wrong")
                .MaximumLength(50)
                .WithMessage("Full name can be max 50 characters");

            RuleFor(m => m.Surname)
               .NotEmpty()
               .WithMessage(" Surname is required")
               //.Matches(@"^(?i)[a-z]+[\ -].*[a-z]$")
               //.WithMessage(" Surname format is wrong")
               .MaximumLength(50)
               .WithMessage("Full name can be max 50 characters");

            RuleFor(m => m.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is invalid")
                .MaximumLength(50)
                .WithMessage("Email can be max 50 characters");

            RuleFor(x => x.Salary)
          .GreaterThan(0).WithMessage("Salary must be a positive number.");

            RuleFor(x => x.Age)
           .InclusiveBetween(15, 100).WithMessage("Age must be between 15 and 100.");





        }
    }
}

