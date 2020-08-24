using FluentValidation;

namespace ProjectManager.PL.ViewModels.Validators
{
    public class ProjectVMValidator : AbstractValidator<ProjectViewModel>
    {
        public ProjectVMValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.CustomerCompany)
                .NotEmpty()
                .MinimumLength(3);
            RuleFor(x => x.PerformerCompany)
                .NotEmpty()
                .MinimumLength(3);
            RuleFor(x => x.StartDate)
                .NotEmpty();
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThan(x => x.StartDate);
        }
    }
}
