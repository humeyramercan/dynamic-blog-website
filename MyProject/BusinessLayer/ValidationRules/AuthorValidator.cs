using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.AuthorName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız");
            RuleFor(x => x.AboutShort).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.AboutShort).MinimumLength(20).WithMessage("Lütfen en az 20 karakter girişi yapınız");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.AuthorAbout).MinimumLength(20).WithMessage("Lütfen en az 40 karakter girişi yapınız");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.AuthorTitle).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.AuthorMail).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.AuthorMail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(x => x.AuthorPassword).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Lütfen resim seçiniz.");
        }
    }
}
