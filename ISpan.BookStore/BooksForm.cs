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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISpan.BookStore
{
    public partial class BooksForm : Form
    {
        private BookIndexVM[] books = null;
        public BooksForm()
        {
            InitializeComponent();
            InitForm();
            DisplayBooks();
        }
        private void InitForm()
        {
            categoryIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<BookCategoryVM> categories = new BookCategoryDAO().GetCategory()
                .Select(dto => dto.ToVM())
                .Prepend(new BookCategoryVM { CategoryId = 0, BookCategoryName = String.Empty })
                .ToList();

            categoryIdComboBox.DataSource = categories;
        }
        private void DisplayBooks()
        {
            //取得篩選值
            int categoryId = ((BookCategoryVM)categoryIdComboBox.SelectedItem).CategoryId;

            books = new BookDAO().GetAll()
                          .Select(dto => dto.ToIndexVM())
                          .ToArray();

            if (categoryId > 0)
            {
                books = new BookDAO().GetAll(categoryId)
                          .Select(dto => dto.ToIndexVM())
                          .ToArray();
            }
            
            BindData(books);
        }

        private void BindData(BookIndexVM[] books)
        {
            dataGridView1.DataSource = books;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.AutoResizeColumns();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var frm = new CreateBookForm();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayBooks();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;
            
            if (rowIndx < 0) return;

            BookIndexVM row = books[rowIndx];

            int id = row.BookId;

            var frm = new EditBookForm(id);

            if(frm.ShowDialog() == DialogResult.OK)
            {
                DisplayBooks();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DisplayBooks();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("listPriceDataGridViewTextBoxColumn"))
            {

                //decimal money = (decimal)e.Value;

                e.CellStyle.Format = "###,###,###";
                //e.CellStyle.SelectionBackColor = Color.Red;
                //e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //if (money > 0 && money <= 1000) e.CellStyle.BackColor = Color.LightBlue;
                //if (money > 1000 && money <= 10000) e.CellStyle.BackColor = Color.LightGreen;
                //if (money > 10000) e.CellStyle.BackColor = Color.LightPink;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("translatedByDataGridViewTextBoxColumn"))
            {

                //decimal money = (decimal)e.Value;
                var translatedBy = e.Value as string;

                if (string.IsNullOrEmpty(translatedBy)) e.CellStyle.BackColor = Color.AliceBlue;
            }

            dataGridView1.Columns["publishDateDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "D";
            //e.CellStyle.SelectionBackColor = Color.BurlyWood;
        }
    }
}
