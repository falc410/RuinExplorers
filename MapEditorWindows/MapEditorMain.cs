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
using MapEditorWindows.MapClasses;
using TextLibrary;
using System.Windows.Forms;


namespace MapEditorWindows
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
    public class MapEditorMain : GraphicsDeviceControl
	{

		#region Variables Declaration

        ContentManager Content;
		SpriteBatch spriteBatch;

		Text text;
		SpriteFont font;

		Map map;
		Texture2D[] segmentTextures;
		Texture2D nullTexture;
		Texture2D arrowsTexture;
		DrawingMode drawingMode = DrawingMode.SegmentSelection;
        System.Drawing.Image segmentImage;

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

        #region Properties        

        public DrawingMode Mode
        {
            get { return drawingMode; }
            set { drawingMode = value; }
        }

        public int CurrentLedge
        {
            get { return currentLedge; }
            set { currentLedge = value; }
        }

        public Map Map
        {
            get { return map; }
            set { map = value; }

        }

        public System.Drawing.Image SegmentImage
        {
            get { return segmentImage; }
        }

        public int CurrentLayer
        {
            get { return currentLayer; }
            set { currentLayer = value; }
        }

        public Vector2 Scroll
        {
            get { return scroll; }
            set { scroll = value; }
        }

        #endregion

		protected override void Initialize()
		{
            Content = new ContentManager(Services, "WindowsContent");
            map = new Map();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>(@"Fonts/Arial");
            text = new Text(spriteBatch, font);
            text.size = 0.8f;

            nullTexture = Content.Load<Texture2D>(@"gfx/1x1");

            segmentTextures = new Texture2D[1];
            for (int i = 0; i < segmentTextures.Length; i++)
            {
                segmentTextures[i] = Content.Load<Texture2D>(@"gfx/segments" + (i + 1).ToString());
            }

            segmentImage = System.Drawing.Bitmap.FromFile(@"WindowsContent/gfx/source/segments1.png");

            arrowsTexture = Content.Load<Texture2D>(@"gfx/arrows");

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

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
        //protected override void Update()
        //{
        //    // Allows the game to exit
        //    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
        //        this.Exit();

        //    UpdateKeys();

        //    mouseState = Mouse.GetState();
        //    mouseX = mouseState.X;
        //    mouseY = mouseState.Y;
        //    bool previousMouseDown = LeftMouseButtonDown;

        //    if (mouseState.LeftButton == ButtonState.Pressed)
        //    {
        //        if (!LeftMouseButtonDown && GetCanEdit())
        //        {
        //            if (drawingMode == DrawingMode.SegmentSelection)
        //            {
        //                int f = map.GetHoveredSegment(mouseX, mouseY, currentLayer, scroll);

        //                if (f != -1)
        //                    mouseDragSegment = f;                        
        //            }
        //            else if (drawingMode == DrawingMode.CollisionMap)
        //            {
        //                int x = (mouseX + (int)(scroll.X / 2)) / 32;
        //                int y = (mouseY + (int)(scroll.Y / 2)) / 32;

        //                if (x >= 0 && y >= 0 && x < 20 && y < 20)
        //                {
        //                    if (mouseState.LeftButton == ButtonState.Pressed)
        //                        if (map.Grid[x, y] == 0)
        //                            map.Grid[x, y] = 1;
        //                        else
        //                            map.Grid[x, y] = 0;
        //                    // did not really work with right button already assigned to scrolling
        //                    //else if (mouseState.RightButton == ButtonState.Pressed)
        //                    //	map.Grid[x, y] = 0;
        //                }
        //            }
        //            else if (drawingMode == DrawingMode.Ledges)
        //            {
        //                if (map.Legdes[currentLedge] == null)
        //                    map.Legdes[currentLedge] = new Ledge();

        //                if (map.Legdes[currentLedge].TotalNodes < 15)
        //                {
        //                    map.Legdes[currentLedge].Nodes[map.Legdes[currentLedge].TotalNodes] = new Vector2(mouseX, mouseY) + scroll / 2.0f;
        //                    map.Legdes[currentLedge].TotalNodes++;
        //                }
        //            }
        //        }
        //        LeftMouseButtonDown = true;
        //    }                
        //    else
        //        LeftMouseButtonDown = false;
        //    if (previousMouseDown && !LeftMouseButtonDown) mouseClick = true;

        //    if (mouseDragSegment > -1)
        //    {
        //        if (!LeftMouseButtonDown)
        //            mouseDragSegment = -1;
        //        else
        //        {
        //            Vector2 location = map.Segments[currentLayer, mouseDragSegment].location;
        //            location.X += (mouseX - previousMouseX);
        //            location.Y += (mouseY - previousMouseY);
        //            map.Segments[currentLayer, mouseDragSegment].location = location;
        //        }
        //    }

        //    RightMouseButtonDown = (mouseState.RightButton == ButtonState.Pressed);

        //    if (RightMouseButtonDown)
        //    {
        //        scroll.X -= (mouseX - previousMouseX) * 2.0f;
        //        scroll.Y -= (mouseY - previousMouseY) * 2.0f;
        //    }
			
        //    previousMouseX = mouseX;
        //    previousMouseY = mouseY;
        //    base.Update(gameTime);
        //}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw()
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			map.Draw(spriteBatch, segmentTextures, scroll);

			switch (drawingMode)
			{
				case DrawingMode.SegmentSelection:					
					break;
				case DrawingMode.CollisionMap:
                    DrawCollisionGrid();
					break;
				case DrawingMode.Ledges:
					DrawLedgeList();
					break;
				default:
					break;
			}

			
			DrawLedges();

			//DrawText();

		}

		

		#region Custom Draw Methods

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

	
		private bool GetCanEdit()
		{
			if (mouseX > 100 && mouseX < 500 & mouseY > 100 && mouseY < 550)
				return true;
			return false;
		}
	}
}
