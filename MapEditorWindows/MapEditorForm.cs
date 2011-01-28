using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rect = System.Drawing.Rectangle;

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
            FillPictureBox(mapEditorMain1.SegmentImage, 0);
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
        #endregion

        private void segmentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addSegmentButton_Click(object sender, EventArgs e)
        {

        }

        private void ledgeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void modeSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FillPictureBox(Image sourceBitmap, int index)
        { 
            Image image = (Image)new Bitmap(150, 100);
            Rect destRectangle = new Rect(0, 0, 150, 100);
            Rect sourceRect = new Rect();
            sourceRect.X = ((index % 64) % 5) * 64;
            sourceRect.Y = ((index % 64) / 5) * 64;
            sourceRect.Width = 64;
            sourceRect.Height = 64;

            Graphics gi = Graphics.FromImage(image);
            gi.DrawImage(sourceBitmap,
                destRectangle,
                sourceRect,
                GraphicsUnit.Pixel);

            segmentPictureBox.Image = image;
          
        }
    }
}
