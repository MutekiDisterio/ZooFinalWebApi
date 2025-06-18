using FluentValidation;
using Zoo.BLL.DTOs.Volunteers;

namespace Zoo.BLL.Validators
{
    public class VolunteerUpdateDtoValidator : AbstractValidator<VolunteerUpdateDto>
    {
        public VolunteerUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Volunteer ID must be greater than 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Volunteer name is required")
                .MaximumLength(50).WithMessage("Volunteer name can't exceed 50 characters");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0");
        }
    }
}