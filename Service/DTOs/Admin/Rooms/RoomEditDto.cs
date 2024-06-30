using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Rooms
{
    public class RoomEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatCount { get; set; }
    }

    public class RoomEditDtoValidator : AbstractValidator<RoomEditDto>
    {
        public RoomEditDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

            RuleFor(x => x.SeatCount)
                .GreaterThan(0).WithMessage("SeatCount must be greater than 0.");
        }
    }

}
