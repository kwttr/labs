using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab6
{
    public partial class Form1 : Form
    {
        void DrawFunction(double x1, double x2, Series series, Equation equation)
        {
            for (int i = (int)x1; i < (int)x2; i++)
            {
                double y = equation.GetValue(i);
                chart1.Series[0].Points.AddXY(i, (int)y);
            }
        }
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            try {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if ((textBox1.Text != null) && textBox2.Text != null)
                    {
                        Equation mono = new MonoEquation(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                        Integrator s0 = new Integrator(mono);
                        DrawFunction(-100, 100, chart1.Series[0], mono);
                    }
                    break;
                case 1:
                    Equation quad = new QuadEquation(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    Integrator s1 = new Integrator(quad);
                    DrawFunction(-100, 100, chart1.Series[0], quad);
                    break;
                case 2:
                    Equation ssin = new SinEquation(Convert.ToDouble(textBox1.Text));
                    Integrator s2 = new Integrator(ssin);
                    DrawFunction(-100, 100, chart1.Series[0], ssin);
                    break;
                default: break;
            }
        }
            catch (Exception ex)
            {
                textBox1.Text= ex.Message;
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            chart1.Series[0].Points.Clear();
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var ctrs = flowLayoutPanel1.Controls.OfType<Control>().ToArray();
        //    flowLayoutPanel1.Controls.Clear();
        //    for(int i = 0; i < ctrs.Length; i++)
        //    {
        //        ctrs[i].Dispose();
        //    }
        //    switch (comboBox1.SelectedIndex)
        //    {
        //        case 0:
        //            TextBox LinK = new TextBox();
        //            TextBox LinB = new TextBox();
        //            flowLayoutPanel1.Controls.Add(LinK);
        //            flowLayoutPanel1.Controls.Add(LinB);
        //            break;
        //        case 1:
        //            TextBox QuadA = new TextBox();
        //            TextBox QuadB = new TextBox();
        //            TextBox QuadC = new TextBox();
        //            flowLayoutPanel1.Controls.Add(QuadA);
        //            flowLayoutPanel1.Controls.Add(QuadB);
        //            flowLayoutPanel1.Controls.Add(QuadC);
        //            break;
        //        case 2:
        //            TextBox SinA = new TextBox();
        //            flowLayoutPanel1.Controls.Add(SinA);
        //            break;
        //        default:break;
        //    }
        //}
    }
}
