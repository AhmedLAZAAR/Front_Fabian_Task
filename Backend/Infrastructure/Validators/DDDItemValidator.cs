using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators
{
    /// <summary>
    /// Validates properties of a DDDItem object.
    /// </summary>
    public class DDDItemValidator : AbstractValidator<DDDItem>
    {
        public DDDItemValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Gender)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Birthday)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.JobTitle)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.JobRank)
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }
}
