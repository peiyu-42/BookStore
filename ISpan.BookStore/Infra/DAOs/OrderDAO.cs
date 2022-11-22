using ISpan.BookStore.Models.DTOs;
using ISpan.BookStore.Models.ViewModels;
using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Infra.DAOs
{
    public class OrderDAO
    {
        public IEnumerable<OrderIndexDTO> GetAll()
        {
            var sql = @"SELECT O.OrderId,M.Account,O.OrderTime FROM Orders O
  INNER JOIN Members M ON O.MemberId=M.Id";            

            var dbHelper = new SqlDbHelper("default");
            // 存放在field裡, 稍後在 grid CellClick事件會需要再度用到它
            return dbHelper.Select(sql, null)
                .AsEnumerable()
                .Select(row => new OrderIndexDTO
                {
                    OrderId = row.Field<int>("OrderId"),
                    Account = row.Field<string>("Account"),
                    OrderTime = row.Field<DateTime>("OrderTime")
                });

        }

        internal void Create(OrderDTO dto)
        {
            var sql = @"INSERT INTO Orders(MemberId,OrderTime)
  VALUES(@MemberId,@OrderTime)";

            var parameters = new SqlParameterBuilder()
                .AddInt("MemberId", dto.MemberId)
                .AddDateTime("OrderTime",dto.OrderTime)
                .Build();           

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
        }

        internal void Update(OrderDTO dto)
        {
            string sql = @"UPDATE Orders
  SET OrderTime=@OrderTime
  WHERE OrderId=@Id";

            var parameters = new SqlParameterBuilder()
                .AddDateTime("OrderTime",dto.OrderTime)
                .AddInt("Id", dto.OrderId)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
        }
    }
}
