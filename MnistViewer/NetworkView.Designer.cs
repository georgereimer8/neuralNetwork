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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkView));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_SaveNetwork = new System.Windows.Forms.Button();
            this.button_loadNetwork = new System.Windows.Forms.Button();
            this.checkBox_shuffle = new System.Windows.Forms.CheckBox();
            this.checkBox_Verbose = new System.Windows.Forms.CheckBox();
            this.button_Stop = new System.Windows.Forms.Button();
            this.textBox_inputNeuronCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown_HiddenLayerCount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_OutputNeuronCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_HiddenNeuronCount = new System.Windows.Forms.NumericUpDown();
            this.label_zoomLevel = new System.Windows.Forms.Label();
            this.trackBar_zoomLevel = new System.Windows.Forms.TrackBar();
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
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown_currentImage = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chartActivations = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox_input = new System.Windows.Forms.PictureBox();
            this.label_result = new System.Windows.Forms.Label();
            this.richTextBox_console = new System.Windows.Forms.RichTextBox();
            this.aquaGauge_batch = new AquaControls.AquaGauge();
            this.aquaGauge_accuracy = new AquaControls.AquaGauge();
            this.aquaGauge_epochs = new AquaControls.AquaGauge();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.zoomPicBox1 = new MnistViewer.ZoomPicBox();
            this.label_TrainingInProgress = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HiddenLayerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_OutputNeuronCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HiddenNeuronCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoomLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_learningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_batchSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_epochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_currentImage)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartActivations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_input)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.button_SaveNetwork);
            this.groupBox1.Controls.Add(this.button_loadNetwork);
            this.groupBox1.Controls.Add(this.checkBox_shuffle);
            this.groupBox1.Controls.Add(this.checkBox_Verbose);
            this.groupBox1.Controls.Add(this.button_Stop);
            this.groupBox1.Controls.Add(this.textBox_inputNeuronCount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numericUpDown_HiddenLayerCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDown_OutputNeuronCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericUpDown_HiddenNeuronCount);
            this.groupBox1.Controls.Add(this.label_zoomLevel);
            this.groupBox1.Controls.Add(this.trackBar_zoomLevel);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 580);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1240, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Hyper Parameters";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox1.Location = new System.Drawing.Point(917, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(320, 187);
            this.richTextBox1.TabIndex = 44;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button_SaveNetwork
            // 
            this.button_SaveNetwork.BackColor = System.Drawing.Color.LightGreen;
            this.button_SaveNetwork.Location = new System.Drawing.Point(777, 65);
            this.button_SaveNetwork.Name = "button_SaveNetwork";
            this.button_SaveNetwork.Size = new System.Drawing.Size(99, 23);
            this.button_SaveNetwork.TabIndex = 43;
            this.button_SaveNetwork.Text = "Save Network";
            this.button_SaveNetwork.UseVisualStyleBackColor = false;
            this.button_SaveNetwork.Click += new System.EventHandler(this.button_SaveNetwork_Click);
            // 
            // button_loadNetwork
            // 
            this.button_loadNetwork.BackColor = System.Drawing.Color.LightGreen;
            this.button_loadNetwork.Location = new System.Drawing.Point(777, 38);
            this.button_loadNetwork.Name = "button_loadNetwork";
            this.button_loadNetwork.Size = new System.Drawing.Size(99, 23);
            this.button_loadNetwork.TabIndex = 42;
            this.button_loadNetwork.Text = "Load Network";
            this.button_loadNetwork.UseVisualStyleBackColor = false;
            this.button_loadNetwork.Click += new System.EventHandler(this.button_loadNetwork_Click);
            // 
            // checkBox_shuffle
            // 
            this.checkBox_shuffle.AutoSize = true;
            this.checkBox_shuffle.Checked = true;
            this.checkBox_shuffle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_shuffle.Location = new System.Drawing.Point(319, 189);
            this.checkBox_shuffle.Name = "checkBox_shuffle";
            this.checkBox_shuffle.Size = new System.Drawing.Size(101, 17);
            this.checkBox_shuffle.TabIndex = 41;
            this.checkBox_shuffle.Text = "Shuffle Batches";
            this.checkBox_shuffle.UseVisualStyleBackColor = true;
            this.checkBox_shuffle.CheckedChanged += new System.EventHandler(this.checkBox_shuffle_CheckedChanged);
            // 
            // checkBox_Verbose
            // 
            this.checkBox_Verbose.AutoSize = true;
            this.checkBox_Verbose.Location = new System.Drawing.Point(429, 189);
            this.checkBox_Verbose.Name = "checkBox_Verbose";
            this.checkBox_Verbose.Size = new System.Drawing.Size(65, 17);
            this.checkBox_Verbose.TabIndex = 40;
            this.checkBox_Verbose.Text = "Verbose";
            this.checkBox_Verbose.UseVisualStyleBackColor = true;
            // 
            // button_Stop
            // 
            this.button_Stop.AutoEllipsis = true;
            this.button_Stop.BackColor = System.Drawing.Color.Red;
            this.button_Stop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Stop.Location = new System.Drawing.Point(29, 94);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(101, 23);
            this.button_Stop.TabIndex = 39;
            this.button_Stop.Text = "Stop Training";
            this.button_Stop.UseVisualStyleBackColor = false;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // textBox_inputNeuronCount
            // 
            this.textBox_inputNeuronCount.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox_inputNeuronCount.Location = new System.Drawing.Point(379, 129);
            this.textBox_inputNeuronCount.Name = "textBox_inputNeuronCount";
            this.textBox_inputNeuronCount.ReadOnly = true;
            this.textBox_inputNeuronCount.Size = new System.Drawing.Size(57, 20);
            this.textBox_inputNeuronCount.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(178, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Zoom";
            // 
            // numericUpDown_HiddenLayerCount
            // 
            this.numericUpDown_HiddenLayerCount.Location = new System.Drawing.Point(447, 158);
            this.numericUpDown_HiddenLayerCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_HiddenLayerCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_HiddenLayerCount.Name = "numericUpDown_HiddenLayerCount";
            this.numericUpDown_HiddenLayerCount.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown_HiddenLayerCount.TabIndex = 35;
            this.numericUpDown_HiddenLayerCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_HiddenLayerCount.ValueChanged += new System.EventHandler(this.numericUpDown_HiddenLayerCount_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "# Layers";
            // 
            // numericUpDown_OutputNeuronCount
            // 
            this.numericUpDown_OutputNeuronCount.Location = new System.Drawing.Point(515, 129);
            this.numericUpDown_OutputNeuronCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_OutputNeuronCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_OutputNeuronCount.Name = "numericUpDown_OutputNeuronCount";
            this.numericUpDown_OutputNeuronCount.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown_OutputNeuronCount.TabIndex = 33;
            this.numericUpDown_OutputNeuronCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_OutputNeuronCount.ValueChanged += new System.EventHandler(this.numericUpDown_OutputNeuronCount_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(522, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Output";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(386, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Input";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(453, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Hidden";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(316, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "# Neurons";
            // 
            // numericUpDown_HiddenNeuronCount
            // 
            this.numericUpDown_HiddenNeuronCount.Location = new System.Drawing.Point(447, 129);
            this.numericUpDown_HiddenNeuronCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_HiddenNeuronCount.Name = "numericUpDown_HiddenNeuronCount";
            this.numericUpDown_HiddenNeuronCount.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown_HiddenNeuronCount.TabIndex = 27;
            this.numericUpDown_HiddenNeuronCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_HiddenNeuronCount.ValueChanged += new System.EventHandler(this.numericUpDown_HiddenNeuronCount_ValueChanged);
            // 
            // label_zoomLevel
            // 
            this.label_zoomLevel.AutoSize = true;
            this.label_zoomLevel.Location = new System.Drawing.Point(257, 155);
            this.label_zoomLevel.Name = "label_zoomLevel";
            this.label_zoomLevel.Size = new System.Drawing.Size(25, 13);
            this.label_zoomLevel.TabIndex = 16;
            this.label_zoomLevel.Text = "100";
            // 
            // trackBar_zoomLevel
            // 
            this.trackBar_zoomLevel.Location = new System.Drawing.Point(161, 123);
            this.trackBar_zoomLevel.Maximum = 100;
            this.trackBar_zoomLevel.Minimum = 1;
            this.trackBar_zoomLevel.Name = "trackBar_zoomLevel";
            this.trackBar_zoomLevel.Size = new System.Drawing.Size(145, 45);
            this.trackBar_zoomLevel.TabIndex = 15;
            this.trackBar_zoomLevel.Value = 100;
            this.trackBar_zoomLevel.Scroll += new System.EventHandler(this.trackBar_zoomLevel_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(722, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Learning Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(651, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Batch Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(583, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Epochs";
            // 
            // checkBox_IncludeTestData
            // 
            this.checkBox_IncludeTestData.AutoSize = true;
            this.checkBox_IncludeTestData.Checked = true;
            this.checkBox_IncludeTestData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_IncludeTestData.Location = new System.Drawing.Point(500, 189);
            this.checkBox_IncludeTestData.Name = "checkBox_IncludeTestData";
            this.checkBox_IncludeTestData.Size = new System.Drawing.Size(109, 17);
            this.checkBox_IncludeTestData.TabIndex = 10;
            this.checkBox_IncludeTestData.Text = "Test Each Epoch";
            this.checkBox_IncludeTestData.UseVisualStyleBackColor = true;
            this.checkBox_IncludeTestData.CheckedChanged += new System.EventHandler(this.checkBox_TestEachEpoch_CheckedChanged);
            // 
            // numericUpDown_learningRate
            // 
            this.numericUpDown_learningRate.DecimalPlaces = 6;
            this.numericUpDown_learningRate.Location = new System.Drawing.Point(722, 129);
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
            this.numericUpDown_batchSize.Location = new System.Drawing.Point(654, 129);
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
            this.numericUpDown_epochs.Location = new System.Drawing.Point(586, 129);
            this.numericUpDown_epochs.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
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
            this.button_trainNetwork.BackColor = System.Drawing.Color.LightGreen;
            this.button_trainNetwork.Location = new System.Drawing.Point(29, 65);
            this.button_trainNetwork.Name = "button_trainNetwork";
            this.button_trainNetwork.Size = new System.Drawing.Size(101, 23);
            this.button_trainNetwork.TabIndex = 6;
            this.button_trainNetwork.Text = "2. Train Network";
            this.button_trainNetwork.UseVisualStyleBackColor = false;
            this.button_trainNetwork.Click += new System.EventHandler(this.button_trainNetwork_Click);
            // 
            // button_createNetwork
            // 
            this.button_createNetwork.AutoEllipsis = true;
            this.button_createNetwork.BackColor = System.Drawing.Color.Gold;
            this.button_createNetwork.Location = new System.Drawing.Point(632, 156);
            this.button_createNetwork.Name = "button_createNetwork";
            this.button_createNetwork.Size = new System.Drawing.Size(101, 23);
            this.button_createNetwork.TabIndex = 5;
            this.button_createNetwork.Text = "Create Network";
            this.button_createNetwork.UseVisualStyleBackColor = false;
            this.button_createNetwork.Click += new System.EventHandler(this.button_createNetwork_Click);
            // 
            // button_load
            // 
            this.button_load.BackColor = System.Drawing.Color.LightGreen;
            this.button_load.Location = new System.Drawing.Point(29, 36);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(101, 23);
            this.button_load.TabIndex = 4;
            this.button_load.Text = "1. Load Images";
            this.button_load.UseVisualStyleBackColor = false;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // textBox_imagesPath
            // 
            this.textBox_imagesPath.Location = new System.Drawing.Point(161, 65);
            this.textBox_imagesPath.Name = "textBox_imagesPath";
            this.textBox_imagesPath.Size = new System.Drawing.Size(476, 20);
            this.textBox_imagesPath.TabIndex = 3;
            this.textBox_imagesPath.Text = "C:\\Users\\GeorgeR\\source\\repos\\neuralNetwork\\mnist\\train-images.idx3-ubyte";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Salmon;
            this.button2.Location = new System.Drawing.Point(655, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Open Images";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_labelsPath
            // 
            this.textBox_labelsPath.Location = new System.Drawing.Point(161, 38);
            this.textBox_labelsPath.Name = "textBox_labelsPath";
            this.textBox_labelsPath.Size = new System.Drawing.Size(476, 20);
            this.textBox_labelsPath.TabIndex = 1;
            this.textBox_labelsPath.Text = "C:\\Users\\GeorgeR\\source\\repos\\neuralNetwork\\mnist\\train-labels.idx1-ubyte";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Salmon;
            this.button1.Location = new System.Drawing.Point(655, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open Labels";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(693, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Select Test Image";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // numericUpDown_currentImage
            // 
            this.numericUpDown_currentImage.Location = new System.Drawing.Point(709, 111);
            this.numericUpDown_currentImage.Name = "numericUpDown_currentImage";
            this.numericUpDown_currentImage.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown_currentImage.TabIndex = 14;
            this.numericUpDown_currentImage.ValueChanged += new System.EventHandler(this.numericUpDown_currentImage_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 409);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.zoomPicBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chartActivations);
            this.splitContainer2.Size = new System.Drawing.Size(1240, 409);
            this.splitContainer2.SplitterDistance = 796;
            this.splitContainer2.TabIndex = 1;
            // 
            // chartActivations
            // 
            this.chartActivations.AllowDrop = true;
            this.chartActivations.BackColor = System.Drawing.SystemColors.Control;
            customLabel1.Text = "Activations";
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.Title = "Activations";
            chartArea1.Name = "ChartArea1";
            this.chartActivations.ChartAreas.Add(chartArea1);
            this.chartActivations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartActivations.Location = new System.Drawing.Point(0, 0);
            this.chartActivations.Name = "chartActivations";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartActivations.Series.Add(series1);
            this.chartActivations.Size = new System.Drawing.Size(440, 409);
            this.chartActivations.TabIndex = 5;
            this.chartActivations.Text = "chart1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 409);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox_input);
            this.splitContainer1.Panel1.Controls.Add(this.label_result);
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox_console);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown_currentImage);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label_TrainingInProgress);
            this.splitContainer1.Panel2.Controls.Add(this.aquaGauge_batch);
            this.splitContainer1.Panel2.Controls.Add(this.aquaGauge_accuracy);
            this.splitContainer1.Panel2.Controls.Add(this.aquaGauge_epochs);
            this.splitContainer1.Size = new System.Drawing.Size(1240, 171);
            this.splitContainer1.SplitterDistance = 791;
            this.splitContainer1.TabIndex = 2;
            // 
            // pictureBox_input
            // 
            this.pictureBox_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_input.Location = new System.Drawing.Point(466, 0);
            this.pictureBox_input.Name = "pictureBox_input";
            this.pictureBox_input.Size = new System.Drawing.Size(225, 169);
            this.pictureBox_input.TabIndex = 4;
            this.pictureBox_input.TabStop = false;
            this.pictureBox_input.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_input_MouseDown);
            this.pictureBox_input.MouseLeave += new System.EventHandler(this.pictureBox_input_MouseLeave);
            this.pictureBox_input.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_input_MouseMove);
            this.pictureBox_input.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_input_MouseUp);
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_result.Location = new System.Drawing.Point(691, 0);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(98, 108);
            this.label_result.TabIndex = 5;
            this.label_result.Text = "0";
            // 
            // richTextBox_console
            // 
            this.richTextBox_console.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_console.Dock = System.Windows.Forms.DockStyle.Left;
            this.richTextBox_console.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_console.Name = "richTextBox_console";
            this.richTextBox_console.Size = new System.Drawing.Size(466, 169);
            this.richTextBox_console.TabIndex = 3;
            this.richTextBox_console.Text = "";
            // 
            // aquaGauge_batch
            // 
            this.aquaGauge_batch.BackColor = System.Drawing.Color.Transparent;
            this.aquaGauge_batch.DialColor = System.Drawing.Color.Lavender;
            this.aquaGauge_batch.DialText = "Batch";
            this.aquaGauge_batch.Dock = System.Windows.Forms.DockStyle.Left;
            this.aquaGauge_batch.Glossiness = 11.36364F;
            this.aquaGauge_batch.Location = new System.Drawing.Point(300, 0);
            this.aquaGauge_batch.MaxValue = 30F;
            this.aquaGauge_batch.MinValue = 0F;
            this.aquaGauge_batch.Name = "aquaGauge_batch";
            this.aquaGauge_batch.RecommendedValue = 0F;
            this.aquaGauge_batch.Size = new System.Drawing.Size(150, 150);
            this.aquaGauge_batch.TabIndex = 8;
            this.aquaGauge_batch.ThresholdPercent = 0F;
            this.aquaGauge_batch.Value = 0F;
            // 
            // aquaGauge_accuracy
            // 
            this.aquaGauge_accuracy.BackColor = System.Drawing.Color.Transparent;
            this.aquaGauge_accuracy.DialColor = System.Drawing.Color.Lavender;
            this.aquaGauge_accuracy.DialText = "Accuracy";
            this.aquaGauge_accuracy.Dock = System.Windows.Forms.DockStyle.Left;
            this.aquaGauge_accuracy.Glossiness = 11.36364F;
            this.aquaGauge_accuracy.Location = new System.Drawing.Point(150, 0);
            this.aquaGauge_accuracy.MaxValue = 100F;
            this.aquaGauge_accuracy.MinValue = 0F;
            this.aquaGauge_accuracy.Name = "aquaGauge_accuracy";
            this.aquaGauge_accuracy.RecommendedValue = 0F;
            this.aquaGauge_accuracy.Size = new System.Drawing.Size(150, 150);
            this.aquaGauge_accuracy.TabIndex = 7;
            this.aquaGauge_accuracy.ThresholdPercent = 0F;
            this.aquaGauge_accuracy.Value = 0F;
            // 
            // aquaGauge_epochs
            // 
            this.aquaGauge_epochs.BackColor = System.Drawing.Color.Transparent;
            this.aquaGauge_epochs.DialColor = System.Drawing.Color.Lavender;
            this.aquaGauge_epochs.DialText = "Epoch";
            this.aquaGauge_epochs.Dock = System.Windows.Forms.DockStyle.Left;
            this.aquaGauge_epochs.Glossiness = 11.36364F;
            this.aquaGauge_epochs.Location = new System.Drawing.Point(0, 0);
            this.aquaGauge_epochs.MaxValue = 30F;
            this.aquaGauge_epochs.MinValue = 0F;
            this.aquaGauge_epochs.Name = "aquaGauge_epochs";
            this.aquaGauge_epochs.RecommendedValue = 0F;
            this.aquaGauge_epochs.Size = new System.Drawing.Size(150, 150);
            this.aquaGauge_epochs.TabIndex = 6;
            this.aquaGauge_epochs.ThresholdPercent = 0F;
            this.aquaGauge_epochs.Value = 0F;
            // 
            // zoomPicBox1
            // 
            this.zoomPicBox1.AutoScroll = true;
            this.zoomPicBox1.AutoScrollMargin = new System.Drawing.Size(836, 208);
            this.zoomPicBox1.AutoScrollMinSize = new System.Drawing.Size(782, 408);
            this.zoomPicBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomPicBox1.Image = global::MnistViewer.Properties.Resources.algorithm;
            this.zoomPicBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.zoomPicBox1.Location = new System.Drawing.Point(0, 0);
            this.zoomPicBox1.Name = "zoomPicBox1";
            this.zoomPicBox1.Size = new System.Drawing.Size(796, 409);
            this.zoomPicBox1.TabIndex = 0;
            this.zoomPicBox1.Text = "zoomPicBox1";
            this.zoomPicBox1.Zoom = 1F;
            this.zoomPicBox1.Click += new System.EventHandler(this.zoomPicBox1_Click);
            // 
            // label_TrainingInProgress
            // 
            this.label_TrainingInProgress.AutoSize = true;
            this.label_TrainingInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TrainingInProgress.ForeColor = System.Drawing.Color.DarkRed;
            this.label_TrainingInProgress.Location = new System.Drawing.Point(117, 145);
            this.label_TrainingInProgress.Name = "label_TrainingInProgress";
            this.label_TrainingInProgress.Size = new System.Drawing.Size(199, 24);
            this.label_TrainingInProgress.TabIndex = 37;
            this.label_TrainingInProgress.Text = "Training in Progress";
            this.label_TrainingInProgress.Visible = false;
            // 
            // NetworkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 786);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "NetworkView";
            this.Text = "MNIST Network";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HiddenLayerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_OutputNeuronCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HiddenNeuronCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoomLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_learningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_batchSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_epochs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_currentImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartActivations)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_input)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private ZoomPicBox zoomPicBox1;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown_HiddenLayerCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_OutputNeuronCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_HiddenNeuronCount;
        private System.Windows.Forms.TextBox textBox_inputNeuronCount;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.CheckBox checkBox_Verbose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private AquaControls.AquaGauge aquaGauge_accuracy;
        private AquaControls.AquaGauge aquaGauge_epochs;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartActivations;
        private System.Windows.Forms.RichTextBox richTextBox_console;
        private System.Windows.Forms.CheckBox checkBox_shuffle;
        private AquaControls.AquaGauge aquaGauge_batch;
        private System.Windows.Forms.PictureBox pictureBox_input;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.Button button_loadNetwork;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button_SaveNetwork;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label_TrainingInProgress;
    }
}

