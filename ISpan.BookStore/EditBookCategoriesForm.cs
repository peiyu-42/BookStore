using ISpan.BookStore.Infra;
using ISpan.BookStore.Infra.DAOs;
using ISpan.BookStore.Infra.Extensions;
using ISpan.BookStore.Models.DTOs;
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
    public partial class EditBookCategoriesForm : Form
    {
        private int id;
        public EditBookCategoriesForm(int id)
        {
            InitializeComponent();
            this.Load += EditBookCategoriesForm_Load;
            this.id = id;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // 取得表單的各欄位值
            string categoryName = categoryTextBox.Text;
            int displayOrder = displsyTextBox.Text.ToInt(-1);

            BookCategoryValidateVM model = new BookCategoryValidateVM
            {
                CategoryId = id,
                BookCategoryName = categoryName,
                DisplayOrder = displayOrder,
            };

            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"BookCategoryName", categoryTextBox},
                {"DisplayOrder", displsyTextBox},
            };

            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;

            BookCategoryDTO dto = model.ToDTO();

            try
            {
                new BookCategoryService().Update(dto);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void BindData(int id)
        {
            BookCategoryDTO dto = new BookCategoryDAO().Get(id);
            BookCategoryValidateVM model = dto.ToValidateVM();

            categoryTextBox.Text = model.BookCategoryName;
            displsyTextBox.Text = model.DisplayOrder.ToString();
        }

        private void EditBookCategoriesForm_Load(object sender, EventArgs e)
        {
            BindData(id);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox
                .Show("您真的要刪除嗎?",
                        "刪除記錄",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            new BookCategoryService().Delete(id);

            this.DialogResult = DialogResult.OK;
        }
    }
}
