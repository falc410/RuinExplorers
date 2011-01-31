
using System.Windows.Forms;
using CharacterEditorWindows.Character;
using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Rect = System.Drawing.Rectangle;


namespace CharacterEditorWindows
{
    public partial class MainForm : Form
    {
        enum EditingMode
        {
            Location,
            Scale,
            Rotation
        }

        EditingMode editMode;

        bool initialize;
        int mouseX;
        int mouseY;
        bool isMouseDown;

        public MainForm()
        {
            InitializeComponent();

            editModeComboBox.SelectedIndex = 0;
        }

        #region MenuStrip1
        
        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void newCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (characterEditorMain1.charDef != null)
                characterEditorMain1.charDef = new CharacterDefinition();

            initialize = true;
            //need to set the first frameName for compatibility reasons
            characterEditorMain1.charDef.Frames[0].Name = "newFrame";
            //initialize animationsbox
            animationsListBox.Items.Clear();
            for (int i = 0; i < characterEditorMain1.charDef.Animations.Length; i++)
            {
                animationsListBox.Items.Add(i.ToString() + ": ");
            }

            // initialize part listbox
            partListBox.Items.Clear();
            for (int i = 0; i < characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts.Length; i++)
            {
                partListBox.Items.Add(i.ToString() + ": ");
            }

            // initialize frame information
            framesListBox.Items.Clear();            
            for (int i = 0; i < characterEditorMain1.charDef.Frames.Length; i++)
            {
                framesListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Frames[i].Name);
            }

