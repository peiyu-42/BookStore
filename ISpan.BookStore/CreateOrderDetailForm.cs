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
    public partial class CreateOrderDetailForm : Form
    {
        private int id;

        public CreateOrderDetailForm(int id)
        {
            InitializeComponent();
            this.id = id;

            orderidTextBox.Text = id.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int orderId = orderidTextBox.Text.ToInt(-1);
            int bookId = bookIdTextBox.Text.ToInt(-1);
            //int listprice = priceTextBox.Text.ToInt(-1);
            int quantity = quantityTextBox.Text.ToInt(-1);

            OrderDetailVM model = new OrderDetailVM
            {
                OrderId = orderId,
                BookId = bookId,
                //UnitPrice = listprice,
                Quantity = quantity,
            };

            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"OrderId", orderidTextBox},
                {"BookId", bookIdTextBox},
                //{"UnitPrice", priceTextBox},
                {"Quantity", quantityTextBox},                
            };

            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;

            OrderDetailDTO dto = model.ToDTO();

            try
            {
                new OrderDetailService().Create(dto);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗, 原因: " + ex.Message);
            }
        }
    }
}
