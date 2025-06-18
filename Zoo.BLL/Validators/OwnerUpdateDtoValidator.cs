using FluentValidation;
using Zoo.BLL.DTOs.Owners;

namespace Zoo.BLL.Validators
{
    public class OwnerUpdateDtoValidator : AbstractValidator<OwnerUpdateDto>
    {
        public OwnerUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Owner ID must be greater than 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Owner name is required");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required");
        }
    }
}