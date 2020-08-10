using FluentValidation;
using Microsoft.Extensions.Localization;
using ProjectManager.ViewModels;

namespace ProjectManager.PL.ViewModels.Validators
{
    public class EmployeeVMValidator: AbstractValidator<EmployeeViewModel>
    {
        public EmployeeVMValidator(IStringLocalizer<EmployeeViewModel> stringLocalizer)
        {
            StringLocalizer = stringLocalizer;

            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.Email)
                .EmailAddress();
        }
        public IStringLocalizer<EmployeeViewModel> StringLocalizer { get; }
    }
}
