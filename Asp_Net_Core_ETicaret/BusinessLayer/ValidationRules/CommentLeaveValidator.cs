using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentLeaveValidator:AbstractValidator<CommentTable>
    {
        CommentLeaveValidator() 
        {
            RuleFor(x => x.CommentMessage).NotEmpty().WithMessage("Mesaj alanı boş geçilemez!!!");
            RuleFor(x => x.CommentMessage).MaximumLength(200).WithMessage("Mesaj alanı 200 karakterden fazla girmeyiniz!!!");
            RuleFor(x => x.CommentMessage).MinimumLength(3).WithMessage("Mesaj alanı 3 karakterden az girmeyiniz!!!");
        }
    }
}
