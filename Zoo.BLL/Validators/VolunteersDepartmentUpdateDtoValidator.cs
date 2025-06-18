using FluentValidation;
using Zoo.BLL.DTOs.VolunteersDepartment;

namespace Zoo.BLL.Validators
{
    public class VolunteersDepartmentUpdateDtoValidator : AbstractValidator<VolunteersDepartmentUpdateDto>
    {
        public VolunteersDepartmentUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0");

            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Department name is required")
                .MaximumLength(50).WithMessage("Department name can't exceed 50 characters");
        }
    }
}