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
            this.startBtn = new System.Windows.Forms.Button();
            this.saveLineDataBtn = new System.Windows.Forms.Button();
            this.updateImageBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
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
            this.inputImgLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.parametersGroupBox = new System.Windows.Forms.GroupBox();
            this.autoUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.msUpDown = new System.Windows.Forms.NumericUpDown();
            this.msLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfEdgePointsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChangeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerLinesNum)).BeginInit();
            this.algorithmGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerSeedNumeric)).BeginInit();
            this.parametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // picturePanel
            // 
            this.picturePanel.Location = new System.Drawing.Point(298, 34);
            this.picturePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(700, 700);
            this.picturePanel.TabIndex = 0;
            this.picturePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PicturePanelPaint);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(1022, 34);
            this.canvas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(700, 700);
            this.canvas.TabIndex = 1;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            // 
            // numberOfEdgePointsNumeric
            // 
            this.numberOfEdgePointsNumeric.Location = new System.Drawing.Point(165, 32);
            this.numberOfEdgePointsNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numberOfEdgePointsNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numberOfEdgePointsNumeric.Name = "numberOfEdgePointsNumeric";
            this.numberOfEdgePointsNumeric.Size = new System.Drawing.Size(72, 25);
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
            this.numberOfEdgePointsLbl.Location = new System.Drawing.Point(7, 34);
            this.numberOfEdgePointsLbl.Name = "numberOfEdgePointsLbl";
            this.numberOfEdgePointsLbl.Size = new System.Drawing.Size(153, 17);
            this.numberOfEdgePointsLbl.TabIndex = 3;
            this.numberOfEdgePointsLbl.Text = "Circle edge points count:";
            // 
            // lineChangeLbl
            // 
            this.lineChangeLbl.AutoSize = true;
            this.lineChangeLbl.Location = new System.Drawing.Point(7, 73);
            this.lineChangeLbl.Name = "lineChangeLbl";
            this.lineChangeLbl.Size = new System.Drawing.Size(158, 17);
            this.lineChangeLbl.TabIndex = 5;
            this.lineChangeLbl.Text = "Line change (alpha value):";
            // 
            // lineChangeNumeric
            // 
            this.lineChangeNumeric.Location = new System.Drawing.Point(165, 70);
            this.lineChangeNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lineChangeNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.lineChangeNumeric.Name = "lineChangeNumeric";
            this.lineChangeNumeric.Size = new System.Drawing.Size(72, 25);
            this.lineChangeNumeric.TabIndex = 4;
            this.lineChangeNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(20, 614);
            this.startBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(71, 29);
            this.startBtn.TabIndex = 6;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.ArtBtnClick);
            // 
            // saveLineDataBtn
            // 
            this.saveLineDataBtn.Location = new System.Drawing.Point(25, 706);
            this.saveLineDataBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveLineDataBtn.Name = "saveLineDataBtn";
            this.saveLineDataBtn.Size = new System.Drawing.Size(115, 30);
            this.saveLineDataBtn.TabIndex = 7;
            this.saveLineDataBtn.Text = "Save Line Data";
            this.saveLineDataBtn.UseVisualStyleBackColor = true;
            this.saveLineDataBtn.Click += new System.EventHandler(this.SaveLineDataBtnClick);
            // 
            // updateImageBtn
            // 
            this.updateImageBtn.Location = new System.Drawing.Point(56, 658);
            this.updateImageBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updateImageBtn.Name = "updateImageBtn";
            this.updateImageBtn.Size = new System.Drawing.Size(154, 35);
            this.updateImageBtn.TabIndex = 8;
            this.updateImageBtn.Text = "Update Image Display";
            this.updateImageBtn.UseVisualStyleBackColor = true;
            this.updateImageBtn.Click += new System.EventHandler(this.UpdateImageBtnClick);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(101, 614);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(66, 30);
            this.stopBtn.TabIndex = 9;
            this.stopBtn.Text = "Stop ";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.StopArtBtn);
            // 
            // clearArtBtn
            // 
            this.clearArtBtn.Location = new System.Drawing.Point(173, 614);
            this.clearArtBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clearArtBtn.Name = "clearArtBtn";
            this.clearArtBtn.Size = new System.Drawing.Size(66, 30);
            this.clearArtBtn.TabIndex = 10;
            this.clearArtBtn.Text = "Clear Art";
            this.clearArtBtn.UseVisualStyleBackColor = true;
            this.clearArtBtn.Click += new System.EventHandler(this.ClearArtBtnClick);
            // 
            // randomizerLinesLbl
            // 
            this.randomizerLinesLbl.AutoSize = true;
            this.randomizerLinesLbl.Location = new System.Drawing.Point(17, 88);
            this.randomizerLinesLbl.Name = "randomizerLinesLbl";
            this.randomizerLinesLbl.Size = new System.Drawing.Size(230, 51);
            this.randomizerLinesLbl.TabIndex = 12;
            this.randomizerLinesLbl.Text = "Number of lines to take \r\ninto considiration (more is slower but \r\nmay yield bett" +
    "er result)";
            // 
            // randomizerLinesNum
            // 
            this.randomizerLinesNum.Location = new System.Drawing.Point(15, 144);
            this.randomizerLinesNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.randomizerLinesNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.randomizerLinesNum.Name = "randomizerLinesNum";
            this.randomizerLinesNum.Size = new System.Drawing.Size(140, 25);
            this.randomizerLinesNum.TabIndex = 13;
            this.randomizerLinesNum.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // chooseImageBtn
            // 
            this.chooseImageBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chooseImageBtn.Location = new System.Drawing.Point(25, 9);
            this.chooseImageBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chooseImageBtn.Name = "chooseImageBtn";
            this.chooseImageBtn.Size = new System.Drawing.Size(75, 48);
            this.chooseImageBtn.TabIndex = 17;
            this.chooseImageBtn.Text = "Load Image";
            this.chooseImageBtn.UseVisualStyleBackColor = true;
            this.chooseImageBtn.Click += new System.EventHandler(this.ChooseImage);
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.Location = new System.Drawing.Point(457, -16);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(0, 17);
            this.fileNameLbl.TabIndex = 18;
            // 
            // loadLineDataBtn
            // 
            this.loadLineDataBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.loadLineDataBtn.Location = new System.Drawing.Point(124, 9);
            this.loadLineDataBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loadLineDataBtn.Name = "loadLineDataBtn";
            this.loadLineDataBtn.Size = new System.Drawing.Size(131, 48);
            this.loadLineDataBtn.TabIndex = 20;
            this.loadLineDataBtn.Text = "Load Line Data (*.Tart file)";
            this.loadLineDataBtn.UseVisualStyleBackColor = true;
            this.loadLineDataBtn.Click += new System.EventHandler(this.LoadLineDataBtnClick);
            // 
            // firstComeFirstTakesRadioBtn
            // 
            this.firstComeFirstTakesRadioBtn.AutoSize = true;
            this.firstComeFirstTakesRadioBtn.Location = new System.Drawing.Point(15, 25);
            this.firstComeFirstTakesRadioBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.firstComeFirstTakesRadioBtn.Name = "firstComeFirstTakesRadioBtn";
            this.firstComeFirstTakesRadioBtn.Size = new System.Drawing.Size(220, 21);
            this.firstComeFirstTakesRadioBtn.TabIndex = 21;
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
            this.algorithmGroupBox.Location = new System.Drawing.Point(20, 73);
            this.algorithmGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.algorithmGroupBox.Name = "algorithmGroupBox";
            this.algorithmGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.algorithmGroupBox.Size = new System.Drawing.Size(256, 339);
            this.algorithmGroupBox.TabIndex = 22;
            this.algorithmGroupBox.TabStop = false;
            this.algorithmGroupBox.Text = "Algorithm Selection";
            // 
            // constantUpdateRadioBtn
            // 
            this.constantUpdateRadioBtn.AutoSize = true;
            this.constantUpdateRadioBtn.Location = new System.Drawing.Point(15, 225);
            this.constantUpdateRadioBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.constantUpdateRadioBtn.Name = "constantUpdateRadioBtn";
            this.constantUpdateRadioBtn.Size = new System.Drawing.Size(129, 21);
            this.constantUpdateRadioBtn.TabIndex = 24;
            this.constantUpdateRadioBtn.Text = "Constant Updater";
            this.constantUpdateRadioBtn.UseVisualStyleBackColor = true;
            this.constantUpdateRadioBtn.CheckedChanged += new System.EventHandler(this.ConstantUpdateRadioBtnCheckedChanged);
            // 
            // customSeedCheckBox
            // 
            this.customSeedCheckBox.AutoSize = true;
            this.customSeedCheckBox.Enabled = false;
            this.customSeedCheckBox.Location = new System.Drawing.Point(10, 274);
            this.customSeedCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customSeedCheckBox.Name = "customSeedCheckBox";
            this.customSeedCheckBox.Size = new System.Drawing.Size(138, 21);
            this.customSeedCheckBox.TabIndex = 15;
            this.customSeedCheckBox.Text = "Use a custom seed";
            this.customSeedCheckBox.UseVisualStyleBackColor = true;
            this.customSeedCheckBox.CheckedChanged += new System.EventHandler(this.CustomSeedCheckBoxCheckedChanged);
            // 
            // bestFirstRadioBtn
            // 
            this.bestFirstRadioBtn.AutoSize = true;
            this.bestFirstRadioBtn.Location = new System.Drawing.Point(15, 178);
            this.bestFirstRadioBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bestFirstRadioBtn.Name = "bestFirstRadioBtn";
            this.bestFirstRadioBtn.Size = new System.Drawing.Size(171, 38);
            this.bestFirstRadioBtn.TabIndex = 23;
            this.bestFirstRadioBtn.Text = "Best first (very good but \r\nEXTREMELY slow)\r\n";
            this.bestFirstRadioBtn.UseVisualStyleBackColor = true;
            this.bestFirstRadioBtn.CheckedChanged += new System.EventHandler(this.BestFirstRadioBtnCheckedChanged);
            // 
            // customSeedLbl
            // 
            this.customSeedLbl.AutoSize = true;
            this.customSeedLbl.Enabled = false;
            this.customSeedLbl.Location = new System.Drawing.Point(14, 305);
            this.customSeedLbl.Name = "customSeedLbl";
            this.customSeedLbl.Size = new System.Drawing.Size(88, 17);
            this.customSeedLbl.TabIndex = 16;
            this.customSeedLbl.Text = "Custom Seed:";
            // 
            // randomizerRadioBtn
            // 
            this.randomizerRadioBtn.AutoSize = true;
            this.randomizerRadioBtn.Location = new System.Drawing.Point(15, 62);
            this.randomizerRadioBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.randomizerRadioBtn.Name = "randomizerRadioBtn";
            this.randomizerRadioBtn.Size = new System.Drawing.Size(96, 21);
            this.randomizerRadioBtn.TabIndex = 22;
            this.randomizerRadioBtn.Text = "Randomizer";
            this.randomizerRadioBtn.UseVisualStyleBackColor = true;
            this.randomizerRadioBtn.CheckedChanged += new System.EventHandler(this.RandomizerRadioBtnCheckedChanged);
            // 
            // randomizerSeedNumeric
            // 
            this.randomizerSeedNumeric.Enabled = false;
            this.randomizerSeedNumeric.Location = new System.Drawing.Point(111, 302);
            this.randomizerSeedNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.randomizerSeedNumeric.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.randomizerSeedNumeric.Name = "randomizerSeedNumeric";
            this.randomizerSeedNumeric.Size = new System.Drawing.Size(115, 25);
            this.randomizerSeedNumeric.TabIndex = 14;
            // 
            // createGifBtn
            // 
            this.createGifBtn.Location = new System.Drawing.Point(152, 706);
            this.createGifBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.createGifBtn.Name = "createGifBtn";
            this.createGifBtn.Size = new System.Drawing.Size(87, 30);
            this.createGifBtn.TabIndex = 23;
            this.createGifBtn.Text = "Create Gif";
            this.createGifBtn.UseVisualStyleBackColor = true;
            this.createGifBtn.Click += new System.EventHandler(this.CreateGifBtnClick);
            // 
            // inputImgLbl
            // 
            this.inputImgLbl.AutoSize = true;
            this.inputImgLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.inputImgLbl.Location = new System.Drawing.Point(560, 4);
            this.inputImgLbl.Name = "inputImgLbl";
            this.inputImgLbl.Size = new System.Drawing.Size(121, 25);
            this.inputImgLbl.TabIndex = 24;
            this.inputImgLbl.Text = "Input Image";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(1303, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "String Art Image";
            // 
            // parametersGroupBox
            // 
            this.parametersGroupBox.Controls.Add(this.numberOfEdgePointsLbl);
            this.parametersGroupBox.Controls.Add(this.numberOfEdgePointsNumeric);
            this.parametersGroupBox.Controls.Add(this.lineChangeNumeric);
            this.parametersGroupBox.Controls.Add(this.lineChangeLbl);
            this.parametersGroupBox.Location = new System.Drawing.Point(20, 423);
            this.parametersGroupBox.Name = "parametersGroupBox";
            this.parametersGroupBox.Size = new System.Drawing.Size(256, 100);
            this.parametersGroupBox.TabIndex = 26;
            this.parametersGroupBox.TabStop = false;
            this.parametersGroupBox.Text = "Parameters";
            // 
            // autoUpdateCheckBox
            // 
            this.autoUpdateCheckBox.AutoSize = true;
            this.autoUpdateCheckBox.Location = new System.Drawing.Point(20, 540);
            this.autoUpdateCheckBox.Name = "autoUpdateCheckBox";
            this.autoUpdateCheckBox.Size = new System.Drawing.Size(190, 21);
            this.autoUpdateCheckBox.TabIndex = 27;
            this.autoUpdateCheckBox.Text = "Update image display every";
            this.autoUpdateCheckBox.UseVisualStyleBackColor = true;
            this.autoUpdateCheckBox.CheckedChanged += new System.EventHandler(this.AutoUpdateCheckBoxCheckedChanged);
            // 
            // msUpDown
            // 
            this.msUpDown.Location = new System.Drawing.Point(40, 568);
            this.msUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.msUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.msUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.msUpDown.Name = "msUpDown";
            this.msUpDown.Size = new System.Drawing.Size(72, 25);
            this.msUpDown.TabIndex = 6;
            this.msUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // msLbl
            // 
            this.msLbl.AutoSize = true;
            this.msLbl.Location = new System.Drawing.Point(116, 572);
            this.msLbl.Name = "msLbl";
            this.msLbl.Size = new System.Drawing.Size(79, 17);
            this.msLbl.TabIndex = 28;
            this.msLbl.Text = "milliseconds";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1751, 749);
            this.Controls.Add(this.msLbl);
            this.Controls.Add(this.msUpDown);
            this.Controls.Add(this.autoUpdateCheckBox);
            this.Controls.Add(this.parametersGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputImgLbl);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.createGifBtn);
            this.Controls.Add(this.algorithmGroupBox);
            this.Controls.Add(this.loadLineDataBtn);
            this.Controls.Add(this.fileNameLbl);
            this.Controls.Add(this.chooseImageBtn);
            this.Controls.Add(this.clearArtBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.updateImageBtn);
            this.Controls.Add(this.saveLineDataBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.picturePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "String Art";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfEdgePointsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChangeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerLinesNum)).EndInit();
            this.algorithmGroupBox.ResumeLayout(false);
            this.algorithmGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerSeedNumeric)).EndInit();
            this.parametersGroupBox.ResumeLayout(false);
            this.parametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msUpDown)).EndInit();
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
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button saveLineDataBtn;
        private System.Windows.Forms.Button updateImageBtn;
        private System.Windows.Forms.Button stopBtn;
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
        private System.Windows.Forms.Label inputImgLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox parametersGroupBox;
        private System.Windows.Forms.CheckBox autoUpdateCheckBox;
        private System.Windows.Forms.NumericUpDown msUpDown;
        private System.Windows.Forms.Label msLbl;
    }
}

