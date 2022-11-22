using ISpan.BookStore.Models.ViewModels;
using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;

namespace ISpan.BookStore.Models.Services
{
    public class MemberService
    {
        internal IEnumerable<MemberIndexVM> GetAll()
        {
            string sql = @"SELECT * FROM Members ORDER BY Id";
            var dbHelper = new SqlDbHelper("default");

            return dbHelper.Select(sql, null).AsEnumerable().Select(x => ParseToIndexVM(x));
        }

        internal IEnumerable<MemberIndexVM> GetPartAccount(string account)
        {
            string sql = @"SELECT * FROM Members WHERE Account LIKE '%'+@Account+'%' ";
            var parameters = new SqlParameterBuilder()
                .AddNVarchar("Account", 50, account)
                .Build();

            var dbHelper = new SqlDbHelper("default");

            return dbHelper.Select(sql, parameters).AsEnumerable().Select(x => ParseToIndexVM(x));
        }


        internal void Create(MemberVM model)
        {
            bool isExists = AccountIsExists(model.Account);
            if (isExists) throw new Exception("帳號已存在");

            bool isEmailExist = EmailIsExist(model.Email);
            if(isEmailExist) throw new Exception("電子郵件已存在");

            string sql = @"INSERT INTO Members (Account,Password,Birthday,Email,Gender) 
                  VALUES(@Account,@Password,@Birthday,@Email,@Gender) ";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("Account", 50, model.Account)
                .AddNVarchar("Password", 50, model.Password)
                .AddDateTime("Birthday",model.Birthday)
                .AddNVarchar("Email",50,model.Email)
                .AddNVarchar("Gender",50,model.Gender)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
        }

        private bool EmailIsExist(string email)
        {
            string sql = @"SELECT count(*) as count FROM Members WHERE Email=@Email ";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("Email", 50, email)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            return data.Rows[0].Field<int>("count") > 0;
        }

        private bool AccountIsExists(string account)
        {
            string sql = @"SELECT count(*) as count FROM Members WHERE Account=@Account ";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("Account", 50, account)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            return data.Rows[0].Field<int>("count") > 0;
        }


        private MemberIndexVM ParseToIndexVM(DataRow row)
        {
            return new MemberIndexVM
            {
                Id = row.Field<int>("Id"),
                Account = row.Field<string>("Account"),
                Birthday = row.Field<DateTime>("Birthday"),
                Email = row.Field<string>("Email"),
                Gender = row.Field<string>("Gender"),
            };
        }

        internal void Update(MemberVM model)
        {
            bool isExists = AccountIsExists(model);
            if (isExists) throw new Exception("帳號已存在");

            bool isEmailExist = EmailIsExist(model);
            if (isEmailExist) throw new Exception("電子郵件已存在");

            string sql = @"Update Members 
                           SET Account=@Account,Password=@Password,Birthday=@Birthday,Email=@Email,Gender=@Gender 
                           WHERE Id=@Id";

            var parameters = new SqlParameterBuilder()                
                .AddNVarchar("Account", 50, model.Account)
                .AddNVarchar("Password", 50, model.Password)
                .AddDateTime("Birthday", model.Birthday)
                .AddNVarchar("Email", 50, model.Email)
                .AddNVarchar("Gender", 50, model.Gender)
                .AddInt("Id",model.Id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

        }
        private bool AccountIsExists(MemberVM model)
        {
            string sql = @"SELECT count(*) as count FROM Members WHERE Account=@Account
                                            AND Id!=@Id";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("Account", 50, model.Account)
                .AddInt("Id", model.Id)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            return data.Rows[0].Field<int>("count") > 0;
        }
        private bool EmailIsExist(MemberVM model)
        {
            string sql = @"SELECT count(*) as count FROM Members WHERE Email=@Email 
                                            AND Id!=@Id";

            var parameters = new SqlParameterBuilder()
                .AddNVarchar("Email", 50, model.Email)
                .AddInt("Id", model.Id)
                .Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            return data.Rows[0].Field<int>("count") > 0;
        }

        internal void Delete(int id)
        {
            string sql = @"DELETE  FROM　Members WHERE id = @Id";

            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
        }

        internal MemberVM Get(int id)
        {
            string sql = "SELECT * FROM Members WHERE Id=@Id";
            var parameters = new SqlParameterBuilder()
                              .AddInt("Id", id)
                              .Build();
            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                throw new Exception("抱歉，找不到要編輯的紀錄");
            }
            // 將找到的一筆紀錄由DataTable 轉換到MemberVM
            return ToMemberVM(data.Rows[0]);
        }
        private MemberVM ToMemberVM(DataRow row)
        {
            return new MemberVM
            {
                Id = row.Field<int>("Id"),
                Account = row.Field<string>("Account"),
                Password = row.Field<string>("Password"),
                PasswordConfirm = row.Field<string>("Password"),
                Birthday = row.Field<DateTime>("Birthday"),
                Email = row.Field<string>("Email"),
                Gender = row.Field<string>("Gender"),
            };
        }

    }
}
