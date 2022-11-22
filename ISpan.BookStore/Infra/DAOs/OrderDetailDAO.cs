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
    public class OrderDetailDAO
    {
        public IEnumerable<OrderDetailIndexDTO> GetAll(int orderId)
        {
            string sql = @"SELECT OD.Id,OD.OrderId, B.BookName, B.ListPrice, OD.Quantity 
	FROM OrderDetails OD
	INNER JOIN Books B ON OD.BookId=B.BookId
    WHERE OrderId=@OrderId
	ORDER BY OD.Id";

            var parameters = new SqlParameterBuilder()
                .AddInt("OrderId", orderId)
                .Build();

            var dbHelper = new SqlDbHelper("default");

            return dbHelper.Select(sql, parameters)
                          .AsEnumerable()
                          .Select(row => new OrderDetailIndexDTO
                          {
                              Id = row.Field<int>("Id"),
                              OrderId = row.Field<int>("OrderId"),
                              BookName = row.Field<string>("BookName"),
                              ListPrice = row.Field<int>("ListPrice"),
                              Quantity = row.Field<int>("Quantity"),
                          });
        }

        public void Create(OrderDetailDTO dto)
        {
            string sql = @"INSERT INTO OrderDetails(OrderId,BookId,Quantity)
  VALUES(@OrderId,@BookId,@Quantity)";

            var parameters = new SqlParameterBuilder()
                .AddInt("OrderId",dto.OrderId)
                .AddInt("BookId",dto.BookId)                
                .AddInt("Quantity",dto.Quantity)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }

        public void Update(OrderDetailDTO dto)
        {
            string sql = @"UPDATE OrderDetails
  SET OrderId=@OrderId,BookId=@BookId,Quantity=@Quantity
  WHERE Id=@Id";

            var parameters = new SqlParameterBuilder()
                .AddInt("OrderId", dto.OrderId)
                .AddInt("BookId", dto.BookId)                
                .AddInt("Quantity", dto.Quantity)
                .AddInt("Id",dto.Id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }
        public void Delete(int id)
        {
            string sql = @" DELETE FROM OrderDetails WHERE Id=@Id ";

            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }

        public OrderDetailDTO Get(int id)
        {
            string sql = "SELECT * FROM OrderDetails WHERE Id=@Id";
            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                throw new Exception("找不到要編輯的記錄");
            }

            // 將找到的一筆記錄由DataTable 轉換到 VM
            return ToOrderDetailDTO(data.Rows[0]);
        }

        private OrderDetailDTO ToOrderDetailDTO(DataRow row)
        {
            return new OrderDetailDTO
            {
                Id = row.Field<int>("Id"),
                OrderId = row.Field<int>("OrderId"),
                BookId = row.Field<int>("BookId"),
                //UnitPrice = row.Field<int>("UnitPrice"),
                Quantity = row.Field<int>("Quantity"),
            };
        }

        internal void DeleteOrder(int id)
        {
            string sql = @" DELETE FROM Orders WHERE OrderId=@Id ";

            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
        }
    }
}
