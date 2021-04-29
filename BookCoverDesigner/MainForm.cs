using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BookCoverDesigner
{
    public partial class MainForm : Form
    {
        private int _prevWidth;
        private int _prevHeight;
        private int _splitterDist;
        private Point _lastPosition;
        private int _width = 300;
        private int _height = 500;
        private int _middleWidth = 30;
        private bool _addClicked;
        private string _addedText = "";
        private StringAlignment _addedAlignment = StringAlignment.Near;
        private float _addedFontSize = 16;
        private Color _rectColor = Color.White;
        private Color _textColor = Color.Black;
        private NewText _selectedText;
        private int _selectedTextIndex;

        private List<NewText> _textList;
        private Point _rectPoint;
        private readonly ComponentResourceManager _resources;

        private class NewText
        {
            public Point Point;
            public string Text;
            public float FontSize;
            public SizeF StringSize;
            public StringAlignment Alignment;

            public NewText(Point point, string text, float fontSize, StringAlignment alignment)
            {
                Point = point;
                Text = text;
                FontSize = fontSize;
                Alignment = alignment;
            }

            public override bool Equals(object obj)
            {
                return obj is NewText text && Point.Equals(text.Point) && FontSize.Equals(text.FontSize);
            }

            public override int GetHashCode()
            {
                var hashCode = 27;
                hashCode = hashCode * 13 + Point.GetHashCode();
                hashCode = hashCode * 13 + FontSize.GetHashCode();
                return hashCode;
            }
        }

        public MainForm()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            InitializeComponent();
          
            _textList = new List<NewText>();
            _resources = new ComponentResourceManager(typeof(MainForm));
            _splitterDist = splitContainer1.SplitterDistance;
            _prevWidth = Width;
            _prevHeight = Height;
        }

        private float DrawTitle(PaintEventArgs e, SolidBrush textBrush)
        {
            float titleHeight = 0;
            if (!string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                int xText = pictureBox1.Width / 2 + _middleWidth / 2 + _width / 2;
                int yText = pictureBox1.Height / 2 - _height / 2 + _height / 5;
                int titleFontSize = 32;
                string title = TitleTextBox.Text;
                bool small = false;
                Font textFont = new Font("Arial", titleFontSize);
                SizeF stringSize = e.Graphics.MeasureString(title, textFont);

                while (stringSize.Width > _width || stringSize.Height > _height / 3)
                {
                    titleFontSize--;
                    if (titleFontSize == 0)
                    {
                        small = true;
                        break;
                    }
                    textFont = new Font("Arial", titleFontSize);
                    stringSize = e.Graphics.MeasureString(title, textFont);
                }

                if (!small)
                    e.Graphics.DrawString(title, textFont, textBrush, xText - stringSize.Width / 2, yText - stringSize.Height / 2, null);

                string spineTitle = Regex.Replace(title, @"\s+", " ");
                titleHeight = stringSize.Height;
                titleFontSize = 32;
                int xMiddle = pictureBox1.Width / 2;
                int yMiddle = pictureBox1.Height / 2 + _height / 4;
                textFont = new Font("Arial", titleFontSize);
                stringSize = e.Graphics.MeasureString(spineTitle, textFont);
                small = false;

                while (stringSize.Width > _height / 2 || stringSize.Height > _middleWidth)
                {
                    titleFontSize--;
                    if (titleFontSize == 0)
                    {
                        small = true;
                        break;
                    }
                    textFont = new Font("Arial", titleFontSize);
                    stringSize = e.Graphics.MeasureString(spineTitle, textFont);
                }

                if (stringSize.Width > 0 && stringSize.Height > 0 && small == false)
                {
                    GraphicsState state = e.Graphics.Save();
                    e.Graphics.ResetTransform();
                    e.Graphics.RotateTransform(-90);
                    e.Graphics.TranslateTransform(xMiddle - stringSize.Height / 2, yMiddle + stringSize.Width / 2, MatrixOrder.Append);
                    e.Graphics.DrawString(spineTitle, textFont, textBrush, 0, 0);
                    e.Graphics.Restore(state);
                }
            }

            return titleHeight;
        }

        private void DrawAuthor(PaintEventArgs e, float titleHeight, SolidBrush textBrush)
        {
            if (!string.IsNullOrWhiteSpace(AuthorTextBox.Text))
            {
                int xFont = pictureBox1.Width / 2 + _middleWidth / 2 + _width / 2;
                int yText = pictureBox1.Height / 2 - _height / 2 + _height / 4+ (int)titleHeight;
                int authorFontSize = 24;
                string author = AuthorTextBox.Text;
                bool small = false;
                Font textFont = new Font("Arial", authorFontSize);
                SizeF stringSize = e.Graphics.MeasureString(author, textFont);

                while (stringSize.Width > _width || stringSize.Height > (float)_height / 6)
                {
                    authorFontSize--;
                    if (authorFontSize == 0)
                    {
                        small = true;
                        break;
                    }
                    textFont = new Font("Arial", authorFontSize);
                    stringSize = e.Graphics.MeasureString(author, textFont);
                }

                if (!small)
                    e.Graphics.DrawString(author, textFont, textBrush, xFont - stringSize.Width / 2, yText - stringSize.Height / 2, null);

                authorFontSize = 24;
                string spineAuthor = Regex.Replace(author, @"\s+", " ");
                int yMiddle = pictureBox1.Height / 2 - _height / 4;
                int xMiddle = pictureBox1.Width / 2;
                textFont = new Font("Arial", authorFontSize);
                stringSize = e.Graphics.MeasureString(spineAuthor, textFont);
                small = false;

                while (stringSize.Width > (float)_height / 2 || stringSize.Height > _middleWidth)
                {
                    authorFontSize--;
                    if (authorFontSize == 0)
                    {
                        small = true;
                        break;
                    }
                    textFont = new Font("Arial", authorFontSize);
                    stringSize = e.Graphics.MeasureString(spineAuthor, textFont);
                }

                if (stringSize.Width > 0 && stringSize.Height > 0 && small == false)
                {
                    GraphicsState state = e.Graphics.Save();
                    e.Graphics.ResetTransform();
                    e.Graphics.RotateTransform(-90);
                    e.Graphics.TranslateTransform(xMiddle - stringSize.Height / 2, yMiddle + stringSize.Width / 2, MatrixOrder.Append);
                    e.Graphics.DrawString(spineAuthor, textFont, textBrush, 0, 0);
                    e.Graphics.Restore(state);
                }

            }
        }

        private void DrawRectangle(PaintEventArgs e)
        {
            SolidBrush rectBrush = new SolidBrush(_rectColor);
            int y = pictureBox1.Height / 2 - _height / 2;
            Rectangle rec1 = new Rectangle(pictureBox1.Width / 2 - _width - _middleWidth / 2, y, _width, _height);
            _rectPoint = rec1.Location;
            Rectangle rec2 = new Rectangle(pictureBox1.Width / 2 - _middleWidth / 2, y, _middleWidth, _height);
            Rectangle rec3 = new Rectangle(pictureBox1.Width / 2 + _middleWidth / 2, y, _width, _height);

            e.Graphics.FillRectangle(rectBrush, rec1);
            e.Graphics.FillRectangle(rectBrush, rec2);
            e.Graphics.FillRectangle(rectBrush, rec3);

            using Pen pen = new Pen(Color.Gray, 2);
            e.Graphics.DrawRectangle(pen, rec1);
            e.Graphics.DrawRectangle(pen, rec2);
            e.Graphics.DrawRectangle(pen, rec3);

        }
        
        private void DrawTexts(PaintEventArgs e, SolidBrush textBrush)
        {
            foreach (var text in _textList)
            {
                Font myFont = new Font("Arial", text.FontSize);
                StringFormat stringFormat = new StringFormat
                {
                    Alignment = text.Alignment, LineAlignment = text.Alignment
                };
                SizeF stringSize = e.Graphics.MeasureString(text.Text, myFont, new PointF(_rectPoint.X + text.Point.X, _rectPoint.Y + text.Point.Y), stringFormat);
                text.StringSize = stringSize;

                PointF point;

                switch (text.Alignment)
                {
                    case StringAlignment.Near:
                        point = new PointF(_rectPoint.X + text.Point.X - stringSize.Width / 2, _rectPoint.Y + text.Point.Y - stringSize.Height / 2);
                        break;
                    case StringAlignment.Center:
                        point = new PointF(_rectPoint.X + text.Point.X, _rectPoint.Y + text.Point.Y);
                        break;
                    case StringAlignment.Far:
                        point = new PointF(_rectPoint.X + text.Point.X + stringSize.Width / 2, _rectPoint.Y + text.Point.Y + stringSize.Height / 2);
                        break;
                    default:
                        point = new PointF(_rectPoint.X + text.Point.X, _rectPoint.Y + text.Point.Y);
                        break;
                }

                e.Graphics.DrawString(text.Text, myFont, textBrush, point, stringFormat);
            }
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush textBrush = new SolidBrush(_textColor);
            DrawRectangle(e);
            var titleHeight = DrawTitle(e, textBrush);
            DrawAuthor(e, titleHeight, textBrush);
            DrawTexts(e, textBrush);
        }
        
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (_addClicked && string.IsNullOrWhiteSpace(_addedText) == false)
            {
                _textList.Add(new NewText(new Point(e.X - _rectPoint.X, e.Y - _rectPoint.Y), _addedText, _addedFontSize, _addedAlignment));
                pictureBox1.Refresh();
                _addedText = "";
                _addClicked = false;
                pictureBox1.Cursor = Cursors.Default;
            }
        }

        private void EnglishMenuItem_Click(object sender, EventArgs e)
        {
            _splitterDist = splitContainer1.SplitterDistance;
            _prevWidth = Width;
            _prevHeight = Height;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            _resources.ApplyResources(this, "$this");
            ApplyResourcesRec(_resources, Controls);

            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripDropDownItem downItem)
                    foreach (ToolStripItem dropDownItem in downItem.DropDownItems)
                    {
                        _resources.ApplyResources(dropDownItem, dropDownItem.Name);
                    }

                _resources.ApplyResources(item, item.Name);
            }

            PolishMenuItem.Checked = false;
            PolishMenuItem.CheckState = CheckState.Unchecked;
            EnglishMenuItem.Checked = true;
            EnglishMenuItem.CheckState = CheckState.Checked;
            Width = _prevWidth;
            Height = _prevHeight;
            splitContainer1.SplitterDistance = _splitterDist;
        }

        private void PolishMenuItem_Click(object sender, EventArgs e)
        {
            _splitterDist = splitContainer1.SplitterDistance;
            _prevWidth = Width;
            _prevHeight = Height;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");
            _resources.ApplyResources(this, "$this");
            ApplyResourcesRec(_resources, Controls);

            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripDropDownItem downItem)
                    foreach (ToolStripItem dropDownItem in downItem.DropDownItems)
                    {
                        foreach (ToolStripItem languages in ((ToolStripDropDownItem)dropDownItem).DropDownItems)
                            _resources.ApplyResources(languages, languages.Name);
                        

                        _resources.ApplyResources(dropDownItem, dropDownItem.Name);
                    }

                _resources.ApplyResources(item, item.Name);
            }

            EnglishMenuItem.Checked = false;
            EnglishMenuItem.CheckState = CheckState.Unchecked;
            PolishMenuItem.Checked = true;
            PolishMenuItem.CheckState = CheckState.Checked;
            Width = _prevWidth;
            Height = _prevHeight;
            splitContainer1.SplitterDistance = _splitterDist;
        }

        private void ApplyResourcesRec(ComponentResourceManager resources, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                resources.ApplyResources(control, control.Name);
                ApplyResourcesRec(resources, control.Controls);
            }
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            bool changed = false;
            using(NewForm form = new NewForm())
            {
                if(form.ShowDialog() == DialogResult.OK)
                {
                    _width = (int)form.NewWidth;
                    _height = (int)form.NewHeight;
                    _middleWidth = (int)form.Spine;
                    changed = true;
                }
            }

            if (changed)
            {
                ClearCover();
                pictureBox1.Refresh();
            }
        }

        private void ClearCover()
        {
            _textList.Clear();
            TitleTextBox.Text = "";
            AuthorTextBox.Text = "";
            _textColor = Color.Black;
            _rectColor = Color.White;
        }

        private void ChangeBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _rectColor = colorDialog1.Color;
                pictureBox1.Refresh();
            }
        }

        private void ChangeBackgroundText_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _textColor = colorDialog1.Color;
                pictureBox1.Refresh();
            }
        }

        private void AddTextBox_Click_1(object sender, EventArgs e)
        {
            using (TextForm form = new TextForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _addedText = form.AddedText;
                    _addedFontSize = (float)form.FontSize;
                    _addedAlignment = form.Alignment;
                }
            }

            if (!string.IsNullOrWhiteSpace(_addedText))
            {
                _addClicked = true;
                pictureBox1.Cursor = Cursors.Cross;
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _lastPosition = new Point(e.X,e.Y);

                (_selectedText, _selectedTextIndex) = FindClosestTexts();

                if (_selectedText != null)
                {
                    using (TextForm form = new TextForm((decimal)_textList[_selectedTextIndex].FontSize,
                       _textList[_selectedTextIndex].Text, _textList[_selectedTextIndex].Alignment))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            _textList[_selectedTextIndex].Alignment = form.Alignment;
                            _textList[_selectedTextIndex].Text = form.AddedText;
                            _textList[_selectedTextIndex].FontSize = (float)form.FontSize;
                        }
                    }

                    pictureBox1.Refresh();
                }
            }
        }

        private (NewText, int) FindClosestTexts()
        {
            NewText result = null;
            int index = -1;
            double minDist = double.PositiveInfinity;
            for (int i = 0; i < _textList.Count; ++i)
            {
                if (TextsIntersect(_textList[i], _lastPosition) || _textList[i].Point.Equals(_lastPosition))
                {
                    double currDist = DistanceBetweenPoints(_textList[i].Point, _lastPosition);
                    if (minDist > currDist)
                    {
                        minDist = currDist;
                        result = _textList[i];
                        index = i;
                    }
                }
            }

            return (result, index);
        }

        private double DistanceBetweenPoints(Point p1, Point p2)
        {
            return (p1.Y - p2.Y) * (p1.Y - p2.Y)+ (p1.X - p2.X)*(p1.X - p2.X);
        }

        private bool TextsIntersect(NewText newText, Point p2)
        {
            if (p2.X >= _rectPoint.X + newText.Point.X - newText.StringSize.Width/2 &&
                p2.Y >= _rectPoint.Y + newText.Point.Y - newText.StringSize.Height / 2 &&
                p2.X <= _rectPoint.X + newText.Point.X + newText.StringSize.Width/2 &&
                p2.Y <= _rectPoint.Y + newText.Point.Y + newText.StringSize.Height/2)
                return true;

            return false;
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void AuthorTextBox_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
