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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorForm));
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
            this.deleteSegmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ledgeCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ledgeNodeLabel = new System.Windows.Forms.Label();
            this.nodeDeleteButton = new System.Windows.Forms.Button();
            this.ledgeDeleteButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.mouseCoordinatesLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ingameMouseCoordinates = new System.Windows.Forms.Label();
            this.scriptListBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.scriptLineTextBox = new System.Windows.Forms.TextBox();
            this.scriptDeleteButton = new System.Windows.Forms.Button();
            this.scriptEditButton = new System.Windows.Forms.Button();
            this.scriptCommandsListBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.addScriptCommandButton = new System.Windows.Forms.Button();
            this.getMouseCoordButton = new System.Windows.Forms.Button();
            this.scriptInsertLineButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.scriptDetailTextBox = new System.Windows.Forms.TextBox();
            this.mapEditorMain1 = new MapEditorWindows.MapEditorMain();
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
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
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
            this.editLedgesToolStripMenuItem,
            this.deleteSegmentsToolStripMenuItem,
            this.scriptCoordinatesToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // drawingToolStripMenuItem
            // 
            this.drawingToolStripMenuItem.Name = "drawingToolStripMenuItem";
            this.drawingToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.drawingToolStripMenuItem.Text = "Drawing";
            this.drawingToolStripMenuItem.Click += new System.EventHandler(this.drawingToolStripMenuItem_Click);
            // 
            // collisionMapToolStripMenuItem
            // 
            this.collisionMapToolStripMenuItem.Name = "collisionMapToolStripMenuItem";
            this.collisionMapToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.collisionMapToolStripMenuItem.Text = "Collision Map";
            this.collisionMapToolStripMenuItem.Click += new System.EventHandler(this.collisionMapToolStripMenuItem_Click);
            // 
            // editLedgesToolStripMenuItem
            // 
            this.editLedgesToolStripMenuItem.Name = "editLedgesToolStripMenuItem";
            this.editLedgesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.editLedgesToolStripMenuItem.Text = "Edit Ledges";
            this.editLedgesToolStripMenuItem.Click += new System.EventHandler(this.editLedgesToolStripMenuItem_Click);
            // 
            // deleteSegmentsToolStripMenuItem
            // 
            this.deleteSegmentsToolStripMenuItem.Name = "deleteSegmentsToolStripMenuItem";
            this.deleteSegmentsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteSegmentsToolStripMenuItem.Text = "Delete Segments";
            this.deleteSegmentsToolStripMenuItem.Click += new System.EventHandler(this.deleteSegmentsToolStripMenuItem_Click);
            // 
            // scriptCoordinatesToolStripMenuItem
            // 
            this.scriptCoordinatesToolStripMenuItem.Name = "scriptCoordinatesToolStripMenuItem";
            this.scriptCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.scriptCoordinatesToolStripMenuItem.Text = "Script Coordinates";
            this.scriptCoordinatesToolStripMenuItem.Click += new System.EventHandler(this.scriptCoordinatesToolStripMenuItem_Click);
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
            "Edit Ledges",
            "Delete Segments",
            "Script Coordiantes"});
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
            this.segmentPictureBox.Location = new System.Drawing.Point(825, 182);
            this.segmentPictureBox.Name = "segmentPictureBox";
            this.segmentPictureBox.Size = new System.Drawing.Size(150, 100);
            this.segmentPictureBox.TabIndex = 4;
            this.segmentPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(825, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Preview";
            // 
            // segmentListBox
            // 
            this.segmentListBox.FormattingEnabled = true;
            this.segmentListBox.Location = new System.Drawing.Point(825, 289);
            this.segmentListBox.Name = "segmentListBox";
            this.segmentListBox.Size = new System.Drawing.Size(150, 95);
            this.segmentListBox.TabIndex = 6;
            this.segmentListBox.SelectedIndexChanged += new System.EventHandler(this.segmentListBox_SelectedIndexChanged);
            // 
            // addSegmentButton
            // 
            this.addSegmentButton.Location = new System.Drawing.Point(860, 390);
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
            this.ledgeListBox.Location = new System.Drawing.Point(825, 441);
            this.ledgeListBox.Name = "ledgeListBox";
            this.ledgeListBox.Size = new System.Drawing.Size(147, 95);
            this.ledgeListBox.TabIndex = 8;
            this.ledgeListBox.SelectedIndexChanged += new System.EventHandler(this.ledgeListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(822, 425);
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
            // ledgeCheckBox
            // 
            this.ledgeCheckBox.AutoSize = true;
            this.ledgeCheckBox.Location = new System.Drawing.Point(825, 542);
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
            this.label5.Location = new System.Drawing.Point(843, 562);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nodes in Ledge:";
            // 
            // ledgeNodeLabel
            // 
            this.ledgeNodeLabel.AutoSize = true;
            this.ledgeNodeLabel.Location = new System.Drawing.Point(929, 562);
            this.ledgeNodeLabel.Name = "ledgeNodeLabel";
            this.ledgeNodeLabel.Size = new System.Drawing.Size(13, 13);
            this.ledgeNodeLabel.TabIndex = 13;
            this.ledgeNodeLabel.Text = "0";
            // 
            // nodeDeleteButton
            // 
            this.nodeDeleteButton.Location = new System.Drawing.Point(846, 578);
            this.nodeDeleteButton.Name = "nodeDeleteButton";
            this.nodeDeleteButton.Size = new System.Drawing.Size(100, 23);
            this.nodeDeleteButton.TabIndex = 14;
            this.nodeDeleteButton.Text = "Delete Last Node";
            this.nodeDeleteButton.UseVisualStyleBackColor = true;
            this.nodeDeleteButton.Click += new System.EventHandler(this.nodeDeleteButton_Click);
            // 
            // ledgeDeleteButton
            // 
            this.ledgeDeleteButton.Location = new System.Drawing.Point(846, 609);
            this.ledgeDeleteButton.Name = "ledgeDeleteButton";
            this.ledgeDeleteButton.Size = new System.Drawing.Size(100, 23);
            this.ledgeDeleteButton.TabIndex = 15;
            this.ledgeDeleteButton.Text = "Delete Ledge";
            this.ledgeDeleteButton.UseVisualStyleBackColor = true;
            this.ledgeDeleteButton.Click += new System.EventHandler(this.ledgeDeleteButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(822, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mouse ( x / y ):";
            // 
            // mouseCoordinatesLabel
            // 
            this.mouseCoordinatesLabel.AutoSize = true;
            this.mouseCoordinatesLabel.Location = new System.Drawing.Point(903, 119);
            this.mouseCoordinatesLabel.Name = "mouseCoordinatesLabel";
            this.mouseCoordinatesLabel.Size = new System.Drawing.Size(30, 13);
            this.mouseCoordinatesLabel.TabIndex = 17;
            this.mouseCoordinatesLabel.Text = "0 / 0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(822, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ingame ( x / y ):";
            // 
            // ingameMouseCoordinates
            // 
            this.ingameMouseCoordinates.AutoSize = true;
            this.ingameMouseCoordinates.Location = new System.Drawing.Point(903, 141);
            this.ingameMouseCoordinates.Name = "ingameMouseCoordinates";
            this.ingameMouseCoordinates.Size = new System.Drawing.Size(30, 13);
            this.ingameMouseCoordinates.TabIndex = 17;
            this.ingameMouseCoordinates.Text = "0 / 0";
            // 
            // scriptListBox
            // 
            this.scriptListBox.FormattingEnabled = true;
            this.scriptListBox.Location = new System.Drawing.Point(1001, 44);
            this.scriptListBox.Name = "scriptListBox";
            this.scriptListBox.Size = new System.Drawing.Size(171, 199);
            this.scriptListBox.TabIndex = 19;
            this.scriptListBox.SelectedIndexChanged += new System.EventHandler(this.scriptListBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(998, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Script:";
            // 
            // scriptLineTextBox
            // 
            this.scriptLineTextBox.Location = new System.Drawing.Point(1001, 249);
            this.scriptLineTextBox.Name = "scriptLineTextBox";
            this.scriptLineTextBox.Size = new System.Drawing.Size(146, 20);
            this.scriptLineTextBox.TabIndex = 21;
            this.scriptLineTextBox.TextChanged += new System.EventHandler(this.scriptLineTextBox_TextChanged);
            this.scriptLineTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.scriptLineBoxOnEnterPressed);
            // 
            // scriptDeleteButton
            // 
            this.scriptDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("scriptDeleteButton.Image")));
            this.scriptDeleteButton.Location = new System.Drawing.Point(1153, 278);
            this.scriptDeleteButton.Name = "scriptDeleteButton";
            this.scriptDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.scriptDeleteButton.TabIndex = 22;
            this.scriptDeleteButton.UseVisualStyleBackColor = true;
            this.scriptDeleteButton.Click += new System.EventHandler(this.scriptDeleteButton_Click);
            // 
            // scriptEditButton
            // 
            this.scriptEditButton.Image = ((System.Drawing.Image)(resources.GetObject("scriptEditButton.Image")));
            this.scriptEditButton.Location = new System.Drawing.Point(1152, 249);
            this.scriptEditButton.Name = "scriptEditButton";
            this.scriptEditButton.Size = new System.Drawing.Size(20, 20);
            this.scriptEditButton.TabIndex = 22;
            this.scriptEditButton.UseVisualStyleBackColor = true;
            this.scriptEditButton.Click += new System.EventHandler(this.scriptEditButton_Click);
            // 
            // scriptCommandsListBox
            // 
            this.scriptCommandsListBox.FormattingEnabled = true;
            this.scriptCommandsListBox.Location = new System.Drawing.Point(1001, 343);
            this.scriptCommandsListBox.Name = "scriptCommandsListBox";
            this.scriptCommandsListBox.Size = new System.Drawing.Size(172, 95);
            this.scriptCommandsListBox.TabIndex = 23;
            this.scriptCommandsListBox.SelectedIndexChanged += new System.EventHandler(this.scriptCommandsListBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(998, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Available Script Commands:";
            // 
            // addScriptCommandButton
            // 
            this.addScriptCommandButton.Location = new System.Drawing.Point(1027, 441);
            this.addScriptCommandButton.Name = "addScriptCommandButton";
            this.addScriptCommandButton.Size = new System.Drawing.Size(120, 23);
            this.addScriptCommandButton.TabIndex = 25;
            this.addScriptCommandButton.Text = "Add Script Command";
            this.addScriptCommandButton.UseVisualStyleBackColor = true;
            this.addScriptCommandButton.Click += new System.EventHandler(this.addScriptCommandButton_Click);
            // 
            // getMouseCoordButton
            // 
            this.getMouseCoordButton.Location = new System.Drawing.Point(1001, 278);
            this.getMouseCoordButton.Name = "getMouseCoordButton";
            this.getMouseCoordButton.Size = new System.Drawing.Size(120, 23);
            this.getMouseCoordButton.TabIndex = 26;
            this.getMouseCoordButton.Text = "Get Mouse Coord.";
            this.getMouseCoordButton.UseVisualStyleBackColor = true;
            this.getMouseCoordButton.Click += new System.EventHandler(this.getMouseCoordButton_Click);
            // 
            // scriptInsertLineButton
            // 
            this.scriptInsertLineButton.Image = global::MapEditorWindows.Properties.Resources.plus;
            this.scriptInsertLineButton.Location = new System.Drawing.Point(1127, 278);
            this.scriptInsertLineButton.Name = "scriptInsertLineButton";
            this.scriptInsertLineButton.Size = new System.Drawing.Size(20, 20);
            this.scriptInsertLineButton.TabIndex = 27;
            this.scriptInsertLineButton.UseVisualStyleBackColor = true;
            this.scriptInsertLineButton.Click += new System.EventHandler(this.scriptInsertLineButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1001, 466);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Explanation:";
            // 
            // scriptDetailTextBox
            // 
            this.scriptDetailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scriptDetailTextBox.Enabled = false;
            this.scriptDetailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptDetailTextBox.Location = new System.Drawing.Point(1001, 482);
            this.scriptDetailTextBox.Multiline = true;
            this.scriptDetailTextBox.Name = "scriptDetailTextBox";
            this.scriptDetailTextBox.ReadOnly = true;
            this.scriptDetailTextBox.Size = new System.Drawing.Size(172, 150);
            this.scriptDetailTextBox.TabIndex = 30;
            this.scriptDetailTextBox.TextChanged += new System.EventHandler(this.scriptDetailTextBox_TextChanged);
            // 
            // mapEditorMain1
            // 
            this.mapEditorMain1.CurrentLayer = 1;
            this.mapEditorMain1.CurrentLedge = 0;
            this.mapEditorMain1.Location = new System.Drawing.Point(13, 28);
            this.mapEditorMain1.Map = null;
            this.mapEditorMain1.Mode = MapEditorWindows.MapClasses.DrawingMode.SegmentSelection;
            this.mapEditorMain1.Name = "mapEditorMain1";
            this.mapEditorMain1.Scroll = new Microsoft.Xna.Framework.Vector2(0F, 0F);
            this.mapEditorMain1.Size = new System.Drawing.Size(800, 600);
            this.mapEditorMain1.TabIndex = 31;
            this.mapEditorMain1.Text = "mapEditorMain1";
            this.mapEditorMain1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.mapEditorMain1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            this.mapEditorMain1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onMouseUp);
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 647);
            this.Controls.Add(this.mapEditorMain1);
            this.Controls.Add(this.scriptDetailTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.scriptEditButton);
            this.Controls.Add(this.scriptInsertLineButton);
            this.Controls.Add(this.getMouseCoordButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.scriptCommandsListBox);
            this.Controls.Add(this.addScriptCommandButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.scriptLineTextBox);
            this.Controls.Add(this.scriptDeleteButton);
            this.Controls.Add(this.scriptListBox);
            this.Controls.Add(this.ingameMouseCoordinates);
            this.Controls.Add(this.mouseCoordinatesLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ledgeDeleteButton);
            this.Controls.Add(this.nodeDeleteButton);
            this.Controls.Add(this.ledgeNodeLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ledgeCheckBox);
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
       
        private System.Windows.Forms.CheckBox ledgeCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ledgeNodeLabel;
        private System.Windows.Forms.ToolStripMenuItem deleteSegmentsToolStripMenuItem;
        private System.Windows.Forms.Button nodeDeleteButton;
        private System.Windows.Forms.Button ledgeDeleteButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label mouseCoordinatesLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ingameMouseCoordinates;
        private System.Windows.Forms.ListBox scriptListBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox scriptLineTextBox;
        private System.Windows.Forms.Button scriptDeleteButton;
        private System.Windows.Forms.Button scriptEditButton;
        private System.Windows.Forms.ListBox scriptCommandsListBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button addScriptCommandButton;
        private System.Windows.Forms.Button getMouseCoordButton;
        private System.Windows.Forms.Button scriptInsertLineButton;
        
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox scriptDetailTextBox;
        private System.Windows.Forms.ToolStripMenuItem scriptCoordinatesToolStripMenuItem;
        private MapEditorMain mapEditorMain1;
        
    }
}

