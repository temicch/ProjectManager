using FluentValidation;
using Microsoft.Extensions.Localization;

namespace ProjectManager.PL.ViewModels.Validators
{
    public class ProjectTaskVMValidator : AbstractValidator<ProjectTaskViewModel>
    {
        public ProjectTaskVMValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.Comment)
                .MaximumLength(512);
        }
    }
}
