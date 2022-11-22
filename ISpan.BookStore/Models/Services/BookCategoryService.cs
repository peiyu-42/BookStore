using ISpan.BookStore.Infra.DAOs;
using ISpan.BookStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.Services
{
    public class BookCategoryService
    {
        public void Create(BookCategoryDTO dto)
        {
            new BookCategoryDAO().Create(dto);
        }

        internal void Delete(int id)
        {
            new BookCategoryDAO().Delete(id);
        }

        internal void Update(BookCategoryDTO dto)
        {
            new BookCategoryDAO().Update(dto);
        }
    }
}
