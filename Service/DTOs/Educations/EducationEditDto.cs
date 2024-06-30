using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Educations
{
    public class EducationEditDto
    {
       
        public string Name { get; set; }
    }
    public class EducationEditDtoValidator : AbstractValidator<EducationEditDto>
    {
        public EducationEditDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required");


        }
    }
}
