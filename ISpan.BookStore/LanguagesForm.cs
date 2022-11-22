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
    public partial class LanguagesForm : Form
    {
        private LanguageVM[] langueages = null;
        public LanguagesForm()
        {
            InitializeComponent();

            DisplayLanguages();
        }
        private void DisplayLanguages()
        {
            langueages = new LangueageDAO().GetAll()
                .Select(dto => dto.ToVM())
                .ToArray();
            BindData(langueages);
        }

        private void BindData(LanguageVM[] langueages)
        {
            dataGridView1.DataSource = langueages;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
