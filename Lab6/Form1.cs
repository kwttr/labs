using System;
using System.IO;
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
    delegate void Print(double x);
    public partial class Form1 : Form
    {
        Print ShowResult;
        void PrintTB(double x)
        {
            textBox6.Text = Convert.ToString(x);
        }
        static void PrintMB(double x)
        {
            MessageBox.Show(Convert.ToString(x));
        }
        static void PrintFile(double x)
        {
            File.WriteAllText("text.txt", Convert.ToString(x)+" ");
        }

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
            tbCoeffA.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "10";
            comboBox1.Items.Add(new MonoEquation(0, 0));
            comboBox1.Items.Add(new QuadEquation(0,0,0));
            comboBox1.Items.Add(new SinEquation(0));
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add(new IntegrateSimpson());
            comboBox2.Items.Add(new IntegrateRectangle());
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static double AAA(double x)
        {
            return x+1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            var equation = comboBox1.SelectedItem as Equation;
            var integr = comboBox2.SelectedItem as Integrator;
            if (equation != null)
            {
                if (equation is MonoEquation mono)
                {
                    mono.k = Convert.ToDouble(tbCoeffA.Text);
                    mono.b = Convert.ToDouble(textBox2.Text);
                }
                else if (equation is QuadEquation quad)
                {
                    quad.a = Convert.ToDouble(tbCoeffA.Text);
                    quad.b = Convert.ToDouble(textBox2.Text);
                    quad.c = Convert.ToDouble(textBox3.Text);
                }
                else if (equation is SinEquation sin)
                {
                    sin.a = Convert.ToDouble(tbCoeffA.Text);
                }
                DrawFunction(Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), chart1.Series[0], equation);
                if (textStep.Text != null)
                {
                    double s = integr.Integrate(equation.GetValue, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textStep.Text));
                    ShowResult?.Invoke(s);
                }
            }


        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            chart1.Series[0].Points.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    tbCoeffA.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = false;
                    label1.Enabled = true;
                    label2.Enabled = true;
                    label3.Enabled = false;
                    break;
                case 1:
                    tbCoeffA.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    label1.Enabled = true;
                    label2.Enabled = true;
                    label3.Enabled = true;
                    break;
                case 2:
                    tbCoeffA.Enabled = true;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    label1.Enabled = true;
                    label2.Enabled = false;
                    label3.Enabled = false;
                    break;
                default: break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                ShowResult = PrintTB;
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                ShowResult = PrintMB;
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                ShowResult = PrintFile;
            }
        }
    }
}
