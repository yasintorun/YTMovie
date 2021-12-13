using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validations.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Adınız zorunlu");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adınız boş olamaz");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Adınız en fazla 30 karakter olabilir!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Adınız en az 2 karakter olabilir!");

            RuleFor(x => x.CommentContent).NotNull().WithMessage("Yorum kısmı zorunlu");
            RuleFor(x => x.CommentContent).NotEmpty().WithMessage("Yorum kısmı boş olamaz");
            RuleFor(x => x.CommentContent).MaximumLength(30).WithMessage("Yorumunuz en fazla 250 karakter olabilir!");
            RuleFor(x => x.CommentContent).MinimumLength(10).WithMessage("Yorumunuz en az 10 karakter olabilir!");
        }
    }
}
