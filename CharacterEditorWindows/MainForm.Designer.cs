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
            this.characterEditorMain1 = new CharacterEditorWindows.CharacterEditorMain();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partRotationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partScaleXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partScaleYUpDown)).BeginInit();
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
            this.openCharacterToolStripMenuItem,
            this.saveCharacterToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.importTexturesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
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
            this.partListBox.Location = new System.Drawing.Point(820, 130);
            this.partListBox.Name = "partListBox";
            this.partListBox.Size = new System.Drawing.Size(120, 121);
            this.partListBox.TabIndex = 11;
            this.partListBox.SelectedIndexChanged += new System.EventHandler(this.partListBox_SelectedIndexChanged);
            // 
            // partMoveUpButton
            // 
            this.partMoveUpButton.Location = new System.Drawing.Point(946, 130);
            this.partMoveUpButton.Name = "partMoveUpButton";
            this.partMoveUpButton.Size = new System.Drawing.Size(75, 23);
            this.partMoveUpButton.TabIndex = 12;
            this.partMoveUpButton.Text = "Move Up";
            this.partMoveUpButton.UseVisualStyleBackColor = true;
            this.partMoveUpButton.Click += new System.EventHandler(this.partMoveUpButton_Click);
            // 
            // partMoveDownButton
            // 
            this.partMoveDownButton.Location = new System.Drawing.Point(1027, 130);
            this.partMoveDownButton.Name = "partMoveDownButton";
            this.partMoveDownButton.Size = new System.Drawing.Size(75, 23);
            this.partMoveDownButton.TabIndex = 12;
            this.partMoveDownButton.Text = "Move Down";
            this.partMoveDownButton.UseVisualStyleBackColor = true;
            this.partMoveDownButton.Click += new System.EventHandler(this.partMoveDownButton_Click);
            // 
            // partRotationUpDown
            // 
            this.partRotationUpDown.Location = new System.Drawing.Point(946, 169);
            this.partRotationUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.partRotationUpDown.Name = "partRotationUpDown";
            this.partRotationUpDown.Size = new System.Drawing.Size(39, 20);
            this.partRotationUpDown.TabIndex = 13;
            this.partRotationUpDown.ValueChanged += new System.EventHandler(this.partRotationUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(991, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Rotation";
            // 
            // partResetRotationButton
            // 
            this.partResetRotationButton.Image = ((System.Drawing.Image)(resources.GetObject("partResetRotationButton.Image")));
            this.partResetRotationButton.Location = new System.Drawing.Point(1052, 167);
            this.partResetRotationButton.Name = "partResetRotationButton";
            this.partResetRotationButton.Size = new System.Drawing.Size(20, 20);
            this.partResetRotationButton.TabIndex = 15;
            this.partResetRotationButton.UseVisualStyleBackColor = true;
            // 
            // partScaleXUpDown
            // 
            this.partScaleXUpDown.Location = new System.Drawing.Point(946, 198);
            this.partScaleXUpDown.Name = "partScaleXUpDown";
            this.partScaleXUpDown.Size = new System.Drawing.Size(39, 20);
            this.partScaleXUpDown.TabIndex = 13;
            this.partScaleXUpDown.ValueChanged += new System.EventHandler(this.partScaleXUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(991, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "x-Scale";
            // 
            // partResetXScaleButton
            // 
            this.partResetXScaleButton.Image = ((System.Drawing.Image)(resources.GetObject("partResetXScaleButton.Image")));
            this.partResetXScaleButton.Location = new System.Drawing.Point(1052, 196);
            this.partResetXScaleButton.Name = "partResetXScaleButton";
            this.partResetXScaleButton.Size = new System.Drawing.Size(20, 20);
            this.partResetXScaleButton.TabIndex = 15;
            this.partResetXScaleButton.UseVisualStyleBackColor = true;
            this.partResetXScaleButton.Click += new System.EventHandler(this.partResetXScaleButton_Click);
            // 
            // partDeleteButton
            // 
            this.partDeleteButton.Location = new System.Drawing.Point(1027, 248);
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
            this.partFlipCheckBox.Location = new System.Drawing.Point(946, 248);
            this.partFlipCheckBox.Name = "partFlipCheckBox";
            this.partFlipCheckBox.Size = new System.Drawing.Size(64, 17);
            this.partFlipCheckBox.TabIndex = 17;
            this.partFlipCheckBox.Text = "Flip Part";
            this.partFlipCheckBox.UseVisualStyleBackColor = true;
            this.partFlipCheckBox.CheckedChanged += new System.EventHandler(this.partFlipCheckBox_CheckedChanged);
            // 
            // partScaleYUpDown
            // 
            this.partScaleYUpDown.Location = new System.Drawing.Point(946, 224);
            this.partScaleYUpDown.Name = "partScaleYUpDown";
            this.partScaleYUpDown.Size = new System.Drawing.Size(39, 20);
            this.partScaleYUpDown.TabIndex = 13;
            this.partScaleYUpDown.ValueChanged += new System.EventHandler(this.partScaleYUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(991, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "y-Scale";
            // 
            // partResetYScaleButton
            // 
            this.partResetYScaleButton.Image = ((System.Drawing.Image)(resources.GetObject("partResetYScaleButton.Image")));
            this.partResetYScaleButton.Location = new System.Drawing.Point(1052, 222);
            this.partResetYScaleButton.Name = "partResetYScaleButton";
            this.partResetYScaleButton.Size = new System.Drawing.Size(20, 20);
            this.partResetYScaleButton.TabIndex = 15;
            this.partResetYScaleButton.UseVisualStyleBackColor = true;
            this.partResetYScaleButton.Click += new System.EventHandler(this.partResetYScaleButton_Click);
            // 
            // characterEditorMain1
            // 
            this.characterEditorMain1.Location = new System.Drawing.Point(13, 27);
            this.characterEditorMain1.Name = "characterEditorMain1";
            this.characterEditorMain1.SelectedAnimation = 0;
            this.characterEditorMain1.SelectedFrame = 0;
            this.characterEditorMain1.SelectedPart = 0;
            this.characterEditorMain1.Size = new System.Drawing.Size(800, 600);
            this.characterEditorMain1.TabIndex = 18;
            this.characterEditorMain1.Text = "characterEditorMain1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 662);
            this.Controls.Add(this.characterEditorMain1);
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
            this.Controls.Add(this.animationsNametextBox);
            this.Controls.Add(this.animationsEditbutton);
            this.Controls.Add(this.animationsDeletebutton);
            this.Controls.Add(this.animationsListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partRotationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partScaleXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partScaleYUpDown)).EndInit();
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
        private CharacterEditorMain characterEditorMain1;
        
    }
}

