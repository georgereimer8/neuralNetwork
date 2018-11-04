namespace BinaryConvertor
{
    partial class NetworkView
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownOutputLayerNeuronCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHiddenLayerNeuronCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInputLayerNeuronCount = new System.Windows.Forms.NumericUpDown();
            this.panelCostChart = new System.Windows.Forms.Panel();
            this.chartCost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownLearningRate = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputLayerNeuronCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHiddenLayerNeuronCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputLayerNeuronCount)).BeginInit();
            this.panelCostChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLearningRate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDownLearningRate);
            this.groupBox1.Controls.Add(this.buttonCreate);
            this.groupBox1.Controls.Add(this.buttonTrain);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownOutputLayerNeuronCount);
            this.groupBox1.Controls.Add(this.numericUpDownHiddenLayerNeuronCount);
            this.groupBox1.Controls.Add(this.numericUpDownInputLayerNeuronCount);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(330, 35);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonTrain
            // 
            this.buttonTrain.Location = new System.Drawing.Point(330, 64);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(75, 23);
            this.buttonTrain.TabIndex = 7;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hidden";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Input";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Neurons";
            // 
            // numericUpDownOutputLayerNeuronCount
            // 
            this.numericUpDownOutputLayerNeuronCount.Location = new System.Drawing.Point(51, 96);
            this.numericUpDownOutputLayerNeuronCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownOutputLayerNeuronCount.Name = "numericUpDownOutputLayerNeuronCount";
            this.numericUpDownOutputLayerNeuronCount.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownOutputLayerNeuronCount.TabIndex = 2;
            this.numericUpDownOutputLayerNeuronCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownOutputLayerNeuronCount.ValueChanged += new System.EventHandler(this.numericUpDownOutputLayerNeuronCount_ValueChanged);
            // 
            // numericUpDownHiddenLayerNeuronCount
            // 
            this.numericUpDownHiddenLayerNeuronCount.Location = new System.Drawing.Point(51, 68);
            this.numericUpDownHiddenLayerNeuronCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHiddenLayerNeuronCount.Name = "numericUpDownHiddenLayerNeuronCount";
            this.numericUpDownHiddenLayerNeuronCount.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownHiddenLayerNeuronCount.TabIndex = 1;
            this.numericUpDownHiddenLayerNeuronCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownHiddenLayerNeuronCount.ValueChanged += new System.EventHandler(this.numericUpDownHiddenLayerNeuronCount_ValueChanged);
            // 
            // numericUpDownInputLayerNeuronCount
            // 
            this.numericUpDownInputLayerNeuronCount.Location = new System.Drawing.Point(51, 40);
            this.numericUpDownInputLayerNeuronCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownInputLayerNeuronCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInputLayerNeuronCount.Name = "numericUpDownInputLayerNeuronCount";
            this.numericUpDownInputLayerNeuronCount.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownInputLayerNeuronCount.TabIndex = 0;
            this.numericUpDownInputLayerNeuronCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownInputLayerNeuronCount.ValueChanged += new System.EventHandler(this.numericUpDownInputLayerNeuronCount_ValueChanged);
            // 
            // panelCostChart
            // 
            this.panelCostChart.Controls.Add(this.chartCost);
            this.panelCostChart.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCostChart.Location = new System.Drawing.Point(0, 0);
            this.panelCostChart.Name = "panelCostChart";
            this.panelCostChart.Size = new System.Drawing.Size(470, 399);
            this.panelCostChart.TabIndex = 1;
            // 
            // chartCost
            // 
            chartArea3.Name = "ChartArea1";
            this.chartCost.ChartAreas.Add(chartArea3);
            this.chartCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCost.Location = new System.Drawing.Point(0, 0);
            this.chartCost.Name = "chartCost";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Name = "Series1";
            this.chartCost.Series.Add(series3);
            this.chartCost.Size = new System.Drawing.Size(470, 399);
            this.chartCost.TabIndex = 0;
            this.chartCost.Text = "chart1";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(470, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(14, 399);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(484, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(476, 399);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Learning Rate";
            // 
            // numericUpDownLearningRate
            // 
            this.numericUpDownLearningRate.DecimalPlaces = 6;
            this.numericUpDownLearningRate.Location = new System.Drawing.Point(229, 38);
            this.numericUpDownLearningRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownLearningRate.Name = "numericUpDownLearningRate";
            this.numericUpDownLearningRate.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownLearningRate.TabIndex = 9;
            this.numericUpDownLearningRate.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownLearningRate.ValueChanged += new System.EventHandler(this.numericUpDownLearningRate_ValueChanged);
            // 
            // NetworkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 527);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelCostChart);
            this.Controls.Add(this.groupBox1);
            this.Name = "NetworkView";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputLayerNeuronCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHiddenLayerNeuronCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInputLayerNeuronCount)).EndInit();
            this.panelCostChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLearningRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownOutputLayerNeuronCount;
        private System.Windows.Forms.NumericUpDown numericUpDownHiddenLayerNeuronCount;
        private System.Windows.Forms.NumericUpDown numericUpDownInputLayerNeuronCount;
        private System.Windows.Forms.Panel panelCostChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCost;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownLearningRate;
    }
}

