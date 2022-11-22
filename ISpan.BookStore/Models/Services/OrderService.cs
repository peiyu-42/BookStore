using ISpan.BookStore.Infra.DAOs;
using ISpan.BookStore.Models.DTOs;
using ISpan.BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.Services
{
    public class OrderService
    {
        public void Create(OrderDTO dto)
        {
            new OrderDAO().Create(dto);
        }

        internal void Update(OrderDTO dto)
        {
            new OrderDAO().Update(dto);
        }
    }
}
