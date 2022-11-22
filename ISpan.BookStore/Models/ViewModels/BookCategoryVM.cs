using ISpan.BookStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.ViewModels
{
    public class BookCategoryVM
    {
        public int CategoryId { get; set; }
        public string BookCategoryName { get; set; }
        public int DisplayOrder { get; set; }
    }
    public class BookCategoryValidateVM : IValidatableObject
    {
        public int CategoryId { get; set; }
        public string BookCategoryName { get; set; }
        public int DisplayOrder { get; set; }

        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            if (BookCategoryName == String.Empty) yield return new ValidationResult("類別必填", new string[] { "BookCategoryName" });
            if (DisplayOrder < 0) yield return new ValidationResult("順序必填", new string[] { "DisplayOrder" });
        }
        
    }
    public static class BookCategoryVMExts
    {
        public static BookCategoryDTO ToDTO(this BookCategoryValidateVM vm)
        {
            return new BookCategoryDTO
            {
                CategoryId = vm.CategoryId,
                BookCategoryName = vm.BookCategoryName,
                DisplayOrder = vm.DisplayOrder,
            };
        }
    }

}
