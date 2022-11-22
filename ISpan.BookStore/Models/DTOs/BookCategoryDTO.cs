using ISpan.BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.DTOs
{
    public class BookCategoryDTO
    {
        public int CategoryId { get; set; }
        public string BookCategoryName { get; set; }
        public int DisplayOrder { get; set; }

        
    }
    public static class BookCategoryDTOExts
    {
        public static BookCategoryVM ToVM(this BookCategoryDTO dto)
        {
            return new BookCategoryVM
            {
                CategoryId = dto.CategoryId,
                BookCategoryName = dto.BookCategoryName,
                DisplayOrder = dto.DisplayOrder,                
            };
        }
        public static BookCategoryValidateVM ToValidateVM(this BookCategoryDTO dto)
        {
            return new BookCategoryValidateVM
            {
                CategoryId = dto.CategoryId,
                BookCategoryName = dto.BookCategoryName,
                DisplayOrder = dto.DisplayOrder,
            };
        }
    }
}
