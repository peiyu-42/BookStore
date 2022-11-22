using ISpan.BookStore.Models.Services;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ISpan.BookStore
{
    public partial class MembersForm : Form
    {
        private MemberIndexVM[] members = null;
        public MembersForm()
        {
            InitializeComponent();

            DisplayMembers();
        }
        private void DisplayMembers()
        {
            members = new MemberService().GetAll().ToArray();
            BindData(members);
        }

        private void BindData(MemberIndexVM[] members)
        {
            dataGridView1.DataSource = members;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;
            if (rowIndx < 0) return;
            MemberIndexVM row= this.members[rowIndx];
            int id = row.Id;

            var frm = new EditMemberForm(id);
            DialogResult result = frm.ShowDialog();

            if(result == DialogResult.OK)
            { 
                DisplayMembers(); 
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var frm = new CreateMemberForm();
            DialogResult result = frm.ShowDialog();

            if(result == DialogResult.OK)
            { 
                DisplayMembers();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Columns["birthdayDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "D";            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string account = searchTextBox.Text;
            members = new MemberService().GetPartAccount(account).ToArray();
            BindData(members);

        }        
    }
}
