namespace ISpan.BookStore.Controls
{
    partial class GenderControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.nonRadioButton = new System.Windows.Forms.RadioButton();
            this.femaleRadioButton = new System.Windows.Forms.RadioButton();
            this.maleRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // nonRadioButton
            // 
            this.nonRadioButton.AutoSize = true;
            this.nonRadioButton.Location = new System.Drawing.Point(108, 3);
            this.nonRadioButton.Name = "nonRadioButton";
            this.nonRadioButton.Size = new System.Drawing.Size(35, 16);
            this.nonRadioButton.TabIndex = 8;
            this.nonRadioButton.TabStop = true;
            this.nonRadioButton.Tag = "-1";
            this.nonRadioButton.Text = "無";
            this.nonRadioButton.UseVisualStyleBackColor = true;
            // 
            // femaleRadioButton
            // 
            this.femaleRadioButton.AutoSize = true;
            this.femaleRadioButton.Location = new System.Drawing.Point(55, 3);
            this.femaleRadioButton.Name = "femaleRadioButton";
            this.femaleRadioButton.Size = new System.Drawing.Size(35, 16);
            this.femaleRadioButton.TabIndex = 7;
            this.femaleRadioButton.TabStop = true;
            this.femaleRadioButton.Tag = "0";
            this.femaleRadioButton.Text = "女";
            this.femaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // maleRadioButton
            // 
            this.maleRadioButton.AutoSize = true;
            this.maleRadioButton.Location = new System.Drawing.Point(2, 3);
            this.maleRadioButton.Name = "maleRadioButton";
            this.maleRadioButton.Size = new System.Drawing.Size(35, 16);
            this.maleRadioButton.TabIndex = 6;
            this.maleRadioButton.TabStop = true;
            this.maleRadioButton.Tag = "1";
            this.maleRadioButton.Text = "男";
            this.maleRadioButton.UseVisualStyleBackColor = true;
            // 
            // GenderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nonRadioButton);
            this.Controls.Add(this.femaleRadioButton);
            this.Controls.Add(this.maleRadioButton);
            this.Name = "GenderControl";
            this.Size = new System.Drawing.Size(152, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton nonRadioButton;
        private System.Windows.Forms.RadioButton femaleRadioButton;
        private System.Windows.Forms.RadioButton maleRadioButton;
    }
}
