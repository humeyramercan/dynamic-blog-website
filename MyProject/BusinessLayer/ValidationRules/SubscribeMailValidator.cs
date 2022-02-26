using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SubscribeMailValidator : AbstractValidator<SubscribeMail>
    {
        public SubscribeMailValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz.");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
        }
    }
}
