using ISpan.BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.DTOs
{
    public class OrderIndexDTO
    {
        public int OrderId { get; set; }
        public string Account { get; set; }
        public DateTime OrderTime { get; set; }
    }
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderTime { get; set; }
    }
    public static class OrderDTOExts
    {
        public static OrderIndexVM ToIndexVM(this OrderIndexDTO dto)
        {
            return new OrderIndexVM
            {
                OrderId = dto.OrderId,
                Account = dto.Account,
                OrderTime = dto.OrderTime,
            };
        }
    }
}
