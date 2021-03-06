﻿using FluentValidation;
using Microsoft.Extensions.Localization;

namespace ProjectManager.PL.ViewModels.Validators
{
    public class EmployeeVMValidator: AbstractValidator<EmployeeViewModel>
    {
        public EmployeeVMValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.Email)
                .EmailAddress();
        }
    }
}
