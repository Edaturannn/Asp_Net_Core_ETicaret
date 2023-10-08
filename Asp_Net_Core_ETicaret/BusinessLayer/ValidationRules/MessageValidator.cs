using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<MessageTable>
    {
        public MessageValidator() 
        {
            RuleFor(x => x.UserAdminName).NotEmpty().WithMessage("Name Surname alanı boş geçilemez!!!");
            RuleFor(x => x.UserAdminName).MaximumLength(50).WithMessage("Name Surname alanı 50 karakterden fazla girmeyiniz!!!");
            RuleFor(x => x.UserAdminName).MinimumLength(5).WithMessage("Name Surname alanı 5 karakterden az girmeyiniz!!!");


            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez!!!");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Email alanı 50 karakterden fazla girmeyiniz!!!");
            RuleFor(x => x.Email).MinimumLength(5).WithMessage("Email alanı 5 karakterden az girmeyiniz!!!");



            RuleFor(x => x.MessageTitle).NotEmpty().WithMessage("Message Title alanı boş geçilemez!!!");
            RuleFor(x => x.MessageTitle).MaximumLength(50).WithMessage("Message Title alanı 50 karakterden fazla girmeyiniz!!!");
            RuleFor(x => x.MessageTitle).MinimumLength(5).WithMessage("Message Title 5 karakterden az girmeyiniz!!!");


            RuleFor(x => x.MessageText).NotEmpty().WithMessage("Mesaj alanı boş geçilemez!!!");
            RuleFor(x => x.MessageText).MaximumLength(200).WithMessage("Mesaj alanı 200 karakterden fazla girmeyiniz!!!");
            RuleFor(x => x.MessageText).MinimumLength(3).WithMessage("Mesaj alanı 3 karakterden az girmeyiniz!!!");
        }
    }
}
