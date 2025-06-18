using FluentValidation;
using Zoo.BLL.DTOs.Cages;

namespace Zoo.BLL.Validators
{
    public class CageUpdateDtoValidator : AbstractValidator<CageUpdateDto>
    {
        public CageUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Cage ID must be greater than 0");

            RuleFor(x => x.AnimalTypeId)
                .GreaterThan(0).WithMessage("Capacity must be greater than 0");
        }
    }
}