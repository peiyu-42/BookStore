using ISpan.BookStore.Infra.DAOs;
using ISpan.BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.Services
{
    public class ManagerService
    {
        public bool Authenticate(LoginVM model)
        {
            var user = new ManagerDAO().Get(model.Account);
            if (user == null) return false; // 找不到符合的帳號

            return (user.Password == model.Password);
        }
    }
}
