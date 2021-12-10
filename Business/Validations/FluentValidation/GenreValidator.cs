using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validations.FluentValidation
{
    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Film tür adı zorunlu");
            RuleFor(x => x.Name).NotNull().WithMessage("Film tür adı boş olamaz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Tür adı maksimum 50 karakter olabilir!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Tür adı minimum 2 karakter olabilir!");
        }
    }
}
