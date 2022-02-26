using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.BlogContent).MinimumLength(300).WithMessage("En az 300 karakter girişi yapınız.");
            RuleFor(x => x.BlogCoverImage).NotEmpty().WithMessage("Bu alan boş geçilemez.");
        }
    }
}
