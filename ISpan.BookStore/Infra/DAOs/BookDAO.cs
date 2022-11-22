using ISpan.BookStore.Models.DTOs;
using ISpan.BookStore.Models.ViewModels;
using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Infra.DAOs
{
    public class BookDAO
    {
        public IEnumerable<BookIndexDTO> GetAll()
        {
            string sql = @"SELECT  BookId,BookName,BC.BookCategoryName,Author,TranslatedBy,Publisher,PublicationDate,L.Language,ListPrice
  FROM Books B
  INNER JOIN BookCategories BC ON B.BookCategoryId=BC.CategoryId
  INNER JOIN Languages L ON B.LanguageId=L.Id
  ORDER BY BookId";

            var dbHelper = new SqlDbHelper("default");

            return dbHelper.Select(sql, null)
                          .AsEnumerable()
                          .Select(row => new BookIndexDTO
                          {
                              BookId = row.Field<int>("BookId"),
                              BookName = row.Field<string>("BookName"),
                              BookCategoryName = row.Field<string>("BookCategoryName"),
                              Author = row.Field<string>("Author"),
                              TranslatedBy = row.Field<string>("TranslatedBy"),
                              Publisher = row.Field<string>("Publisher"),
                              PublishDate = row.Field<DateTime>("PublicationDate"),
                              Language = row.Field<string>("Language"),
                              ListPrice = row.Field<int>("LIstPrice"),
                          });
        }

        public void Create(BookDTO dto)
        {
            string sql = @"  INSERT INTO Books(BookName,BookCategoryId,Author,TranslatedBy,Publisher,PublicationDate,LanguageId,ListPrice,BookCover)
  VALUES (@BookName,@BookCategoryId,@Author,@TranslatedBy,@Publisher,@PublicationDate,@LanguageId,@ListPrice,@BookCover) ";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("BookName", 50, dto.BookName)
                .AddInt("BookCategoryId", dto.BookCategoryId)
                .AddNVarchar("Author", 50, dto.Author)
                .AddNVarchar("TranslatedBy", 50, dto.TranslatedBy)
                .AddNVarchar("Publisher", 50, dto.Publisher)
                .AddDateTime("PublicationDate", dto.PublishDate)
                .AddInt("LanguageId", dto.LanguageId)
                .AddInt("ListPrice", dto.ListPrice)
                .AddNVarchar("BookCover", 50, dto.BookCover)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }

        public BookDTO Get(int id)
        {
            string sql = "SELECT * FROM Books WHERE BookId=@Id";
            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                throw new Exception("找不到要編輯的記錄");

            }

            // 將找到的一筆記錄由DataTable 轉換到 ProductVM
            return ToBookDTO(data.Rows[0]);
        }

        private BookDTO ToBookDTO(DataRow row)
        {
            return new BookDTO
            {
                BookId = row.Field<int>("BookId"),
                BookName = row.Field<string>("BookName"),
                BookCategoryId = row.Field<int>("BookCategoryId"),
                Author = row.Field<string>("Author"),
                TranslatedBy = row.Field<string>("TranslatedBy"),
                Publisher = row.Field<string>("Publisher"),
                PublishDate = row.Field<DateTime>("PublicationDate"),
                LanguageId = row.Field<int>("LanguageId"),
                ListPrice = row.Field<int>("LIstPrice"),
                BookCover = row.Field<string>("BookCover"),
            };
        }


        public IEnumerable<BookIndexDTO> GetAll(int categoryId)
        {
            string sql = @"SELECT  BookId,BookName,BC.BookCategoryName,Author,TranslatedBy,Publisher,PublicationDate,L.Language,ListPrice
  FROM Books B
  INNER JOIN BookCategories BC ON B.BookCategoryId=BC.CategoryId
  INNER JOIN Languages L ON B.LanguageId=L.Id 
  WHERE BC.CategoryId=@CategoryId
  ORDER BY BookId";

            SqlParameter[] parameters = new SqlParameterBuilder()
                .AddInt("CategoryId", categoryId).Build();

            var dbHelper = new SqlDbHelper("default");

            return dbHelper.Select(sql, parameters)
                          .AsEnumerable()
                          .Select(row => new BookIndexDTO
                          {
                              BookId = row.Field<int>("BookId"),
                              BookName = row.Field<string>("BookName"),
                              BookCategoryName = row.Field<string>("BookCategoryName"),
                              Author = row.Field<string>("Author"),
                              TranslatedBy = row.Field<string>("TranslatedBy"),
                              Publisher = row.Field<string>("Publisher"),
                              PublishDate = row.Field<DateTime>("PublicationDate"),
                              Language = row.Field<string>("Language"),
                              ListPrice = row.Field<int>("LIstPrice"),
                          });
        }

        public void Update(BookDTO dto)
        {
            string sql = @"UPDATE Books
  SET BookName=@BookName,BookCategoryId=@BookCategoryId,Author=@Author,TranslatedBy=@TranslatedBy,
      Publisher=@Publisher,PublicationDate=@PublicationDate,LanguageId=@LanguageId,ListPrice=@ListPrice,BookCover=@BookCover
  WHERE BookId=@Id";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("BookName", 50, dto.BookName)
                .AddInt("BookCategoryId", dto.BookCategoryId)
                .AddNVarchar("Author", 50, dto.Author)
                .AddNVarchar("TranslatedBy", 50, dto.TranslatedBy)
                .AddNVarchar("Publisher", 50, dto.Publisher)
                .AddDateTime("PublicationDate", dto.PublishDate)
                .AddInt("LanguageId", dto.LanguageId)
                .AddInt("ListPrice", dto.ListPrice)
                .AddNVarchar("BookCover", 50,dto.BookCover)
                .AddInt("Id",dto.BookId)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }

        public void Delete(int id)
        {
            string sql = @" DELETE FROM Books WHERE BookId=@Id ";

            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }
    }
}
