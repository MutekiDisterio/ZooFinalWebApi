using FluentValidation;
using Zoo.BLL.DTOs.Owners;

namespace Zoo.BLL.Validators
{
    public class OwnerCreateDtoValidator : AbstractValidator<OwnerCreateDto>
    {
        public OwnerCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Owner name is required");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required");
        }
    }
}