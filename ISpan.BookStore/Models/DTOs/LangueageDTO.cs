using ISpan.BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.DTOs
{
    public class LanguageDTO
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public int DisplayOrder { get; set; }
    }
    public static class LanguageDTOExts
    {
        public static LanguageVM ToVM(this LanguageDTO dto)
        {
            return new LanguageVM
            {
                Id = dto.Id,
                Language = dto.Language,
                DisplayOrder = dto.DisplayOrder,
            };
        }
    }
}
