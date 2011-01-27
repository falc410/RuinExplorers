
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TextLibrary;
using CharacterEditorWindows.Character;
using System;
using System.Windows.Forms;
using System.Diagnostics;

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
      
        Texture2D headsTexture;
        Image headBitmap;   

		CharacterDefinition characterDefinition;

		Texture2D[] headTexture = new Texture2D[1];
		Texture2D[] torsoTexture = new Texture2D[1];
		Texture2D[] legsTexture = new Texture2D[1];
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

		public enum EditingMode
		{
			None,
            Location,
			Scale,
            Rotation           
		}

        EditingMode editMode;

		MouseState mouseState;
		MouseState previousMouseState;
		bool mouseClick = false;

		#endregion

		#region Properties

        public Image HeadBitmap
        {
            get { return headBitmap; }
        }

        public EditingMode EditMode
        {
            get { return editMode; }
            set { editMode = value; }
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
			Content = new ContentManager(Services, "CharacterEditorWindowsContent");

			spriteBatch = new SpriteBatch(GraphicsDevice);

			timer = Stopwatch.StartNew();           

			LoadTextures(legsTexture, @"gfx/legs");
			LoadTextures(headTexture, @"gfx/head");
			LoadTextures(torsoTexture, @"gfx/torso");
            LoadTextures(weaponTexture, @"gfx/weapon");
            
            headsTexture = Content.Load<Texture2D>(@"gfx/heads");
            headBitmap = Bitmap.FromFile(@"CharacterEditorWindowsContent/gfx/heads.png");
			
			nullTexture = Content.Load<Texture2D>(@"gfx/1x1");

            characterDefinition = new CharacterDefinition();           

			// Hook the idle event to constantly redraw our animation.
			Application.Idle += delegate { Invalidate(); };						
		}        

		private void LoadTextures(Texture2D[] textures, string path)
		{
			for (int i = 0; i < textures.Length; i++)
			{
				textures[i] = Content.Load<Texture2D>(path + (i + 1).ToString());
			}
		}


		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		//protected override void Update()
		//{
		//    mouseState = Mouse.GetState();

		//    int mouseDiffX = mouseState.X - previousMouseState.X;
		//    int mouseDiffY = mouseState.Y - previousMouseState.Y;

		//    if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		//    {
		//        if (previousMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		//            characterDefinition.Frames[selectedFrame].Parts[selectedPart].Location +=
		//                new Vector2((float)mouseDiffX / 2.0f, (float)mouseDiffY / 2.0f);
		//    }
		//    else
		//    {
		//        if (previousMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		//        {
		//            mouseClick = true;
		//        }
		//    }

		//    if (mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		//    {
		//        if (previousMouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		//            characterDefinition.Frames[selectedFrame].Parts[selectedPart].Rotation +=
		//                (float)mouseDiffY / 100.0f;
		//    }

		//    if (mouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		//    {
		//        if (previousMouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		//            characterDefinition.Frames[selectedFrame].Parts[selectedPart].Scaling +=
		//                new Vector2((float)mouseDiffX * 0.01f, (float)mouseDiffY * 0.01f);
		//    }

	

		//    if (keyFrame.FrameReference < 0)
		//        currentKeyFrame = 0;
		//}

		/// <summary>
		/// This is called when the windows form should draw itself.
		/// </summary>		
		protected override void Draw()
		{
            mouseState = Mouse.GetState();

            int mouseDiffX = mouseState.X - previousMouseState.X;
            int mouseDiffY = mouseState.Y - previousMouseState.Y;

            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                if (previousMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                    characterDefinition.Frames[selectedFrame].Parts[selectedPart].Location +=
                        new Vector2((float)mouseDiffX / 2.0f, (float)mouseDiffY / 2.0f);
            }
            else
            {
                if (previousMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    mouseClick = true;
                }
            }

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

			DrawPalette();
		  	
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

            previousMouseState = mouseState;
            mouseClick = false;
        }
		#region Custom Draw Methods
				
		/// <summary>
		/// Draws the character by iterating through all parts.
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
						// spritesheet for weapons is 64 x 80 per sprite
						sourceRect.X = ((part.Index % 64) % 3) * 80;
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
			spriteBatch.End();             
		}
        		
		// draw icon palette
		// TODO: either modify this or our source spritesheet
		private void DrawPalette()
		{
			spriteBatch.Begin();
			// iterate over the 4 main spritesheets
			for (int l = 0; l < 4; l++)
			{
				Texture2D texture = null;
				switch (l)
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
					default:
						break;
				}

				if (texture != null)
				{
					// iterate over sprites in sheet 
					for (int i = 0; i < 25; i++)
					{
						Rectangle sourceRect = new Rectangle((i % 5) * 64, (i / 5) * 64, 64, 64);
						Rectangle destinationRect = new Rectangle(i * 23, 467 + l * 32, 23, 32);
						spriteBatch.Draw(nullTexture, destinationRect, new Color(0, 0, 0, 25));

						// special case for weapon texture
						if (l == 3)
						{
							sourceRect.X = (i % 4) * 80;
							sourceRect.Y = (i / 4) * 64;
							sourceRect.Width = 80;

							if (i < 15)
							{
								destinationRect.X = i * 30;
								destinationRect.Width = 30;
							}
						}

						spriteBatch.Draw(texture, destinationRect, sourceRect, Color.White);

						if (destinationRect.Contains(mouseState.X, mouseState.Y))
						{
							if (mouseClick)
								characterDefinition.Frames[selectedFrame].Parts[selectedPart].Index = i + 64 * l;
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

		#region Input Methods
        //private void UpdateKeys()
        //{
        //    keyBoardState = Keyboard.GetState();

        //    Microsoft.Xna.Framework.Input.Keys[] currentKeys = keyBoardState.GetPressedKeys();
        //    Microsoft.Xna.Framework.Input.Keys[] lastKeys = previousKeyBoardState.GetPressedKeys();

        //    bool found = false;

        //    for (int i = 0; i < currentKeys.Length; i++)
        //    {
        //        found = false;

        //        for (int y = 0; y < lastKeys.Length; y++)
        //        {
        //            if (currentKeys[i] == lastKeys[y])
        //            {
        //                found = true;
        //                break;
        //            }
        //        }

        //        if (!found)
        //            PressKey(currentKeys[i]);
        //    }

        //    previousKeyBoardState = keyBoardState;
        //}

        //private void PressKey(Microsoft.Xna.Framework.Input.Keys key)
        //{
        //    string t = String.Empty;
        //    switch (editmode)
        //    {
        //        case EditingMode.None:
        //            break;
        //        case EditingMode.AnimationName:
        //            t = characterDefinition.Animations[selectedAnimation].Name;
        //            break;
        //        case EditingMode.FrameName:
        //            t = characterDefinition.Frames[selectedFrame].Name;
        //            break;
        //        case EditingMode.PathName:
        //            t = characterDefinition.Path;
        //            break;
        //        case EditingMode.Script:
        //            t = characterDefinition.Animations[selectedAnimation].KeyFrames[selectedKeyFrame].Scripts[selectedScriptLine];
        //            break;
        //        default:
        //            break;
        //    }

        //    if (key == Microsoft.Xna.Framework.Input.Keys.Back)
        //    {
        //        if (t.Length > 0)
        //            t = t.Substring(0, t.Length - 1);
        //    }
        //    else if (key == Microsoft.Xna.Framework.Input.Keys.Enter)
        //    {
        //        editmode = EditingMode.None;
        //    }
        //    else
        //    {
        //        t = (t + (char)key).ToLower();
        //    }

        //    switch (editmode)
        //    {
        //        case EditingMode.None:
        //            break;
        //        case EditingMode.AnimationName:
        //            characterDefinition.Animations[selectedAnimation].Name = t;
        //            break;
        //        case EditingMode.FrameName:
        //            characterDefinition.Frames[selectedFrame].Name = t;
        //            break;
        //        case EditingMode.PathName:
        //            characterDefinition.Path = t;
        //            break;
        //        case EditingMode.Script:
        //            characterDefinition.Animations[selectedAnimation].KeyFrames[selectedKeyFrame].Scripts[selectedScriptLine] = t;
        //            break;
        //        default:
        //            break;
        //    }
        //}
		#endregion       

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
			   Content.Unload();
			}

			base.Dispose(disposing);
		}
	}
}
 