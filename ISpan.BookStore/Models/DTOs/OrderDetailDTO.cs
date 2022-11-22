using ISpan.BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.DTOs
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
    public class OrderDetailIndexDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string BookName { get; set; }
        public int ListPrice { get; set; }
        public int Quantity { get; set; }
    }
    public static class OrderDetailDTOExts
    {
        public static OrderDetailIndexVM ToIndexVM(this OrderDetailIndexDTO dto)
        {
            return new OrderDetailIndexVM
            {
                Id = dto.Id,
                OrderId = dto.OrderId,
                BookName = dto.BookName,
                ListPrice = dto.ListPrice,
                Quantity = dto.Quantity,
            };
        }
        public static OrderDetailVM ToVM(this OrderDetailDTO dto)
        {
            return new OrderDetailVM
            {
                Id = dto.Id,
                OrderId=dto.OrderId,
                BookId=dto.BookId,
                UnitPrice=dto.UnitPrice,
                Quantity=dto.Quantity,
            };
        }
    }
}