            // initialize key frame information
            keyFrameListBox.Items.Clear();
            for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames.Length; i++)
            {                
                    keyFrameListBox.Items.Add(i.ToString() + ": ");
            }

            // initialize script information
            scriptsListBox.Items.Clear();
            for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts.Length; i++)
            {
                scriptsListBox.Items.Add(i.ToString() + ": ");
            }
            // initially select some stuff
            animationsListBox.SelectedIndex = characterEditorMain1.SelectedAnimation;
            framesListBox.SelectedIndex = characterEditorMain1.SelectedFrame;
            partListBox.SelectedIndex = characterEditorMain1.SelectedPart;
            keyFrameListBox.SelectedIndex = characterEditorMain1.SelectedKeyFrame;
            scriptsListBox.SelectedIndex = characterEditorMain1.SelectedScriptLine;

            //load picture boxes with textures
            // TODO: arms are not imported!
            // spritesheet thinks that every sprite is 64x64
            // except weapons which are 80x64
            /* index 0-63 for head texture
             * 64-127 for torso texture
             * 128-191 for legs texture
             * 192 - 256 for weapons texture
            */
            for (int i = 0; i < 25; i++)
            {
                availableHeadParts.Items.Add(i.ToString() + ": " + "head" + i.ToString());
                availableTorsoParts.Items.Add(i.ToString() + ": " + "torso" + (i + 64 * 1).ToString());
                availableLegsParts.Items.Add(i.ToString() + ": " + "legs" + (i + 64 * 2).ToString());
                availableWeaponsParts.Items.Add(i.ToString() + ": " + "weapons" + (i + 64 * 3).ToString());
            }
            FillPictureBox(headPreview,characterEditorMain1.HeadBitmap[0], 0);
            FillPictureBox(torsoPreview, characterEditorMain1.TorsoBitmap[0], 0);
            FillPictureBox(legsPreview, characterEditorMain1.LegsBitmap[0], 0);
            FillPictureBox(weaponsPreview, characterEditorMain1.WeaponsBitmap[0], 0);

            availableHeadParts.SelectedIndex = 0;
            availableTorsoParts.SelectedIndex = 0;
            availableLegsParts.SelectedIndex = 0;
            availableWeaponsParts.SelectedIndex = 0;

            // initialize triggers
            triggersListBox.Items.Clear();
            for (int i = 0; i < 25; i++)
            {
                triggersListBox.Items.Add(characterEditorMain1.GetTrigName(i));
            }
            triggersListBox.SelectedIndex = 0;

            //initialize texture selection
            headTextureUpDown.Maximum = characterEditorMain1.HeadTextures.Length - 1;
            headTextureUpDown.Minimum = 0;
            torsoTextureUpDown.Maximum = characterEditorMain1.TorsoTextures.Length - 1;
            torsoTextureUpDown.Minimum = 0;
            legsTextureUpDown.Maximum = characterEditorMain1.LegsTextures.Length - 1;
            legsTextureUpDown.Minimum = 0;
            weaponTextureUpDown.Maximum = characterEditorMain1.WeaponTextures.Length - 1;
            weaponTextureUpDown.Minimum = 0;

            initialize = false;
        }

        private void openCharacterToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                characterEditorMain1.charDef.Path = openFileDialog1.FileName;
                characterEditorMain1.charDef.Read();                

                //fill box with animation names
                animationsListBox.Items.Clear();
                for (int i = 0; i < characterEditorMain1.charDef.Animations.Length; i++)
                {
                    animationsListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Animations[i].Name);                   
                }

                // load part listbox
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

                // load frame information
                framesListBox.Items.Clear();
                for (int i = 0; i < characterEditorMain1.charDef.Frames.Length; i++)
                {
                    framesListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Frames[i].Name);
                }

                // load key frame information
                keyFrameListBox.Items.Clear();
                for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames.Length; i++)
                {
                    if (characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference > -1)
                        keyFrameListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Frames[characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference].Name);                        
                    else
                        keyFrameListBox.Items.Add(i.ToString() + ": ");
                }

                // load script information
                scriptsListBox.Items.Clear();
                for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts.Length; i++)
                {
                    scriptsListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[characterEditorMain1.SelectedKeyFrame].Scripts[i]);
                }
                // initially select some stuff
                animationsListBox.SelectedIndex = characterEditorMain1.SelectedAnimation;
                framesListBox.SelectedIndex = characterEditorMain1.SelectedFrame;
                partListBox.SelectedIndex = characterEditorMain1.SelectedPart;
                keyFrameListBox.SelectedIndex = characterEditorMain1.SelectedKeyFrame;
                scriptsListBox.SelectedIndex = characterEditorMain1.SelectedScriptLine;

                //load picture boxes with textures
                // TODO: arms are not imported!
                // spritesheet thinks that every sprite is 64x64
                // except weapons which are 80x64
                /* index 0-63 for head texture
                 * 64-127 for torso texture
                 * 128-191 for legs texture
                 * 192 - 256 for weapons texture
                */
                for (int i = 0; i < 25; i++)
                {
                    availableHeadParts.Items.Add(i.ToString() + ": " + "head" + i.ToString());
                    availableTorsoParts.Items.Add(i.ToString() + ": " + "torso" + (i + 64 * 1).ToString());
                    availableLegsParts.Items.Add(i.ToString() + ": " + "legs" + (i + 64 * 2).ToString());
                    availableWeaponsParts.Items.Add(i.ToString() + ": " + "weapons" + (i + 64 * 3).ToString());
                }

                //initialize texture selection
                headTextureUpDown.Maximum = characterEditorMain1.HeadTextures.Length - 1;
                headTextureUpDown.Minimum = 0;
                headTextureUpDown.Value = (decimal)characterEditorMain1.charDef.HeadIndex;
                torsoTextureUpDown.Maximum = characterEditorMain1.TorsoTextures.Length - 1;
                torsoTextureUpDown.Minimum = 0;
                torsoTextureUpDown.Value = (decimal)characterEditorMain1.charDef.TorsoIndex;
                legsTextureUpDown.Maximum = characterEditorMain1.LegsTextures.Length - 1;
                legsTextureUpDown.Minimum = 0;
                legsTextureUpDown.Value = (decimal)characterEditorMain1.charDef.LegsIndex;
                weaponTextureUpDown.Maximum = characterEditorMain1.WeaponTextures.Length - 1;
                weaponTextureUpDown.Minimum = 0;
                weaponTextureUpDown.Value = (decimal)characterEditorMain1.charDef.WeaponIndex;

                FillPictureBox(headPreview, characterEditorMain1.HeadBitmap[characterEditorMain1.charDef.HeadIndex], 0);
                FillPictureBox(torsoPreview, characterEditorMain1.TorsoBitmap[characterEditorMain1.charDef.TorsoIndex], 0);
                FillPictureBox(legsPreview, characterEditorMain1.LegsBitmap[characterEditorMain1.charDef.LegsIndex], 0);
                FillPictureBox(weaponsPreview, characterEditorMain1.WeaponsBitmap[characterEditorMain1.charDef.WeaponIndex], 0);

                availableHeadParts.SelectedIndex = 0;
                availableTorsoParts.SelectedIndex = 0;
                availableLegsParts.SelectedIndex = 0;
                availableWeaponsParts.SelectedIndex = 0;

                // initiliaze triggers
                triggersListBox.Items.Clear();

                for (int i = 0; i < 25; i++)
                {
                    triggersListBox.Items.Add(characterEditorMain1.GetTrigName(i));
                }
                triggersListBox.SelectedIndex = 0;
            }
        }

        private void saveCharacterToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                characterEditorMain1.charDef.Path = saveFileDialog1.FileName;
                characterEditorMain1.charDef.Write();
            }
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

        private void startToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            characterEditorMain1.Playing = true;
            startToolStripMenuItem.Checked = true;
            stopToolStripMenuItem.Checked = false;
        }

        private void stopToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            characterEditorMain1.Playing = false;
            startToolStripMenuItem.Checked = false;
            stopToolStripMenuItem.Checked = true;
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveToolStripMenuItem.Checked = true;
            rotateToolStripMenuItem.Checked = false;
            scaleToolStripMenuItem.Checked = false;
            editModeComboBox.SelectedIndex = 0;
            editMode = EditingMode.Location;
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveToolStripMenuItem.Checked = false;
            rotateToolStripMenuItem.Checked = true;
            scaleToolStripMenuItem.Checked = false;
            editModeComboBox.SelectedIndex = 1;
            editMode = EditingMode.Rotation;
        }

        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveToolStripMenuItem.Checked = false;
            rotateToolStripMenuItem.Checked = false;
            scaleToolStripMenuItem.Checked = true;
            editModeComboBox.SelectedIndex = 2;
            editMode = EditingMode.Scale;
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
            animationsNametextBox.Text = "";

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
            characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[partListBox.SelectedIndex].Rotation = 0.0f;
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
            if (!initialize)
            {
                if (String.IsNullOrEmpty(characterEditorMain1.charDef.Frames[framesListBox.SelectedIndex].Name))
                {
                    characterEditorMain1.CopyFrame(characterEditorMain1.SelectedFrame, framesListBox.SelectedIndex);
                    int saveSelectedIndex = framesListBox.SelectedIndex;
                    // reload frames list box
                    framesListBox.Items.Clear();
                    // load frame information
                    for (int i = 0; i < characterEditorMain1.charDef.Frames.Length; i++)
                    {
                        framesListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Frames[i].Name);
                    }
                    framesListBox.SelectedIndex = saveSelectedIndex;
                }

                characterEditorMain1.SelectedFrame = framesListBox.SelectedIndex;
                framesTextBox.Text = characterEditorMain1.charDef.Frames[framesListBox.SelectedIndex].Name;

                //update part list
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
                partListBox.SelectedIndex = 0;
            }
        }

        private void framesAddReferenceButton_Click(object sender, System.EventArgs e)
        {
            
            for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames.Length; i++)
            {
                if (characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference == -1)
                {
                    characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference = framesListBox.SelectedIndex;
                    characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].Duration = 1;

                    //reload keyframes
                    keyFrameListBox.Items.Clear();
                    // load key frame information
                    for (int j = 0; j < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames.Length; j++)
                    {
                        if (characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[j].FrameReference > -1)
                            keyFrameListBox.Items.Add(j.ToString() + ": " + characterEditorMain1.charDef.Frames[characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[j].FrameReference].Name);
                        else
                            keyFrameListBox.Items.Add(j.ToString() + ": ");
                    }
                    keyFrameListBox.SelectedIndex = i;

                    break;
                }
            }
        }

        private void framesNametextBox_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void framesEditbutton_Click(object sender, System.EventArgs e)
        {
            characterEditorMain1.charDef.Frames[framesListBox.SelectedIndex].Name = framesTextBox.Text;
            // reload frame listbox
            framesListBox.Items.Clear();
            // load frame information
            for (int i = 0; i < characterEditorMain1.charDef.Frames.Length; i++)
            {
                framesListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Frames[i].Name);
            }

            keyFrameListBox.Items.Clear();
            // load key frame information
            for (int i = 0; i < characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames.Length; i++)
            {
                if (characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference > -1)
                    keyFrameListBox.Items.Add(i.ToString() + ": " + characterEditorMain1.charDef.Frames[characterEditorMain1.charDef.Animations[characterEditorMain1.SelectedAnimation].KeyFrames[i].FrameReference].Name);
                else
                    keyFrameListBox.Items.Add(i.ToString() + ": ");
            }
            framesListBox.SelectedIndex = characterEditorMain1.SelectedFrame;
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

        #region Mouse Events
        
        private void onMouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void onMouseHover(object sender, EventArgs e)
        {
            
        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            int mouseDiffX = e.X - mouseX;
            int mouseDiffY = e.Y - mouseY;

            switch (editMode)
            {
                case EditingMode.Location:
                    if (isMouseDown)
                        characterEditorMain1.charDef.Frames[framesListBox.SelectedIndex].Parts[partListBox.SelectedIndex].Location +=
                           new Microsoft.Xna.Framework.Vector2((mouseDiffX / 2.0f), (mouseDiffY / 2.0f));
                    break;
                case EditingMode.Scale:
                    if (isMouseDown)
                        characterEditorMain1.charDef.Frames[framesListBox.SelectedIndex].Parts[partListBox.SelectedIndex].Scaling +=
                           new Microsoft.Xna.Framework.Vector2((float)mouseDiffX * 0.01f, (float)mouseDiffY * 0.01f);
                    break;
                case EditingMode.Rotation:
                    if (isMouseDown)
                        characterEditorMain1.charDef.Frames[framesListBox.SelectedIndex].Parts[partListBox.SelectedIndex].Rotation +=
                           (float)mouseDiffY / 100.0f;
                    break;
                default:
                    break;
            }
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
       
        #endregion

        #region Part Preview Area

        /// <summary>
        /// Fills the preview picture box.
        /// Requires a source Bitmap and adjusts it to fit a 64x64 picture box
        /// or 80x64 (for weapons). Weapons are still bugged!
        /// </summary>
        /// <param name="targetPictureBox">The target picture box.</param>
        /// <param name="sourceBitmap">The source bitmap.</param>
        /// <param name="index">The index.</param>
        private void FillPictureBox(PictureBox targetPictureBox, Image sourceBitmap, int index)
        {
            // either we have a second method or this stupid if/else for weapons
            if (targetPictureBox == weaponsPreview)
            {
                Image image = (Image)new Bitmap(80, 64);

                Rect destRectangle = new Rect(0, 0, 80, 64);
                Rect sourceRect = new Rect();
                sourceRect.X = ((index % 64 ) % 4) * 80;
                sourceRect.Y = (index / 4) * 64;
                sourceRect.Width = 80;
                sourceRect.Height = 64;

                Graphics gi = Graphics.FromImage(image);
                gi.DrawImage(sourceBitmap,
                    destRectangle,
                    sourceRect,
                    GraphicsUnit.Pixel);

                targetPictureBox.Image = image;
            }
            else
            {
                Image image = (Image)new Bitmap(64, 64);
                Rect destRectangle = new Rect(0, 0, 64, 64);
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

                targetPictureBox.Image = image;
            }           
        }

        private void availableHeadParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPictureBox(headPreview, characterEditorMain1.HeadBitmap[(int)headTextureUpDown.Value], availableHeadParts.SelectedIndex);
        }

        private void availableTorsoParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPictureBox(torsoPreview, characterEditorMain1.TorsoBitmap[(int)torsoTextureUpDown.Value], availableTorsoParts.SelectedIndex);
        }

        private void availableLegsParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPictureBox(legsPreview, characterEditorMain1.LegsBitmap[(int)legsTextureUpDown.Value], availableLegsParts.SelectedIndex);
        }

        private void availableWeaponsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPictureBox(weaponsPreview, characterEditorMain1.WeaponsBitmap[(int)weaponTextureUpDown.Value], availableWeaponsParts.SelectedIndex);
        }

        private void weaponTextureUpDown_ValueChanged(object sender, EventArgs e)
        {
            characterEditorMain1.charDef.WeaponIndex = (int)weaponTextureUpDown.Value;
            // update picture box
            FillPictureBox(weaponsPreview, characterEditorMain1.WeaponsBitmap[(int)weaponTextureUpDown.Value], availableWeaponsParts.SelectedIndex);
        }

        private void legsTextureUpDown_ValueChanged(object sender, EventArgs e)
        {
            characterEditorMain1.charDef.LegsIndex = (int)legsTextureUpDown.Value;
            // update picture box
            FillPictureBox(legsPreview, characterEditorMain1.LegsBitmap[(int)legsTextureUpDown.Value], availableLegsParts.SelectedIndex);
        }

        private void torsoTextureUpDown_ValueChanged(object sender, EventArgs e)
        {
            characterEditorMain1.charDef.TorsoIndex = (int)torsoTextureUpDown.Value;
            // update picture box
            FillPictureBox(torsoPreview, characterEditorMain1.TorsoBitmap[(int)torsoTextureUpDown.Value], availableTorsoParts.SelectedIndex);
        }

        private void headTextureUpDown_ValueChanged(object sender, EventArgs e)
        {
            characterEditorMain1.charDef.HeadIndex = (int)headTextureUpDown.Value;
            // update picture box
            FillPictureBox(headPreview, characterEditorMain1.HeadBitmap[(int)headTextureUpDown.Value], availableHeadParts.SelectedIndex);
        }
        #endregion

        #region Add New Part to Frame
        
        private void addHeadButton_Click(object sender, EventArgs e)
        {
            int saveSelectedPartIndex = partListBox.SelectedIndex;
            characterEditorMain1.charDef.Frames[framesListBox.SelectedIndex].Parts[partListBox.SelectedIndex].Index = availableHeadParts.SelectedIndex;
          
            //update part list
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
            partListBox.SelectedIndex = saveSelectedPartIndex;           
        }

        private void addTorsoButton_Click(object sender, EventArgs e)
        {
            int saveSelectedPartIndex = partListBox.SelectedIndex;
            characterEditorMain1.charDef.Frames[framesListBox.SelectedIndex].Parts[partListBox.SelectedIndex].Index = availableTorsoParts.SelectedIndex + 64;

            //update part list
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
            partListBox.SelectedIndex = saveSelectedPartIndex;
        }

        private void addLegsButton_Click(object sender, EventArgs e)
        {
            int saveSelectedPartIndex = partListBox.SelectedIndex;
            characterEditorMain1.charDef.Frames[framesListBox.SelectedIndex].Parts[partListBox.SelectedIndex].Index = availableLegsParts.SelectedIndex + 128;

            //update part list
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
            partListBox.SelectedIndex = saveSelectedPartIndex;
        }

        private void addWeaponButton_Click(object sender, EventArgs e)
        {
            int saveSelectedPartIndex = partListBox.SelectedIndex;
            characterEditorMain1.charDef.Frames[framesListBox.SelectedIndex].Parts[partListBox.SelectedIndex].Index = availableWeaponsParts.SelectedIndex + 192;

            //update part list
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
            partListBox.SelectedIndex = saveSelectedPartIndex;
        }
        #endregion

        private void editModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (editModeComboBox.SelectedItem.ToString())
            {
                case "Location":
                    moveToolStripMenuItem.Checked = true;
                    rotateToolStripMenuItem.Checked = false;
                    scaleToolStripMenuItem.Checked = false;
                    editMode = EditingMode.Location;
                    break;
                case "Rotation":
                    moveToolStripMenuItem.Checked = false;
                    rotateToolStripMenuItem.Checked = true;
                    scaleToolStripMenuItem.Checked = false;
                    editMode = EditingMode.Rotation;
                    break;
                case "Scale":
                    moveToolStripMenuItem.Checked = false;
                    rotateToolStripMenuItem.Checked = false;
                    scaleToolStripMenuItem.Checked = true;
                    editMode = EditingMode.Scale;
                    break;

                default:
                    break;
            }
        }

        private void triggersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addTriggerButton_Click(object sender, EventArgs e)
        {
            int saveSelectedPartIndex = partListBox.SelectedIndex;

            characterEditorMain1.charDef.Frames[characterEditorMain1.SelectedFrame].Parts[characterEditorMain1.SelectedPart].Index = 
                triggersListBox.SelectedIndex + 1000;

            //update part list
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
            partListBox.SelectedIndex = saveSelectedPartIndex;       
        }

     

    }
}
