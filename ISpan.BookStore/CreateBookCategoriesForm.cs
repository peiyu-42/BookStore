using ISpan.BookStore.Infra;
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
    public partial class CreateBookCategoriesForm : Form
    {
        public CreateBookCategoriesForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string category = categoryTextBox.Text;
            int displayorder = displsyTextBox.Text.ToInt(-1);

            BookCategoryValidateVM model = new BookCategoryValidateVM
            {
                BookCategoryName = category,
                DisplayOrder = displayorder,
            };

            // 針對ViewModel進行欄位驗證
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
                new BookCategoryService().Create(dto);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗, 原因: " + ex.Message);
            }
        }
    }
}
