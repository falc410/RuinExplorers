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
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.headPreview = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.weaponsPreview = new System.Windows.Forms.PictureBox();
            this.availableWeaponsParts = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.addHeadButton = new System.Windows.Forms.Button();
            this.addWeaponButton = new System.Windows.Forms.Button();
            this.torsoPreview = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.addTorsoButton = new System.Windows.Forms.Button();
            this.legsPreview = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.addLegsButton = new System.Windows.Forms.Button();
            this.availableHeadParts = new System.Windows.Forms.ListBox();
            this.availableTorsoParts = new System.Windows.Forms.ListBox();
            this.availableLegsParts = new System.Windows.Forms.ListBox();
            this.characterEditorMain1 = new CharacterEditorWindows.CharacterEditorMain();
            this.editModeComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.headTextureUpDown = new System.Windows.Forms.NumericUpDown();
            this.torsoTextureUpDown = new System.Windows.Forms.NumericUpDown();
            this.legsTextureUpDown = new System.Windows.Forms.NumericUpDown();
            this.weaponTextureUpDown = new System.Windows.Forms.NumericUpDown();
            this.triggersListBox = new System.Windows.Forms.ListBox();
            this.triggerLabel = new System.Windows.Forms.Label();
            this.addTriggerButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partRotationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partScaleXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partScaleYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyFrameDurationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.torsoPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.legsPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headTextureUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.torsoTextureUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.legsTextureUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponTextureUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.previewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(983, 24);
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
            this.newCharacterToolStripMenuItem.Click += new System.EventHandler(this.newCharacterToolStripMenuItem_Click);
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.scaleToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Checked = true;
            this.moveToolStripMenuItem.CheckOnClick = true;
            this.moveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.CheckOnClick = true;
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.CheckOnClick = true;
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.scaleToolStripMenuItem.Text = "Scale";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.scaleToolStripMenuItem_Click);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.previewToolStripMenuItem.Text = "Preview";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.CheckOnClick = true;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Checked = true;
            this.stopToolStripMenuItem.CheckOnClick = true;
            this.stopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
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
            this.animationsListBox.Location = new System.Drawing.Point(821, 52);
            this.animationsListBox.Name = "animationsListBox";
            this.animationsListBox.Size = new System.Drawing.Size(120, 95);
            this.animationsListBox.TabIndex = 3;
            this.animationsListBox.SelectedIndexChanged += new System.EventHandler(this.animationsListBox_SelectedIndexChanged);
            // 
            // animationsDeletebutton
            // 
            this.animationsDeletebutton.Image = ((System.Drawing.Image)(resources.GetObject("animationsDeletebutton.Image")));
            this.animationsDeletebutton.Location = new System.Drawing.Point(953, 152);
            this.animationsDeletebutton.Name = "animationsDeletebutton";
            this.animationsDeletebutton.Size = new System.Drawing.Size(20, 20);
            this.animationsDeletebutton.TabIndex = 6;
            this.animationsDeletebutton.UseVisualStyleBackColor = true;
            this.animationsDeletebutton.Click += new System.EventHandler(this.animationsDeletebutton_Click);
            // 
            // animationsEditbutton
            // 
            this.animationsEditbutton.Image = ((System.Drawing.Image)(resources.GetObject("animationsEditbutton.Image")));
            this.animationsEditbutton.Location = new System.Drawing.Point(927, 152);
            this.animationsEditbutton.Name = "animationsEditbutton";
            this.animationsEditbutton.Size = new System.Drawing.Size(20, 20);
            this.animationsEditbutton.TabIndex = 8;
            this.animationsEditbutton.UseVisualStyleBackColor = true;
            this.animationsEditbutton.Click += new System.EventHandler(this.animationsEditbutton_Click);
            // 
            // animationsNametextBox
            // 
            this.animationsNametextBox.Location = new System.Drawing.Point(821, 153);
            this.animationsNametextBox.Name = "animationsNametextBox";
            this.animationsNametextBox.Size = new System.Drawing.Size(100, 20);
            this.animationsNametextBox.TabIndex = 9;
            this.animationsNametextBox.TextChanged += new System.EventHandler(this.animationsNametextBox_TextChanged);
            // 
            // partListBox
            // 
            this.partListBox.FormattingEnabled = true;
            this.partListBox.Location = new System.Drawing.Point(519, 52);
            this.partListBox.Name = "partListBox";
            this.partListBox.Size = new System.Drawing.Size(120, 121);
            this.partListBox.TabIndex = 11;
            this.partListBox.SelectedIndexChanged += new System.EventHandler(this.partListBox_SelectedIndexChanged);
            // 
            // partMoveUpButton
            // 
            this.partMoveUpButton.Location = new System.Drawing.Point(645, 52);
            this.partMoveUpButton.Name = "partMoveUpButton";
            this.partMoveUpButton.Size = new System.Drawing.Size(75, 23);
            this.partMoveUpButton.TabIndex = 12;
            this.partMoveUpButton.Text = "Move Up";
            this.partMoveUpButton.UseVisualStyleBackColor = true;
            this.partMoveUpButton.Click += new System.EventHandler(this.partMoveUpButton_Click);
            // 
            // partMoveDownButton
            // 
            this.partMoveDownButton.Location = new System.Drawing.Point(726, 52);
            this.partMoveDownButton.Name = "partMoveDownButton";
            this.partMoveDownButton.Size = new System.Drawing.Size(75, 23);
            this.partMoveDownButton.TabIndex = 12;
            this.partMoveDownButton.Text = "Move Down";
            this.partMoveDownButton.UseVisualStyleBackColor = true;
            this.partMoveDownButton.Click += new System.EventHandler(this.partMoveDownButton_Click);
            // 
            // partRotationUpDown
            // 
            this.partRotationUpDown.Location = new System.Drawing.Point(645, 91);
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
            this.label1.Location = new System.Drawing.Point(690, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Rotation";
            // 
            // partResetRotationButton
            // 
            this.partResetRotationButton.Image = ((System.Drawing.Image)(resources.GetObject("partResetRotationButton.Image")));
            this.partResetRotationButton.Location = new System.Drawing.Point(751, 89);
            this.partResetRotationButton.Name = "partResetRotationButton";
            this.partResetRotationButton.Size = new System.Drawing.Size(20, 20);
            this.partResetRotationButton.TabIndex = 15;
            this.partResetRotationButton.UseVisualStyleBackColor = true;
            this.partResetRotationButton.Click += new System.EventHandler(this.partResetRotationButton_Click);
            // 
            // partScaleXUpDown
            // 
            this.partScaleXUpDown.Location = new System.Drawing.Point(645, 120);
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
            this.label2.Location = new System.Drawing.Point(690, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "x-Scale";
            // 
            // partResetXScaleButton
            // 
            this.partResetXScaleButton.Image = ((System.Drawing.Image)(resources.GetObject("partResetXScaleButton.Image")));
            this.partResetXScaleButton.Location = new System.Drawing.Point(751, 118);
            this.partResetXScaleButton.Name = "partResetXScaleButton";
            this.partResetXScaleButton.Size = new System.Drawing.Size(20, 20);
            this.partResetXScaleButton.TabIndex = 15;
            this.partResetXScaleButton.UseVisualStyleBackColor = true;
            this.partResetXScaleButton.Click += new System.EventHandler(this.partResetXScaleButton_Click);
            // 
            // partDeleteButton
            // 
            this.partDeleteButton.Location = new System.Drawing.Point(726, 170);
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
            this.partFlipCheckBox.Location = new System.Drawing.Point(645, 170);
            this.partFlipCheckBox.Name = "partFlipCheckBox";
            this.partFlipCheckBox.Size = new System.Drawing.Size(64, 17);
            this.partFlipCheckBox.TabIndex = 17;
            this.partFlipCheckBox.Text = "Flip Part";
            this.partFlipCheckBox.UseVisualStyleBackColor = true;
            this.partFlipCheckBox.CheckedChanged += new System.EventHandler(this.partFlipCheckBox_CheckedChanged);
            // 
            // partScaleYUpDown
            // 
            this.partScaleYUpDown.Location = new System.Drawing.Point(645, 146);
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
            this.label3.Location = new System.Drawing.Point(690, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "y-Scale";
            // 
            // partResetYScaleButton
            // 
            this.partResetYScaleButton.Image = ((System.Drawing.Image)(resources.GetObject("partResetYScaleButton.Image")));
            this.partResetYScaleButton.Location = new System.Drawing.Point(751, 144);
            this.partResetYScaleButton.Name = "partResetYScaleButton";
            this.partResetYScaleButton.Size = new System.Drawing.Size(20, 20);
            this.partResetYScaleButton.TabIndex = 15;
            this.partResetYScaleButton.UseVisualStyleBackColor = true;
            this.partResetYScaleButton.Click += new System.EventHandler(this.partResetYScaleButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(821, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Animations";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(519, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Select Part:";
            // 
            // framesListBox
            // 
            this.framesListBox.FormattingEnabled = true;
            this.framesListBox.Location = new System.Drawing.Point(519, 202);
            this.framesListBox.Name = "framesListBox";
            this.framesListBox.Size = new System.Drawing.Size(120, 186);
            this.framesListBox.TabIndex = 21;
            this.framesListBox.SelectedIndexChanged += new System.EventHandler(this.framesListBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(519, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Frames";
            // 
            // framesAddReferenceButton
            // 
            this.framesAddReferenceButton.Location = new System.Drawing.Point(645, 238);
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
            this.framesDeleteButton.Location = new System.Drawing.Point(777, 203);
            this.framesDeleteButton.Name = "framesDeleteButton";
            this.framesDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.framesDeleteButton.TabIndex = 6;
            this.framesDeleteButton.UseVisualStyleBackColor = true;
            this.framesDeleteButton.Click += new System.EventHandler(this.framesDeletebutton_Click);
            // 
            // framesEditButton
            // 
            this.framesEditButton.Image = ((System.Drawing.Image)(resources.GetObject("framesEditButton.Image")));
            this.framesEditButton.Location = new System.Drawing.Point(751, 203);
            this.framesEditButton.Name = "framesEditButton";
            this.framesEditButton.Size = new System.Drawing.Size(20, 20);
            this.framesEditButton.TabIndex = 8;
            this.framesEditButton.UseVisualStyleBackColor = true;
            this.framesEditButton.Click += new System.EventHandler(this.framesEditbutton_Click);
            // 
            // framesTextBox
            // 
            this.framesTextBox.Location = new System.Drawing.Point(645, 203);
            this.framesTextBox.Name = "framesTextBox";
            this.framesTextBox.Size = new System.Drawing.Size(100, 20);
            this.framesTextBox.TabIndex = 9;
            this.framesTextBox.TextChanged += new System.EventHandler(this.framesNametextBox_TextChanged);
            // 
            // keyFrameListBox
            // 
            this.keyFrameListBox.FormattingEnabled = true;
            this.keyFrameListBox.Location = new System.Drawing.Point(651, 293);
            this.keyFrameListBox.Name = "keyFrameListBox";
            this.keyFrameListBox.Size = new System.Drawing.Size(120, 95);
            this.keyFrameListBox.TabIndex = 24;
            this.keyFrameListBox.SelectedIndexChanged += new System.EventHandler(this.keyFrameListBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(649, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "KeyFrames";
            // 
            // keyFrameDurationUpDown
            // 
            this.keyFrameDurationUpDown.Location = new System.Drawing.Point(670, 394);
            this.keyFrameDurationUpDown.Name = "keyFrameDurationUpDown";
            this.keyFrameDurationUpDown.Size = new System.Drawing.Size(38, 20);
            this.keyFrameDurationUpDown.TabIndex = 26;
            this.keyFrameDurationUpDown.ValueChanged += new System.EventHandler(this.keyFrameDurationUpDown_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(714, 396);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Duration";
            // 
            // scriptsListBox
            // 
            this.scriptsListBox.FormattingEnabled = true;
            this.scriptsListBox.Location = new System.Drawing.Point(821, 203);
            this.scriptsListBox.Name = "scriptsListBox";
            this.scriptsListBox.Size = new System.Drawing.Size(120, 95);
            this.scriptsListBox.TabIndex = 28;
            this.scriptsListBox.SelectedIndexChanged += new System.EventHandler(this.scriptsListBox_SelectedIndexChanged);
            // 
            // scriptsDeleteButton
            // 
            this.scriptsDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("scriptsDeleteButton.Image")));
            this.scriptsDeleteButton.Location = new System.Drawing.Point(953, 303);
            this.scriptsDeleteButton.Name = "scriptsDeleteButton";
            this.scriptsDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.scriptsDeleteButton.TabIndex = 6;
            this.scriptsDeleteButton.UseVisualStyleBackColor = true;
            this.scriptsDeleteButton.Click += new System.EventHandler(this.scriptsDeletebutton_Click);
            // 
            // scriptsEditButton
            // 
            this.scriptsEditButton.Image = ((System.Drawing.Image)(resources.GetObject("scriptsEditButton.Image")));
            this.scriptsEditButton.Location = new System.Drawing.Point(927, 303);
            this.scriptsEditButton.Name = "scriptsEditButton";
            this.scriptsEditButton.Size = new System.Drawing.Size(20, 20);
            this.scriptsEditButton.TabIndex = 8;
            this.scriptsEditButton.UseVisualStyleBackColor = true;
            this.scriptsEditButton.Click += new System.EventHandler(this.scriptsEditbutton_Click);
            // 
            // scriptsTextBox
            // 
            this.scriptsTextBox.Location = new System.Drawing.Point(821, 304);
            this.scriptsTextBox.Name = "scriptsTextBox";
            this.scriptsTextBox.Size = new System.Drawing.Size(100, 20);
            this.scriptsTextBox.TabIndex = 9;
            this.scriptsTextBox.TextChanged += new System.EventHandler(this.scriptsNametextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(821, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Scripts";
            // 
            // headPreview
            // 
            this.headPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.headPreview.Location = new System.Drawing.Point(12, 553);
            this.headPreview.Name = "headPreview";
            this.headPreview.Size = new System.Drawing.Size(64, 64);
            this.headPreview.TabIndex = 31;
            this.headPreview.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(79, 535);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Available Head Parts";
            // 
            // weaponsPreview
            // 
            this.weaponsPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.weaponsPreview.Location = new System.Drawing.Point(619, 553);
            this.weaponsPreview.Name = "weaponsPreview";
            this.weaponsPreview.Size = new System.Drawing.Size(80, 64);
            this.weaponsPreview.TabIndex = 35;
            this.weaponsPreview.TabStop = false;
            // 
            // availableWeaponsParts
            // 
            this.availableWeaponsParts.FormattingEnabled = true;
            this.availableWeaponsParts.Location = new System.Drawing.Point(705, 555);
            this.availableWeaponsParts.Name = "availableWeaponsParts";
            this.availableWeaponsParts.Size = new System.Drawing.Size(120, 95);
            this.availableWeaponsParts.TabIndex = 37;
            this.availableWeaponsParts.SelectedIndexChanged += new System.EventHandler(this.availableWeaponsListBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(706, 539);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Available Weapons";
            // 
            // addHeadButton
            // 
            this.addHeadButton.Location = new System.Drawing.Point(12, 627);
            this.addHeadButton.Name = "addHeadButton";
            this.addHeadButton.Size = new System.Drawing.Size(65, 23);
            this.addHeadButton.TabIndex = 40;
            this.addHeadButton.Text = "Add";
            this.addHeadButton.UseVisualStyleBackColor = true;
            this.addHeadButton.Click += new System.EventHandler(this.addHeadButton_Click);
            // 
            // addWeaponButton
            // 
            this.addWeaponButton.Location = new System.Drawing.Point(619, 627);
            this.addWeaponButton.Name = "addWeaponButton";
            this.addWeaponButton.Size = new System.Drawing.Size(65, 23);
            this.addWeaponButton.TabIndex = 40;
            this.addWeaponButton.Text = "Add";
            this.addWeaponButton.UseVisualStyleBackColor = true;
            this.addWeaponButton.Click += new System.EventHandler(this.addWeaponButton_Click);
            // 
            // torsoPreview
            // 
            this.torsoPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.torsoPreview.Location = new System.Drawing.Point(215, 553);
            this.torsoPreview.Name = "torsoPreview";
            this.torsoPreview.Size = new System.Drawing.Size(64, 64);
            this.torsoPreview.TabIndex = 31;
            this.torsoPreview.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(282, 535);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Available Torso Parts";
            // 
            // addTorsoButton
            // 
            this.addTorsoButton.Location = new System.Drawing.Point(215, 627);
            this.addTorsoButton.Name = "addTorsoButton";
            this.addTorsoButton.Size = new System.Drawing.Size(65, 23);
            this.addTorsoButton.TabIndex = 40;
            this.addTorsoButton.Text = "Add";
            this.addTorsoButton.UseVisualStyleBackColor = true;
            this.addTorsoButton.Click += new System.EventHandler(this.addTorsoButton_Click);
            // 
            // legsPreview
            // 
            this.legsPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.legsPreview.Location = new System.Drawing.Point(418, 553);
            this.legsPreview.Name = "legsPreview";
            this.legsPreview.Size = new System.Drawing.Size(64, 64);
            this.legsPreview.TabIndex = 31;
            this.legsPreview.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(485, 535);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 13);
            this.label17.TabIndex = 34;
            this.label17.Text = "Available Legs Parts";
            // 
            // addLegsButton
            // 
            this.addLegsButton.Location = new System.Drawing.Point(418, 627);
            this.addLegsButton.Name = "addLegsButton";
            this.addLegsButton.Size = new System.Drawing.Size(65, 23);
            this.addLegsButton.TabIndex = 40;
            this.addLegsButton.Text = "Add";
            this.addLegsButton.UseVisualStyleBackColor = true;
            this.addLegsButton.Click += new System.EventHandler(this.addLegsButton_Click);
            // 
            // availableHeadParts
            // 
            this.availableHeadParts.FormattingEnabled = true;
            this.availableHeadParts.Location = new System.Drawing.Point(82, 555);
            this.availableHeadParts.Name = "availableHeadParts";
            this.availableHeadParts.Size = new System.Drawing.Size(120, 95);
            this.availableHeadParts.TabIndex = 41;
            this.availableHeadParts.SelectedIndexChanged += new System.EventHandler(this.availableHeadParts_SelectedIndexChanged);
            // 
            // availableTorsoParts
            // 
            this.availableTorsoParts.FormattingEnabled = true;
            this.availableTorsoParts.Location = new System.Drawing.Point(285, 555);
            this.availableTorsoParts.Name = "availableTorsoParts";
            this.availableTorsoParts.Size = new System.Drawing.Size(120, 95);
            this.availableTorsoParts.TabIndex = 41;
            this.availableTorsoParts.SelectedIndexChanged += new System.EventHandler(this.availableTorsoParts_SelectedIndexChanged);
            // 
            // availableLegsParts
            // 
            this.availableLegsParts.FormattingEnabled = true;
            this.availableLegsParts.Location = new System.Drawing.Point(488, 555);
            this.availableLegsParts.Name = "availableLegsParts";
            this.availableLegsParts.Size = new System.Drawing.Size(120, 95);
            this.availableLegsParts.TabIndex = 41;
            this.availableLegsParts.SelectedIndexChanged += new System.EventHandler(this.availableLegsParts_SelectedIndexChanged);
            // 
            // characterEditorMain1
            // 
            this.characterEditorMain1.charDef = null;
            this.characterEditorMain1.Location = new System.Drawing.Point(13, 28);
            this.characterEditorMain1.Name = "characterEditorMain1";
            this.characterEditorMain1.Playing = false;
            this.characterEditorMain1.SelectedAnimation = 0;
            this.characterEditorMain1.SelectedFrame = 0;
            this.characterEditorMain1.SelectedKeyFrame = 0;
            this.characterEditorMain1.SelectedPart = 0;
            this.characterEditorMain1.SelectedScriptLine = 0;
            this.characterEditorMain1.Size = new System.Drawing.Size(500, 500);
            this.characterEditorMain1.TabIndex = 42;
            this.characterEditorMain1.Text = "characterEditorMain1";
            this.characterEditorMain1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onMouseClick);
            this.characterEditorMain1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.characterEditorMain1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            this.characterEditorMain1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onMouseUp);
            // 
            // editModeComboBox
            // 
            this.editModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editModeComboBox.FormattingEnabled = true;
            this.editModeComboBox.Items.AddRange(new object[] {
            "Location",
            "Rotation",
            "Scale"});
            this.editModeComboBox.Location = new System.Drawing.Point(519, 448);
            this.editModeComboBox.MaxDropDownItems = 3;
            this.editModeComboBox.Name = "editModeComboBox";
            this.editModeComboBox.Size = new System.Drawing.Size(121, 21);
            this.editModeComboBox.TabIndex = 43;
            this.editModeComboBox.SelectedIndexChanged += new System.EventHandler(this.editModeComboBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(519, 429);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Current Editing Mode";
            // 
            // headTextureUpDown
            // 
            this.headTextureUpDown.Location = new System.Drawing.Point(26, 532);
            this.headTextureUpDown.Name = "headTextureUpDown";
            this.headTextureUpDown.Size = new System.Drawing.Size(33, 20);
            this.headTextureUpDown.TabIndex = 45;
            this.headTextureUpDown.ValueChanged += new System.EventHandler(this.headTextureUpDown_ValueChanged);
            // 
            // torsoTextureUpDown
            // 
            this.torsoTextureUpDown.Location = new System.Drawing.Point(231, 532);
            this.torsoTextureUpDown.Name = "torsoTextureUpDown";
            this.torsoTextureUpDown.Size = new System.Drawing.Size(33, 20);
            this.torsoTextureUpDown.TabIndex = 45;
            this.torsoTextureUpDown.ValueChanged += new System.EventHandler(this.torsoTextureUpDown_ValueChanged);
            // 
            // legsTextureUpDown
            // 
            this.legsTextureUpDown.Location = new System.Drawing.Point(434, 532);
            this.legsTextureUpDown.Name = "legsTextureUpDown";
            this.legsTextureUpDown.Size = new System.Drawing.Size(33, 20);
            this.legsTextureUpDown.TabIndex = 45;
            this.legsTextureUpDown.ValueChanged += new System.EventHandler(this.legsTextureUpDown_ValueChanged);
            // 
            // weaponTextureUpDown
            // 
            this.weaponTextureUpDown.Location = new System.Drawing.Point(636, 532);
            this.weaponTextureUpDown.Name = "weaponTextureUpDown";
            this.weaponTextureUpDown.Size = new System.Drawing.Size(33, 20);
            this.weaponTextureUpDown.TabIndex = 45;
            this.weaponTextureUpDown.ValueChanged += new System.EventHandler(this.weaponTextureUpDown_ValueChanged);
            // 
            // triggersListBox
            // 
            this.triggersListBox.FormattingEnabled = true;
            this.triggersListBox.Location = new System.Drawing.Point(821, 347);
            this.triggersListBox.Name = "triggersListBox";
            this.triggersListBox.Size = new System.Drawing.Size(120, 95);
            this.triggersListBox.TabIndex = 46;
            this.triggersListBox.SelectedIndexChanged += new System.EventHandler(this.triggersListBox_SelectedIndexChanged);
            // 
            // triggerLabel
            // 
            this.triggerLabel.AutoSize = true;
            this.triggerLabel.Location = new System.Drawing.Point(821, 328);
            this.triggerLabel.Name = "triggerLabel";
            this.triggerLabel.Size = new System.Drawing.Size(91, 13);
            this.triggerLabel.TabIndex = 47;
            this.triggerLabel.Text = "Available Triggers";
            // 
            // addTriggerButton
            // 
            this.addTriggerButton.Location = new System.Drawing.Point(846, 448);
            this.addTriggerButton.Name = "addTriggerButton";
            this.addTriggerButton.Size = new System.Drawing.Size(75, 23);
            this.addTriggerButton.TabIndex = 48;
            this.addTriggerButton.Text = "Add Trigger";
            this.addTriggerButton.UseVisualStyleBackColor = true;
            this.addTriggerButton.Click += new System.EventHandler(this.addTriggerButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 662);
            this.Controls.Add(this.addTriggerButton);
            this.Controls.Add(this.triggerLabel);
            this.Controls.Add(this.triggersListBox);
            this.Controls.Add(this.weaponTextureUpDown);
            this.Controls.Add(this.legsTextureUpDown);
            this.Controls.Add(this.torsoTextureUpDown);
            this.Controls.Add(this.headTextureUpDown);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.editModeComboBox);
            this.Controls.Add(this.characterEditorMain1);
            this.Controls.Add(this.availableLegsParts);
            this.Controls.Add(this.availableTorsoParts);
            this.Controls.Add(this.availableHeadParts);
            this.Controls.Add(this.addWeaponButton);
            this.Controls.Add(this.addLegsButton);
            this.Controls.Add(this.addTorsoButton);
            this.Controls.Add(this.addHeadButton);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.availableWeaponsParts);
            this.Controls.Add(this.weaponsPreview);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.legsPreview);
            this.Controls.Add(this.torsoPreview);
            this.Controls.Add(this.headPreview);
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
            ((System.ComponentModel.ISupportInitialize)(this.headPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.torsoPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.legsPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headTextureUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.torsoTextureUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.legsTextureUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponTextureUpDown)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.PictureBox headPreview;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox weaponsPreview;
        private System.Windows.Forms.ListBox availableWeaponsParts;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        
        private System.Windows.Forms.Button addHeadButton;
        private System.Windows.Forms.Button addWeaponButton;
        private System.Windows.Forms.PictureBox torsoPreview;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button addTorsoButton;
        private System.Windows.Forms.PictureBox legsPreview;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button addLegsButton;
        private System.Windows.Forms.ListBox availableHeadParts;
        private System.Windows.Forms.ListBox availableTorsoParts;
        private System.Windows.Forms.ListBox availableLegsParts;
        private CharacterEditorMain characterEditorMain1;
        private System.Windows.Forms.ComboBox editModeComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown headTextureUpDown;
        private System.Windows.Forms.NumericUpDown torsoTextureUpDown;
        private System.Windows.Forms.NumericUpDown legsTextureUpDown;
        private System.Windows.Forms.NumericUpDown weaponTextureUpDown;
        private System.Windows.Forms.ListBox triggersListBox;
        private System.Windows.Forms.Label triggerLabel;
        private System.Windows.Forms.Button addTriggerButton;
        
        
    }
}

