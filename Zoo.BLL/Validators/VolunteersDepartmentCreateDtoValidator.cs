using FluentValidation;
using Zoo.BLL.DTOs.VolunteersDepartment;

namespace Zoo.BLL.Validators
{
    public class VolunteersDepartmentCreateDtoValidator : AbstractValidator<VolunteersDepartmentCreateDto>
    {
        public VolunteersDepartmentCreateDtoValidator()
        {
            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Department name is required")
                .MaximumLength(50).WithMessage("Department name can't exceed 50 characters");
        }
    }
}