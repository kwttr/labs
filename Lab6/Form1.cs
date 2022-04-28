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
using static Lab6.Integrator;

namespace Lab6
{
    delegate void Print(double x);
    public partial class Form1 : Form
    {
        Print ShowResult;
        void PrintTB(double x)
        {
            tbArea.Text = Convert.ToString(x);
        }
        static void PrintMB(double x)
        {
            MessageBox.Show(Convert.ToString(x));
        }
        static void PrintFile(double x)
        {
            File.WriteAllText("C:/Users/Kerbix/Desktop/выфа/labs/Lab6/text.txt", Convert.ToString(x)+" ");
        }
        void PrintLB(double x, double f, double sum)
        {
            lbOnStep.Text = lbOnStep.Text+Convert.ToString(x) + " " + Convert.ToString(f) + " " + Convert.ToString(sum)+"\n";
        }
        static void PrintFile(double x, double f,double sum)
        {
            File.WriteAllText("C:/Users/Kerbix/Desktop/выфа/labs/Lab6/text.txt", Convert.ToString(x) + " " + Convert.ToString(f) + " " + Convert.ToString(sum));
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
            tbCoeffB.Text = "0";
            tbCoeffC.Text = "0";
            tbLeftBorder.Text = "0";
            tbRightBorder.Text = "10";
            textStep.Text = "0";
            cbListEquations.Items.Add(new MonoEquation(0, 0));
            cbListEquations.Items.Add(new QuadEquation(0,0,0));
            cbListEquations.Items.Add(new SinEquation(0));
            cbListEquations.SelectedIndex = 0;
            cbListIntegr.Items.Add(new IntegrateSimpson());
            cbListIntegr.Items.Add(new IntegrateRectangle());
            cbListIntegr.SelectedIndex = 0;
            cbListDelegate.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            var equation = cbListEquations.SelectedItem as Equation;
            var integr = cbListIntegr.SelectedItem as Integrator;
            integr.OnStep += new IntStepDelegate(PrintLB);
            integr.OnStep += PrintFile;
            if (equation != null)   
            {
                if (equation is MonoEquation mono)
                {
                    mono.k = Convert.ToDouble(tbCoeffA.Text);
                    mono.b = Convert.ToDouble(tbCoeffB.Text);
                }
                else if (equation is QuadEquation quad)
                {
                    quad.a = Convert.ToDouble(tbCoeffA.Text);
                    quad.b = Convert.ToDouble(tbCoeffB.Text);
                    quad.c = Convert.ToDouble(tbCoeffC.Text);
                }
                else if (equation is SinEquation sin)
                {
                    sin.a = Convert.ToDouble(tbCoeffA.Text);
                }
                DrawFunction(Convert.ToDouble(tbLeftBorder.Text), Convert.ToDouble(tbRightBorder.Text), chart1.Series[0], equation);
                if (textStep.Text != "")
                {
                    double s = integr.Integrate(equation.GetValue, Convert.ToDouble(tbLeftBorder.Text), Convert.ToDouble(tbRightBorder.Text), Convert.ToDouble(textStep.Text));
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
            switch (cbListEquations.SelectedIndex)
            {
                case 0:
                    tbCoeffA.Enabled = true;
                    tbCoeffB.Enabled = true;
                    tbCoeffC.Enabled = false;
                    label1.Enabled = true;
                    label2.Enabled = true;
                    label3.Enabled = false;
                    break;
                case 1:
                    tbCoeffA.Enabled = true;
                    tbCoeffB.Enabled = true;
                    tbCoeffC.Enabled = true;
                    label1.Enabled = true;
                    label2.Enabled = true;
                    label3.Enabled = true;
                    break;
                case 2:
                    tbCoeffA.Enabled = true;
                    tbCoeffB.Enabled = false;
                    tbCoeffC.Enabled = false;
                    label1.Enabled = true;
                    label2.Enabled = false;
                    label3.Enabled = false;
                    break;
                default: break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbListDelegate.SelectedIndex == 0)
            {
                ShowResult = PrintTB;
            }
            else if (cbListDelegate.SelectedIndex == 1)
            {
                ShowResult = PrintMB;
            }
            else if (cbListDelegate.SelectedIndex == 2)
            {
                ShowResult = PrintFile;
            }
        }
    }
}
