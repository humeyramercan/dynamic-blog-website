using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız.");
            RuleFor(x => x.CommentText).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.BlogRating).NotEmpty().WithMessage("Lütfen bir puan veriniz.");
            RuleFor(x => x.CommentText).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız.");
        }

    }
}
