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
    public partial class CreateOrderForm : Form
    {
        public CreateOrderForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int memberId = memberIdTextBox.Text.ToInt(-1);
            DateTime orderTime = orderTimeTextBox.Text.ToDateTime(DateTime.Now);

           

            OrderVM model = new OrderVM
            {
                MemberId = memberId,
                OrderTime = orderTime,
            };

            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"MemberId", memberIdTextBox},
                {"OrderTime", orderTimeTextBox},                
            };

            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;

            OrderDTO dto = model.ToDTO();

            try
            {
                new OrderService().Create(dto);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗, 原因: " + ex.Message);
            }
        }
    }
}
