using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RuinExplorers.MapClasses
{
	/// <summary>
	/// A map consists out of an array of segments[64] which are located on
	/// three different layers (back, middle, foreground)
	/// it also got a collisiongrid for quick collision testing and an array
	/// of ledges[16] to draw a collision line
	/// It also contains an array of segmentDefinitions[512] which essentially
	/// reads in a file containing rectangle information and flags for a specific
	/// texture file (max of 512 lines).
	/// </summary>
	class Map
	{
		#region Variable Declaration
		
		public SegmentDefinitions[] segDef;
		MapSegment[,] mapSegment;
		int[,] colisionGrid;
		Ledge[] ledges;
		private string path = "mapname";

		const int LAYER_BACK = 0;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="Map"/> class.
		/// Creates an empty array for segmentDefinition, 3 layers each with
		/// room for 64 segments, an array of 16 ledges and a collision grid which is 20x20
		/// then it reads segment definitions - to load a map from a file the Read() method
		/// has to be invoked manually (we do this in the initialize method from the main class)
		/// </summary>
		public Map()
		{
			segDef = new SegmentDefinitions[512];
			mapSegment = new MapSegment[3, 64];
			colisionGrid = new int[20, 20];
			ledges = new Ledge[16];
			for (int i = 0; i < 16; i++)
			{
				ledges[i] = new Ledge();
			}
			ReadSegmentDefinitions();
		}
		#endregion

		#region Properties

		public string Path
		{
			get { return path; }
			set { path = value; }
		}

		public Ledge[] Legdes
		{
			get { return ledges; }
		}

		public int[,] Grid
		{
			get { return colisionGrid; }
		}

		public MapSegment[,] Segments
		{
			get { return mapSegment; }
		}

		#endregion

		public int AddSeg(int layer, int index)
		{
			// 64 is the max size of mapSegment array. 3 Layers with 64 segments per map
			for (int i = 0; i < 64; i++)
			{
				if (mapSegment[layer, i] == null)
				{
					mapSegment[layer, i] = new MapSegment();
					mapSegment[layer, i].Index = index;
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Reads the segment definitions from fixed path (mapSegments.dat).
		/// The layout of the file has to look like this:
		/// #src 1
		/// name
		/// 0 0 0 0
		/// 0
		/// line 1: index of source texture
		/// line 2: name of the segment - is drawn in the level editor
		/// line 3: coordinates of source rectangle in the following order: x coordinate of upper left corner,
		/// y coordinate of upper left corner, width of rectangle, height of rectangle
		/// </summary>
		private void ReadSegmentDefinitions()
		{
			StreamReader streamReader = new StreamReader(@"Content/data/mapSegments.dat");
			string t = "";

			int n;
			int currentTex = 0;

			int curDef = -1;
			Rectangle tRect = new Rectangle();
			string[] split;
			t = streamReader.ReadLine();

			while (!streamReader.EndOfStream)
			{
				t = streamReader.ReadLine();
				if (t.StartsWith("#"))
				{
					if (t.StartsWith("#src"))
					{
						split = t.Split(' ');
						if (split.Length > 1)
						{
							n = Convert.ToInt32(split[1]);
							currentTex = n - 1;
						}
					}
				}
				else
				{
					curDef++;
					string name = t;
					t = streamReader.ReadLine();
					split = t.Split(' ');
					if (split.Length > 3)
					{
						tRect.X = Convert.ToInt32(split[0]);
						tRect.Y = Convert.ToInt32(split[1]);
						tRect.Width = Convert.ToInt32(split[2]);
						tRect.Height = Convert.ToInt32(split[3]);
					}
				else
					Console.WriteLine("read fail: " + name);

				int tex = currentTex;
				t = streamReader.ReadLine();
				int flags = Convert.ToInt32(t);
				segDef[curDef] = new SegmentDefinitions(name, tex, tRect, flags);
				}
			}
		}//ReadSegmentDefinitions()

		public int GetHoveredSegment(int x, int y, int l, Vector2 scroll)
		{
			float scale = 1.0f;
			if (l == 0)
				scale = 0.75f;
			else if (l == 2)
				scale = 1.25f;
			scale *= 0.5f;

			for (int i = 63; i >= 0; i--)
			{
				if (mapSegment[l,i] != null)
				{
					Rectangle sourceRect = segDef[mapSegment[l, i].Index].sourceRect;
					Rectangle destinationRect = new Rectangle((int)(mapSegment[l, i].location.X - scroll.X * scale),
						(int)(mapSegment[l, i].location.Y - scroll.Y * scale),
						(int)(sourceRect.Width * scale), (int)(sourceRect.Height * scale));
					if (destinationRect.Contains(x, y))
						return i;
				}
			}
			return -1;
		}


		/// <summary>
		/// Returns the section of a ledge in which an entity's x value reside.
		/// </summary>
		/// <param name="l">The l.</param>
		/// <param name="x">The x.</param>
		/// <returns></returns>
		public int GetLedgeSection(int l, float x)
		{
			for (int i = 0; i < ledges[l].TotalNodes -1; i++)
			{
				if (x >= ledges[l].Nodes[i].X && x <= ledges[l].Nodes[i + 1].X)
					return i;
			}
			return -1;
		}

		/// <summary>
		/// Determine if a characters locations is within a ledge's bounds (x value to the left and right side).
		/// </summary>
		/// <param name="l">The ledge index.</param>
		/// <param name="i">The section index.</param>
		/// <param name="x">The x value.</param>
		/// <returns></returns>
		public float GetLedgeYLocation(int l,int i,float x)
		{
			return (ledges[l].Nodes[i + 1].Y - ledges[l].Nodes[i].Y) * ((x - ledges[l].Nodes[i].X) / (ledges[l].Nodes[i + 1].X - ledges[l].Nodes[i].X)) +
				ledges[l].Nodes[i].Y;
		}

		/// <summary>
		/// Quickly check the collision based on a location and our collision grid (which is only 20x20 array).
		/// </summary>
		/// <param name="location">The location to check.</param>
		/// <returns></returns>
		public bool CheckCollision(Vector2 location)
		{
			if (location.X < 0f)
				return true;
			if (location.Y < 0f)
				return true;

			int x = (int)(location.X / 64f);
			int y = (int)(location.Y / 64f);

			if (x >= 0 && y >= 0 && x < 20 && y < 20)
				if (colisionGrid[x, y] == 0)
					return false;
			return true;
		}

		public void Draw(SpriteBatch spriteBatch, Texture2D[] mapsTexture, Texture2D[] mapBackground, int startLayer, int endLayer)
		{
			Rectangle sourceRect = new Rectangle();
			Rectangle destinationRect = new Rectangle();

			spriteBatch.Begin();

			if (startLayer == LAYER_BACK)
			{
				float xLim = GetXLim();
				float yLim = GetYLim();
				Vector2 target = new Vector2(RuinExplorersMain.ScreenSize.X / 2f -
				((RuinExplorersMain.Scroll.X / xLim) - 0.5f) * 100f,
				RuinExplorersMain.ScreenSize.Y / 2f - ((RuinExplorersMain.Scroll.Y / yLim) - 0.5f) * 100f);

				spriteBatch.Draw(mapBackground[0], target, new Rectangle(0, 0, 1280, 720), Color.White, 0f, new Vector2(640f, 360f), 1f, SpriteEffects.None, 1f);
			}

			for (int l = startLayer; l < endLayer; l++)
			{
				float scale = 1.0f;
				Color color = Color.White;
				if (l == 0)
				{
					color = Color.Gray;
					scale = 0.75f;
				}
				else if (l == 2)
				{
					color = Color.DarkGray;
					scale = 1.25f;
				}			

				for (int i = 0; i < 64; i++)
				{
					if (mapSegment[l,i] != null)
					{
						sourceRect = segDef[mapSegment[l, i].Index].sourceRect;
						destinationRect.X = (int)(mapSegment[l, i].location.X * 2f - RuinExplorersMain.Scroll.X * scale);
						destinationRect.Y = (int)(mapSegment[l, i].location.Y * 2f - RuinExplorersMain.Scroll.Y * scale);
						destinationRect.Width = (int)(sourceRect.Width * scale);
						destinationRect.Height = (int)(sourceRect.Height * scale);

						spriteBatch.Draw(mapsTexture[segDef[mapSegment[l, i].Index].sourceIndex],
							destinationRect, sourceRect, color);
					}
				}
			}
			spriteBatch.End();
		}

		#region Map IO Methods

		/// <summary>
		/// Writes the map to disk. Not used in the live engine - only for editor!
		/// might want to delete this in the future from here.
		/// </summary>
		public void Write()
		{
			BinaryWriter file = new BinaryWriter(File.Open(@"Content/data/" + path + ".dat", FileMode.Create));

			//Write all information about our map in binary to file
			// start with ledges information
			for (int i = 0; i < ledges.Length; i++)
			{               
			file.Write(ledges[i].TotalNodes);
			for (int n = 0; n < ledges[i].TotalNodes; n++)
			{
				file.Write(ledges[i].Nodes[n].X);
				file.Write(ledges[i].Nodes[n].Y);
			}
			file.Write(ledges[i].isHardLedge);
	   
			}
			// write layer / segment informatoin
			for (int l = 0; l < 3; l++)
			{
				for (int i = 0; i < 64; i++)
				{
					if (mapSegment[l, i] == null)
						file.Write(-1);
					else
					{
						file.Write(mapSegment[l, i].Index);
						file.Write(mapSegment[l, i].location.X);
						file.Write(mapSegment[l, i].location.Y);
					}
				}
			}
			// write collision grid information
			for (int x = 0; x < 20; x++)
			{
				for (int y = 0; y < 20; y++)
				{
					file.Write(colisionGrid[x, y]);
				}
			}

			file.Close();
		}

		/// <summary>
		/// Reads the map from file.
		/// </summary>
		public void Read()
		{
			BinaryReader file = new BinaryReader(File.Open(@"Content/data/maps/" + path + ".dat", FileMode.Open));

			// read ledge information first
			for (int i = 0; i < ledges.Length; i++)
			{
				ledges[i] = new Ledge();
				ledges[i].TotalNodes = file.ReadInt32();
				for (int n = 0; n < ledges[i].TotalNodes; n++)
				{
					ledges[i].Nodes[n] = new Vector2(
					file.ReadSingle() * 2f, file.ReadSingle() *2f);
				}
				ledges[i].isHardLedge = file.ReadInt32();
			}
			// read layer / segment information
			for (int l = 0; l < 3; l++)
			{
				for (int i = 0; i < 64; i++)
				{
					int t = file.ReadInt32();
					if (t == -1)
						mapSegment[l, i] = null;
					else
					{
						mapSegment[l, i] = new MapSegment();
						mapSegment[l, i].Index = t;
						mapSegment[l, i].location = new Vector2(
						file.ReadSingle(),
						file.ReadSingle());
					}
				}
			}
			// read collision grid information
			for (int x = 0; x < 20; x++)
			{
				for (int y = 0; y < 20; y++)
				{
					colisionGrid[x, y] = file.ReadInt32();
				}
			}
			file.Close();
		}
		#endregion

		public float GetXLim()
		{
			return 1280 - RuinExplorersMain.ScreenSize.X;
		}
		public float GetYLim()
		{
			return 1280 - RuinExplorersMain.ScreenSize.Y;
		}
	}
}
