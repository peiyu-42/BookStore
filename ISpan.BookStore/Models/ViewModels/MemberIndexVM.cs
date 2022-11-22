using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.ViewModels
{
    public class MemberIndexVM
    {
        public int Id { get; set; }
        public string Account { get; set; }
        // public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
    public class MemberVM : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="帳號必填")]
        public string Account { get; set; }



        [Required(ErrorMessage = "密碼必填")]
        public string Password { get; set; }



        [Required(ErrorMessage = "密碼確認必填")]
        //[Compare("Password",ErrorMessage ="確認密碼要與密碼相同")]     
        public string PasswordConfirm { get; set; }



        [Required(ErrorMessage = "生日必填")]
        public DateTime Birthday { get; set; }



        [Required(ErrorMessage = "電子郵件必填")]
        [EmailAddress(ErrorMessage = "E-mail 格式有誤")]
        public string Email { get; set; }

        [Required(ErrorMessage = "性別必填")]
        public string Gender { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PasswordConfirm == String.Empty) yield return new ValidationResult("密碼確認必填", new string[] { "PasswordConfirm" });
            if (PasswordConfirm != Password) yield return new ValidationResult("確認密碼要與密碼相同", new string[] { "PasswordConfirm" });

            if (Birthday > DateTime.Today)
            {
                yield return new ValidationResult("請選擇出生生日", new[] { "Birthday" });
            }
        }
    }
}
