using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class imageAddForm : Form
    {
        public string FileName
        {
            get
            {
                if (textBox2.Text == null) return "unknown";
                return textBox1.Text;
            }
        }
        public int W
        {
            get
            {
                if (textBox2.Text == "") return 200;
                string text = textBox2.Text;
                int value = Convert.ToInt32(text);
                return value;
            }
        }
        public int H
        {
            get
            {
                if (textBox2.Text == "") return 200;
                string text = textBox3.Text;
                int value = Convert.ToInt32(text);
                return value;
            }
        }
        bool _canceled = false;
        public bool Canceled
        {
            get { return _canceled; }
        }
        public imageAddForm()
        {
            InitializeComponent();
        }

        private void imageAddForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _canceled = true;
            Close();
        }
    }
}
