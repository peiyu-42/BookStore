using ISpan.BookStore.Infra.DAOs;
using ISpan.BookStore.Models.DTOs;
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
    public partial class BookCategoriesForm : Form
    {
        private BookCategoryVM[] bookCategories = null;

        public BookCategoriesForm()
        {
            InitializeComponent();
            

            DisplayBookCategories();
        }
        private void DisplayBookCategories()
        {
            bookCategories = new BookCategoryDAO().GetCategory()
                  .Select(dto => dto.ToVM())
                  .ToArray();
            BindData(bookCategories);
        }

        private void BindData(BookCategoryVM[] bookCategories)
        {
            dataGridView1.DataSource = bookCategories;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var frm = new CreateBookCategoriesForm();
            DialogResult result = frm.ShowDialog();

            if(result == DialogResult.OK)
            {
                DisplayBookCategories();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;

            if (rowIndx < 0) return;

            BookCategoryVM row = bookCategories[rowIndx]; // 使用者點到的那一筆記錄

            int id = row.CategoryId; // 使用者點到的那一筆記錄的id值

            // 把 id 傳給編輯表單的建構函數
            var frm = new EditBookCategoriesForm(id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DisplayBookCategories();
            }
        }
    }
}
