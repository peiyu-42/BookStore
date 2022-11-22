using ISpan.BookStore.Infra;
using ISpan.BookStore.Infra.DAOs;
using ISpan.BookStore.Infra.Extensions;
using ISpan.BookStore.Models.DTOs;
using ISpan.BookStore.Models.Services;
using ISpan.BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ISpan.BookStore
{
    public partial class CreateBookForm : Form
    {
        private string sPicName = string.Empty;
        public CreateBookForm()
        {
            InitializeComponent();
            InitForm();
        }
        private void InitForm()
        {
            // 書籍分類
            categoryIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<BookCategoryVM> categories = new BookCategoryDAO().GetCategory()
                .Select(dto => dto.ToVM())
                .ToList();

            categoryIdComboBox.DataSource = categories;

            // 語言
            languageIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<LanguageVM> languages = new LangueageDAO().GetAll()
                .Select(dto => dto.ToVM())
                .ToList();

            languageIdComboBox.DataSource = languages;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string bookName = bookNameTextBox.Text;
            int categoryId = ((BookCategoryVM)categoryIdComboBox.SelectedItem).CategoryId;
            string author = authorTextBox.Text;
            string translator = translatorTextBox.Text;
            string publisher = publisherTextBox.Text;
            string publishDateString = publishDateTextBox.Text;
            int languageId = ((LanguageVM)languageIdComboBox.SelectedItem).Id;
            string listPriceString = listPriceTextBox.Text;

            DateTime publishDate = publishDateTextBox.Text.ToDateTime(DateTime.Today.AddDays(1));
            int listPrice = listPriceTextBox.Text.ToInt(-1);


            // 將它們繫結到ViewModel
            BookVM model = new BookVM
            {
                BookName = bookName,
                BookCategoryId = categoryId,
                Author = author,
                TranslatedBy = translator,
                Publisher = publisher,
                PublishDate = publishDate,
                LanguageId = languageId,
                ListPrice = listPrice,
                BookCover = sPicName,
            };
            // 針對ViewModel進行欄位驗證
            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"BookName", bookNameTextBox},
                {"Author", authorTextBox},
                {"TranslatedBy", translatorTextBox},
                {"Publisher", publisherTextBox},
                {"PublishDate", publishDateTextBox},
                {"ListPrice", listPriceTextBox},
                {"BookCover", pictureBox1},
            };

            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;

            // 如果通過驗證,就新增記錄
            // 將ViewModel轉成DTO
            BookDTO dto = model.ToDTO();

            try
            {
                // new UserService().Create(model);
                new BookService().Create(dto);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗, 原因: " + ex.Message);
            }


        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            //開啟檔案的類別
            OpenFileDialog ofdPic = new OpenFileDialog();
            //預設開起的路徑
            ofdPic.InitialDirectory = Application.StartupPath;

            //預設可以開啟的副檔名
            ofdPic.Filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.gif,*.tif)|*.jpg;*.png;*.jpeg;*.bmp;*.gif;*.tif";
            //取得或設定檔案對話方塊中目前所選取之篩選條件的索引
            ofdPic.FilterIndex = 1;
            //關閉對話框，還原當前的目錄
            ofdPic.RestoreDirectory = true;
            //取得或設定含有檔案對話方塊中所選文件的名稱。
            ofdPic.FileName = string.Empty;

            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                //得到文件名及路徑
                string sPicPaht = ofdPic.FileName.ToString();

                //FileInfo：提供建立、複製、刪除、移動和開啟檔案的執行個體 (Instance) 方法
                FileInfo fiPicInfo = new FileInfo(sPicPaht);
                //Length：取得目前檔案的大小。以字節為單位
                long lPicLong = fiPicInfo.Length / 1024;
                //得到文名
                sPicName = fiPicInfo.Name;
                //取得父目錄
                string sPicDirectory = fiPicInfo.Directory.ToString();
                //DirectoryName ：取得表示目錄完整路徑。
                string sPicDirectoryPath = fiPicInfo.DirectoryName;



                //封裝GDI+點陣圖像，是用來處理像素資料所定義影像的物件。
                //Bitmap類：封裝GDI+ 點陣圖，這個點陣圖是由圖形影像的像素資料及其屬性所組成。Bitmap 是用來處理像素資料所定義影像的物件。
                Bitmap bmPic = new Bitmap(sPicPaht);

                //如果文件大於500KB，警告
                if (lPicLong > 1400)
                {
                    MessageBox.Show("此文件大小為" + lPicLong + "K；已超過最大限制的400K范圍！");
                }
                else
                {
                    Point ptLoction = new Point(bmPic.Size);
                    if (ptLoction.X > pictureBox1.Width || ptLoction.Y > pictureBox1.Size.Height)
                    {
                        //圖像框的停靠方式
                        //pcbPic.Dock = DockStyle.Fill;

                        //圖像充滿圖像框，並且圖像維持比例
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        //圖像在圖像框置中
                        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                }
                //LoadAsync：非同步載入圖像
                pictureBox1.LoadAsync(sPicPaht);
            }
        }
    }
}
