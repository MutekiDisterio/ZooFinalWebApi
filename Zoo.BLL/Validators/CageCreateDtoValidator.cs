using FluentValidation;
using Zoo.BLL.DTOs.Cages;

namespace Zoo.BLL.Validators
{
    public class CageCreateDtoValidator : AbstractValidator<CageCreateDto>
    {
        public CageCreateDtoValidator()
        {

            RuleFor(x => x.AnimalTypeId)
                .GreaterThan(0).WithMessage("Capacity must be greater than 0");
        }
    }
}