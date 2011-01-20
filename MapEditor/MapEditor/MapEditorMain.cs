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
using MapEditor.MapClasses;
using TextLibrary;

namespace MapEditor
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class MapEditorMain : Microsoft.Xna.Framework.Game
	{
		#region Variables Declaration
		
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		Text text;
		SpriteFont font;

		Map map;
		Texture2D[] segmentTextures;
		Texture2D nullTexture;
		Texture2D arrowsTexture;
		Texture2D openIcon;
		Texture2D saveIcon;
		DrawingMode drawingMode = DrawingMode.SegmentSelection;

		int mouseX, mouseY;
		bool LeftMouseButtonDown;
		bool RightMouseButtonDown;
		bool mouseClick;

		int mouseDragSegment = -1;
		int currentLayer = 1;
		Vector2 scroll;
		int currentLedge = 0;
		int currentNode = 0;

		int previousMouseX, previousMouseY;

		MouseState mouseState;

		enum EditingMode
		{
			None,
			Path
		}

		KeyboardState keyboardState;
		KeyboardState oldKeyboardState;
		EditingMode editmode = EditingMode.None;

		#endregion

		#region Constructor
		
		public MapEditorMain()
		{
			graphics = new GraphicsDeviceManager(this);
					  
			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 600;

			Content.RootDirectory = "Content";
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
			map = new Map();
			this.IsMouseVisible = true;
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

			nullTexture = Content.Load<Texture2D>(@"gfx/1x1");
			saveIcon = Content.Load<Texture2D>(@"gfx/save_icon");
			openIcon = Content.Load<Texture2D>(@"gfx/folder_open_icon");

			segmentTextures = new Texture2D[1];
			for (int i = 0; i < segmentTextures.Length; i++)
			{
					segmentTextures[i] = Content.Load<Texture2D>(@"gfx/segments" + (i + 1).ToString());
			}
			arrowsTexture = Content.Load<Texture2D>(@"gfx/arrows");
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

			UpdateKeys();

			mouseState = Mouse.GetState();
			mouseX = mouseState.X;
			mouseY = mouseState.Y;
			bool previousMouseDown = LeftMouseButtonDown;

			if (mouseState.LeftButton == ButtonState.Pressed)
			{
				if (!LeftMouseButtonDown && GetCanEdit())
				{
					if (drawingMode == DrawingMode.SegmentSelection)
					{
						int f = map.GetHoveredSegment(mouseX, mouseY, currentLayer, scroll);

						if (f != -1)
							mouseDragSegment = f;                        
					}
					else if (drawingMode == DrawingMode.CollisionMap)
					{
						int x = (mouseX + (int)(scroll.X / 2)) / 32;
						int y = (mouseY + (int)(scroll.Y / 2)) / 32;

						if (x >= 0 && y >= 0 && x < 20 && y < 20)
						{
							if (mouseState.LeftButton == ButtonState.Pressed)
								if (map.Grid[x, y] == 0)
									map.Grid[x, y] = 1;
								else
									map.Grid[x, y] = 0;
							// did not really work with right button already assigned to scrolling
							//else if (mouseState.RightButton == ButtonState.Pressed)
							//	map.Grid[x, y] = 0;
						}
					}
					else if (drawingMode == DrawingMode.Ledges)
					{
						if (map.Legdes[currentLedge] == null)
							map.Legdes[currentLedge] = new Ledge();

						if (map.Legdes[currentLedge].TotalNodes < 15)
						{
							map.Legdes[currentLedge].Nodes[map.Legdes[currentLedge].TotalNodes] = new Vector2(mouseX, mouseY) + scroll / 2.0f;
							map.Legdes[currentLedge].TotalNodes++;
						}
					}
				}
				LeftMouseButtonDown = true;
			}                
			else
				LeftMouseButtonDown = false;
			if (previousMouseDown && !LeftMouseButtonDown) mouseClick = true;

			if (mouseDragSegment > -1)
			{
				if (!LeftMouseButtonDown)
					mouseDragSegment = -1;
				else
				{
					Vector2 location = map.Segments[currentLayer, mouseDragSegment].location;
					location.X += (mouseX - previousMouseX);
					location.Y += (mouseY - previousMouseY);
					map.Segments[currentLayer, mouseDragSegment].location = location;
				}
			}

			RightMouseButtonDown = (mouseState.RightButton == ButtonState.Pressed);

			if (RightMouseButtonDown)
			{
				scroll.X -= (mouseX - previousMouseX) * 2.0f;
				scroll.Y -= (mouseY - previousMouseY) * 2.0f;
			}
			
			previousMouseX = mouseX;
			previousMouseY = mouseY;
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			map.Draw(spriteBatch, segmentTextures, scroll);

			switch (drawingMode)
			{
				case DrawingMode.SegmentSelection:
					DrawMapSegments();
					break;
				case DrawingMode.CollisionMap:
					break;
				case DrawingMode.Ledges:
					DrawLedgeList();
					break;
				default:
					break;
			}

			DrawCollisionGrid();
			DrawLedges();

			if (DrawButton(5, 65, saveIcon, mouseX, mouseY, mouseClick))
				map.Write();
			if (DrawButton(40, 65, openIcon, mouseX, mouseY, mouseClick))
				map.Read();

			DrawText();

			base.Draw(gameTime);
		}

		

		#region Custom Draw Methods

		// Used to draw a texture as a clickable button
		private bool DrawButton(int x, int y, Texture2D buttonTexture, int mouseX, int mouseY, bool mouseClick)
		{
			bool r = false;
			Rectangle destinationRect = new Rectangle(x, y, 32, 32);

			if (destinationRect.Contains(mouseX,mouseY))
			{
				destinationRect.X -= 1;
				destinationRect.Y -= 1;
				destinationRect.Width += 2;
				destinationRect.Height += 2;
				if (mouseClick)
					r = true;
			}
			spriteBatch.Begin();
			spriteBatch.Draw(buttonTexture, destinationRect, Color.White);
			spriteBatch.End();

			return r;
			
		}

		// Draws the List of Ledges and lets edit the flag for hard ledge
		private void DrawLedgeList()
		{
			for (int i = 0; i < 16; i++)
			{
				if (map.Legdes[i] == null)
					continue;

				int y = 50 + i * 20;
				if (currentLedge == i)
				{
					text.color = Color.Lime;
					text.DrawText(520, y, "ledge " + i.ToString());
				}
				else
				{
					if (text.DrawClickText(520, y, "ledge " + i.ToString(), mouseX, mouseY, mouseClick))
						currentLedge = i;
				}

				text.color = Color.White;
				text.DrawText(620, y, "n" + map.Legdes[i].TotalNodes.ToString());

				if (text.DrawClickText(680, y, "f" + map.Legdes[i].isHardLedge.ToString(), mouseX, mouseY, mouseClick))
					map.Legdes[i].isHardLedge = (map.Legdes[i].isHardLedge + 1) % 2;
			}
		}

		// Draws the CollisionGrid (small Squares) for easy Collision settings
		// TODO: does not scroll with the view? maybe increase from 20x20 to higher setting?
		private void DrawCollisionGrid()
		{
			spriteBatch.Begin();
			for (int y = 0; y < 20; y++)
			{
				for (int x = 0; x < 20; x++)
				{
					Rectangle destionationRect = new Rectangle(
						x * 32 - (int)(scroll.X / 2),
						y * 32 - (int)(scroll.Y / 2),
						32,
						32);

					if (x < 19)
						spriteBatch.Draw(nullTexture, new Rectangle(destionationRect.X, destionationRect.Y, 32, 1), new Color(255, 0, 0, 100));
					if (y < 19)
						spriteBatch.Draw(nullTexture, new Rectangle(destionationRect.X, destionationRect.Y, 1, 32), new Color(255, 0, 0, 100));

					if (x < 19 && y < 19)
					{
						if (map.Grid[x, y] == 1)
						{
							spriteBatch.Draw(nullTexture, destionationRect, new Color(255, 0, 0, 100));
						}
					}
				}
			}

			// Draw a Rectangle, each Rectangle coresponds to one side
			Color oColor = new Color(255, 255, 255, 100);
			spriteBatch.Draw(nullTexture, new Rectangle(100, 50, 400, 1), oColor);
			spriteBatch.Draw(nullTexture, new Rectangle(100, 50, 1, 500), oColor);
			spriteBatch.Draw(nullTexture, new Rectangle(500, 50, 1, 500), oColor);
			spriteBatch.Draw(nullTexture, new Rectangle(100, 550, 400, 1), oColor);

			spriteBatch.End();
		}

		// Draws the Segment List on the right hand side when in Segment Mode
		private void DrawMapSegments()
		{
			Rectangle sourceRect = new Rectangle();
			Rectangle destinationRect = new Rectangle();

			text.size = 0.8f;

			spriteBatch.Begin();
			// Draw Blue Background behind Map Segments
			spriteBatch.Draw(nullTexture, new Rectangle(500, 20, 280, 550), new Color(0, 0, 0, 100));
			spriteBatch.End();

			// TODO: if new shapes are added increase i in for loop
			for (int i = 0; i < 6; i++)
			{
				SegmentDefinitions segDef = map.segDef[i];
				if (segDef == null)
					continue;

				spriteBatch.Begin();

				destinationRect.X = 500;
				destinationRect.Y = 50 + i * 60;

				sourceRect = segDef.sourceRect;

				// Shapes are made smaller to fit into right hand side of editor
				if (sourceRect.Width > sourceRect.Height)
				{
					destinationRect.Width = 45;
					destinationRect.Height = (int)(((float)sourceRect.Height /
					(float)sourceRect.Width) * 45.0f);
				}
				else
				{
					destinationRect.Height = 45;
					destinationRect.Width = (int)(((float)sourceRect.Width /
					(float)sourceRect.Height) * 45.0f);
				}
				spriteBatch.Draw(
				segmentTextures[segDef.sourceIndex], destinationRect, sourceRect, Color.White);
				spriteBatch.End();

				text.color = Color.White;
				text.DrawText(destinationRect.X + 50, destinationRect.Y, segDef.name);

				if (LeftMouseButtonDown)
				{
					if (mouseX > destinationRect.X && mouseY < 780 && mouseY > destinationRect.Y && mouseY < destinationRect.Y + 45)
					{
						if (mouseDragSegment == -1)
						{
							int f = map.AddSeg(currentLayer, i);
							if (f <= -1)
								continue;

							float layerScalar = 0.5f;
							if (currentLayer == 0)
								layerScalar = 0.375f;
							else if (currentLayer == 2)
								layerScalar = 0.625f;

							map.Segments[currentLayer, f].location.X = (mouseX - sourceRect.Width / 4 + scroll.X * layerScalar);
							map.Segments[currentLayer, f].location.Y = (mouseY - sourceRect.Height / 4 + scroll.Y * layerScalar);
							mouseDragSegment = f;
						}
					}
				}


			}
		}

		// Draws the clickable Text in the upper left corner
		private void DrawText()
		{
			// Layerbutton
			string layerName = "map";

			switch (currentLayer)
			{
				case 0:
					layerName = "back";
					break;
				case 1:
					layerName = "mid";
					break;
				case 2:
					layerName = "fore";
					break;
				default:
					break;
			}
			if (text.DrawClickText(5, 5, "layer: " + layerName, mouseX, mouseY, mouseClick))
				currentLayer = (currentLayer + 1) % 3;

			// DrawingMode Button
			switch (drawingMode)
			{
				case DrawingMode.SegmentSelection:
					layerName = "select";
					break;
				case DrawingMode.CollisionMap:
					layerName = "collision";
					break;
				case DrawingMode.Ledges:
					layerName = "ledges";
					break;
				default:
					break;
			}

			if (text.DrawClickText(5, 25, "draw: " + layerName, mouseX, mouseY, mouseClick))
				drawingMode = (DrawingMode)((int)(drawingMode + 1) % 3);

			text.color = Color.White;
			if (editmode == EditingMode.Path)
				text.DrawText(5, 45, map.Path + "*");
			else
			{
				if (text.DrawClickText(5, 45, map.Path, mouseX, mouseY, mouseClick))
					editmode = EditingMode.Path;
			}

			mouseClick = false;
		}

		// TODO: CleanUp and document better!
		private void DrawLedges()
		{
			// Rectangle so select arrow from arrowTexture
			Rectangle rect = new Rectangle(264, 14, 242, 137);
			spriteBatch.Begin();

			Color tColor = new Color();

			// iterate through all 16 ledges
			for (int i = 0; i < 16; i++)
			{
				if (map.Legdes[i] != null && map.Legdes[i].TotalNodes > 0)
				{
					// iterate through all nodes in current ledge and draw them
					for (int n = 0; n < map.Legdes[i].TotalNodes; n++)
					{
						Vector2 tVec;
						tVec = map.Legdes[i].Nodes[n];
						tVec -= scroll / 2.0f;
						tVec.X -= 5.0f;

						if (currentLedge == i)
							tColor = Color.Yellow;
						else
							tColor = Color.White;

						spriteBatch.Draw(arrowsTexture, tVec, rect, tColor, 0.0f, Vector2.Zero, 0.08f, SpriteEffects.None, 0.0f);

						if (n < map.Legdes[i].TotalNodes - 1)
						{
							Vector2 nVec;
							nVec = map.Legdes[i].Nodes[n + 1];
							nVec -= scroll / 2.0f;
							nVec.X -= 4.0f;

							// iterage through midpoints between adjacent pair of nodes in current ledge
							// draws a makeshift line of 20 arrows between those pairs
							// colors them red if hardLedge
							for (int x = 0; x < 20; x++)
							{
								Vector2 iVec = (nVec - tVec) * ((float)x / 20.0f) + tVec;
								Color nColor = new Color(255, 255, 255, 75);

								if (map.Legdes[i].isHardLedge == 1)
									nColor = new Color(255, 0, 0, 75);

								spriteBatch.Draw(arrowsTexture, iVec, rect, nColor, 0.0f, Vector2.Zero, 0.03f, SpriteEffects.None, 0.0f);
							}
						}
					}
				}
			}
			spriteBatch.End();
		}

		#endregion

		#region Handle Keyboard input
		
		// Registers Key presses and sends them to PressKey(Keys key) method
		private void UpdateKeys()
		{
			keyboardState = Keyboard.GetState();

			Keys[] currentKeys = keyboardState.GetPressedKeys();
			Keys[] lastUsedKeys = oldKeyboardState.GetPressedKeys();

			bool found = false;

			for (int i = 0; i < currentKeys.Length; i++)
			{
				found = false;

				for (int y = 0; y < lastUsedKeys.Length; y++)
				{
					if (currentKeys[i] == lastUsedKeys[y])
						found = true;
					break;
				}
				if (!found)
					PressKey(currentKeys[i]);
			}
			oldKeyboardState = keyboardState;
		}

		// Adds Keypress to string
		// TODO: very crude implementation
		private void PressKey(Keys key)
		{
			string t = String.Empty;
			switch (editmode)
			{
				case EditingMode.None:
					break;
				case EditingMode.Path:
					t = map.Path;
					break;
				default:
					break;
			}

			if (key == Keys.Back)
			{
				if (t.Length > 0)
					t = t.Substring(0, t.Length - 1);
			}
			else if (key == Keys.Enter)
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
				case EditingMode.Path:
					map.Path = t;
					break;
				default:
					break;
			}
		}

		#endregion

		private bool GetCanEdit()
		{
			if (mouseX > 100 && mouseX < 500 & mouseY > 100 && mouseY < 550)
				return true;
			return false;
		}
	}
}
