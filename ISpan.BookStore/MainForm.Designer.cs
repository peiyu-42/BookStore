namespace ISpan.BookStore
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.維護會員ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.維護書籍ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.維護書籍分類ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.維護訂單ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.維護會員ToolStripMenuItem,
            this.維護書籍ToolStripMenuItem,
            this.維護書籍分類ToolStripMenuItem,
            this.維護訂單ToolStripMenuItem,
            this.登出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(975, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 維護會員ToolStripMenuItem
            // 
            this.維護會員ToolStripMenuItem.Name = "維護會員ToolStripMenuItem";
            this.維護會員ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.維護會員ToolStripMenuItem.Text = "維護會員";
            this.維護會員ToolStripMenuItem.Click += new System.EventHandler(this.維護會員ToolStripMenuItem_Click);
            // 
            // 維護書籍ToolStripMenuItem
            // 
            this.維護書籍ToolStripMenuItem.Name = "維護書籍ToolStripMenuItem";
            this.維護書籍ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.維護書籍ToolStripMenuItem.Text = "維護書籍";
            this.維護書籍ToolStripMenuItem.Click += new System.EventHandler(this.維護書籍ToolStripMenuItem_Click);
            // 
            // 維護書籍分類ToolStripMenuItem
            // 
            this.維護書籍分類ToolStripMenuItem.Name = "維護書籍分類ToolStripMenuItem";
            this.維護書籍分類ToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.維護書籍分類ToolStripMenuItem.Text = "維護書籍分類";
            this.維護書籍分類ToolStripMenuItem.Click += new System.EventHandler(this.維護書籍分類ToolStripMenuItem_Click);
            // 
            // 維護訂單ToolStripMenuItem
            // 
            this.維護訂單ToolStripMenuItem.Name = "維護訂單ToolStripMenuItem";
            this.維護訂單ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.維護訂單ToolStripMenuItem.Text = "維護訂單";
            this.維護訂單ToolStripMenuItem.Click += new System.EventHandler(this.維護訂單ToolStripMenuItem_Click);
            // 
            // 登出ToolStripMenuItem
            // 
            this.登出ToolStripMenuItem.Name = "登出ToolStripMenuItem";
            this.登出ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.登出ToolStripMenuItem.Text = "登出";
            this.登出ToolStripMenuItem.Click += new System.EventHandler(this.登出ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(975, 659);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(990, 670);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 維護會員ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 維護書籍ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 維護書籍分類ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 維護訂單ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登出ToolStripMenuItem;
    }
}