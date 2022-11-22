using ISpan.BookStore.Infra.DAOs;
using ISpan.BookStore.Models.DTOs;
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
    public partial class OrdersForm : Form
    {
        private OrderIndexVM[] orders = null;
        public OrdersForm()
        {
            InitializeComponent();
            DisplayOrders();
        }

        private void DisplayOrders()
        {
            orders = new OrderDAO().GetAll()
                        .Select(dto => dto.ToIndexVM())
                        .ToArray();

            BindData(orders);           
        }

        private void BindData(OrderIndexVM[] data)
        {
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void addButton_Click(object sender, EventArgs e)
        {

            var frm = new CreateOrderForm();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayOrders();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;

            if (rowIndx < 0) return;

            OrderIndexVM row = this.orders[rowIndx]; // 使用者點到的那一筆記錄

            int id = row.OrderId; // 使用者點到的那一筆記錄的id值

            // 把 id 傳給編輯表單的建構函數
            var frm = new OrderDetailsForm(id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DisplayOrders();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = Color.BurlyWood;            
        }
    }
}
