using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Entities.Dto.V1.CreateDtos;
using FluentValidation;

namespace Dotnet.Core.Business.ValidationRules.FluentValidation.CreateValidations
{
    public class CityForCreateValidation : AbstractValidator<CityForCreateDto>
    {
        private ICityService _service;

        public CityForCreateValidation(ICityService service)
        {
            _service = service;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(255)
                .Must(UniqueNameField).WithMessage("City name field must be unique");

            RuleFor(x => x.CountryId).NotNull();
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