using ISpan.BookStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.ViewModels
{
    public class BookIndexVM
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookCategoryName { get; set; }
        public string Author { get; set; }
        public string TranslatedBy { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public int ListPrice { get; set; }
    }
    public class BookVM:IValidatableObject
    {
        public int BookId { get; set; }

        //[Required(ErrorMessage = "書名必填")]
        public string BookName { get; set; }

        //[Required(ErrorMessage = "必填")]
        public int BookCategoryId { get; set; }

        //[Required(ErrorMessage = "作者必填")]
        public string Author { get; set; }

        public string TranslatedBy { get; set; }

        //[Required(ErrorMessage = "出版社必填")]
        public string Publisher { get; set; }

        //[Required(ErrorMessage = "出版日期必填")]
        public DateTime PublishDate { get; set; }

        //[Required(ErrorMessage = "必填")]
        public int LanguageId { get; set; }

        //[Required(ErrorMessage = "單價必填")]
        public int ListPrice { get; set; }
        public string BookCover { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BookName == String.Empty) yield return new ValidationResult("書名必填", new string[] { "BookName" });
            if (Author == String.Empty) yield return new ValidationResult("作者必填", new string[] { "Author" });
            if (Publisher == String.Empty) yield return new ValidationResult("出版社必填", new string[] { "Publisher" });
            if (Publisher == String.Empty) yield return new ValidationResult("出版社必填", new string[] { "Publisher" });
            if (PublishDate > DateTime.Today) yield return new ValidationResult("出版日期必填，\r\n請填寫正確的日期格式(年-月-日)", new string[] { "PublishDate" });            
            if (ListPrice < 0 ) yield return new ValidationResult("價格必填", new string[] { "ListPrice" });
        }
    }

    public static class BookVMExts
    {
        public static BookDTO ToDTO(this BookVM vm)
        {
            return new BookDTO
            {
                BookId = vm.BookId,
                BookName = vm.BookName,
                BookCategoryId = vm.BookCategoryId,
                Author = vm.Author,
                TranslatedBy = vm.TranslatedBy,
                Publisher = vm.Publisher,
                PublishDate = vm.PublishDate,
                LanguageId = vm.LanguageId,
                ListPrice = vm.ListPrice,
                BookCover = vm.BookCover,
            };
        }
    }
}
