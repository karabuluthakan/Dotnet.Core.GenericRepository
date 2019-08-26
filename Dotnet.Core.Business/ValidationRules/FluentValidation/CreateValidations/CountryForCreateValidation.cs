using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Entities.Dto.V1.CreateDtos;
using FluentValidation;

namespace Dotnet.Core.Business.ValidationRules.FluentValidation.CreateValidations
{
    public class CountryForCreateValidation : AbstractValidator<CountryForCreateDto>
    {
        private ICountryService _service;

        public CountryForCreateValidation(ICountryService service)
        {
            _service = service;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(255)
                .Must(UniqueNameField).WithMessage("Country name field must be unique");

            RuleFor(x => x.Alpha2Code).Length(2).NotNull();
            RuleFor(x => x.Alpha3Code).Length(3).NotNull();
            RuleFor(x => x.UNCode).NotNull();
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