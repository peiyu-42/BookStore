using ISpan.BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookCategoryId { get; set; }
        public string Author { get; set; }
        public string TranslatedBy { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public int LanguageId { get; set; }
        public int ListPrice { get; set; }
        public string BookCover { get; set; }
    }
    public class BookIndexDTO
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
    public static class BookDTOExts
    {
        public static BookIndexVM ToIndexVM(this BookIndexDTO dto)
        {
            return new BookIndexVM
            {
                BookId = dto.BookId,
                BookName = dto.BookName,
                BookCategoryName = dto.BookCategoryName,
                Author = dto.Author,
                TranslatedBy = dto.TranslatedBy,
                Publisher = dto.Publisher,
                PublishDate = dto.PublishDate,
                Language = dto.Language,
                ListPrice = dto.ListPrice,                
            };
        }
        public static BookVM ToVM(this BookDTO dto)
        {
            return new BookVM
            {
                BookId = dto.BookId,
                BookName = dto.BookName,
                BookCategoryId = dto.BookCategoryId,
                Author = dto.Author,
                TranslatedBy = dto.TranslatedBy,
                Publisher = dto.Publisher,
                PublishDate = dto.PublishDate,
                LanguageId = dto.LanguageId,
                ListPrice = dto.ListPrice,
                BookCover = dto.BookCover,
            };
        }
    }

}
