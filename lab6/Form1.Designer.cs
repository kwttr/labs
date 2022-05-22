namespace Lab6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.toolsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCoeffA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCoeffB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCoeffC = new System.Windows.Forms.TextBox();
            this.cbListIntegr = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLeftBorder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRightBorder = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textStep = new System.Windows.Forms.TextBox();
            this.cbListDelegate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbArea = new System.Windows.Forms.TextBox();
            this.cbListEquations = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.toolsPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 685);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Left;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(570, 685);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(3, 3);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(94, 49);
            this.buttonDraw.TabIndex = 2;
            this.buttonDraw.Text = "Нарисовать график";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolsPanel
            // 
            this.toolsPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolsPanel.Controls.Add(this.flowLayoutPanel1);
            this.toolsPanel.Controls.Add(this.cbListEquations);
            this.toolsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolsPanel.Location = new System.Drawing.Point(570, 0);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(205, 685);
            this.toolsPanel.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonDraw, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 327);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(205, 110);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.tbCoeffA);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.tbCoeffB);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.tbCoeffC);
            this.flowLayoutPanel1.Controls.Add(this.cbListIntegr);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.tbLeftBorder);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.tbRightBorder);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.textStep);
            this.flowLayoutPanel1.Controls.Add(this.cbListDelegate);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.tbArea);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(205, 306);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "a";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCoeffA
            // 
            this.tbCoeffA.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbCoeffA.Location = new System.Drawing.Point(22, 3);
            this.tbCoeffA.Name = "tbCoeffA";
            this.tbCoeffA.Size = new System.Drawing.Size(166, 20);
            this.tbCoeffA.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "b";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCoeffB
            // 
            this.tbCoeffB.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbCoeffB.Location = new System.Drawing.Point(22, 29);
            this.tbCoeffB.Name = "tbCoeffB";
            this.tbCoeffB.Size = new System.Drawing.Size(166, 20);
            this.tbCoeffB.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "c";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCoeffC
            // 
            this.tbCoeffC.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbCoeffC.Location = new System.Drawing.Point(22, 55);
            this.tbCoeffC.Name = "tbCoeffC";
            this.tbCoeffC.Size = new System.Drawing.Size(166, 20);
            this.tbCoeffC.TabIndex = 2;
            // 
            // cbListIntegr
            // 
            this.cbListIntegr.FormattingEnabled = true;
            this.cbListIntegr.Location = new System.Drawing.Point(3, 81);
            this.cbListIntegr.Name = "cbListIntegr";
            this.cbListIntegr.Size = new System.Drawing.Size(200, 21);
            this.cbListIntegr.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(3, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Левая граница интегрирования";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLeftBorder
            // 
            this.tbLeftBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbLeftBorder.Location = new System.Drawing.Point(3, 121);
            this.tbLeftBorder.Name = "tbLeftBorder";
            this.tbLeftBorder.Size = new System.Drawing.Size(202, 20);
            this.tbLeftBorder.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(3, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Правая граница интегрирования";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbRightBorder
            // 
            this.tbRightBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbRightBorder.Location = new System.Drawing.Point(3, 160);
            this.tbRightBorder.Name = "tbRightBorder";
            this.tbRightBorder.Size = new System.Drawing.Size(202, 20);
            this.tbRightBorder.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(3, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Количество разбиений";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textStep
            // 
            this.textStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.textStep.Location = new System.Drawing.Point(3, 199);
            this.textStep.Name = "textStep";
            this.textStep.Size = new System.Drawing.Size(202, 20);
            this.textStep.TabIndex = 14;
            // 
            // cbListDelegate
            // 
            this.cbListDelegate.FormattingEnabled = true;
            this.cbListDelegate.Items.AddRange(new object[] {
            "TextBox",
            "MessageBox",
            "File"});
            this.cbListDelegate.Location = new System.Drawing.Point(3, 225);
            this.cbListDelegate.Name = "cbListDelegate";
            this.cbListDelegate.Size = new System.Drawing.Size(200, 21);
            this.cbListDelegate.TabIndex = 13;
            this.cbListDelegate.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(3, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Площадь:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbArea
            // 
            this.tbArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbArea.Location = new System.Drawing.Point(3, 265);
            this.tbArea.Name = "tbArea";
            this.tbArea.ReadOnly = true;
            this.tbArea.Size = new System.Drawing.Size(202, 20);
            this.tbArea.TabIndex = 12;
            // 
            // cbListEquations
            // 
            this.cbListEquations.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbListEquations.FormattingEnabled = true;
            this.cbListEquations.Location = new System.Drawing.Point(0, 0);
            this.cbListEquations.Name = "cbListEquations";
            this.cbListEquations.Size = new System.Drawing.Size(205, 21);
            this.cbListEquations.TabIndex = 3;
            this.cbListEquations.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 685);
            this.Controls.Add(this.toolsPanel);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.toolsPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Panel toolsPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbListEquations;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCoeffA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCoeffB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCoeffC;
        private System.Windows.Forms.ComboBox cbListIntegr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLeftBorder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRightBorder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbArea;
        private System.Windows.Forms.ComboBox cbListDelegate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textStep;
    }
}

