using ISpan.BookStore.Infra.DAOs;
using ISpan.BookStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.Services
{
    public class BookService
    {
        internal void Create(BookDTO dto)
        {
            new BookDAO().Create(dto);
        }

        internal void Delete(int id)
        {
            new BookDAO().Delete(id);
        }

        internal void Update(BookDTO dto)
        {
            new BookDAO().Update(dto);
        }
    }
}
