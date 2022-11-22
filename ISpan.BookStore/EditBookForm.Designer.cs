namespace ISpan.BookStore
{
    partial class EditBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.languageIdComboBox = new System.Windows.Forms.ComboBox();
            this.languageVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryIdComboBox = new System.Windows.Forms.ComboBox();
            this.bookCategoryVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listPriceTextBox = new System.Windows.Forms.TextBox();
            this.publishDateTextBox = new System.Windows.Forms.TextBox();
            this.publisherTextBox = new System.Windows.Forms.TextBox();
            this.translatorTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.bookNameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.languageVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookCategoryVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // languageIdComboBox
            // 
            this.languageIdComboBox.DataSource = this.languageVMBindingSource;
            this.languageIdComboBox.DisplayMember = "Language";
            this.languageIdComboBox.FormattingEnabled = true;
            this.languageIdComboBox.Location = new System.Drawing.Point(104, 229);
            this.languageIdComboBox.Name = "languageIdComboBox";
            this.languageIdComboBox.Size = new System.Drawing.Size(168, 20);
            this.languageIdComboBox.TabIndex = 6;
            this.languageIdComboBox.ValueMember = "Id";
            // 
            // languageVMBindingSource
            // 
            this.languageVMBindingSource.DataSource = typeof(ISpan.BookStore.Models.ViewModels.LanguageVM);
            // 
            // categoryIdComboBox
            // 
            this.categoryIdComboBox.DataSource = this.bookCategoryVMBindingSource;
            this.categoryIdComboBox.DisplayMember = "BookCategoryName";
            this.categoryIdComboBox.FormattingEnabled = true;
            this.categoryIdComboBox.Location = new System.Drawing.Point(104, 64);
            this.categoryIdComboBox.Name = "categoryIdComboBox";
            this.categoryIdComboBox.Size = new System.Drawing.Size(168, 20);
            this.categoryIdComboBox.TabIndex = 1;
            this.categoryIdComboBox.ValueMember = "CategoryId";
            // 
            // bookCategoryVMBindingSource
            // 
            this.bookCategoryVMBindingSource.DataSource = typeof(ISpan.BookStore.Models.ViewModels.BookCategoryVM);
            // 
            // listPriceTextBox
            // 
            this.listPriceTextBox.Location = new System.Drawing.Point(104, 262);
            this.listPriceTextBox.MaxLength = 20;
            this.listPriceTextBox.Name = "listPriceTextBox";
            this.listPriceTextBox.Size = new System.Drawing.Size(168, 22);
            this.listPriceTextBox.TabIndex = 7;
            // 
            // publishDateTextBox
            // 
            this.publishDateTextBox.Location = new System.Drawing.Point(104, 196);
            this.publishDateTextBox.MaxLength = 200;
            this.publishDateTextBox.Name = "publishDateTextBox";
            this.publishDateTextBox.Size = new System.Drawing.Size(168, 22);
            this.publishDateTextBox.TabIndex = 5;
            // 
            // publisherTextBox
            // 
            this.publisherTextBox.Location = new System.Drawing.Point(104, 163);
            this.publisherTextBox.MaxLength = 200;
            this.publisherTextBox.Name = "publisherTextBox";
            this.publisherTextBox.Size = new System.Drawing.Size(168, 22);
            this.publisherTextBox.TabIndex = 4;
            // 
            // translatorTextBox
            // 
            this.translatorTextBox.Location = new System.Drawing.Point(104, 130);
            this.translatorTextBox.MaxLength = 200;
            this.translatorTextBox.Name = "translatorTextBox";
            this.translatorTextBox.Size = new System.Drawing.Size(168, 22);
            this.translatorTextBox.TabIndex = 3;
            // 
            // authorTextBox
            // 
            this.authorTextBox.Location = new System.Drawing.Point(104, 97);
            this.authorTextBox.MaxLength = 200;
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(168, 22);
            this.authorTextBox.TabIndex = 2;
            // 
            // bookNameTextBox
            // 
            this.bookNameTextBox.Location = new System.Drawing.Point(104, 31);
            this.bookNameTextBox.MaxLength = 200;
            this.bookNameTextBox.Name = "bookNameTextBox";
            this.bookNameTextBox.Size = new System.Drawing.Size(168, 22);
            this.bookNameTextBox.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "單價:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "語言:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "出版日期:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "出版社:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "譯者:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "作者:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "類別:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "書名:";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(116, 303);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(197, 303);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(312, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(475, 303);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(75, 23);
            this.fileButton.TabIndex = 14;
            this.fileButton.Text = "選擇圖片";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // EditBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 354);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.languageIdComboBox);
            this.Controls.Add(this.categoryIdComboBox);
            this.Controls.Add(this.listPriceTextBox);
            this.Controls.Add(this.publishDateTextBox);
            this.Controls.Add(this.publisherTextBox);
            this.Controls.Add(this.translatorTextBox);
            this.Controls.Add(this.authorTextBox);
            this.Controls.Add(this.bookNameTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "編輯書籍";
            this.Load += new System.EventHandler(this.EditBookForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.languageVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookCategoryVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox languageIdComboBox;
        private System.Windows.Forms.ComboBox categoryIdComboBox;
        private System.Windows.Forms.TextBox listPriceTextBox;
        private System.Windows.Forms.TextBox publishDateTextBox;
        private System.Windows.Forms.TextBox publisherTextBox;
        private System.Windows.Forms.TextBox translatorTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.TextBox bookNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource languageVMBindingSource;
        private System.Windows.Forms.BindingSource bookCategoryVMBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button fileButton;
    }
}