namespace MnistViewer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_zoomLevel = new System.Windows.Forms.Label();
            this.trackBar_zoomLevel = new System.Windows.Forms.TrackBar();
            this.numericUpDown_currentImage = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_IncludeTestData = new System.Windows.Forms.CheckBox();
            this.numericUpDown_learningRate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_batchSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_epochs = new System.Windows.Forms.NumericUpDown();
            this.button_trainNetwork = new System.Windows.Forms.Button();
            this.button_createNetwork = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.textBox_imagesPath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_labelsPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zoomPicBox1 = new InspectionStation.Classes.Components.ZoomPicBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoomLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_currentImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_learningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_batchSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_epochs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_zoomLevel);
            this.groupBox1.Controls.Add(this.trackBar_zoomLevel);
            this.groupBox1.Controls.Add(this.numericUpDown_currentImage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox_IncludeTestData);
            this.groupBox1.Controls.Add(this.numericUpDown_learningRate);
            this.groupBox1.Controls.Add(this.numericUpDown_batchSize);
            this.groupBox1.Controls.Add(this.numericUpDown_epochs);
            this.groupBox1.Controls.Add(this.button_trainNetwork);
            this.groupBox1.Controls.Add(this.button_createNetwork);
            this.groupBox1.Controls.Add(this.button_load);
            this.groupBox1.Controls.Add(this.textBox_imagesPath);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox_labelsPath);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label_zoomLevel
            // 
            this.label_zoomLevel.AutoSize = true;
            this.label_zoomLevel.Location = new System.Drawing.Point(209, 190);
            this.label_zoomLevel.Name = "label_zoomLevel";
            this.label_zoomLevel.Size = new System.Drawing.Size(25, 13);
            this.label_zoomLevel.TabIndex = 16;
            this.label_zoomLevel.Text = "100";
            // 
            // trackBar_zoomLevel
            // 
            this.trackBar_zoomLevel.Location = new System.Drawing.Point(161, 155);
            this.trackBar_zoomLevel.Maximum = 100;
            this.trackBar_zoomLevel.Minimum = 1;
            this.trackBar_zoomLevel.Name = "trackBar_zoomLevel";
            this.trackBar_zoomLevel.Size = new System.Drawing.Size(165, 45);
            this.trackBar_zoomLevel.TabIndex = 15;
            this.trackBar_zoomLevel.Value = 100;
            this.trackBar_zoomLevel.Scroll += new System.EventHandler(this.trackBar_zoomLevel_Scroll);
            // 
            // numericUpDown_currentImage
            // 
            this.numericUpDown_currentImage.Location = new System.Drawing.Point(29, 161);
            this.numericUpDown_currentImage.Name = "numericUpDown_currentImage";
            this.numericUpDown_currentImage.Size = new System.Drawing.Size(101, 20);
            this.numericUpDown_currentImage.TabIndex = 14;
            this.numericUpDown_currentImage.ValueChanged += new System.EventHandler(this.numericUpDown_currentImage_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(646, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Learning Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(575, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Batch Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(507, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Epochs";
            // 
            // checkBox_IncludeTestData
            // 
            this.checkBox_IncludeTestData.AutoSize = true;
            this.checkBox_IncludeTestData.Location = new System.Drawing.Point(651, 189);
            this.checkBox_IncludeTestData.Name = "checkBox_IncludeTestData";
            this.checkBox_IncludeTestData.Size = new System.Drawing.Size(111, 17);
            this.checkBox_IncludeTestData.TabIndex = 10;
            this.checkBox_IncludeTestData.Text = "Include Test Data";
            this.checkBox_IncludeTestData.UseVisualStyleBackColor = true;
            this.checkBox_IncludeTestData.CheckedChanged += new System.EventHandler(this.checkBox_IncludeTestData_CheckedChanged);
            // 
            // numericUpDown_learningRate
            // 
            this.numericUpDown_learningRate.DecimalPlaces = 6;
            this.numericUpDown_learningRate.Location = new System.Drawing.Point(646, 127);
            this.numericUpDown_learningRate.Name = "numericUpDown_learningRate";
            this.numericUpDown_learningRate.Size = new System.Drawing.Size(74, 20);
            this.numericUpDown_learningRate.TabIndex = 9;
            this.numericUpDown_learningRate.Value = new decimal(new int[] {
            30,
            0,
            0,
            65536});
            this.numericUpDown_learningRate.ValueChanged += new System.EventHandler(this.numericUpDown_learningRate_ValueChanged);
            // 
            // numericUpDown_batchSize
            // 
            this.numericUpDown_batchSize.Location = new System.Drawing.Point(578, 127);
            this.numericUpDown_batchSize.Name = "numericUpDown_batchSize";
            this.numericUpDown_batchSize.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown_batchSize.TabIndex = 8;
            this.numericUpDown_batchSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_batchSize.ValueChanged += new System.EventHandler(this.numericUpDown_batchSize_ValueChanged);
            // 
            // numericUpDown_epochs
            // 
            this.numericUpDown_epochs.Location = new System.Drawing.Point(510, 128);
            this.numericUpDown_epochs.Name = "numericUpDown_epochs";
            this.numericUpDown_epochs.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown_epochs.TabIndex = 7;
            this.numericUpDown_epochs.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_epochs.ValueChanged += new System.EventHandler(this.numericUpDown_epochs_ValueChanged);
            // 
            // button_trainNetwork
            // 
            this.button_trainNetwork.AutoEllipsis = true;
            this.button_trainNetwork.Location = new System.Drawing.Point(403, 127);
            this.button_trainNetwork.Name = "button_trainNetwork";
            this.button_trainNetwork.Size = new System.Drawing.Size(101, 23);
            this.button_trainNetwork.TabIndex = 6;
            this.button_trainNetwork.Text = "Train Network";
            this.button_trainNetwork.UseVisualStyleBackColor = true;
            this.button_trainNetwork.Click += new System.EventHandler(this.button_trainNetwork_Click);
            // 
            // button_createNetwork
            // 
            this.button_createNetwork.AutoEllipsis = true;
            this.button_createNetwork.Location = new System.Drawing.Point(285, 127);
            this.button_createNetwork.Name = "button_createNetwork";
            this.button_createNetwork.Size = new System.Drawing.Size(101, 23);
            this.button_createNetwork.TabIndex = 5;
            this.button_createNetwork.Text = "Create Network";
            this.button_createNetwork.UseVisualStyleBackColor = true;
            this.button_createNetwork.Click += new System.EventHandler(this.button_createNetwork_Click);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(161, 127);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(101, 23);
            this.button_load.TabIndex = 4;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // textBox_imagesPath
            // 
            this.textBox_imagesPath.Location = new System.Drawing.Point(29, 101);
            this.textBox_imagesPath.Name = "textBox_imagesPath";
            this.textBox_imagesPath.Size = new System.Drawing.Size(733, 20);
            this.textBox_imagesPath.TabIndex = 3;
            this.textBox_imagesPath.Text = "C:\\Users\\GeorgeR\\source\\repos\\handwriting\\mnist\\t10k-images.idx3-ubyte";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Open Images";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_labelsPath
            // 
            this.textBox_labelsPath.Location = new System.Drawing.Point(29, 39);
            this.textBox_labelsPath.Name = "textBox_labelsPath";
            this.textBox_labelsPath.Size = new System.Drawing.Size(733, 20);
            this.textBox_labelsPath.TabIndex = 1;
            this.textBox_labelsPath.Text = "C:\\Users\\GeorgeR\\source\\repos\\handwriting\\mnist\\t10k-labels.idx1-ubyte";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open Labels";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.zoomPicBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 229);
            this.panel1.TabIndex = 1;
            // 
            // zoomPicBox1
            // 
            this.zoomPicBox1.AutoScroll = true;
            this.zoomPicBox1.AutoScrollMargin = new System.Drawing.Size(800, 229);
            this.zoomPicBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomPicBox1.Image = null;
            this.zoomPicBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.zoomPicBox1.Location = new System.Drawing.Point(0, 0);
            this.zoomPicBox1.Name = "zoomPicBox1";
            this.zoomPicBox1.Size = new System.Drawing.Size(800, 229);
            this.zoomPicBox1.TabIndex = 0;
            this.zoomPicBox1.Text = "zoomPicBox1";
            this.zoomPicBox1.Zoom = 1F;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // NetworkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "NetworkView";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoomLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_currentImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_learningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_batchSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_epochs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private InspectionStation.Classes.Components.ZoomPicBox zoomPicBox1;
        private System.Windows.Forms.TextBox textBox_labelsPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_imagesPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_createNetwork;
        private System.Windows.Forms.Button button_trainNetwork;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_IncludeTestData;
        private System.Windows.Forms.NumericUpDown numericUpDown_learningRate;
        private System.Windows.Forms.NumericUpDown numericUpDown_batchSize;
        private System.Windows.Forms.NumericUpDown numericUpDown_epochs;
        private System.Windows.Forms.NumericUpDown numericUpDown_currentImage;
        private System.Windows.Forms.TrackBar trackBar_zoomLevel;
        private System.Windows.Forms.Label label_zoomLevel;
    }
}

