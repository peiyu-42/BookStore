using ISpan.BookStore.Infra;
using ISpan.BookStore.Models.Services;
using ISpan.BookStore.Models.ViewModels;
using ISpan.Utility;
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
    public partial class CreateMemberForm : Form
    {
        public CreateMemberForm()
        {
            InitializeComponent();

            dateTimePicker1.MinDate = DateTime.Today.AddYears(-150);
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(1);
            dateTimePicker1.Value = DateTime.Today.AddDays(1);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // 取得表單個欄位值
            string account = accountTextBox.Text;
            string password = passwordTextBox.Text;
            string passwordConfirm = pwConfirmTextBox.Text;
            string year = dateTimePicker1.Value.Year.ToString();
            string month = dateTimePicker1.Value.Month.ToString();
            string day = dateTimePicker1.Value.Day.ToString();
            string email = emailTextBox.Text;
            string gender = this.genderControl1.GetText();           

            MemberVM model = new MemberVM
            {
                Account = account,
                Password = password,
                PasswordConfirm = passwordConfirm,
                Birthday = Convert.ToDateTime($"{year}-{month}-{day}"),                
                Email = email,
                Gender = gender,
            };

            // 針對ViewModel進行欄位驗證
            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"Account", accountTextBox},
                {"Password", passwordTextBox},
                {"PasswordConfirm", pwConfirmTextBox},
                {"Birthday", dateTimePicker1},
                {"Email", emailTextBox},
                {"Gender", genderControl1},
            };

            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;

            // 如果通過驗證，就新增紀錄
            try
            {
                new MemberService().Create(model);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show("新增失敗，原因: " + ex.Message);
            }
        }
    }
}
