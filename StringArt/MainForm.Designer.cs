namespace StringArt
{
    partial class MainForm
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
            this.picturePanel = new System.Windows.Forms.Panel();
            this.canvas = new System.Windows.Forms.Panel();
            this.numberOfEdgePointsNumeric = new System.Windows.Forms.NumericUpDown();
            this.numberOfEdgePointsLbl = new System.Windows.Forms.Label();
            this.lineChangeLbl = new System.Windows.Forms.Label();
            this.lineChangeNumeric = new System.Windows.Forms.NumericUpDown();
            this.artBtn = new System.Windows.Forms.Button();
            this.saveLineDataBtn = new System.Windows.Forms.Button();
            this.updateImageBtn = new System.Windows.Forms.Button();
            this.stopArtBtn = new System.Windows.Forms.Button();
            this.clearArtBtn = new System.Windows.Forms.Button();
            this.randomizerLinesLbl = new System.Windows.Forms.Label();
            this.randomizerLinesNum = new System.Windows.Forms.NumericUpDown();
            this.chooseImageBtn = new System.Windows.Forms.Button();
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.loadLineDataBtn = new System.Windows.Forms.Button();
            this.firstComeFirstTakesRadioBtn = new System.Windows.Forms.RadioButton();
            this.algorithmGroupBox = new System.Windows.Forms.GroupBox();
            this.constantUpdateRadioBtn = new System.Windows.Forms.RadioButton();
            this.customSeedCheckBox = new System.Windows.Forms.CheckBox();
            this.bestFirstRadioBtn = new System.Windows.Forms.RadioButton();
            this.customSeedLbl = new System.Windows.Forms.Label();
            this.randomizerRadioBtn = new System.Windows.Forms.RadioButton();
            this.randomizerSeedNumeric = new System.Windows.Forms.NumericUpDown();
            this.createGifBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfEdgePointsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChangeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerLinesNum)).BeginInit();
            this.algorithmGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerSeedNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // picturePanel
            // 
            this.picturePanel.Location = new System.Drawing.Point(12, 12);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(600, 600);
            this.picturePanel.TabIndex = 0;
            this.picturePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PicturePanelPaint);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(618, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(600, 600);
            this.canvas.TabIndex = 1;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            // 
            // numberOfEdgePointsNumeric
            // 
            this.numberOfEdgePointsNumeric.Location = new System.Drawing.Point(1347, 17);
            this.numberOfEdgePointsNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numberOfEdgePointsNumeric.Name = "numberOfEdgePointsNumeric";
            this.numberOfEdgePointsNumeric.Size = new System.Drawing.Size(72, 20);
            this.numberOfEdgePointsNumeric.TabIndex = 2;
            this.numberOfEdgePointsNumeric.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numberOfEdgePointsNumeric.ValueChanged += new System.EventHandler(this.NumberOfEdgePointsNumericValueChanged);
            // 
            // numberOfEdgePointsLbl
            // 
            this.numberOfEdgePointsLbl.AutoSize = true;
            this.numberOfEdgePointsLbl.Location = new System.Drawing.Point(1224, 19);
            this.numberOfEdgePointsLbl.Name = "numberOfEdgePointsLbl";
            this.numberOfEdgePointsLbl.Size = new System.Drawing.Size(117, 13);
            this.numberOfEdgePointsLbl.TabIndex = 3;
            this.numberOfEdgePointsLbl.Text = "Number of edge points:";
            // 
            // lineChangeLbl
            // 
            this.lineChangeLbl.AutoSize = true;
            this.lineChangeLbl.Location = new System.Drawing.Point(1229, 50);
            this.lineChangeLbl.Name = "lineChangeLbl";
            this.lineChangeLbl.Size = new System.Drawing.Size(69, 13);
            this.lineChangeLbl.TabIndex = 5;
            this.lineChangeLbl.Text = "Line change:";
            // 
            // lineChangeNumeric
            // 
            this.lineChangeNumeric.Location = new System.Drawing.Point(1308, 48);
            this.lineChangeNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.lineChangeNumeric.Name = "lineChangeNumeric";
            this.lineChangeNumeric.Size = new System.Drawing.Size(56, 20);
            this.lineChangeNumeric.TabIndex = 4;
            this.lineChangeNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // artBtn
            // 
            this.artBtn.Location = new System.Drawing.Point(1237, 580);
            this.artBtn.Name = "artBtn";
            this.artBtn.Size = new System.Drawing.Size(61, 22);
            this.artBtn.TabIndex = 6;
            this.artBtn.Text = "Art!";
            this.artBtn.UseVisualStyleBackColor = true;
            this.artBtn.Click += new System.EventHandler(this.ArtBtnClick);
            // 
            // saveLineDataBtn
            // 
            this.saveLineDataBtn.Location = new System.Drawing.Point(756, 615);
            this.saveLineDataBtn.Name = "saveLineDataBtn";
            this.saveLineDataBtn.Size = new System.Drawing.Size(99, 23);
            this.saveLineDataBtn.TabIndex = 7;
            this.saveLineDataBtn.Text = "Save Line Data";
            this.saveLineDataBtn.UseVisualStyleBackColor = true;
            this.saveLineDataBtn.Click += new System.EventHandler(this.SaveLineDataBtnClick);
            // 
            // updateImageBtn
            // 
            this.updateImageBtn.Location = new System.Drawing.Point(618, 615);
            this.updateImageBtn.Name = "updateImageBtn";
            this.updateImageBtn.Size = new System.Drawing.Size(132, 23);
            this.updateImageBtn.TabIndex = 8;
            this.updateImageBtn.Text = "Update Image Display";
            this.updateImageBtn.UseVisualStyleBackColor = true;
            this.updateImageBtn.Click += new System.EventHandler(this.UpdateImageBtnClick);
            // 
            // stopArtBtn
            // 
            this.stopArtBtn.Location = new System.Drawing.Point(1304, 580);
            this.stopArtBtn.Name = "stopArtBtn";
            this.stopArtBtn.Size = new System.Drawing.Size(57, 23);
            this.stopArtBtn.TabIndex = 9;
            this.stopArtBtn.Text = "Stop Art";
            this.stopArtBtn.UseVisualStyleBackColor = true;
            this.stopArtBtn.Click += new System.EventHandler(this.StopArtBtn);
            // 
            // clearArtBtn
            // 
            this.clearArtBtn.Location = new System.Drawing.Point(1367, 579);
            this.clearArtBtn.Name = "clearArtBtn";
            this.clearArtBtn.Size = new System.Drawing.Size(57, 23);
            this.clearArtBtn.TabIndex = 10;
            this.clearArtBtn.Text = "Clear Art";
            this.clearArtBtn.UseVisualStyleBackColor = true;
            this.clearArtBtn.Click += new System.EventHandler(this.ClearArtBtnClick);
            // 
            // randomizerLinesLbl
            // 
            this.randomizerLinesLbl.AutoSize = true;
            this.randomizerLinesLbl.Location = new System.Drawing.Point(15, 71);
            this.randomizerLinesLbl.Name = "randomizerLinesLbl";
            this.randomizerLinesLbl.Size = new System.Drawing.Size(179, 39);
            this.randomizerLinesLbl.TabIndex = 12;
            this.randomizerLinesLbl.Text = "Number of lines to take \r\ninto considiration (more is slower but \r\nmay yield bett" +
    "er result)";
            // 
            // randomizerLinesNum
            // 
            this.randomizerLinesNum.Location = new System.Drawing.Point(13, 114);
            this.randomizerLinesNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.randomizerLinesNum.Name = "randomizerLinesNum";
            this.randomizerLinesNum.Size = new System.Drawing.Size(120, 20);
            this.randomizerLinesNum.TabIndex = 13;
            this.randomizerLinesNum.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // chooseImageBtn
            // 
            this.chooseImageBtn.Location = new System.Drawing.Point(12, 615);
            this.chooseImageBtn.Name = "chooseImageBtn";
            this.chooseImageBtn.Size = new System.Drawing.Size(86, 28);
            this.chooseImageBtn.TabIndex = 17;
            this.chooseImageBtn.Text = "Choose Image";
            this.chooseImageBtn.UseVisualStyleBackColor = true;
            this.chooseImageBtn.Click += new System.EventHandler(this.ChooseImage);
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.Location = new System.Drawing.Point(392, -12);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(0, 13);
            this.fileNameLbl.TabIndex = 18;
            // 
            // loadLineDataBtn
            // 
            this.loadLineDataBtn.Location = new System.Drawing.Point(861, 615);
            this.loadLineDataBtn.Name = "loadLineDataBtn";
            this.loadLineDataBtn.Size = new System.Drawing.Size(99, 23);
            this.loadLineDataBtn.TabIndex = 20;
            this.loadLineDataBtn.Text = "Load Line Data";
            this.loadLineDataBtn.UseVisualStyleBackColor = true;
            this.loadLineDataBtn.Click += new System.EventHandler(this.LoadLineDataBtnClick);
            // 
            // firstComeFirstTakesRadioBtn
            // 
            this.firstComeFirstTakesRadioBtn.AutoSize = true;
            this.firstComeFirstTakesRadioBtn.Location = new System.Drawing.Point(13, 19);
            this.firstComeFirstTakesRadioBtn.Name = "firstComeFirstTakesRadioBtn";
            this.firstComeFirstTakesRadioBtn.Size = new System.Drawing.Size(179, 17);
            this.firstComeFirstTakesRadioBtn.TabIndex = 21;
            this.firstComeFirstTakesRadioBtn.TabStop = true;
            this.firstComeFirstTakesRadioBtn.Text = "First come first take (fast but shit)";
            this.firstComeFirstTakesRadioBtn.UseVisualStyleBackColor = true;
            this.firstComeFirstTakesRadioBtn.CheckedChanged += new System.EventHandler(this.FirstComeFirstTakesRadioBtnCheckedChanged);
            // 
            // algorithmGroupBox
            // 
            this.algorithmGroupBox.Controls.Add(this.constantUpdateRadioBtn);
            this.algorithmGroupBox.Controls.Add(this.customSeedCheckBox);
            this.algorithmGroupBox.Controls.Add(this.bestFirstRadioBtn);
            this.algorithmGroupBox.Controls.Add(this.customSeedLbl);
            this.algorithmGroupBox.Controls.Add(this.randomizerRadioBtn);
            this.algorithmGroupBox.Controls.Add(this.firstComeFirstTakesRadioBtn);
            this.algorithmGroupBox.Controls.Add(this.randomizerSeedNumeric);
            this.algorithmGroupBox.Controls.Add(this.randomizerLinesLbl);
            this.algorithmGroupBox.Controls.Add(this.randomizerLinesNum);
            this.algorithmGroupBox.Location = new System.Drawing.Point(1224, 105);
            this.algorithmGroupBox.Name = "algorithmGroupBox";
            this.algorithmGroupBox.Size = new System.Drawing.Size(200, 327);
            this.algorithmGroupBox.TabIndex = 22;
            this.algorithmGroupBox.TabStop = false;
            this.algorithmGroupBox.Text = "Algorithm";
            // 
            // constantUpdateRadioBtn
            // 
            this.constantUpdateRadioBtn.AutoSize = true;
            this.constantUpdateRadioBtn.Location = new System.Drawing.Point(11, 176);
            this.constantUpdateRadioBtn.Name = "constantUpdateRadioBtn";
            this.constantUpdateRadioBtn.Size = new System.Drawing.Size(108, 17);
            this.constantUpdateRadioBtn.TabIndex = 24;
            this.constantUpdateRadioBtn.TabStop = true;
            this.constantUpdateRadioBtn.Text = "Constant Updater";
            this.constantUpdateRadioBtn.UseVisualStyleBackColor = true;
            this.constantUpdateRadioBtn.CheckedChanged += new System.EventHandler(this.ConstantUpdateRadioBtnCheckedChanged);
            // 
            // customSeedCheckBox
            // 
            this.customSeedCheckBox.AutoSize = true;
            this.customSeedCheckBox.Enabled = false;
            this.customSeedCheckBox.Location = new System.Drawing.Point(6, 270);
            this.customSeedCheckBox.Name = "customSeedCheckBox";
            this.customSeedCheckBox.Size = new System.Drawing.Size(111, 17);
            this.customSeedCheckBox.TabIndex = 15;
            this.customSeedCheckBox.Text = "Use Custom Seed";
            this.customSeedCheckBox.UseVisualStyleBackColor = true;
            this.customSeedCheckBox.CheckedChanged += new System.EventHandler(this.CustomSeedCheckBoxCheckedChanged);
            // 
            // bestFirstRadioBtn
            // 
            this.bestFirstRadioBtn.AutoSize = true;
            this.bestFirstRadioBtn.Location = new System.Drawing.Point(13, 140);
            this.bestFirstRadioBtn.Name = "bestFirstRadioBtn";
            this.bestFirstRadioBtn.Size = new System.Drawing.Size(139, 30);
            this.bestFirstRadioBtn.TabIndex = 23;
            this.bestFirstRadioBtn.TabStop = true;
            this.bestFirstRadioBtn.Text = "Best first (very good but \r\nEXTREMELY slow)\r\n";
            this.bestFirstRadioBtn.UseVisualStyleBackColor = true;
            this.bestFirstRadioBtn.CheckedChanged += new System.EventHandler(this.BestFirstRadioBtnCheckedChanged);
            // 
            // customSeedLbl
            // 
            this.customSeedLbl.AutoSize = true;
            this.customSeedLbl.Enabled = false;
            this.customSeedLbl.Location = new System.Drawing.Point(8, 295);
            this.customSeedLbl.Name = "customSeedLbl";
            this.customSeedLbl.Size = new System.Drawing.Size(73, 13);
            this.customSeedLbl.TabIndex = 16;
            this.customSeedLbl.Text = "Custom Seed:";
            // 
            // randomizerRadioBtn
            // 
            this.randomizerRadioBtn.AutoSize = true;
            this.randomizerRadioBtn.Location = new System.Drawing.Point(13, 51);
            this.randomizerRadioBtn.Name = "randomizerRadioBtn";
            this.randomizerRadioBtn.Size = new System.Drawing.Size(81, 17);
            this.randomizerRadioBtn.TabIndex = 22;
            this.randomizerRadioBtn.TabStop = true;
            this.randomizerRadioBtn.Text = "Randomizer";
            this.randomizerRadioBtn.UseVisualStyleBackColor = true;
            this.randomizerRadioBtn.CheckedChanged += new System.EventHandler(this.RandomizerRadioBtnCheckedChanged);
            // 
            // randomizerSeedNumeric
            // 
            this.randomizerSeedNumeric.Enabled = false;
            this.randomizerSeedNumeric.Location = new System.Drawing.Point(91, 293);
            this.randomizerSeedNumeric.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.randomizerSeedNumeric.Name = "randomizerSeedNumeric";
            this.randomizerSeedNumeric.Size = new System.Drawing.Size(99, 20);
            this.randomizerSeedNumeric.TabIndex = 14;
            // 
            // createGifBtn
            // 
            this.createGifBtn.Location = new System.Drawing.Point(976, 615);
            this.createGifBtn.Name = "createGifBtn";
            this.createGifBtn.Size = new System.Drawing.Size(75, 23);
            this.createGifBtn.TabIndex = 23;
            this.createGifBtn.Text = "Create Gif";
            this.createGifBtn.UseVisualStyleBackColor = true;
            this.createGifBtn.Click += new System.EventHandler(this.CreateGifBtnClick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(1442, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(187, 615);
            this.listBox1.TabIndex = 24;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1641, 647);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.createGifBtn);
            this.Controls.Add(this.algorithmGroupBox);
            this.Controls.Add(this.loadLineDataBtn);
            this.Controls.Add(this.fileNameLbl);
            this.Controls.Add(this.chooseImageBtn);
            this.Controls.Add(this.clearArtBtn);
            this.Controls.Add(this.stopArtBtn);
            this.Controls.Add(this.updateImageBtn);
            this.Controls.Add(this.saveLineDataBtn);
            this.Controls.Add(this.artBtn);
            this.Controls.Add(this.lineChangeLbl);
            this.Controls.Add(this.lineChangeNumeric);
            this.Controls.Add(this.numberOfEdgePointsLbl);
            this.Controls.Add(this.numberOfEdgePointsNumeric);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.picturePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "String Art";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfEdgePointsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChangeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerLinesNum)).EndInit();
            this.algorithmGroupBox.ResumeLayout(false);
            this.algorithmGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerSeedNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.NumericUpDown numberOfEdgePointsNumeric;
        private System.Windows.Forms.Label numberOfEdgePointsLbl;
        private System.Windows.Forms.Label lineChangeLbl;
        private System.Windows.Forms.NumericUpDown lineChangeNumeric;
        private System.Windows.Forms.Button artBtn;
        private System.Windows.Forms.Button saveLineDataBtn;
        private System.Windows.Forms.Button updateImageBtn;
        private System.Windows.Forms.Button stopArtBtn;
        private System.Windows.Forms.Button clearArtBtn;
        private System.Windows.Forms.Label randomizerLinesLbl;
        private System.Windows.Forms.NumericUpDown randomizerLinesNum;
        private System.Windows.Forms.Button chooseImageBtn;
        private System.Windows.Forms.Label fileNameLbl;
        private System.Windows.Forms.Button loadLineDataBtn;
        private System.Windows.Forms.RadioButton firstComeFirstTakesRadioBtn;
        private System.Windows.Forms.GroupBox algorithmGroupBox;
        private System.Windows.Forms.RadioButton bestFirstRadioBtn;
        private System.Windows.Forms.RadioButton randomizerRadioBtn;
        private System.Windows.Forms.CheckBox customSeedCheckBox;
        private System.Windows.Forms.Label customSeedLbl;
        private System.Windows.Forms.NumericUpDown randomizerSeedNumeric;
        private System.Windows.Forms.Button createGifBtn;
        private System.Windows.Forms.RadioButton constantUpdateRadioBtn;
        private System.Windows.Forms.ListBox listBox1;
    }
}

