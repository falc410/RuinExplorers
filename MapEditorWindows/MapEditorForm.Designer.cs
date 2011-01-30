namespace MapEditorWindows
{
    partial class MapEditorForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collisionMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLedgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.middleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foregroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.modeSelectComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.segmentPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.segmentListBox = new System.Windows.Forms.ListBox();
            this.addSegmentButton = new System.Windows.Forms.Button();
            this.ledgeListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.layerSelectComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mapEditorMain1 = new MapEditorWindows.MapEditorMain();
            this.ledgeCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ledgeNodeLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segmentPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.layerToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.openMapToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.importTextureToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newMapToolStripMenuItem.Text = "New Map";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.newMapToolStripMenuItem_Click);
            // 
            // openMapToolStripMenuItem
            // 
            this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
            this.openMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openMapToolStripMenuItem.Text = "Open Map";
            this.openMapToolStripMenuItem.Click += new System.EventHandler(this.openMapToolStripMenuItem_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveMapToolStripMenuItem.Text = "Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // importTextureToolStripMenuItem
            // 
            this.importTextureToolStripMenuItem.Name = "importTextureToolStripMenuItem";
            this.importTextureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importTextureToolStripMenuItem.Text = "Import Texture";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawingToolStripMenuItem,
            this.collisionMapToolStripMenuItem,
            this.editLedgesToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // drawingToolStripMenuItem
            // 
            this.drawingToolStripMenuItem.Name = "drawingToolStripMenuItem";
            this.drawingToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.drawingToolStripMenuItem.Text = "Drawing";
            this.drawingToolStripMenuItem.Click += new System.EventHandler(this.drawingToolStripMenuItem_Click);
            // 
            // collisionMapToolStripMenuItem
            // 
            this.collisionMapToolStripMenuItem.Name = "collisionMapToolStripMenuItem";
            this.collisionMapToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.collisionMapToolStripMenuItem.Text = "Collision Map";
            this.collisionMapToolStripMenuItem.Click += new System.EventHandler(this.collisionMapToolStripMenuItem_Click);
            // 
            // editLedgesToolStripMenuItem
            // 
            this.editLedgesToolStripMenuItem.Name = "editLedgesToolStripMenuItem";
            this.editLedgesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editLedgesToolStripMenuItem.Text = "Edit Ledges";
            this.editLedgesToolStripMenuItem.Click += new System.EventHandler(this.editLedgesToolStripMenuItem_Click);
            // 
            // layerToolStripMenuItem
            // 
            this.layerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem,
            this.middleToolStripMenuItem,
            this.foregroundToolStripMenuItem});
            this.layerToolStripMenuItem.Name = "layerToolStripMenuItem";
            this.layerToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.layerToolStripMenuItem.Text = "Layer";
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // middleToolStripMenuItem
            // 
            this.middleToolStripMenuItem.Name = "middleToolStripMenuItem";
            this.middleToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.middleToolStripMenuItem.Text = "Middle";
            this.middleToolStripMenuItem.Click += new System.EventHandler(this.middleToolStripMenuItem_Click);
            // 
            // foregroundToolStripMenuItem
            // 
            this.foregroundToolStripMenuItem.Name = "foregroundToolStripMenuItem";
            this.foregroundToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.foregroundToolStripMenuItem.Text = "Foreground";
            this.foregroundToolStripMenuItem.Click += new System.EventHandler(this.foregroundToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // modeSelectComboBox
            // 
            this.modeSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeSelectComboBox.FormattingEnabled = true;
            this.modeSelectComboBox.Items.AddRange(new object[] {
            "Drawing",
            "Collision Map",
            "Edit Ledges"});
            this.modeSelectComboBox.Location = new System.Drawing.Point(822, 44);
            this.modeSelectComboBox.Name = "modeSelectComboBox";
            this.modeSelectComboBox.Size = new System.Drawing.Size(121, 21);
            this.modeSelectComboBox.TabIndex = 2;
            this.modeSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.modeSelectComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(819, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mode Select:";
            // 
            // segmentPictureBox
            // 
            this.segmentPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.segmentPictureBox.Location = new System.Drawing.Point(825, 200);
            this.segmentPictureBox.Name = "segmentPictureBox";
            this.segmentPictureBox.Size = new System.Drawing.Size(150, 100);
            this.segmentPictureBox.TabIndex = 4;
            this.segmentPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(825, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Preview";
            // 
            // segmentListBox
            // 
            this.segmentListBox.FormattingEnabled = true;
            this.segmentListBox.Location = new System.Drawing.Point(825, 307);
            this.segmentListBox.Name = "segmentListBox";
            this.segmentListBox.Size = new System.Drawing.Size(150, 95);
            this.segmentListBox.TabIndex = 6;
            this.segmentListBox.SelectedIndexChanged += new System.EventHandler(this.segmentListBox_SelectedIndexChanged);
            // 
            // addSegmentButton
            // 
            this.addSegmentButton.Location = new System.Drawing.Point(860, 408);
            this.addSegmentButton.Name = "addSegmentButton";
            this.addSegmentButton.Size = new System.Drawing.Size(86, 23);
            this.addSegmentButton.TabIndex = 7;
            this.addSegmentButton.Text = "Add Segment";
            this.addSegmentButton.UseVisualStyleBackColor = true;
            this.addSegmentButton.Click += new System.EventHandler(this.addSegmentButton_Click);
            // 
            // ledgeListBox
            // 
            this.ledgeListBox.FormattingEnabled = true;
            this.ledgeListBox.Location = new System.Drawing.Point(825, 479);
            this.ledgeListBox.Name = "ledgeListBox";
            this.ledgeListBox.Size = new System.Drawing.Size(147, 95);
            this.ledgeListBox.TabIndex = 8;
            this.ledgeListBox.SelectedIndexChanged += new System.EventHandler(this.ledgeListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(822, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ledge Select:";
            // 
            // layerSelectComboBox
            // 
            this.layerSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerSelectComboBox.FormattingEnabled = true;
            this.layerSelectComboBox.Items.AddRange(new object[] {
            "Background",
            "Middle",
            "Foreground"});
            this.layerSelectComboBox.Location = new System.Drawing.Point(822, 93);
            this.layerSelectComboBox.Name = "layerSelectComboBox";
            this.layerSelectComboBox.Size = new System.Drawing.Size(121, 21);
            this.layerSelectComboBox.TabIndex = 2;
            this.layerSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.layerSelectComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(819, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Layer Select:";
            // 
            // mapEditorMain1
            // 
            this.mapEditorMain1.CurrentLayer = 1;
            this.mapEditorMain1.CurrentLedge = 0;
            this.mapEditorMain1.Location = new System.Drawing.Point(12, 27);
            this.mapEditorMain1.Map = null;
            this.mapEditorMain1.Mode = MapEditorWindows.MapClasses.DrawingMode.SegmentSelection;
            this.mapEditorMain1.Name = "mapEditorMain1";
            this.mapEditorMain1.Scroll = new Microsoft.Xna.Framework.Vector2(0F, 0F);
            this.mapEditorMain1.Size = new System.Drawing.Size(800, 600);
            this.mapEditorMain1.TabIndex = 10;
            this.mapEditorMain1.Text = "mapEditorMain1";
            this.mapEditorMain1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.mapEditorMain1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            this.mapEditorMain1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onMouseUp);
            // 
            // ledgeCheckBox
            // 
            this.ledgeCheckBox.AutoSize = true;
            this.ledgeCheckBox.Location = new System.Drawing.Point(825, 580);
            this.ledgeCheckBox.Name = "ledgeCheckBox";
            this.ledgeCheckBox.Size = new System.Drawing.Size(96, 17);
            this.ledgeCheckBox.TabIndex = 11;
            this.ledgeCheckBox.Text = "is hard Ledge?";
            this.ledgeCheckBox.UseVisualStyleBackColor = true;
            this.ledgeCheckBox.CheckedChanged += new System.EventHandler(this.ledgeCheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(825, 613);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nodes in Ledge:";
            // 
            // ledgeNodeLabel
            // 
            this.ledgeNodeLabel.AutoSize = true;
            this.ledgeNodeLabel.Location = new System.Drawing.Point(908, 614);
            this.ledgeNodeLabel.Name = "ledgeNodeLabel";
            this.ledgeNodeLabel.Size = new System.Drawing.Size(13, 13);
            this.ledgeNodeLabel.TabIndex = 13;
            this.ledgeNodeLabel.Text = "0";
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.ledgeNodeLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ledgeCheckBox);
            this.Controls.Add(this.mapEditorMain1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ledgeListBox);
            this.Controls.Add(this.addSegmentButton);
            this.Controls.Add(this.segmentListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.segmentPictureBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.layerSelectComboBox);
            this.Controls.Add(this.modeSelectComboBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapEditorForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segmentPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem importTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collisionMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLedgesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foregroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem middleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ComboBox modeSelectComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox segmentPictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox segmentListBox;
        private System.Windows.Forms.Button addSegmentButton;
        private System.Windows.Forms.ListBox ledgeListBox;
        private System.Windows.Forms.Label label3;
        
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ComboBox layerSelectComboBox;
        private System.Windows.Forms.Label label4;
        private MapEditorMain mapEditorMain1;
        private System.Windows.Forms.CheckBox ledgeCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ledgeNodeLabel;
        
    }
}

