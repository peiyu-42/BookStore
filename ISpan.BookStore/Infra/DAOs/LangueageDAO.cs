using ISpan.BookStore.Models.DTOs;
using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Models.ViewModels
{
    public class LangueageDAO
    {
        public IEnumerable<LanguageDTO> GetAll()
        {
            var sql = "SELECT * FROM Languages ORDER BY DisplayOrder";
            var dbHelper = new SqlDbHelper("default");

            return dbHelper.Select(sql, null)
                .AsEnumerable()
                .Select(row => new LanguageDTO
                {
                    Id = row.Field<int>("Id"),
                    Language = row.Field<string>("Language"),
                    DisplayOrder = row.Field<int>("DisplayOrder"),
                });
        }
    }
}
