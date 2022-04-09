using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int _x;
        int _y;
        bool _mouseClicked = false;
        public Color SelectedColor
        {
            get { return colorDialog1.Color; }
        }
        int SelectedSize
        {
            get { return trackBar1.Value; }
            set { trackBar1.Value = value; }
        }
        Brush _selectedBrush;
        Color DefaultColor
        {
            get { return Color.White; }
        }
        void CreateBlank(int width, int height)
        {
            var oldImage = pictureBox1.Image;
            var bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bmp.SetPixel(i, j, DefaultColor);
                }
            }
            pictureBox1.Image = bmp;
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
            pictureBox1.Refresh();
        }
        public Form1()
        {
            InitializeComponent();
            CreateBlank(pictureBox1.Width, pictureBox1.Height);
            var colors = new List<Color>();
            colors.Add(Color.FromKnownColor(KnownColor.Black));
            colors.Add(Color.FromKnownColor(KnownColor.DarkGray));
            colors.Add(Color.FromKnownColor(KnownColor.Maroon));
            colors.Add(Color.FromKnownColor(KnownColor.Red));
            colors.Add(Color.FromKnownColor(KnownColor.Orange));
            colors.Add(Color.FromKnownColor(KnownColor.Yellow));
            colors.Add(Color.FromKnownColor(KnownColor.LightGreen));
            colors.Add(Color.FromKnownColor(KnownColor.LightCyan));
            colors.Add(Color.FromKnownColor(KnownColor.Blue));
            colors.Add(Color.FromKnownColor(KnownColor.DarkCyan));
            colors.Add(Color.FromKnownColor(KnownColor.Purple));
            colors.Add(Color.FromKnownColor(KnownColor.Pink));
            foreach (Color col in colors)
            {
                Button b = new Button();
                b.Size = new Size(40, 40);
                b.BackColor = col;
                flowLayoutPanel2.Controls.Add(b);
                b.Click += b_Click;
            }

        }
        private void b_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (_selectedBrush == null) return;
            _selectedBrush.BrushColor = btn.BackColor;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedBrush == null) { return; }
            try
            {
                _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y);

                _mouseClicked = true;
            }
            finally
            {
                pictureBox1.Refresh();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseClicked = false;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _x = e.X > 0 ? e.X : 0;
            _y = e.Y > 0 ? e.Y : 0;
            try
            {
                if (_mouseClicked)

                    _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y);
            }
            finally
            {
                pictureBox1.Refresh();
            }
        }
            private void ‚˚ıÓ‰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ÒÓÁ‰‡Ú¸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageAddForm form = new imageAddForm(); 
            form.ShowDialog();
            if (form.Canceled == false)
            {
                CreateBlank(form.W, form.H);
            }
        }
        private void button_SelectBrushClick(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var brushType = Type.GetType($"WinFormsApp1.{btn.Tag}");
            Brush tmp = Activator.CreateInstance(brushType, SelectedColor, SelectedSize) as Brush;
            _selectedBrush= tmp;
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedBrush == null)
            {
                return;
            }
            _selectedBrush.Size = trackBar1.Value;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button7.BackColor = colorDialog1.Color;
                if (_selectedBrush == null) return;
                _selectedBrush.BrushColor= colorDialog1.Color;
            }
        }
    }
}