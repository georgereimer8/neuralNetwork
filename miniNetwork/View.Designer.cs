namespace miniNetwork
{
    partial class View
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownEpochs = new System.Windows.Forms.NumericUpDown();
            this.richTextBox_console = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_learningRate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_target = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_input = new System.Windows.Forms.NumericUpDown();
            this.button_start = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartActivations = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartWeights = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chartErrors = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEpochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_learningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartActivations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWeights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCost)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDownEpochs);
            this.groupBox1.Controls.Add(this.richTextBox_console);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown_learningRate);
            this.groupBox1.Controls.Add(this.numericUpDown_target);
            this.groupBox1.Controls.Add(this.numericUpDown_input);
            this.groupBox1.Controls.Add(this.button_start);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 513);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Epochs";
            // 
            // numericUpDownEpochs
            // 
            this.numericUpDownEpochs.Location = new System.Drawing.Point(39, 107);
            this.numericUpDownEpochs.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownEpochs.Name = "numericUpDownEpochs";
            this.numericUpDownEpochs.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownEpochs.TabIndex = 7;
            this.numericUpDownEpochs.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownEpochs.ValueChanged += new System.EventHandler(this.numericUpDownEpochs_ValueChanged);
            // 
            // richTextBox_console
            // 
            this.richTextBox_console.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox_console.Location = new System.Drawing.Point(366, 16);
            this.richTextBox_console.Name = "richTextBox_console";
            this.richTextBox_console.Size = new System.Drawing.Size(617, 113);
            this.richTextBox_console.TabIndex = 0;
            this.richTextBox_console.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Learning Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Target";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input";
            // 
            // numericUpDown_learningRate
            // 
            this.numericUpDown_learningRate.DecimalPlaces = 6;
            this.numericUpDown_learningRate.Location = new System.Drawing.Point(39, 81);
            this.numericUpDown_learningRate.Name = "numericUpDown_learningRate";
            this.numericUpDown_learningRate.Size = new System.Drawing.Size(74, 20);
            this.numericUpDown_learningRate.TabIndex = 3;
            this.numericUpDown_learningRate.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown_learningRate.ValueChanged += new System.EventHandler(this.numericUpDown_learningRate_ValueChanged);
            // 
            // numericUpDown_target
            // 
            this.numericUpDown_target.DecimalPlaces = 6;
            this.numericUpDown_target.Location = new System.Drawing.Point(39, 55);
            this.numericUpDown_target.Name = "numericUpDown_target";
            this.numericUpDown_target.Size = new System.Drawing.Size(74, 20);
            this.numericUpDown_target.TabIndex = 2;
            this.numericUpDown_target.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            this.numericUpDown_target.ValueChanged += new System.EventHandler(this.numericUpDown_target_ValueChanged);
            // 
            // numericUpDown_input
            // 
            this.numericUpDown_input.DecimalPlaces = 6;
            this.numericUpDown_input.Location = new System.Drawing.Point(39, 29);
            this.numericUpDown_input.Name = "numericUpDown_input";
            this.numericUpDown_input.Size = new System.Drawing.Size(74, 20);
            this.numericUpDown_input.TabIndex = 1;
            this.numericUpDown_input.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.numericUpDown_input.ValueChanged += new System.EventHandler(this.numericUpDown_input_ValueChanged);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(209, 26);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chartActivations);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartWeights);
            this.splitContainer1.Size = new System.Drawing.Size(986, 257);
            this.splitContainer1.SplitterDistance = 519;
            this.splitContainer1.TabIndex = 1;
            // 
            // chartActivations
            // 
            customLabel2.Text = "Activations";
            chartArea5.AxisX.CustomLabels.Add(customLabel2);
            chartArea5.AxisX.Title = "Activations";
            chartArea5.Name = "ChartArea1";
            this.chartActivations.ChartAreas.Add(chartArea5);
            this.chartActivations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartActivations.Location = new System.Drawing.Point(0, 0);
            this.chartActivations.Name = "chartActivations";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartActivations.Series.Add(series5);
            this.chartActivations.Size = new System.Drawing.Size(519, 257);
            this.chartActivations.TabIndex = 0;
            this.chartActivations.Text = "chart1";
            // 
            // chartWeights
            // 
            chartArea6.AxisX.Title = "Weights";
            chartArea6.Name = "ChartArea1";
            this.chartWeights.ChartAreas.Add(chartArea6);
            this.chartWeights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartWeights.Location = new System.Drawing.Point(0, 0);
            this.chartWeights.Name = "chartWeights";
            series6.ChartArea = "ChartArea1";
            series6.Name = "Series1";
            this.chartWeights.Series.Add(series6);
            this.chartWeights.Size = new System.Drawing.Size(463, 257);
            this.chartWeights.TabIndex = 1;
            this.chartWeights.Text = "chart2";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 257);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chartErrors);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chartCost);
            this.splitContainer2.Size = new System.Drawing.Size(986, 256);
            this.splitContainer2.SplitterDistance = 517;
            this.splitContainer2.TabIndex = 2;
            // 
            // chartErrors
            // 
            chartArea7.AxisX.Title = "Z";
            chartArea7.Name = "ChartArea1";
            this.chartErrors.ChartAreas.Add(chartArea7);
            this.chartErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartErrors.Location = new System.Drawing.Point(0, 0);
            this.chartErrors.Name = "chartErrors";
            series7.ChartArea = "ChartArea1";
            series7.Name = "Series1";
            this.chartErrors.Series.Add(series7);
            this.chartErrors.Size = new System.Drawing.Size(517, 256);
            this.chartErrors.TabIndex = 0;
            this.chartErrors.Text = "chart3";
            // 
            // chartCost
            // 
            chartArea8.AxisX.Title = "Cost";
            chartArea8.Name = "ChartArea1";
            this.chartCost.ChartAreas.Add(chartArea8);
            this.chartCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCost.Location = new System.Drawing.Point(0, 0);
            this.chartCost.Name = "chartCost";
            series8.ChartArea = "ChartArea1";
            series8.Name = "Series1";
            this.chartCost.Series.Add(series8);
            this.chartCost.Size = new System.Drawing.Size(465, 256);
            this.chartCost.TabIndex = 1;
            this.chartCost.Text = "chart4";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 645);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "View";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEpochs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_learningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_input)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartActivations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWeights)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_learningRate;
        private System.Windows.Forms.NumericUpDown numericUpDown_target;
        private System.Windows.Forms.NumericUpDown numericUpDown_input;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartActivations;
        private System.Windows.Forms.RichTextBox richTextBox_console;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWeights;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartErrors;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCost;
        private System.Windows.Forms.NumericUpDown numericUpDownEpochs;
        private System.Windows.Forms.Label label4;
    }
}

