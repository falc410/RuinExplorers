namespace CharacterEditorWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTexturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.animationsListBox = new System.Windows.Forms.ListBox();
            this.animationsDeletebutton = new System.Windows.Forms.Button();
            this.animationsEditbutton = new System.Windows.Forms.Button();
            this.animationsNametextBox = new System.Windows.Forms.TextBox();
            this.partListBox = new System.Windows.Forms.ListBox();
            this.partMoveUpButton = new System.Windows.Forms.Button();
            this.partMoveDownButton = new System.Windows.Forms.Button();
            this.partRotationUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.partResetRotationButton = new System.Windows.Forms.Button();
            this.partScaleXUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.partResetXScaleButton = new System.Windows.Forms.Button();
            this.partDeleteButton = new System.Windows.Forms.Button();
            this.partFlipCheckBox = new System.Windows.Forms.CheckBox();
            this.partScaleYUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.partResetYScaleButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.framesListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.framesAddReferenceButton = new System.Windows.Forms.Button();
            this.framesDeleteButton = new System.Windows.Forms.Button();
            this.framesEditButton = new System.Windows.Forms.Button();
            this.framesTextBox = new System.Windows.Forms.TextBox();
            this.keyFrameListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.keyFrameDurationUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.scriptsListBox = new System.Windows.Forms.ListBox();
            this.scriptsDeleteButton = new System.Windows.Forms.Button();
            this.scriptsEditButton = new System.Windows.Forms.Button();
            this.scriptsTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.characterEditorMain1 = new CharacterEditorWindows.CharacterEditorMain();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partRotationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partScaleXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partScaleYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyFrameDurationUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1140, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCharacterToolStripMenuItem,
            this.openCharacterToolStripMenuItem,
            this.saveCharacterToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.importTexturesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newCharacterToolStripMenuItem
            // 
            this.newCharacterToolStripMenuItem.Name = "newCharacterToolStripMenuItem";
            this.newCharacterToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newCharacterToolStripMenuItem.Text = "New Character";
            // 
            // openCharacterToolStripMenuItem
            // 
            this.openCharacterToolStripMenuItem.Name = "openCharacterToolStripMenuItem";
            this.openCharacterToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openCharacterToolStripMenuItem.Text = "&Open Character";
            this.openCharacterToolStripMenuItem.Click += new System.EventHandler(this.openCharacterToolStripMenuItem_Click);
            // 
            // saveCharacterToolStripMenuItem
            // 
            this.saveCharacterToolStripMenuItem.Name = "saveCharacterToolStripMenuItem";
            this.saveCharacterToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveCharacterToolStripMenuItem.Text = "&Save Character";
            this.saveCharacterToolStripMenuItem.Click += new System.EventHandler(this.saveCharacterToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // importTexturesToolStripMenuItem
            // 
            this.importTexturesToolStripMenuItem.Name = "importTexturesToolStripMenuItem";
            this.importTexturesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.importTexturesToolStripMenuItem.Text = "&Import Textures";
            this.importTexturesToolStripMenuItem.Click += new System.EventHandler(this.importTexturesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // animationsListBox
            // 
            this.animationsListBox.FormattingEnabled = true;
            this.animationsListBox.Location = new System.Drawing.Point(820, 28);
            this.animationsListBox.Name = "animationsListBox";
            this.animationsListBox.Size = new System.Drawing.Size(120, 95);
            this.animationsListBox.TabIndex = 3;
            this.animationsListBox.SelectedIndexChanged += new System.EventHandler(this.animationsListBox_SelectedIndexChanged);
            // 
            // animationsDeletebutton
            // 
            this.animationsDeletebutton.Image = ((System.Drawing.Image)(resources.GetObject("animationsDeletebutton.Image")));
            this.animationsDeletebutton.Location = new System.Drawing.Point(1078, 27);
            this.animationsDeletebutton.Name = "animationsDeletebutton";
            this.animationsDeletebutton.Size = new System.Drawing.Size(20, 20);
            this.animationsDeletebutton.TabIndex = 6;
            this.animationsDeletebutton.UseVisualStyleBackColor = true;
            this.animationsDeletebutton.Click += new System.EventHandler(this.animationsDeletebutton_Click);
            // 
            // animationsEditbutton
            // 
            this.animationsEditbutton.Image = ((System.Drawing.Image)(resources.GetObject("animationsEditbutton.Image")));
            this.animationsEditbutton.Location = new System.Drawing.Point(1052, 27);
            this.animationsEditbutton.Name = "animationsEditbutton";
            this.animationsEditbutton.Size = new System.Drawing.Size(20, 20);
            this.animationsEditbutton.TabIndex = 8;
            this.animationsEditbutton.UseVisualStyleBackColor = true;
            this.animationsEditbutton.Click += new System.EventHandler(this.animationsEditbutton_Click);
            // 
            // animationsNametextBox
            // 
            this.animationsNametextBox.Location = new System.Drawing.Point(946, 28);
            this.animationsNametextBox.Name = "animationsNametextBox";
            this.animationsNametextBox.Size = new System.Drawing.Size(100, 20);
            this.animationsNametextBox.TabIndex = 9;
            this.animationsNametextBox.TextChanged += new System.EventHandler(this.animationsNametextBox_TextChanged);
            // 
            // partListBox
            // 
            this.partListBox.FormattingEnabled = true;
            this.partListBox.Location = new System.Drawing.Point(820, 149);
            this.partListBox.Name = "partListBox";
            this.partListBox.Size = new System.Drawing.Size(120, 121);
            this.partListBox.TabIndex = 11;
            this.partListBox.SelectedIndexChanged += new System.EventHandler(this.partListBox_SelectedIndexChanged);
            // 
            // partMoveUpButton
            // 
            this.partMoveUpButton.Location = new System.Drawing.Point(946, 149);
            this.partMoveUpButton.Name = "partMoveUpButton";
            this.partMoveUpButton.Size = new System.Drawing.Size(75, 23);
            this.partMoveUpButton.TabIndex = 12;
            this.partMoveUpButton.Text = "Move Up";
            this.partMoveUpButton.UseVisualStyleBackColor = true;
            this.partMoveUpButton.Click += new System.EventHandler(this.partMoveUpButton_Click);
            // 
            // partMoveDownButton
            // 
            this.partMoveDownButton.Location = new System.Drawing.Point(1027, 149);
            this.partMoveDownButton.Name = "partMoveDownButton";
            this.partMoveDownButton.Size = new System.Drawing.Size(75, 23);
            this.partMoveDownButton.TabIndex = 12;
            this.partMoveDownButton.Text = "Move Down";
            this.partMoveDownButton.UseVisualStyleBackColor = true;
            this.partMoveDownButton.Click += new System.EventHandler(this.partMoveDownButton_Click);
            // 
            // partRotationUpDown
            // 
            this.partRotationUpDown.Location = new System.Drawing.Point(946, 188);
            this.partRotationUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.partRotationUpDown.Name = "partRotationUpDown";
            this.partRotationUpDown.Size = new System.Drawing.Size(39, 20);
            this.partRotationUpDown.TabIndex = 13;
            this.partRotationUpDown.ValueChanged += new System.EventHandler(this.partRotationUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(991, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Rotation";
            // 
            // partResetRotationButton
            // 
            this.partResetRotationButton.Image = ((System.Drawing.Image)(resources.GetObject("partResetRotationButton.Image")));
            this.partResetRotationButton.Location = new System.Drawing.Point(1052, 186);
            this.partResetRotationButton.Name = "partResetRotationButton";
            this.partResetRotationButton.Size = new System.Drawing.Size(20, 20);
            this.partResetRotationButton.TabIndex = 15;
            this.partResetRotationButton.UseVisualStyleBackColor = true;
            this.partResetRotationButton.Click += new System.EventHandler(this.partResetRotationButton_Click);
            // 
            // partScaleXUpDown
            // 
            this.partScaleXUpDown.Location = new System.Drawing.Point(946, 217);
            this.partScaleXUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.partScaleXUpDown.Name = "partScaleXUpDown";
            this.partScaleXUpDown.Size = new System.Drawing.Size(39, 20);
            this.partScaleXUpDown.TabIndex = 13;
            this.partScaleXUpDown.ValueChanged += new System.EventHandler(this.partScaleXUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(991, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "x-Scale";
            // 
            // partResetXScaleButton
            // 
            this.partResetXScaleButton.Image = ((System.Drawing.Image)(resources.GetObject("partResetXScaleButton.Image")));
            this.partResetXScaleButton.Location = new System.Drawing.Point(1052, 215);
            this.partResetXScaleButton.Name = "partResetXScaleButton";
            this.partResetXScaleButton.Size = new System.Drawing.Size(20, 20);
            this.partResetXScaleButton.TabIndex = 15;
            this.partResetXScaleButton.UseVisualStyleBackColor = true;
            this.partResetXScaleButton.Click += new System.EventHandler(this.partResetXScaleButton_Click);
            // 
            // partDeleteButton
            // 
            this.partDeleteButton.Location = new System.Drawing.Point(1027, 267);
            this.partDeleteButton.Name = "partDeleteButton";
            this.partDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.partDeleteButton.TabIndex = 16;
            this.partDeleteButton.Text = "Delete";
            this.partDeleteButton.UseVisualStyleBackColor = true;
            this.partDeleteButton.Click += new System.EventHandler(this.partDeleteButton_Click);
            // 
            // partFlipCheckBox
            // 
            this.partFlipCheckBox.AutoSize = true;
            this.partFlipCheckBox.Location = new System.Drawing.Point(946, 267);
            this.partFlipCheckBox.Name = "partFlipCheckBox";
            this.partFlipCheckBox.Size = new System.Drawing.Size(64, 17);
            this.partFlipCheckBox.TabIndex = 17;
            this.partFlipCheckBox.Text = "Flip Part";
            this.partFlipCheckBox.UseVisualStyleBackColor = true;
            this.partFlipCheckBox.CheckedChanged += new System.EventHandler(this.partFlipCheckBox_CheckedChanged);
            // 
            // partScaleYUpDown
            // 
            this.partScaleYUpDown.Location = new System.Drawing.Point(946, 243);
            this.partScaleYUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.partScaleYUpDown.Name = "partScaleYUpDown";
            this.partScaleYUpDown.Size = new System.Drawing.Size(39, 20);
            this.partScaleYUpDown.TabIndex = 13;
            this.partScaleYUpDown.ValueChanged += new System.EventHandler(this.partScaleYUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(991, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "y-Scale";
            // 
            // partResetYScaleButton
            // 
            this.partResetYScaleButton.Image = ((System.Drawing.Image)(resources.GetObject("partResetYScaleButton.Image")));
            this.partResetYScaleButton.Location = new System.Drawing.Point(1052, 241);
            this.partResetYScaleButton.Name = "partResetYScaleButton";
            this.partResetYScaleButton.Size = new System.Drawing.Size(20, 20);
            this.partResetYScaleButton.TabIndex = 15;
            this.partResetYScaleButton.UseVisualStyleBackColor = true;
            this.partResetYScaleButton.Click += new System.EventHandler(this.partResetYScaleButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(820, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Animations";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(820, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Parts";
            // 
            // framesListBox
            // 
            this.framesListBox.FormattingEnabled = true;
            this.framesListBox.Location = new System.Drawing.Point(820, 302);
            this.framesListBox.Name = "framesListBox";
            this.framesListBox.Size = new System.Drawing.Size(120, 186);
            this.framesListBox.TabIndex = 21;
            this.framesListBox.SelectedIndexChanged += new System.EventHandler(this.framesListBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(820, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Frames";
            // 
            // framesAddReferenceButton
            // 
            this.framesAddReferenceButton.Location = new System.Drawing.Point(946, 338);
            this.framesAddReferenceButton.Name = "framesAddReferenceButton";
            this.framesAddReferenceButton.Size = new System.Drawing.Size(102, 23);
            this.framesAddReferenceButton.TabIndex = 23;
            this.framesAddReferenceButton.Text = "Add to KeyFrame";
            this.framesAddReferenceButton.UseVisualStyleBackColor = true;
            this.framesAddReferenceButton.Click += new System.EventHandler(this.framesAddReferenceButton_Click);
            // 
            // framesDeleteButton
            // 
            this.framesDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("framesDeleteButton.Image")));
            this.framesDeleteButton.Location = new System.Drawing.Point(1078, 302);
            this.framesDeleteButton.Name = "framesDeleteButton";
            this.framesDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.framesDeleteButton.TabIndex = 6;
            this.framesDeleteButton.UseVisualStyleBackColor = true;
            this.framesDeleteButton.Click += new System.EventHandler(this.framesDeletebutton_Click);
            // 
            // framesEditButton
            // 
            this.framesEditButton.Image = ((System.Drawing.Image)(resources.GetObject("framesEditButton.Image")));
            this.framesEditButton.Location = new System.Drawing.Point(1052, 302);
            this.framesEditButton.Name = "framesEditButton";
            this.framesEditButton.Size = new System.Drawing.Size(20, 20);
            this.framesEditButton.TabIndex = 8;
            this.framesEditButton.UseVisualStyleBackColor = true;
            this.framesEditButton.Click += new System.EventHandler(this.framesEditbutton_Click);
            // 
            // framesTextBox
            // 
            this.framesTextBox.Location = new System.Drawing.Point(946, 303);
            this.framesTextBox.Name = "framesTextBox";
            this.framesTextBox.Size = new System.Drawing.Size(100, 20);
            this.framesTextBox.TabIndex = 9;
            this.framesTextBox.TextChanged += new System.EventHandler(this.framesNametextBox_TextChanged);
            // 
            // keyFrameListBox
            // 
            this.keyFrameListBox.FormattingEnabled = true;
            this.keyFrameListBox.Location = new System.Drawing.Point(1008, 386);
            this.keyFrameListBox.Name = "keyFrameListBox";
            this.keyFrameListBox.Size = new System.Drawing.Size(120, 95);
            this.keyFrameListBox.TabIndex = 24;
            this.keyFrameListBox.SelectedIndexChanged += new System.EventHandler(this.keyFrameListBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1069, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "KeyFrames";
            // 
            // keyFrameDurationUpDown
            // 
            this.keyFrameDurationUpDown.Location = new System.Drawing.Point(1027, 487);
            this.keyFrameDurationUpDown.Name = "keyFrameDurationUpDown";
            this.keyFrameDurationUpDown.Size = new System.Drawing.Size(38, 20);
            this.keyFrameDurationUpDown.TabIndex = 26;
            this.keyFrameDurationUpDown.ValueChanged += new System.EventHandler(this.keyFrameDurationUpDown_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1071, 489);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Duration";
            // 
            // scriptsListBox
            // 
            this.scriptsListBox.FormattingEnabled = true;
            this.scriptsListBox.Location = new System.Drawing.Point(820, 532);
            this.scriptsListBox.Name = "scriptsListBox";
            this.scriptsListBox.Size = new System.Drawing.Size(120, 95);
            this.scriptsListBox.TabIndex = 28;
            this.scriptsListBox.SelectedIndexChanged += new System.EventHandler(this.scriptsListBox_SelectedIndexChanged);
            // 
            // scriptsDeleteButton
            // 
            this.scriptsDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("scriptsDeleteButton.Image")));
            this.scriptsDeleteButton.Location = new System.Drawing.Point(1080, 531);
            this.scriptsDeleteButton.Name = "scriptsDeleteButton";
            this.scriptsDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.scriptsDeleteButton.TabIndex = 6;
            this.scriptsDeleteButton.UseVisualStyleBackColor = true;
            this.scriptsDeleteButton.Click += new System.EventHandler(this.scriptsDeletebutton_Click);
            // 
            // scriptsEditButton
            // 
            this.scriptsEditButton.Image = ((System.Drawing.Image)(resources.GetObject("scriptsEditButton.Image")));
            this.scriptsEditButton.Location = new System.Drawing.Point(1054, 531);
            this.scriptsEditButton.Name = "scriptsEditButton";
            this.scriptsEditButton.Size = new System.Drawing.Size(20, 20);
            this.scriptsEditButton.TabIndex = 8;
            this.scriptsEditButton.UseVisualStyleBackColor = true;
            this.scriptsEditButton.Click += new System.EventHandler(this.scriptsEditbutton_Click);
            // 
            // scriptsTextBox
            // 
            this.scriptsTextBox.Location = new System.Drawing.Point(948, 532);
            this.scriptsTextBox.Name = "scriptsTextBox";
            this.scriptsTextBox.Size = new System.Drawing.Size(100, 20);
            this.scriptsTextBox.TabIndex = 9;
            this.scriptsTextBox.TextChanged += new System.EventHandler(this.scriptsNametextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(820, 513);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Scripts";
            // 
            // characterEditorMain1
            // 
            this.characterEditorMain1.Location = new System.Drawing.Point(13, 27);
            this.characterEditorMain1.Name = "characterEditorMain1";
            this.characterEditorMain1.SelectedAnimation = 0;
            this.characterEditorMain1.SelectedFrame = 0;
            this.characterEditorMain1.SelectedPart = 0;
            this.characterEditorMain1.Size = new System.Drawing.Size(800, 600);
            this.characterEditorMain1.TabIndex = 30;
            this.characterEditorMain1.Text = "characterEditorMain1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 662);
            this.Controls.Add(this.characterEditorMain1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.scriptsListBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.keyFrameDurationUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.keyFrameListBox);
            this.Controls.Add(this.framesAddReferenceButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.framesListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.partFlipCheckBox);
            this.Controls.Add(this.partDeleteButton);
            this.Controls.Add(this.partResetYScaleButton);
            this.Controls.Add(this.partResetXScaleButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.partResetRotationButton);
            this.Controls.Add(this.partScaleYUpDown);
            this.Controls.Add(this.partScaleXUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.partRotationUpDown);
            this.Controls.Add(this.partMoveDownButton);
            this.Controls.Add(this.partMoveUpButton);
            this.Controls.Add(this.partListBox);
            this.Controls.Add(this.scriptsTextBox);
            this.Controls.Add(this.framesTextBox);
            this.Controls.Add(this.scriptsEditButton);
            this.Controls.Add(this.animationsNametextBox);
            this.Controls.Add(this.scriptsDeleteButton);
            this.Controls.Add(this.framesEditButton);
            this.Controls.Add(this.framesDeleteButton);
            this.Controls.Add(this.animationsEditbutton);
            this.Controls.Add(this.animationsDeletebutton);
            this.Controls.Add(this.animationsListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Character Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partRotationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partScaleXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partScaleYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyFrameDurationUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importTexturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListBox animationsListBox;
        
        private System.Windows.Forms.Button animationsDeletebutton;
        
        private System.Windows.Forms.Button animationsEditbutton;
        private System.Windows.Forms.TextBox animationsNametextBox;
        
        private System.Windows.Forms.ListBox partListBox;
        private System.Windows.Forms.Button partMoveUpButton;
        private System.Windows.Forms.Button partMoveDownButton;
        private System.Windows.Forms.NumericUpDown partRotationUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button partResetRotationButton;
        private System.Windows.Forms.NumericUpDown partScaleXUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button partResetXScaleButton;
        private System.Windows.Forms.Button partDeleteButton;
        private System.Windows.Forms.CheckBox partFlipCheckBox;
        
        private System.Windows.Forms.NumericUpDown partScaleYUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button partResetYScaleButton;
        private System.Windows.Forms.ToolStripMenuItem newCharacterToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox framesListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button framesAddReferenceButton;
        private System.Windows.Forms.Button framesDeleteButton;
        private System.Windows.Forms.Button framesEditButton;
        private System.Windows.Forms.TextBox framesTextBox;
        private System.Windows.Forms.ListBox keyFrameListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown keyFrameDurationUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox scriptsListBox;
        private System.Windows.Forms.Button scriptsDeleteButton;
        private System.Windows.Forms.Button scriptsEditButton;
        private System.Windows.Forms.TextBox scriptsTextBox;
        private System.Windows.Forms.Label label9;
        private CharacterEditorMain characterEditorMain1;
        
    }
}

