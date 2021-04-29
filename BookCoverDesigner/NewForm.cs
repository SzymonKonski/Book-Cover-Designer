using System;
using System.Windows.Forms;

namespace BookCoverDesigner
{
    public partial class NewForm : Form
    {
        public decimal NewWidth;
        public decimal NewHeight;
        public decimal Spine;
        public NewForm()
        {
            InitializeComponent();
            NewWidth = widthNumerical.Value;
            NewHeight = heightNumerical.Value;
            Spine = spineNumerical.Value;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            NewWidth = widthNumerical.Value;
            NewHeight = heightNumerical.Value;
            Spine = spineNumerical.Value;
        }
    }
}
