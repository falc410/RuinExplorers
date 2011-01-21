using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TextLibrary;
using CharacterEditor.Character;

namespace CharacterEditor
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class CharacterEditorMain : Microsoft.Xna.Framework.Game
	{
		#region Variable Declartion
		
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		SpriteFont font;
		Text text;

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

		MouseState mouseState;
		MouseState previousMouseState;
		bool mouseClick = false;

		#endregion

		public CharacterEditorMain()
		{
			graphics = new GraphicsDeviceManager(this);

			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 600;

			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			this.IsMouseVisible = true;

			characterDefinition = new CharacterDefinition();

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			font = Content.Load<SpriteFont>(@"Fonts/Arial");
			text = new Text(spriteBatch, font);

			LoadTextures(legsTexture, @"gfx/legs");
			LoadTextures(headTexture, @"gfx/head");
			LoadTextures(torsoTexture, @"gfx/torso");
			LoadTextures(weaponTexture, @"gfx/weapon");

			saveIcon = Content.Load<Texture2D>(@"gfx/save_icon");
			openFolderIcon = Content.Load<Texture2D>(@"gfx/folder_open_icon");
			upArrowTexture = Content.Load<Texture2D>(@"gfx/upArrow");
			downArrowTexture = Content.Load<Texture2D>(@"gfx/downArrow");
			nullTexture = Content.Load<Texture2D>(@"gfx/1x1");
		}

		private void LoadTextures(Texture2D[] textures, string path)
		{
			for (int i = 0; i < textures.Length; i++)
			{
				textures[i] = Content.Load<Texture2D>(path + (i + 1).ToString());
			}
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();

			mouseState = Mouse.GetState();

			int mouseDiffX = mouseState.X - previousMouseState.X;
			int mouseDiffY = mouseState.Y - previousMouseState.Y;
						
			if (mouseState.LeftButton == ButtonState.Pressed)
			{
				if (previousMouseState.LeftButton == ButtonState.Pressed)
					characterDefinition.Frames[selectedFrame].Parts[selectedPart].Location +=
						new Vector2((float)mouseDiffX / 2.0f, (float)mouseDiffY / 2.0f);
			}
			else
			{
				if (previousMouseState.LeftButton == ButtonState.Pressed)
				{
					mouseClick = true;
				}
			}

			if (mouseState.RightButton == ButtonState.Pressed)
			{
				if (previousMouseState.RightButton == ButtonState.Pressed)
					characterDefinition.Frames[selectedFrame].Parts[selectedPart].Rotation +=
						(float)mouseDiffY / 100.0f;
			}

			if (mouseState.MiddleButton == ButtonState.Pressed)
			{
				if (previousMouseState.MiddleButton == ButtonState.Pressed)
					characterDefinition.Frames[selectedFrame].Parts[selectedPart].Scaling +=
						new Vector2((float)mouseDiffX * 0.01f, (float)mouseDiffY * 0.01f);
			}

			previousMouseState = mouseState;

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			
			spriteBatch.Begin();

			//draw dark-blue background rectangle for part list
			spriteBatch.Draw(nullTexture, new Rectangle(590, 0, 300, 600), new Color(new
				Vector4(0.0f, 0.0f, 0.0f, 0.5f)));

			spriteBatch.End();


			DrawCharacter(new Vector2(400f, 450f), 2f, FACE_RIGHT, selectedFrame, false, 1.0f);

			DrawPalette();
			DrawPartList();

			mouseClick = false;

			base.Draw(gameTime);
		}
		#region Custom Draw Methods
		
		// Draws the character on screen by iterating through all parts
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

		// Used to draw a texture as a clickable button
		private bool DrawButton(int x, int y, Texture2D buttonTexture, int mouseX, int mouseY, bool mouseClick)
		{
			bool r = false;
			Rectangle sourceRect = new Rectangle(0, 0, 64, 35);
			Rectangle destinationRect = new Rectangle(x, y, 32, 16);

			if (destinationRect.Contains(mouseX, mouseY))
			{
				destinationRect.X -= 1;
				destinationRect.Y -= 1;
				destinationRect.Width += 2;
				destinationRect.Height += 2;
				if (mouseClick)
					r = true;
			}
			spriteBatch.Begin();
			spriteBatch.Draw(buttonTexture, destinationRect, sourceRect, Color.White);
			spriteBatch.End();

			return r;

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


		private void DrawPartList()
		{
			for (int i = 0; i < characterDefinition.Frames[selectedFrame].Parts.Length; i++)
			{
				int y = 5 + i * 15;
				text.size = 0.75f;
				string line = "";
				int index = characterDefinition.Frames[selectedFrame].Parts[i].Index;

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

				if (selectedPart == i)
				{
					text.color = Color.Lime;
					text.DrawText(600, y, i.ToString() + ": " + line);
					// TODO: Fix DrawButton Function!
					if (DrawButton(675,y,upArrowTexture,mouseState.X,mouseState.Y,mouseClick))
					{
						SwapParts(selectedPart, selectedPart - 1);
						if(selectedPart > 0)
							selectedPart--;
					}
					if (DrawButton(705,5+y,downArrowTexture,mouseState.X,mouseState.Y,mouseClick))
					{
						SwapParts(selectedPart, selectedPart + 1);
						if (selectedPart < characterDefinition.Frames[selectedFrame].Parts.Length - 1)
							selectedPart++;
					}

					Part part = characterDefinition.Frames[selectedFrame].Parts[selectedPart];
					// flip part button
					if (text.DrawClickText(740, y, (part.Flip == 0 ? "(n)" : "(m)"), mouseState.X, mouseState.Y, mouseClick))
						part.Flip = 1 - part.Flip;
					// reset scale of part button
					if (text.DrawClickText(762, y, "(r)", mouseState.X, mouseState.Y, mouseClick))
						part.Scaling = new Vector2(1.0f, 1.0f);
					// delete part button
					if (text.DrawClickText(780, y, "(x)", mouseState.X, mouseState.Y, mouseClick))
						part.Index = -1;
				}
				else
				{
					if (text.DrawClickText(600, y, i.ToString() + ":" + line, mouseState.X, mouseState.Y, mouseClick))
						selectedPart = i;
				}
			}
		}
		#endregion

		private void SwapParts(int index1, int index2)
		{
			if (index1 < 0 || index2 < 0 || index1 >= characterDefinition.Frames[selectedFrame].Parts.Length ||
				index2 >= characterDefinition.Frames[selectedFrame].Parts.Length)
				return;

			Part i = characterDefinition.Frames[selectedFrame].Parts[index1];
			Part j = characterDefinition.Frames[selectedFrame].Parts[index2];

			characterDefinition.Frames[selectedFrame].Parts[index1] = j;
			characterDefinition.Frames[selectedFrame].Parts[index2] = i;
		}
	}
}
 