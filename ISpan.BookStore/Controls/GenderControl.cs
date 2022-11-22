using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISpan.BookStore.Controls
{
    public partial class GenderControl : UserControl
    {
        public GenderControl()
        {
            InitializeComponent();
        }
        public int GetValue()
        {
            RadioButton[] controls = new RadioButton[] { maleRadioButton, femaleRadioButton, nonRadioButton };

            int value = -1;
            foreach (RadioButton item in controls)
            {
                if (item.Checked)
                {
                    value = Convert.ToInt32(item.Tag);
                    break;
                }
            }
            return value;
        }
        public string GetText()
        {
            RadioButton[] controls = new RadioButton[] { maleRadioButton, femaleRadioButton, nonRadioButton };

            string value = string.Empty;
            foreach (RadioButton item in controls)
            {
                if (item.Checked)
                {
                    value = item.Text;
                    break;
                }
            }
            return value;
        }
        public void SetValue(int value)
        {
            RadioButton[] controls = new RadioButton[] { maleRadioButton, femaleRadioButton, nonRadioButton };
            // 先清空所有 Radio Button被選取的狀態
            foreach (RadioButton item in controls)
            {
                item.Checked = false;
            }

            foreach (RadioButton item in controls)
            {
                int controlTag = Convert.ToInt32(item.Tag);
                if (controlTag == value)
                {
                    item.Checked = true;
                    break;
                }
            }
        }
        public void SetValue(string value)
        {
            RadioButton[] controls = new RadioButton[] { maleRadioButton, femaleRadioButton, nonRadioButton };
            // 先清空所有 Radio Button被選取的狀態
            foreach (RadioButton item in controls)
            {
                item.Checked = false;
            }

            foreach (RadioButton item in controls)
            {
                string controlTag = item.Text;
                if (controlTag == value)
                {
                    item.Checked = true;
                    break;
                }
            }
        }
    }
}
