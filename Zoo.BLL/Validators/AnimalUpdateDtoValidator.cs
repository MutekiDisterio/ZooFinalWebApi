using FluentValidation;
using Zoo.BLL.DTOs.Animals;

namespace Zoo.BLL.Validators
{
    public class AnimalUpdateDtoValidator : AbstractValidator<AnimalUpdateDto>
    {
        public AnimalUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Animal ID must be greater than 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name can't exceed 50 characters");


            RuleFor(x => x.AnimalTypeId)
                .GreaterThan(0).WithMessage("Animal type ID must be greater than 0");

            RuleFor(x => x.OwnerId)
                .GreaterThan(0).WithMessage("Owner ID must be greater than 0");
        }
    }
}