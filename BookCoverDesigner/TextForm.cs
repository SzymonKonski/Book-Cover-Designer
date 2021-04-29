using System;
using System.Drawing;
using System.Windows.Forms;

namespace BookCoverDesigner
{
    public partial class TextForm : Form
    {
        public decimal FontSize;
        public string AddedText;
        public StringAlignment Alignment;
        public TextForm(decimal fontSize=16, string text="", StringAlignment alignment = StringAlignment.Near)
        {
            InitializeComponent();
            FontSize = fontSize;
            AddedText = text;
            Alignment = alignment;
            fontNumericUpDown.Value = FontSize;
            
            switch (alignment)
            {
                case StringAlignment.Near:
                    textBox.TextAlign = HorizontalAlignment.Left;
                    leftRadioButton.Checked = true;
                    break;
                case StringAlignment.Far:
                    textBox.TextAlign = HorizontalAlignment.Right;
                    rightRadioButton.Checked = true;
                    break;
                case StringAlignment.Center:
                    textBox.TextAlign = HorizontalAlignment.Center;
                    centerRadioButton.Checked = true;
                    break;
            }
            textBox.Text = AddedText;
        }

        private void centerRadioButton_Click(object sender, EventArgs e)
        {
            textBox.TextAlign = HorizontalAlignment.Center;
            Alignment = StringAlignment.Center; 
        }

        private void leftRadioButton_Click(object sender, EventArgs e)
        {
            textBox.TextAlign = HorizontalAlignment.Left;
            Alignment = StringAlignment.Near;
        }

        private void rightRadioButton_Click(object sender, EventArgs e)
        {
            textBox.TextAlign = HorizontalAlignment.Right;
            Alignment = StringAlignment.Far;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            AddedText = textBox.Text;
            FontSize = fontNumericUpDown.Value;
        }
    }
}
