
using System.Windows.Forms;


namespace CharacterEditorWindows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region MenuStrip1
        
        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }       

        private void openCharacterToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                characterEditorMain1.charDef.Path = openFileDialog1.FileName;
                characterEditorMain1.charDef.Read();

                //fill box with animation names
                for (int i = 0; i < characterEditorMain1.charDef.Animations.Length; i++)
                {
                    animationsListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Animations[i].Name);                   
                }

                // load part listbox
                for (int i = 0; i < characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts.Length; i++)
                {
                    string line = "";
                    int index = characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[i].Index;

                    if (index < 0)
                        line = "";
                    else if (index < 64)
                        line = "head" + index.ToString();
                    else if (index < 74)
                        line = "torso" + index.ToString();
                    else if (index < 128)
                        line = "arms" + index.ToString();
                    else if (index < 192)
                        line = "legs" + index.ToString();
                    else
                        line = "weapons" + index.ToString();

                    partListBox.Items.Add(i.ToString() + ": " + line);
                }
            }
        }

        private void saveCharacterToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void importTexturesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }
        
        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        #endregion
        #region Animation Related Forms
        
        private void animationsDeletebutton_Click(object sender, System.EventArgs e)
        {
            // just erase the name in the array - the animation will still exist
            // TODO: how can we really erase it?
            characterEditorMain1.charDef.Animations[animationsListBox.SelectedIndex].Name = "";
            // next problem is updating the listbox. We can't delete the entry from here and we can not
            // rename it. so we clear it completely and reload it.
            // sucks!
            animationsListBox.Items.Clear();
            //fill box with animation names
            for (int i = 0; i < characterEditorMain1.charDef.Animations.Length; i++)
            {
                animationsListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Animations[i].Name);
            }

        }

        private void animationsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            characterEditorMain1.SelectedAnimation = animationsListBox.SelectedIndex;
            animationsNametextBox.Text = characterEditorMain1.charDef.Animations[animationsListBox.SelectedIndex].Name;
        }

        private void animationsEditbutton_Click(object sender, System.EventArgs e)
        {
            characterEditorMain1.charDef.Animations[animationsListBox.SelectedIndex].Name = animationsNametextBox.Text;
            // and again update the listbox 
            animationsListBox.Items.Clear();
            //fill box with animation names
            for (int i = 0; i < characterEditorMain1.charDef.Animations.Length; i++)
            {
                animationsListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Animations[i].Name);
            }
        }

        private void animationsNametextBox_TextChanged(object sender, System.EventArgs e)
        {
            
        }
        #endregion
        #region Part Related Forms
       
        private void partDeleteButton_Click(object sender, System.EventArgs e)
        {
            characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[partListBox.SelectedIndex].Index = -1;
            //reload partListBox
            partListBox.Items.Clear();

            for (int i = 0; i < characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts.Length; i++)
            {
                string line = "";
                int index = characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[i].Index;

                if (index < 0)
                    line = "";
                else if (index < 64)
                    line = "head" + index.ToString();
                else if (index < 74)
                    line = "torso" + index.ToString();
                else if (index < 128)
                    line = "arms" + index.ToString();
                else if (index < 192)
                    line = "legs" + index.ToString();
                else
                    line = "weapons" + index.ToString();

                partListBox.Items.Add(i.ToString() + ": " + line);
            }

        }

        private void partListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            characterEditorMain1.SelectedPart = partListBox.SelectedIndex;
            if (characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[characterEditorMain1.SelectedPart].Flip == 0)
                partFlipCheckBox.Checked = false;
            else
                partFlipCheckBox.Checked = true;
            //partRotationUpDown.Value = (decimal)characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[partListBox.SelectedIndex].Rotation;
            //partScaleXUpDown.Value = (decimal)characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[partListBox.SelectedIndex].Scaling.X;
            //partScaleYUpDown.Value = (decimal)characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[partListBox.SelectedIndex].Scaling.Y;
        }

        private void partRotationUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[partListBox.SelectedIndex].Rotation = (float)partRotationUpDown.Value / 100.0f;
        }

        private void partFlipCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (partFlipCheckBox.Checked == true)
                characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[characterEditorMain1.SelectedPart].Flip = 1;
            if (partFlipCheckBox.Checked == false)
                characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[characterEditorMain1.SelectedPart].Flip = 0;
        }

        private void partResetXScaleButton_Click(object sender, System.EventArgs e)
        {
            characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[partListBox.SelectedIndex].Scaling.X = 1.0f;
        }

        private void partResetYScaleButton_Click(object sender, System.EventArgs e)
        {
            characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[partListBox.SelectedIndex].Scaling.Y = 1.0f;
        }

        private void partMoveUpButton_Click(object sender, System.EventArgs e)
        {
            characterEditorMain1.SwapParts(characterEditorMain1.SelectedPart, characterEditorMain1.SelectedPart - 1);
            // update partlistbox
            partListBox.Items.Clear();
            // load part listbox
            for (int i = 0; i < characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts.Length; i++)
            {
                string line = "";
                int index = characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[i].Index;

                if (index < 0)
                    line = "";
                else if (index < 64)
                    line = "head" + index.ToString();
                else if (index < 74)
                    line = "torso" + index.ToString();
                else if (index < 128)
                    line = "arms" + index.ToString();
                else if (index < 192)
                    line = "legs" + index.ToString();
                else
                    line = "weapons" + index.ToString();

                partListBox.Items.Add(i.ToString() + ": " + line);
            }
            // set focus again
            partListBox.SelectedIndex = characterEditorMain1.SelectedPart - 1;
        }

        private void partMoveDownButton_Click(object sender, System.EventArgs e)
        {
            if (characterEditorMain1.SwapParts(characterEditorMain1.SelectedPart, characterEditorMain1.SelectedPart + 1))
            {
                // update partlistbox
            partListBox.Items.Clear();
            // load part listbox
            for (int i = 0; i < characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts.Length; i++)
                {
                    string line = "";
                    int index = characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[i].Index;

                    if (index < 0)
                        line = "";
                    else if (index < 64)
                        line = "head" + index.ToString();
                    else if (index < 74)
                        line = "torso" + index.ToString();
                    else if (index < 128)
                        line = "arms" + index.ToString();
                    else if (index < 192)
                        line = "legs" + index.ToString();
                    else
                        line = "weapons" + index.ToString();

                    partListBox.Items.Add(i.ToString() + ": " + line);
                }
                // set focus again
            partListBox.SelectedIndex = characterEditorMain1.SelectedPart + 1;                
            }            
        }

        private void partScaleXUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[partListBox.SelectedIndex].Scaling.X = (float)partScaleXUpDown.Value / 100.0f;
        }

        private void partScaleYUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[partListBox.SelectedIndex].Scaling.Y = (float)partScaleYUpDown.Value / 100.0f;
        }
        #endregion

    }
}
