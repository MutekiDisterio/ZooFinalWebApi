using FluentValidation;
using Zoo.BLL.DTOs.AnimalTypes;

namespace Zoo.BLL.Validators
{
    public class AnimalTypeUpdateDtoValidator : AbstractValidator<AnimalTypeUpdateDto>
    {
        public AnimalTypeUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Animal type ID must be greater than 0");

            RuleFor(x => x.AnimalType)
                .NotEmpty().WithMessage("Animal type name is required")
                .MaximumLength(30).WithMessage("Animal type name can't exceed 30 characters");
        }
    }
}