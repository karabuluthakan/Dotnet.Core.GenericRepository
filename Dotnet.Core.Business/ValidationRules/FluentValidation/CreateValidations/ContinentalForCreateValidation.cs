using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Entities.Dto.V1.CreateDtos;
using FluentValidation;

namespace Dotnet.Core.Business.ValidationRules.FluentValidation.CreateValidations
{
    public class ContinentalForCreateValidation : AbstractValidator<ContinentalForCreateDto>
    {
        private IContinentalService _service;

        public ContinentalForCreateValidation(IContinentalService service)
        {
            _service = service;
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(255)
                .Must(UniqueNameField).WithMessage("Continental name field must be unique");
        }

        private bool UniqueNameField(string name)
        {
            var exist = _service.IsExistName(name);
            if (exist)
                return false;
            return true;
        }
    }
}