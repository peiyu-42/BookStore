using ISpan.BookStore.Infra.Extensions;
using ISpan.BookStore.Infra;
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
using ISpan.BookStore.Infra.DAOs;

namespace ISpan.BookStore
{
    public partial class EditOrderDetailForm : Form
    {
        private int id;
        public EditOrderDetailForm(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void EditOrderDetailForm_Load(object sender, EventArgs e)
        {
            BindData(id);
        }
        private void BindData(int id)
        {
            OrderDetailDTO dto = new OrderDetailDAO().Get(id);

            // 把DTO轉型為ViewModel
            OrderDetailVM model = dto.ToVM();

            // 再將 viewModel值繫結到各控制項
            orderidTextBox.Text = model.OrderId.ToString();
            bookIdTextBox.Text = model.BookId.ToString();
            quantityTextBox.Text = model.Quantity.ToString();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int orderId = orderidTextBox.Text.ToInt(-1);
            int bookId = bookIdTextBox.Text.ToInt(-1);
            int quantity = quantityTextBox.Text.ToInt(-1);

            OrderDetailVM model = new OrderDetailVM
            {
                Id = id,
                OrderId = orderId,
                BookId = bookId,
                Quantity = quantity,
            };

            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"OrderId", orderidTextBox},
                {"BookId", bookIdTextBox},
                {"Quantity", quantityTextBox},
            };

            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;

            OrderDetailDTO dto = model.ToDTO();

            try
            {
                new OrderDetailService().Update(dto);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗, 原因: " + ex.Message);
            }
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

            new OrderDetailService().Delete(id);

            this.DialogResult = DialogResult.OK;

        }
    }
}
