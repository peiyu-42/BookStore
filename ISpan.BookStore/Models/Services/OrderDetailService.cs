using ISpan.BookStore.Infra.DAOs;
using ISpan.BookStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.Services
{
    public class OrderDetailService
    {
        internal void Create(OrderDetailDTO dto)
        {
            new OrderDetailDAO().Create(dto);
        }

        internal void Delete(int id)
        {
            new OrderDetailDAO().Delete(id);
        }

        internal void DeleteOrder(int id)
        {
            new OrderDetailDAO().DeleteOrder(id);
        }

        internal void Update(OrderDetailDTO dto)
        {
            new OrderDetailDAO().Update(dto);
        }
    }
}
