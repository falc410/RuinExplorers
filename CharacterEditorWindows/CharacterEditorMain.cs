
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
		SpriteFont font;
		Text text;
		Stopwatch timer;

		CharacterDefinition characterDefinition;

		Texture2D[] headTexture = new Texture2D[1];
		Texture2D[] torsoTexture = new Texture2D[1];
		Texture2D[] legsTexture = new Texture2D[1];
		Texture2D[] weaponTexture = new Texture2D[1];

		Texture2D nullTexture;
		Texture2D upArrowTexture;
		Texture2D downArrowTexture;
		Texture2D saveIcon;
		Texture2D openFolderIcon;

		const int FACE_LEFT = 0;
		const int FACE_RIGHT = 1;

		int selectedPart = 0;
		int selectedFrame = 0;
		int selectedAnimation = 0;
		int selectedKeyFrame = 0;
		int selectedScriptLine = 0;

		int currentKeyFrame = 0;
		float currentFrame = 0;
		int frameScroll;
		int animScroll;
		int keyFrameScroll;
		bool playing = false;

		enum EditingMode
		{
			None,
			FrameName,
			AnimationName,
			PathName,
			Script
		}

		EditingMode editmode = EditingMode.None;

		MouseState mouseState;
		MouseState previousMouseState;
		bool mouseClick = false;

		KeyboardState keyBoardState;
		KeyboardState previousKeyBoardState;

		#endregion

		#region Properties
		public CharacterDefinition charDef
		{
			get { return characterDefinition; }            
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

			font = Content.Load<SpriteFont>(@"Fonts/Arial");
			text = new Text(spriteBatch, font);
            text.size = 0.75f;

			LoadTextures(legsTexture, @"gfx/legs");
			LoadTextures(headTexture, @"gfx/head");
			LoadTextures(torsoTexture, @"gfx/torso");
			LoadTextures(weaponTexture, @"gfx/weapon");

			saveIcon = Content.Load<Texture2D>(@"gfx/save_icon");
			openFolderIcon = Content.Load<Texture2D>(@"gfx/folder_open_icon");
			upArrowTexture = Content.Load<Texture2D>(@"gfx/upArrow");
			downArrowTexture = Content.Load<Texture2D>(@"gfx/downArrow");
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

		//    previousMouseState = mouseState;

		//    UpdateKeys();

		//    Animation animation = characterDefinition.Animations[selectedAnimation];
		//    KeyFrame keyFrame = animation.KeyFrames[currentKeyFrame];

		//    if (playing)
		//    {
		//        currentFrame += (float)timer.Elapsed.TotalSeconds * 30.0f;

		//        if (currentFrame > keyFrame.Duration)
		//        {
		//            currentFrame -= keyFrame.Duration;
		//            currentKeyFrame++;

		//            if (currentKeyFrame >= animation.KeyFrames.Length)
		//                currentKeyFrame = 0;
		//            keyFrame = animation.KeyFrames[currentKeyFrame];
		//        }
		//    }
		//    else
		//        currentKeyFrame = selectedKeyFrame;

		//    if (keyFrame.FrameReference < 0)
		//        currentKeyFrame = 0;
		//}

		/// <summary>
		/// This is called when the windows form should draw itself.
		/// </summary>		
		protected override void Draw()
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();

			//draw dark-blue background rectangle for animation and keyframe list
			spriteBatch.Draw(nullTexture, new Rectangle(0, 0, 200, 450), new Color(new
				Vector4(0.0f, 0.0f, 0.0f, 0.5f)));
			//draw dark-blue background rectangle for part and frame list
			spriteBatch.Draw(nullTexture, new Rectangle(590, 0, 300, 600), new Color(new
				Vector4(0.0f, 0.0f, 0.0f, 0.5f)));
			// red bar at the bottom
			spriteBatch.Draw(nullTexture, new Rectangle(300, 450, 200, 5), new Color(new
	 Vector4(1.0f, 0.0f, 0.0f, 0.5f)));
			// draw background rectangle for save and load buttons and scripts
			spriteBatch.Draw(nullTexture, new Rectangle(200, 0, 150, 110), new Color(new
				Vector4(0.0f, 0.0f, 0.0f, 0.5f)));

			spriteBatch.End();

			// draw onionskin effect - previews frame next to currently selected frame
			// so we draw our character thrice on the screen (twice with low alpha)
            if (selectedFrame > 0)
                DrawCharacter(new Vector2(400f, 450f), 2f, FACE_RIGHT, selectedFrame - 1, false, 0.2f);
            if (selectedFrame < characterDefinition.Frames.Length - 1)
                DrawCharacter(new Vector2(400f, 450f), 2f, FACE_RIGHT, selectedFrame + 1, false, 0.2f);
            DrawCharacter(new Vector2(400f, 450f), 2f, FACE_RIGHT, selectedFrame, false, 1.0f);

			DrawPalette();
          
			DrawFramesList();
			DrawKeyFrameList();

			int fref = characterDefinition.Animations[selectedAnimation].KeyFrames[currentKeyFrame].FrameReference;
			if (fref < 0)
				fref = 0;

			DrawCharacter(new Vector2(500f, 100f), 0.5f, FACE_LEFT, fref, true, 1.0f);
			if (playing)
			{
				if (text.DrawClickText(480, 100, "stop", mouseState.X, mouseState.Y, mouseClick))
					playing = false;
			}
			else
			{
				if (text.DrawClickText(480, 100, "play", mouseState.X, mouseState.Y, mouseClick))
					playing = true;
			}			

			if (editmode == EditingMode.PathName)
			{
				text.color = Color.Lime;

				text.DrawText(270, 15, characterDefinition.Path + "*");
			}
			else
			{
				if (text.DrawClickText(280, 15, characterDefinition.Path, mouseState.X, mouseState.Y, mouseClick))
					editmode = EditingMode.PathName;
			}

			#region Script
			for (int i = 0; i < 4; i++)
			{
				if (editmode == EditingMode.Script && selectedScriptLine == i)
				{
					text.color = Color.Lime;
					text.DrawText(210, 42 + i * 16, i.ToString() + ": " + characterDefinition.Animations[selectedAnimation].KeyFrames[selectedKeyFrame].Scripts[i] + "*");
				}
				else
				{
					if (text.DrawClickText(210, 42 + i * 16, i.ToString() + ": " + characterDefinition.Animations[selectedAnimation].KeyFrames[selectedKeyFrame].Scripts[i], mouseState.X, mouseState.Y, mouseClick))
					{
						selectedScriptLine = i;
						editmode = EditingMode.Script;
					}
				}
			}
			#endregion

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
		
		
		
		
		/// <summary>
		/// Draws the frames list in the lower right corner of editor.
		/// Pressing the (a) button next to a frame adds it as KeyFrame to the current Animation
		/// Frames can be renamed
		/// </summary>
		private void DrawFramesList()
		{
			for (int i = frameScroll; i < frameScroll + 20; i++)
			{
				if (i < characterDefinition.Frames.Length)
				{
					int y = (i - frameScroll) * 15 + 280;
					if (i == selectedFrame)
					{
						text.color = Color.Lime;
						text.DrawText(600, y, i.ToString() + ": " + characterDefinition.Frames[i].Name + (editmode == EditingMode.FrameName ? "*" : ""));
						
						// clicking the (a) will add a reference of this frame to the selected animation
						if (text.DrawClickText(720,y,"(a)",mouseState.X,mouseState.Y,mouseClick))
						{
							Animation animation = characterDefinition.Animations[selectedAnimation];

							for (int j = 0; j < animation.KeyFrames.Length; j++)
							{
								KeyFrame keyFrame = animation.KeyFrames[j];
								if (keyFrame.FrameReference == -1)
								{
									keyFrame.FrameReference = i;
									keyFrame.Duration = 1;
									break;
								}
							}
						}
					}
					else
					{
						// clicking a new frame will create a copy of the old frame
						if (text.DrawClickText(600,y,i.ToString() + ": " + characterDefinition.Frames[i].Name,mouseState.X,mouseState.Y,mouseClick))
						{
							if (selectedFrame != i)
							{
								if (String.IsNullOrEmpty(characterDefinition.Frames[i].Name))
									CopyFrame(selectedFrame, i);
								
								selectedFrame = i;
								editmode = EditingMode.FrameName;
							}
						}
					}
				}
			}			
		}
	   
		//draws the keyframe list in the lower left corner
		private void DrawKeyFrameList()
		{
			for (int i = keyFrameScroll; i < keyFrameScroll + 13; i++)
			{
				Animation animation = characterDefinition.Animations[selectedAnimation];

				if (i < animation.KeyFrames.Length)
				{
					int y = (i - keyFrameScroll) * 15 + 250;
					int frameReference = animation.KeyFrames[i].FrameReference;
					string name = "";

					if (frameReference > -1)
						name = characterDefinition.Frames[frameReference].Name;

					if (i == selectedKeyFrame)
					{
						text.color = Color.Lime;
						text.DrawText(5, y, i.ToString() + ": " + name);
					}
					else
					{
						if (text.DrawClickText(5, y, i.ToString() + ": " + name, mouseState.X, mouseState.Y, mouseClick))
							selectedKeyFrame = i;
					}

					if (frameReference > -1)
					{
						if (text.DrawClickText(110,y,"-",mouseState.X,mouseState.Y,mouseClick))
						{
							animation.KeyFrames[i].Duration--;
							// did we drop the duration to 0? then delete keyframe and move all following one row up
							if (animation.KeyFrames[i].Duration <= 0)
							{
								for (int j = i; j < animation.KeyFrames.Length - 1; j++)
								{
									KeyFrame keyFrame = animation.KeyFrames[j];
									keyFrame.FrameReference = animation.KeyFrames[j + 1].FrameReference;
									keyFrame.Duration = animation.KeyFrames[j + 1].Duration;
								}
								animation.KeyFrames[animation.KeyFrames.Length - 1].FrameReference = -1;
							}
						}
						//draw KeyFrame Duration
						text.DrawText(125, y, animation.KeyFrames[i].Duration.ToString());
						
						//add a clickable + sign to increase duration
						if (text.DrawClickText(140, y, "+", mouseState.X, mouseState.Y, mouseClick))
							animation.KeyFrames[i].Duration++;
					}
				}
			}
				
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

		private void CopyFrame(int src, int dest)
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
		private void UpdateKeys()
		{
			keyBoardState = Keyboard.GetState();

			Microsoft.Xna.Framework.Input.Keys[] currentKeys = keyBoardState.GetPressedKeys();
			Microsoft.Xna.Framework.Input.Keys[] lastKeys = previousKeyBoardState.GetPressedKeys();

			bool found = false;

			for (int i = 0; i < currentKeys.Length; i++)
			{
				found = false;

				for (int y = 0; y < lastKeys.Length; y++)
				{
					if (currentKeys[i] == lastKeys[y])
					{
						found = true;
						break;
					}
				}

				if (!found)
					PressKey(currentKeys[i]);
			}

			previousKeyBoardState = keyBoardState;
		}

		private void PressKey(Microsoft.Xna.Framework.Input.Keys key)
		{
			string t = String.Empty;
			switch (editmode)
			{
				case EditingMode.None:
					break;
				case EditingMode.AnimationName:
					t = characterDefinition.Animations[selectedAnimation].Name;
					break;
				case EditingMode.FrameName:
					t = characterDefinition.Frames[selectedFrame].Name;
					break;
				case EditingMode.PathName:
					t = characterDefinition.Path;
					break;
				case EditingMode.Script:
					t = characterDefinition.Animations[selectedAnimation].KeyFrames[selectedKeyFrame].Scripts[selectedScriptLine];
					break;
				default:
					break;
			}

			if (key == Microsoft.Xna.Framework.Input.Keys.Back)
			{
				if (t.Length > 0)
					t = t.Substring(0, t.Length - 1);
			}
			else if (key == Microsoft.Xna.Framework.Input.Keys.Enter)
			{
				editmode = EditingMode.None;
			}
			else
			{
				t = (t + (char)key).ToLower();
			}

			switch (editmode)
			{
				case EditingMode.None:
					break;
				case EditingMode.AnimationName:
					characterDefinition.Animations[selectedAnimation].Name = t;
					break;
				case EditingMode.FrameName:
					characterDefinition.Frames[selectedFrame].Name = t;
					break;
				case EditingMode.PathName:
					characterDefinition.Path = t;
					break;
				case EditingMode.Script:
					characterDefinition.Animations[selectedAnimation].KeyFrames[selectedKeyFrame].Scripts[selectedScriptLine] = t;
					break;
				default:
					break;
			}
		}
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
 