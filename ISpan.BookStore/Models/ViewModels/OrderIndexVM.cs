using ISpan.BookStore.Infra.DAOs;
using ISpan.BookStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.ViewModels
{
    public class OrderIndexVM
    {
        public int OrderId { get; set; }
        public string Account { get; set; }
        public DateTime OrderTime { get; set; }

    }
    public class OrderVM : IValidatableObject
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MemberId < 0) yield return new ValidationResult("會員Id必填", new string[] { "MemberId" });
        }

    }
    public static class OrderVMExts
    {
        public static OrderDTO ToDTO(this OrderVM vm)
        {
            return new OrderDTO
            {
                OrderId = vm.OrderId,
                MemberId = vm.MemberId,
                OrderTime = vm.OrderTime,                
            };
        }
    }
}
