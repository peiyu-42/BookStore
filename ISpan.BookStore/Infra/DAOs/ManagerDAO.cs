using ISpan.BookStore.Models.DTOs;
using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Infra.DAOs
{
    public class ManagerDAO
    {
        public ManagerDTO Get(string account)
        {
            string sql = "SELECT * FROM Managers WHERE Account=@Account";
            var parameters = new SqlParameterBuilder()
                .AddNVarchar("Account", 50, account)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                return null;
            }

            // 將找到的一筆記錄由DataTable 轉換到 UserVM
            return ToManagerDTO(data.Rows[0]);
        }

        private ManagerDTO ToManagerDTO(DataRow row)
        {
            return new ManagerDTO
            {
                Id = row.Field<int>("Id"), 
                ManagerName = row.Field<string>("ManagerName"),
                Account = row.Field<string>("Account"),
                Password = row.Field<string>("Password"),               
            };
        }
    }
}
