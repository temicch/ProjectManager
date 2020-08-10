using FluentValidation;
using Microsoft.Extensions.Localization;
using ProjectManager.ViewModels;

namespace ProjectManager.PL.ViewModels.Validators
{
    public class ProjectTaskVMValidator : AbstractValidator<ProjectTaskViewModel>
    {
        public ProjectTaskVMValidator(IStringLocalizer<ProjectTaskViewModel> stringLocalizer)
        {
            StringLocalizer = stringLocalizer;

            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.Comment)
                .MaximumLength(512);
        }

        public IStringLocalizer<ProjectTaskViewModel> StringLocalizer { get; }
    }
}
