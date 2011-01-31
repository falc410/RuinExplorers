
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CharacterEditorWindows.Character;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using TextLibrary;

using Image = System.Drawing.Image;
using Bitmap = System.Drawing.Bitmap;



namespace CharacterEditorWindows
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class CharacterEditorMain : GraphicsDeviceControl
	{        

		#region Variable Declartion
				
		ContentManager Content;		
		SpriteBatch spriteBatch;
		Stopwatch timer;
        SpriteFont font;
        Text text;
        
        Image[] headBitmap = new Image[2];
        Image[] torsoBitmap = new Image[2];
        Image[] legsBitmap = new Image[2];
        Image[] weaponsBitmap = new Image[1];

		CharacterDefinition characterDefinition;

		Texture2D[] headTexture = new Texture2D[2];
		Texture2D[] torsoTexture = new Texture2D[2];
		Texture2D[] legsTexture = new Texture2D[2];
		Texture2D[] weaponTexture = new Texture2D[1];

        Texture2D nullTexture;

		const int FACE_LEFT = 0;
		const int FACE_RIGHT = 1;

		int selectedPart = 0;
		int selectedFrame = 0;
		int selectedAnimation = 0;
		int selectedKeyFrame = 0;
		int selectedScriptLine = 0;

		int currentKeyFrame = 0;
        float currentFrame = 0;
		bool playing = false;
        
		#endregion

        #region Triggers

        const int TRIG_PISTOL_ACROSS = 0;
        const int TRIG_PISTOL_UP = 1;
        const int TRIG_PISTOL_DOWN = 2;

        #endregion

        #region Properties

        public Texture2D[] TorsoTextures
        {
            get { return torsoTexture; }
        }

        public Texture2D[] LegsTextures
        {
            get { return legsTexture; }
        }

        public Texture2D[] WeaponTextures
        {
            get { return weaponTexture; }
        }

        public Texture2D[] HeadTextures
        {
            get { return headTexture; }
        }

        public Image[] HeadBitmap
        {
            get { return headBitmap; }
        }

        public Image[] TorsoBitmap
        {
            get { return torsoBitmap; }
        }

        public Image[] LegsBitmap
        {
            get { return legsBitmap; }
        }

        public Image[] WeaponsBitmap
        {
            get { return weaponsBitmap; }
        }
        
		public CharacterDefinition charDef
		{
			get { return characterDefinition; }
            set { characterDefinition = value; }
		}

		public int SelectedAnimation
		{
			get { return selectedAnimation; }
			set { selectedAnimation = value; }
		}

		public int SelectedFrame
		{
			get { return selectedFrame; }
			set { selectedFrame = value; }
		}

		public int SelectedPart
		{
			get { return selectedPart; }
			set { selectedPart = value; }
		}

		public int SelectedKeyFrame
		{
			get { return selectedKeyFrame; }
			set { selectedKeyFrame = value; }
		}

		public int SelectedScriptLine
		{
			get { return selectedScriptLine; }
			set { selectedScriptLine = value; }
		}

        public bool Playing
        {
            get { return playing; }
            set { playing = value; }
        }

		#endregion

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			Content = new ContentManager(Services, "WindowsContent");
            
			spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>(@"Fonts/Arial");
            text = new Text(spriteBatch, font);


			timer = Stopwatch.StartNew();           

			LoadTextures(legsTexture, @"gfx/legs");
			LoadTextures(headTexture, @"gfx/head");
			LoadTextures(torsoTexture, @"gfx/torso");
            LoadTextures(weaponTexture, @"gfx/weapon");
                        
            
            LoadBitmaps(headBitmap, "head");
            LoadBitmaps(torsoBitmap, "torso");
            LoadBitmaps(legsBitmap, "legs");
            LoadBitmaps(weaponsBitmap, "weapon");            
			
			nullTexture = Content.Load<Texture2D>(@"gfx/1x1");

            characterDefinition = new CharacterDefinition();           

			// Hook the idle event to constantly redraw our animation.
			Application.Idle += delegate { Invalidate(); };						
		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Content.Unload();
            }

            base.Dispose(disposing);
        }

        private void LoadBitmaps(Image[] textures, string path)
        {
            for (int i = 0; i < textures.Length; i++)
            {
                textures[i] = Bitmap.FromFile(@"WindowsContent/gfx/source/" + path + (i + 1).ToString() + ".png");
            }
        }

		private void LoadTextures(Texture2D[] textures, string path)
		{
			for (int i = 0; i < textures.Length; i++)
			{
				textures[i] = Content.Load<Texture2D>(path + (i + 1).ToString());
			}
		}

		/// <summary>
		/// This is called when the windows form should draw itself.
		/// </summary>		
		protected override void Draw()
		{           
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();

			// red bar at the bottom
			spriteBatch.Draw(nullTexture, new Rectangle(100, 450, 200, 5), new Color(new
	 Vector4(1.0f, 0.0f, 0.0f, 0.5f)));


			spriteBatch.End();

			// draw onionskin effect - previews frame next to currently selected frame
			// so we draw our character thrice on the screen (twice with low alpha)
			if (selectedFrame > 0)
				DrawCharacter(new Vector2(200f, 450f), 2f, FACE_RIGHT, selectedFrame - 1, false, 0.2f);
			if (selectedFrame < characterDefinition.Frames.Length - 1)
				DrawCharacter(new Vector2(200f, 450f), 2f, FACE_RIGHT, selectedFrame + 1, false, 0.2f);
			DrawCharacter(new Vector2(200f, 450f), 2f, FACE_RIGHT, selectedFrame, false, 1.0f);			
		  	
            // Select keyFrame to draw for preview
			int fref = characterDefinition.Animations[selectedAnimation].KeyFrames[currentKeyFrame].FrameReference;
			if (fref < 0)
				fref = 0;
            // draw preview
			DrawCharacter(new Vector2(300f, 100f), 0.5f, FACE_RIGHT, fref, true, 1.0f);		

            // update preview animation
            // TODO: NOT WORKING!
            if (playing)
            {               
                currentFrame += (float)timer.Elapsed.TotalSeconds;

                // Switch to next KeyFrame if our Elapsed Time is higher then the Duration                   
                if (currentFrame > characterDefinition.Animations[selectedAnimation].KeyFrames[selectedKeyFrame].Duration)
                {
                    // Reset our Timer
                    currentFrame = 0;
                    timer.Restart();
                    // Draw next KeyFrame
                    currentKeyFrame++;

                    // Did we reach the end or our Animation? Then reset keyFrame and timer and start again
                    if (currentKeyFrame >= characterDefinition.Animations[selectedAnimation].KeyFrames.Length)
                    {                        
                        currentFrame = 0;
                        timer.Restart();

                        currentKeyFrame = 0;
                    }
                        
                }
            }
            else
                currentKeyFrame = selectedKeyFrame;

        }

        public string GetTrigName(int index)
        {
            switch (index)
            {
                case TRIG_PISTOL_ACROSS:
                    return "pistol across";
                case TRIG_PISTOL_DOWN:
                    return "pistol down";
                case TRIG_PISTOL_UP:
                    return "pistol up";
                default:
                    break;
            }
            return "n/a";
        }

		#region Custom Draw Methods
				
		/// <summary>
		/// Draws the character by iterating through all parts - very important!.
		/// </summary>
		/// <param name="_location">The _location.</param>
		/// <param name="_scale">The scale of the part.</param>
		/// <param name="_face">Left or right facing of the character.</param>
		/// <param name="_frameIndex">Index of the _frame.</param>
		/// <param name="_preview">if set to <c>true</c> [_preview] will be drawn.</param>
		/// <param name="_alpha">The alpha value of character.</param>
		private void DrawCharacter(Vector2 _location, float _scale, int _face, int _frameIndex, bool _preview, float _alpha)
		{
			Rectangle sourceRect = new Rectangle();

			Frame frame = characterDefinition.Frames[_frameIndex];

			spriteBatch.Begin();

			for (int i = 0; i < frame.Parts.Length; i++)
			{
				Part part = frame.Parts[i];
				if (part.Index > -1)
				{
					// TODO: modify according to texture!!
					// spritesheet thinks that every sprite is 64x64
                    // except weapons which are 80x64
					/* index 0-63 for head texture
					 * 64-127 for torso texture
					 * 128-191 for legs texture
					 * 192 - 256 for weapons texture
					*/
					sourceRect.X = ((part.Index % 64) % 5) * 64;
					sourceRect.Y = ((part.Index % 64) / 5) * 64;
					sourceRect.Width = 64;
					sourceRect.Height = 64;

					if (part.Index >= 192)
					{
						// spritesheet for weapons is 80 x 64 per sprite
                        // I commented the original line out and added another for Y coordinates
                        // I think it should be correct now - maybe the book was wrong?
                        //sourceRect.X = ((part.Index % 64) % 3) * 80;
                        sourceRect.X = ((part.Index % 64) % 4) * 80;
                        sourceRect.Y = ((part.Index % 64) / 4) * 64;
						sourceRect.Width = 80;
					}

					float rotation = part.Rotation;

					Vector2 location = part.Location * _scale + _location;
					Vector2 scaling = part.Scaling * _scale;
					
					// if weapons or legs are used they have to be scaled up since the image was scaled down in the original spritesheet
					if (part.Index >= 128)
						scaling *= 1.35f;
					if (_face == FACE_LEFT)
					{
						rotation = -rotation;
						location.X -= part.Location.X * _scale * 2.0f;
					}

                    if (part.Index >= 1000 && _alpha >= 1f)
                    {
                        spriteBatch.End();
                        text.color = Color.Lime;
                        if (_preview)
                        {
                            text.size = 0.45f;
                            text.DrawText((int)location.X, (int)location.Y, "*");
                        }
                        else
                        {
                            text.size = 1f;
                            text.DrawText((int)location.X, (int)location.Y, "*" + GetTrigName(part.Index - 1000));
                        }
                        spriteBatch.Begin();
                    }
                    else
                    {
                        Texture2D texture = null;

                        int t = part.Index / 64;
                        switch (t)
                        {
                            case 0:
                                texture = headTexture[characterDefinition.HeadIndex];
                                break;
                            case 1:
                                texture = torsoTexture[characterDefinition.TorsoIndex];
                                break;
                            case 2:
                                texture = legsTexture[characterDefinition.LegsIndex];
                                break;
                            case 3:
                                texture = weaponTexture[characterDefinition.WeaponIndex];
                                break;
                        }

                        Color color = new Color(255, 255, 255, (byte)(_alpha * 255));

                        // highlight selected part in red on editable character
                        if (!_preview && selectedPart == i)
                            color = new Color(255, 0, 0, (byte)(_alpha * 255));

                        bool flip = false;

                        if ((_face == FACE_RIGHT && part.Flip == 0) ||
                            (_face == FACE_LEFT && part.Flip == 1))
                            flip = true;

                        if (texture != null)
                        {
                            spriteBatch.Draw(
                                texture,
                                location,
                                sourceRect,
                                color,
                                rotation,
                                new Vector2((float)sourceRect.Width / 2f, 32f),
                                scaling,
                                (flip ? SpriteEffects.None : SpriteEffects.FlipHorizontally),
                                1.0f
                                );
                        }
                    }
				}
			}
			spriteBatch.End();             
		}
      		
		#endregion

		#region Helper Methods
		
		public bool SwapParts(int index1, int index2)
		{
			if (index1 < 0 || index2 < 0 || index1 >= characterDefinition.Frames[selectedFrame].Parts.Length ||
				index2 >= characterDefinition.Frames[selectedFrame].Parts.Length)
				return false;

			Part i = characterDefinition.Frames[selectedFrame].Parts[index1];
			Part j = characterDefinition.Frames[selectedFrame].Parts[index2];

			characterDefinition.Frames[selectedFrame].Parts[index1] = j;
			characterDefinition.Frames[selectedFrame].Parts[index2] = i;

			return true;
		}

		public void CopyFrame(int src, int dest)
		{
			Frame keySrc = characterDefinition.Frames[src];
			Frame keyDest = characterDefinition.Frames[dest];

			keyDest.Name = keySrc.Name;

			for (int i = 0; i < keyDest.Parts.Length; i++)
			{
				Part srcPart = keySrc.Parts[i];
				Part destPart = keyDest.Parts[i];

				destPart.Index = srcPart.Index;
				destPart.Location = srcPart.Location;
				destPart.Rotation = srcPart.Rotation;
				destPart.Scaling = srcPart.Scaling;
			}
		}
		#endregion
        
	}
}
 