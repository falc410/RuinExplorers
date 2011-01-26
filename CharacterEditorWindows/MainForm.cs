
using System.Windows.Forms;
using CharacterEditorWindows.Character;


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

                // load frame information
                for (int i = 0; i < characterEditorMain1.charDef.Frames.Length; i++)
                {
                    framesListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Frames[i].Name);
                }

                // load key frame information
                for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames.Length; i++)
                {
                    if (characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference > -1)
                        keyFrameListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Frames[characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference].Name);                        
                    else
                        keyFrameListBox.Items.Add(i.ToString() + ": ");
                }

                // load script information
                for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts.Length; i++)
                {
                    scriptsListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts[i]);
                }
                // initially select some stuff - or maybe not
                animationsListBox.SelectedIndex = characterEditorMain1.SelectedAnimation;
                framesListBox.SelectedIndex = characterEditorMain1.SelectedFrame;
                partListBox.SelectedIndex = characterEditorMain1.SelectedPart;
                keyFrameListBox.SelectedIndex = characterEditorMain1.SelectedKeyFrame;
                scriptsListBox.SelectedIndex = characterEditorMain1.SelectedScriptLine;
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
            // rename it. so we clear it completely and reload it. haven't found a better way to handle it

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
            // reload key frame box
            keyFrameListBox.Items.Clear();
            // load key frame information
            for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames.Length; i++)
            {
                if (characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference > -1)
                    keyFrameListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Frames[characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference].Name);
                else
                    keyFrameListBox.Items.Add(i.ToString() + ": ");
            }
            keyFrameListBox.SelectedIndex = characterEditorMain1.SelectedKeyFrame;

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

        private void partResetRotationButton_Click(object sender, System.EventArgs e)
        {

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

        #region KeyFrame Related Forms
       
        private void keyFrameListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            characterEditorMain1.SelectedKeyFrame = keyFrameListBox.SelectedIndex;
            keyFrameDurationUpDown.Value = characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Duration;
            // reload script box
            scriptsListBox.Items.Clear();
            // load script information
            for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts.Length; i++)
            {
                scriptsListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts[i]);
            }
        }

        private void keyFrameDurationUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            if (keyFrameDurationUpDown.Value <= 0)
            {
                Animation animation = characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation];
                for (int j = keyFrameListBox.SelectedIndex; j < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames.Length - 1; j++)
                {
                    KeyFrame keyFrame = characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[j];
                    keyFrame.FrameReference = animation.KeyFrames[j + 1].FrameReference;
                    keyFrame.Duration = animation.KeyFrames[j + 1].Duration;
                }
                animation.KeyFrames[animation.KeyFrames.Length - 1].FrameReference = -1;
                //reload list box
                keyFrameListBox.Items.Clear();
                // load key frame information
                for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames.Length; i++)
                {
                    if (characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference > -1)
                        keyFrameListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Frames[characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference].Name);
                    else
                        keyFrameListBox.Items.Add(i.ToString() + ": ");
                }
                keyFrameListBox.SelectedIndex = characterEditorMain1.SelectedKeyFrame;
            }
            characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Duration = (int)keyFrameDurationUpDown.Value;            
        }
        #endregion

        #region Frames Related Forms
        
        private void framesListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void framesAddReferenceButton_Click(object sender, System.EventArgs e)
        {

        }

        private void framesNametextBox_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void framesEditbutton_Click(object sender, System.EventArgs e)
        {

        }

        private void framesDeletebutton_Click(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region Script Related Forms
        
        private void scriptsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            characterEditorMain1.SelectedScriptLine = scriptsListBox.SelectedIndex;
            scriptsTextBox.Text = characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts[characterEditorMain1.SelectedScriptLine];
        }

        private void scriptsNametextBox_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void scriptsEditbutton_Click(object sender, System.EventArgs e)
        {
            characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts[characterEditorMain1.SelectedScriptLine] = scriptsTextBox.Text;
            // reload script box
            scriptsListBox.Items.Clear();
            // load script information
            for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts.Length; i++)
            {
                scriptsListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts[i]);
            }
        }

        private void scriptsDeletebutton_Click(object sender, System.EventArgs e)
        {
            characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts[characterEditorMain1.SelectedScriptLine] = "";
            // reload script box
            scriptsListBox.Items.Clear();
            // load script information
            for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts.Length; i++)
            {
                scriptsListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts[i]);
            }
        }
        #endregion
       
    }
}
