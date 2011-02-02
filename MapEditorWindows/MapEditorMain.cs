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

		int currentLayer = 1;
		Vector2 scroll;
		int currentLedge = 0;
		
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
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw()
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			map.Draw(spriteBatch, segmentTextures, scroll);

            if (drawingMode == DrawingMode.CollisionMap)
                DrawCollisionGrid();
			
			DrawLedges();

		}

		#region Custom Draw Methods	

		// Draws the CollisionGrid (small Squares) for easy Collision settings
		// TODO: does not scroll with the view? maybe increase from 20x20 to bigger array?
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

        #region Script Related

        public T NumToEnum<T>(int number)
        {
            return (T)Enum.ToObject(typeof(T), number);
        }

        public string GetScriptCommandExplanation(ScriptCommands scriptCommand)
        {
            switch (scriptCommand)
            {
                case ScriptCommands.fog:
                    return "'fog' : Turns map fog on";
                case ScriptCommands.monster:
                    return "'monster type x y name' : Creates a monster of type 'type' at location 'x y' with the name 'name'. Example: 'monster zombie 200 100 z1'";
                case ScriptCommands.makebucket:
                    return "'makebucket size' : Creates a bucket of size 'size'. A bucket is a list of monsters that will empty itself onto the map as long as screen population is < size. Example: 'makebucket 3'";
                case ScriptCommands.addbucket:
                    return "'addbucket type x y' : Adds a monster of type 'type' to the bucket. It will spawn at location 'x y'. Example: 'addbucket zombie 300 100'";
                case ScriptCommands.ifnotbucketgoto:
                    break;
                case ScriptCommands.wait:
                    return "'wait ticks' : Pauses the script for 'ticks' ticks. Example: wait 5";
                case ScriptCommands.setflag:
                    break;
                case ScriptCommands.iftruegoto:
                    break;
                case ScriptCommands.iffalsegoto:
                    break;
                case ScriptCommands.setglobalflag:
                    break;
                case ScriptCommands.ifglobaltruegoto:
                    break;
                case ScriptCommands.ifglobalfalsegoto:
                    break;
                case ScriptCommands.stop:
                    break;
                case ScriptCommands.setleftexit:
                    break;
                case ScriptCommands.setleftentrance:
                    break;
                case ScriptCommands.setrightexit:
                    break;
                case ScriptCommands.setrightentrance:
                    break;
                case ScriptCommands.setintroentrance:
                    break;
                case ScriptCommands.water:
                    break;
                case ScriptCommands.tag:
                    break;
                default:
                    break;
            }

            return "Not available for this Command!";
        }
        #endregion
    }
}
