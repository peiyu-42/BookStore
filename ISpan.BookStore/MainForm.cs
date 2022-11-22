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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

            RemoveMdiBackColor();

        }
        /// <summary>
        /// 設定MDI背景
        /// </summary>
        void RemoveMdiBackColor()
        {
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                {
                    c.BackColor = this.BackColor; //顏色 
                    c.BackgroundImage = this.BackgroundImage; //背景 
                }
            }
        }
        private void 維護會員ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new MembersForm();
            //frm.MdiParent = this;
            //frm.Show();

            bool isFind = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name == "MembersForm")
                {
                    isFind = true;
                    form.MdiParent = this;
                    form.Focus();
                }
            }
            if (isFind == false)
            {
                MembersForm childForm = new MembersForm();
                childForm.MdiParent = this;
                childForm.Show();
            }


        }

        private void 維護書籍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new BooksForm();
            //frm.MdiParent = this;
            //frm.Show();

            bool isFind = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name == "BooksForm")
                {
                    isFind = true;
                    form.MdiParent = this;
                    form.Focus();
                }
            }
            if (isFind == false)
            {
                BooksForm childForm = new BooksForm();
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void 維護書籍分類ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new BookCategoriesForm();
            //frm.MdiParent = this;
            //frm.Show();

            bool isFind = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name == "BookCategoriesForm")
                {
                    isFind = true;
                    form.MdiParent = this;
                    form.Focus();
                }
            }
            if (isFind == false)
            {
                BookCategoriesForm childForm = new BookCategoriesForm();
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void 維護訂單ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new OrdersForm();
            //frm.MdiParent = this;
            //frm.Show();

            bool isFind = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name == "OrdersForm")
                {
                    isFind = true;
                    form.MdiParent = this;
                    form.Focus();
                }
            }
            if (isFind == false)
            {
                OrdersForm childForm = new OrdersForm();
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void 登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("您確定要登出嗎?",
                "登出",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
