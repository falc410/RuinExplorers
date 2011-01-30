using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MapEditorWindows.MapClasses;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MapEditorWindows
{
    public partial class MapEditorForm : Form
    {

        int mouseX;
        int mouseY;
        bool isLeftMouseDown;
        bool isRightMouseDown;        
        int mouseDragSegment;

        public MapEditorForm()
        {
            InitializeComponent();            
        }

        #region MenuStrip Items
        
        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapEditorMain1.Map = new Map();

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
            backgroundToolStripMenuItem.Checked = true;            
            drawingToolStripMenuItem.Checked = true;            
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mapEditorMain1.Map.Path = openFileDialog1.FileName;
                mapEditorMain1.Map.Read();
            }

            for (int i = 0; i < mapEditorMain1.Map.segDef.Length; i++)
            {
                if (mapEditorMain1.Map.segDef[i] != null)
                    segmentListBox.Items.Add(mapEditorMain1.Map.segDef[i].name);
            }
            FillPictureBox(mapEditorMain1.SegmentImage, mapEditorMain1.Map.segDef[0].sourceRect.X, mapEditorMain1.Map.segDef[0].sourceRect.Y, mapEditorMain1.Map.segDef[0].sourceRect.Width, mapEditorMain1.Map.segDef[0].sourceRect.Height);

            for (int i = 0; i < mapEditorMain1.Map.Legdes.Length; i++)
            {
                ledgeListBox.Items.Add("ledge " + i.ToString());
            }
            
            mapEditorMain1.CurrentLedge = 0;            
            if (mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].isHardLedge == 1)
                ledgeCheckBox.Checked = true;
            ledgeNodeLabel.Text = mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].TotalNodes.ToString();            
            modeSelectComboBox.SelectedIndex = 0;
            layerSelectComboBox.SelectedIndex = 0;
            backgroundToolStripMenuItem.Checked = true;
            drawingToolStripMenuItem.Checked = true;
            ledgeListBox.SelectedIndex = 0;
            segmentListBox.SelectedIndex = 0;
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
            backgroundToolStripMenuItem.Checked = false;
            middleToolStripMenuItem.Checked = false;
            foregroundToolStripMenuItem.Checked = true;
            layerSelectComboBox.SelectedIndex = 2;
        }

        private void middleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundToolStripMenuItem.Checked = false;
            middleToolStripMenuItem.Checked = true;
            foregroundToolStripMenuItem.Checked = false;
            layerSelectComboBox.SelectedIndex = 1;
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundToolStripMenuItem.Checked = true;
            middleToolStripMenuItem.Checked = false;
            foregroundToolStripMenuItem.Checked = false;
            layerSelectComboBox.SelectedIndex = 0;
        }

        private void drawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingToolStripMenuItem.Checked = true;
            collisionMapToolStripMenuItem.Checked = false;
            editLedgesToolStripMenuItem.Checked = false;
            deleteSegmentsToolStripMenuItem.Checked = false;
            modeSelectComboBox.SelectedIndex = 0;
        }

        private void collisionMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingToolStripMenuItem.Checked = false;
            collisionMapToolStripMenuItem.Checked = true;
            editLedgesToolStripMenuItem.Checked = false;
            deleteSegmentsToolStripMenuItem.Checked = false;
            modeSelectComboBox.SelectedIndex = 1;
        }

        private void editLedgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingToolStripMenuItem.Checked = false;
            collisionMapToolStripMenuItem.Checked = false;
            editLedgesToolStripMenuItem.Checked = true;
            deleteSegmentsToolStripMenuItem.Checked = false;
            modeSelectComboBox.SelectedIndex = 2;
        }

        private void deleteSegmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingToolStripMenuItem.Checked = false;
            collisionMapToolStripMenuItem.Checked = false;
            editLedgesToolStripMenuItem.Checked = false;
            deleteSegmentsToolStripMenuItem.Checked = true;
            modeSelectComboBox.SelectedIndex = 3;

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

        private void nodeDeleteButton_Click(object sender, EventArgs e)
        {
            if (mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].TotalNodes > 0)
            {
                int index = mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].TotalNodes;
                Array.Clear(mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].Nodes, index - 1, 1);
                mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].TotalNodes--;
                ledgeNodeLabel.Text = mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].TotalNodes.ToString();
            }
        }

        private void ledgeDeleteButton_Click(object sender, EventArgs e)
        {
            mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge] = null;
            mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge] = new Ledge();
            ledgeCheckBox.Checked = false;
            ledgeNodeLabel.Text = "0";
        }

        #endregion

        private void modeSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (modeSelectComboBox.SelectedIndex)
            {
                case 0:
                    mapEditorMain1.Mode = DrawingMode.SegmentSelection;
                    drawingToolStripMenuItem.Checked = true;
                collisionMapToolStripMenuItem.Checked = false;
                editLedgesToolStripMenuItem.Checked = false;
                deleteSegmentsToolStripMenuItem.Checked = false;
                    break;
                case 1:
                    mapEditorMain1.Mode = DrawingMode.CollisionMap;
                     drawingToolStripMenuItem.Checked = false;
                     collisionMapToolStripMenuItem.Checked = true;
                editLedgesToolStripMenuItem.Checked = false;
                deleteSegmentsToolStripMenuItem.Checked = false;
                    break;
                case 2:
                    mapEditorMain1.Mode = DrawingMode.Ledges;
                     drawingToolStripMenuItem.Checked = false;
                collisionMapToolStripMenuItem.Checked = false;
                editLedgesToolStripMenuItem.Checked = true;
                deleteSegmentsToolStripMenuItem.Checked = false;
                    break;
                case 3:
                    mapEditorMain1.Mode = DrawingMode.DeleteSegment;
                     drawingToolStripMenuItem.Checked = false;
                collisionMapToolStripMenuItem.Checked = false;
                editLedgesToolStripMenuItem.Checked = false;
                deleteSegmentsToolStripMenuItem.Checked = true;
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
            switch (layerSelectComboBox.SelectedIndex)
            {
                case 0:
                    backgroundToolStripMenuItem.Checked = true;
                    middleToolStripMenuItem.Checked = false;
                    foregroundToolStripMenuItem.Checked = false;
                    break;
                case 1:
                    backgroundToolStripMenuItem.Checked = false;
                    middleToolStripMenuItem.Checked = true;
                    foregroundToolStripMenuItem.Checked = false;
                    break;
                case 2:
                    backgroundToolStripMenuItem.Checked = false;
                    middleToolStripMenuItem.Checked = false;
                    foregroundToolStripMenuItem.Checked = true;
                    break;

                default:
                    break;
            }
        }

        #region Mouse Events
        
        private void onMouseMove(object sender, MouseEventArgs e)
        {
            int mouseDiffX = e.X - mouseX;
            int mouseDiffY = e.Y - mouseY;

            if (isRightMouseDown)
            {
                Vector2 mouseDiff = new Vector2(mouseDiffX * 2.0f, mouseDiffY * 2.0f);
                mapEditorMain1.Scroll -= mouseDiff;  
            }

            switch (mapEditorMain1.Mode)
            {
                case DrawingMode.SegmentSelection:
                    if (isLeftMouseDown && mouseDragSegment == -1)
                    {
                        mouseDragSegment = mapEditorMain1.Map.GetHoveredSegment(e.X, e.Y, mapEditorMain1.CurrentLayer, mapEditorMain1.Scroll);
                      
                    }
                    if (!isLeftMouseDown)
                        mouseDragSegment = -1;
                    if (mouseDragSegment > -1)
                    {
                        Vector2 location = mapEditorMain1.Map.Segments[mapEditorMain1.CurrentLayer, mouseDragSegment].location;
                        location.X += mouseDiffX;
                        location.Y += mouseDiffY;
                        mapEditorMain1.Map.Segments[mapEditorMain1.CurrentLayer, mouseDragSegment].location = location;
                    }
                    break;
                case DrawingMode.CollisionMap:
                    break;
                case DrawingMode.Ledges:
                    break;
                default:
                    break;
            }
           
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                isLeftMouseDown = true;
            if (e.Button == MouseButtons.Right)
                isRightMouseDown = true;

            if (mapEditorMain1.Mode == DrawingMode.Ledges && isLeftMouseDown)
            {
                if (mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge] == null)
                    mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge] = new Ledge();

                if (mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].TotalNodes < 15)
                {
                    mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].Nodes[mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].TotalNodes] = new Vector2(e.X, e.Y) + mapEditorMain1.Scroll / 2.0f;
                    mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].TotalNodes++;
                    ledgeNodeLabel.Text = mapEditorMain1.Map.Legdes[mapEditorMain1.CurrentLedge].TotalNodes.ToString(); 
                }
            }

            if (mapEditorMain1.Mode == DrawingMode.CollisionMap)
            {
                int x = (mouseX + (int)(mapEditorMain1.Scroll.X / 2)) / 32;
                int y = (mouseY + (int)(mapEditorMain1.Scroll.Y / 2)) / 32;

                if (x >= 0 && y >= 0 && x < 20 && y < 20)
                {
                    if (isLeftMouseDown)
                        if (mapEditorMain1.Map.Grid[x, y] == 0)
                            mapEditorMain1.Map.Grid[x, y] = 1;
                        else
                            mapEditorMain1.Map.Grid[x, y] = 0;                    
                }
            }

            if (mapEditorMain1.Mode == DrawingMode.DeleteSegment)
            {
                if (isLeftMouseDown)
                {
                    int selectedSegment = mapEditorMain1.Map.GetHoveredSegment(e.X, e.Y, mapEditorMain1.CurrentLayer, mapEditorMain1.Scroll);
                    mapEditorMain1.Map.DeleteSegment(mapEditorMain1.CurrentLayer, selectedSegment);
                }                                       
            }
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isLeftMouseDown = false;
            if (e.Button == MouseButtons.Right)
                isRightMouseDown = false;      
        }
        #endregion
        

   

      
    }
}
