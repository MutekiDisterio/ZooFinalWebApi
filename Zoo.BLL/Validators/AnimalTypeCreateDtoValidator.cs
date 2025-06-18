using FluentValidation;
using Zoo.BLL.DTOs.AnimalTypes;

namespace Zoo.BLL.Validators
{
    public class AnimalTypeCreateDtoValidator : AbstractValidator<AnimalTypeCreateDto>
    {
        public AnimalTypeCreateDtoValidator()
        {
            RuleFor(x => x.AnimalType)
                .NotEmpty().WithMessage("Animal type name is required")
                .MaximumLength(30).WithMessage("Animal type name can't exceed 30 characters");
        }
    }
}