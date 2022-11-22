using ISpan.BookStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.ViewModels
{
    public class OrderDetailIndexVM
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string BookName { get; set; }
        public int ListPrice { get; set; }
        public int Quantity { get; set; }
    }
    public class OrderDetailVM : IValidatableObject
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OrderId < 0) yield return new ValidationResult("訂單Id必填", new string[] { "OrderId" });
            if (BookId < 0) yield return new ValidationResult("書籍Id必填", new string[] { "BookId" });
            //if (UnitPrice < 0) yield return new ValidationResult("單價必填", new string[] { "UnitPrice" });
            if (Quantity < 0) yield return new ValidationResult("數量必填，且請填寫大於零的整數", new string[] { "Quantity" });
        }
    }
    public static class OrderDetailVMExts
    {
        public static OrderDetailDTO ToDTO(this OrderDetailVM vm)
        {
            return new OrderDetailDTO
            {
                Id = vm.Id,
                OrderId = vm.OrderId,
                BookId = vm.BookId,
                UnitPrice = vm.UnitPrice,
                Quantity = vm.Quantity,
            };
        }
    }
}
