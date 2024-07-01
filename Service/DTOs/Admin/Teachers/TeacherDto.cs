using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Teachers
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
    }
    public class SortParameterValidator : AbstractValidator<string>
    {
        public SortParameterValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Sort parameter is required.")
                .Must(BeAValidSortParameter).WithMessage("Invalid sort parameter.");
        }

        private bool BeAValidSortParameter(string sortParameter)
        {
            var validParameters = new List<string> { "name","salary", "age" };
            return validParameters.Contains(sortParameter.ToLower());
        }
    }


}
