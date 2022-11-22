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
    public class BookCategoryDAO
    {
        public IEnumerable<BookCategoryDTO> GetCategory()
        {
            var sql = "SELECT * FROM BookCategories ORDER BY DisplayOrder";
            var dbHelper = new SqlDbHelper("default");

            return dbHelper.Select(sql, null)
                .AsEnumerable()
                .Select(row => new BookCategoryDTO
                {
                    CategoryId = row.Field<int>("CategoryId"),
                    BookCategoryName = row.Field<string>("BookCategoryName"),
                    DisplayOrder = row.Field<int>("DisplayOrder"),
                });
        }

        internal void Create(BookCategoryDTO dto)
        {
            var sql = @"INSERT INTO BookCategories(BookCategoryName,DisplayOrder)
  VALUES(@BookCategoryName,@DisplayOrder)";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("BookCategoryName",50,dto.BookCategoryName)
                .AddInt("DisplayOrder",dto.DisplayOrder)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
        }

        internal BookCategoryDTO Get(int id)
        {
            string sql = @"SELECT * FROM BookCategories WHERE CategoryId=@Id";

            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                throw new Exception("找不到要編輯的紀錄");
            }

            return ToBookCategoryDTO(data.Rows[0]);
        }

        internal void Update(BookCategoryDTO dto)
        {
            string sql = @"UPDATE BookCategories
  SET BookCategoryName=@BookCategoryName,DisplayOrder=@DisplayOrder
  WHERE CategoryId=@Id";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("BookCategoryName", 50, dto.BookCategoryName)
                .AddInt("DisplayOrder", dto.DisplayOrder)
                .AddInt("Id", dto.CategoryId)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
        }
        public void Delete(int id)
        {
            string sql = @"DELETE FROM BookCategories WHERE CategoryId=@Id";

            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }

        private BookCategoryDTO ToBookCategoryDTO(DataRow dataRow)
        {
            return new BookCategoryDTO
            {
                CategoryId = dataRow.Field<int>("CategoryId"),
                BookCategoryName = dataRow.Field<string>("BookCategoryName"),
                DisplayOrder = dataRow.Field<int>("DisplayOrder"),
            };
        }
    }
}
