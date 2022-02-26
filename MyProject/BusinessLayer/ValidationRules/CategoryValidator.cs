using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Bu alan boş geçilemez. ");
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Bu alan boş geçilemez. ");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız.");
            RuleFor(x => x.CategoryDescription).MinimumLength(150).WithMessage("En az 150 karakter girişi yapınız. ");
        }
    }
}
