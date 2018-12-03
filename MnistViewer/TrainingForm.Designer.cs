namespace MnistViewer
{
    partial class TrainingForm
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
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox_console = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chartActivations = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.aquaGauge_epochs = new AquaControls.AquaGauge();
            this.aquaGauge_accuracy = new AquaControls.AquaGauge();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartActivations)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox_console);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // richTextBox_console
            // 
            this.richTextBox_console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_console.Location = new System.Drawing.Point(3, 16);
            this.richTextBox_console.Name = "richTextBox_console";
            this.richTextBox_console.Size = new System.Drawing.Size(794, 267);
            this.richTextBox_console.TabIndex = 2;
            this.richTextBox_console.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.aquaGauge_accuracy);
            this.groupBox2.Controls.Add(this.chartActivations);
            this.groupBox2.Controls.Add(this.aquaGauge_epochs);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 164);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // chartActivations
            // 
            customLabel1.Text = "Activations";
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.Title = "Activations";
            chartArea1.Name = "ChartArea1";
            this.chartActivations.ChartAreas.Add(chartArea1);
            this.chartActivations.Dock = System.Windows.Forms.DockStyle.Right;
            this.chartActivations.Location = new System.Drawing.Point(384, 16);
            this.chartActivations.Name = "chartActivations";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartActivations.Series.Add(series1);
            this.chartActivations.Size = new System.Drawing.Size(407, 145);
            this.chartActivations.TabIndex = 4;
            this.chartActivations.Text = "chart1";
            // 
            // aquaGauge_epochs
            // 
            this.aquaGauge_epochs.BackColor = System.Drawing.Color.Transparent;
            this.aquaGauge_epochs.DialColor = System.Drawing.Color.Lavender;
            this.aquaGauge_epochs.DialText = "Epoch";
            this.aquaGauge_epochs.Dock = System.Windows.Forms.DockStyle.Left;
            this.aquaGauge_epochs.Glossiness = 11.36364F;
            this.aquaGauge_epochs.Location = new System.Drawing.Point(3, 16);
            this.aquaGauge_epochs.MaxValue = 0F;
            this.aquaGauge_epochs.MinValue = 0F;
            this.aquaGauge_epochs.Name = "aquaGauge_epochs";
            this.aquaGauge_epochs.RecommendedValue = 0F;
            this.aquaGauge_epochs.Size = new System.Drawing.Size(150, 150);
            this.aquaGauge_epochs.TabIndex = 0;
            this.aquaGauge_epochs.ThresholdPercent = 0F;
            this.aquaGauge_epochs.Value = 0F;
            // 
            // aquaGauge_accuracy
            // 
            this.aquaGauge_accuracy.BackColor = System.Drawing.Color.Transparent;
            this.aquaGauge_accuracy.DialColor = System.Drawing.Color.Lavender;
            this.aquaGauge_accuracy.DialText = "Accuracy";
            this.aquaGauge_accuracy.Dock = System.Windows.Forms.DockStyle.Left;
            this.aquaGauge_accuracy.Glossiness = 11.36364F;
            this.aquaGauge_accuracy.Location = new System.Drawing.Point(153, 16);
            this.aquaGauge_accuracy.MaxValue = 100F;
            this.aquaGauge_accuracy.MinValue = 0F;
            this.aquaGauge_accuracy.Name = "aquaGauge_accuracy";
            this.aquaGauge_accuracy.RecommendedValue = 0F;
            this.aquaGauge_accuracy.Size = new System.Drawing.Size(150, 150);
            this.aquaGauge_accuracy.TabIndex = 5;
            this.aquaGauge_accuracy.ThresholdPercent = 0F;
            this.aquaGauge_accuracy.Value = 0F;
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "TrainingForm";
            this.Text = "TrainingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrainingForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartActivations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox_console;
        private System.Windows.Forms.GroupBox groupBox2;
        private AquaControls.AquaGauge aquaGauge_epochs;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartActivations;
        private AquaControls.AquaGauge aquaGauge_accuracy;
    }
}