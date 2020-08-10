using FluentValidation;
using Microsoft.Extensions.Localization;
using ProjectManager.ViewModels;

namespace ProjectManager.PL.ViewModels.Validators
{
    public class ProjectVMValidator : AbstractValidator<ProjectViewModel>
    {
        public ProjectVMValidator(IStringLocalizer<ProjectViewModel> stringLocalizer)
        {
            StringLocalizer = stringLocalizer;

            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.CustomerCompany)
                .NotEmpty();
            RuleFor(x => x.PerformerCompany)
                .MinimumLength(3);
            RuleFor(x => x.StartDate)
                .NotEmpty();
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThan(x => x.StartDate);
        }

        public IStringLocalizer<ProjectViewModel> StringLocalizer { get; }
    }
}
