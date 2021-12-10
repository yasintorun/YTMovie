using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validations.FluentValidation
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Film adı zorunlu");

            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Film açıklaması zorunlu");

            RuleFor(x => x.IMDB).NotNull().NotEmpty().WithMessage("Imdb puanı zorunlu");

            RuleFor(x => x.Year).NotNull().NotEmpty().WithMessage("Film çıkış tarihi zorunlu");

            RuleFor(x => x.VideoLink).NotNull().NotEmpty().WithMessage("Film Video linki zorunlu");

            RuleFor(x => x.PosterLink).NotNull().NotEmpty().WithMessage("Film Poster linki zorunlu");

            RuleFor(x => x.WallpaperLink).NotNull().NotEmpty().WithMessage("Film wallpaper linki zorunlu");

            RuleFor(x => x.Time).NotNull().NotEmpty().WithMessage("Film süresi zorunlu");

        }
    }
}
