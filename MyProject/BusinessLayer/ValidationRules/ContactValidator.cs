using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütden geçerli bir mail adresi giriniz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Message).MinimumLength(30).WithMessage("Lütfen en az 30 karakter girişi yapınız.");
        }
    }
}
