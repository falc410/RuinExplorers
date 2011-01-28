using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MapEditorWindows.MapClasses;

namespace MapEditorWindows
{
    public partial class MapEditorForm : Form
    {

        public MapEditorForm()
        {
            InitializeComponent();
        }

        #region MenuStrip Items
        
        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mapEditorMain1.Map.segDef.Length; i++)
            {
                if(mapEditorMain1.Map.segDef[i] != null)
                    segmentListBox.Items.Add(mapEditorMain1.Map.segDef[i].name);
            }
            FillPictureBox(mapEditorMain1.SegmentImage, mapEditorMain1.Map.segDef[0].sourceRect.X, mapEditorMain1.Map.segDef[0].sourceRect.Y,mapEditorMain1.Map.segDef[0].sourceRect.Width,mapEditorMain1.Map.segDef[0].sourceRect.Height);

            for (int i = 0; i < mapEditorMain1.Map.Legdes.Length; i++)
            {
                ledgeListBox.Items.Add("ledge " + i.ToString());
            }

            ledgeListBox.SelectedIndex = 0;
            mapEditorMain1.CurrentLedge = 0;
            if (mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].isHardLedge == 1)
                ledgeCheckBox.Checked = true;
            segmentListBox.SelectedIndex = 0;
            modeSelectComboBox.SelectedIndex = 0;
            layerSelectComboBox.SelectedIndex = 0;
            foregroundToolStripMenuItem.Checked = true;
            drawingToolStripMenuItem.Checked = true;
            ledgeNodeLabel.Text = "0";
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mapEditorMain1.Map.Path = openFileDialog1.FileName;
                mapEditorMain1.Map.Read();
            }
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void middleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void drawingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void collisionMapToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editLedgesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #region Segment Forms
        
        private void segmentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPictureBox(mapEditorMain1.SegmentImage, mapEditorMain1.Map.segDef[segmentListBox.SelectedIndex].sourceRect.X, mapEditorMain1.Map.segDef[segmentListBox.SelectedIndex].sourceRect.Y, mapEditorMain1.Map.segDef[segmentListBox.SelectedIndex].sourceRect.Width, mapEditorMain1.Map.segDef[segmentListBox.SelectedIndex].sourceRect.Height);
        }

        private void addSegmentButton_Click(object sender, EventArgs e)
        {
            int f = mapEditorMain1.Map.AddSeg(mapEditorMain1.CurrentLayer, segmentListBox.SelectedIndex);
            if (f <= -1)
            {
                Console.WriteLine("Can not add any more segments");
                throw new IndexOutOfRangeException();
            }
                

            float layerScalar = 0.5f;
            if (mapEditorMain1.CurrentLayer == 0)
                layerScalar = 0.375f;
            else if (mapEditorMain1.CurrentLayer == 2)
                layerScalar = 0.625f;

            mapEditorMain1.Map.Segments[mapEditorMain1.CurrentLayer, f].location.X = (mapEditorMain1.Map.segDef[segmentListBox.SelectedIndex].sourceRect.Width + mapEditorMain1.Scroll.X * layerScalar);
            mapEditorMain1.Map.Segments[mapEditorMain1.CurrentLayer, f].location.Y = (mapEditorMain1.Map.segDef[segmentListBox.SelectedIndex].sourceRect.Height + mapEditorMain1.Scroll.Y * layerScalar);
        }

        #endregion

        #region Ledge Forms
        
        private void ledgeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapEditorMain1.CurrentLedge = ledgeListBox.SelectedIndex;
            if (mapEditorMain1.Map.Legdes[ledgeListBox.SelectedIndex].isHardLedge == 0)
                ledgeCheckBox.Checked = false;
            else
                ledgeCheckBox.Checked = true;
            ledgeNodeLabel.Text = mapEditorMain1.Map.Legdes[ledgeListBox.SelectedIndex].TotalNodes.ToString();
        }

        private void ledgeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ledgeCheckBox.Checked == true)
                mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].isHardLedge = 1;            
            else
                mapEditorMain1.Map.Legdes[ledgeListBox.SelectedIndex].isHardLedge = 0;
        }

        #endregion
        private void modeSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (modeSelectComboBox.SelectedIndex)
            {
                case 0:
                    mapEditorMain1.Mode = DrawingMode.SegmentSelection;
                    break;
                case 1:
                    mapEditorMain1.Mode = DrawingMode.CollisionMap;
                    break;
                case 2:
                    mapEditorMain1.Mode = DrawingMode.Ledges;
                    break;
                default:
                    break;
            }            
        }

        private void FillPictureBox(Image sourceBitmap, int x, int y, int width, int height)
        { 
            Image image = (Image)new Bitmap(150, 100);
            Rectangle destRectangle = new Rectangle(0, 0, 150, 100);
            Rectangle sourceRect = new Rectangle(x, y, width, height);

            if (sourceRect.Width > sourceRect.Height)
            {
                destRectangle.Width = 100;
                destRectangle.Height = (int)(((float)sourceRect.Height / (float)sourceRect.Width) * 100.0f);
            }
            else
            {
                destRectangle.Height = 100;
                destRectangle.Width = (int)(((float)sourceRect.Width / (float)sourceRect.Height) * 100.0f);
            }

            Graphics gi = Graphics.FromImage(image);
            gi.DrawImage(sourceBitmap,
                destRectangle,
                sourceRect,
                GraphicsUnit.Pixel);

            segmentPictureBox.Image = image;
          
        }

      
        private void layerSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapEditorMain1.CurrentLayer = layerSelectComboBox.SelectedIndex;
        }

      
    }
}
