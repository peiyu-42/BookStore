using ISpan.BookStore.Infra;
using ISpan.BookStore.Models.Services;
using ISpan.BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISpan.BookStore
{
    public partial class EditMemberForm : Form
    {
        private int id;
        public EditMemberForm(int id)
        {
            InitializeComponent();
            this.Load += EditMemberForm_Load;

            this.id = id;

            dateTimePicker1.MinDate = DateTime.Today.AddYears(-150);
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(1);
        }
        private void EditMemberForm_Load(object sender, EventArgs e)
        {
            BindData(id);
        }


        private void BindData(int id)
        {
            MemberVM model = new MemberService().Get(id);

            // 再將ViewModel值繫結到各控制項裡
            accountTextBox.Text = model.Account;
            passwordTextBox.Text = model.Password;
            passwordConfirmTextBox.Text = model.PasswordConfirm;
            dateTimePicker1.Value = model.Birthday;
            emailTextBox.Text = model.Email;
            string valueInDb = model.Gender;
            this.genderControl1.SetValue(valueInDb);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string account = accountTextBox.Text;
            string passward = passwordTextBox.Text;
            string passwardConfirm = passwordConfirmTextBox.Text;
            string year = dateTimePicker1.Value.Year.ToString();
            string month = dateTimePicker1.Value.Month.ToString();
            string day = dateTimePicker1.Value.Day.ToString();
            string email = emailTextBox.Text;
            string gender = this.genderControl1.GetText();
            
            MemberVM model = new MemberVM
            {
                Id = id,
                Account = account,
                Password = passward,
                PasswordConfirm = passwardConfirm,
                Birthday = Convert.ToDateTime($"{year}-{month}-{day}"),
                Email = email,
                Gender = gender,
            };
            // 針對ViewModel進行欄位驗證
            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"Account", accountTextBox},
                {"Password", passwordTextBox},
                {"PasswordConfirm", passwordConfirmTextBox},
                {"Email", emailTextBox},
                {"Gender", genderControl1},
            };

            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;

            // 如果通過驗證，就新增紀錄
            try
            {
                new MemberService().Update(model);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗，原因: " + ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "你真的要刪除嗎?", "刪除紀錄",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            { return; }


            // 如果通過驗證，就修改紀錄
            new MemberService().Delete(id);

            this.DialogResult = DialogResult.OK;
        }

    }
}
