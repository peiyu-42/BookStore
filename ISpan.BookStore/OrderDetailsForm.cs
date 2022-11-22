using ISpan.BookStore.Infra;
using ISpan.BookStore.Infra.DAOs;
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
    public partial class OrderDetailsForm : Form
    {
        private OrderDetailIndexVM[] orderDetails = null;
        private int orderId;
        public OrderDetailsForm(int id)
        {
            InitializeComponent();

            this.orderId = id;

            DisplayOrderDetails();
        }
        private void DisplayOrderDetails()
        {
            orderDetails = new OrderDetailDAO().GetAll(orderId)
                .Select(dto => dto.ToIndexVM())
                .ToArray();
            BindData(orderDetails);                        
        }

        private void BindData(OrderDetailIndexVM[] orderDetails)
        {
            dataGridView1.DataSource = orderDetails;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var frm = new CreateOrderDetailForm(orderId);
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayOrderDetails();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;

            if (rowIndx < 0) return;

            OrderDetailIndexVM row = orderDetails[rowIndx];

            int id = row.Id;

            var frm = new EditOrderDetailForm(id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DisplayOrderDetails();
            }
        }

        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            if (MessageBox
                .Show("您真的要刪除全部嗎?\r\n訂單的紀錄也會一併刪除",
                        "刪除記錄",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            new OrderDetailService().Delete(orderId);
            new OrderDetailService().DeleteOrder(orderId);

            this.DialogResult = DialogResult.OK;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            DateTime updateTime = DateTime.Now;

            OrderVM model = new OrderVM
            {
                OrderId = orderId,
                OrderTime = updateTime,
            };

            //Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            //{
            //    {"OrderTime", orderidTextBox},
            //    {"BookId", bookIdTextBox},
            //    //{"UnitPrice", priceTextBox},
            //    {"Quantity", quantityTextBox},
            //};

            //bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            //if (!isValid) return;

            OrderDTO dto = model.ToDTO();

            try
            {
                new OrderService().Update(dto);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗, 原因: " + ex.Message);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("listPriceDataGridViewTextBoxColumn"))
            {
                e.CellStyle.Format = "###,###,###";
                //e.CellStyle.SelectionBackColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("quantityDataGridViewTextBoxColumn"))
            {

                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }
    }
}
