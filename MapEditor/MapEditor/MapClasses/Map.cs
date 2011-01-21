using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.MapClasses
{
	class Map
    {
        #region Variable Declaration
        
        public SegmentDefinitions[] segDef;
		MapSegment[,] mapSegment;
		int[,] colisionGrid;
		Ledge[] ledges;
		private string path = "mapname";


        #endregion

        #region Constructor

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

		public void Draw(SpriteBatch spriteBatch, Texture2D[] mapsTexture, Vector2 scroll)
		{
			Rectangle sourceRect = new Rectangle();
			Rectangle destinationRect = new Rectangle();

			spriteBatch.Begin();
			// 3 = Number of Layers
			for (int l = 0; l < 3; l++)
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

				scale *= 0.5f;

				for (int i = 0; i < 64; i++)
				{
					if (mapSegment[l,i] != null)
					{
						sourceRect = segDef[mapSegment[l, i].Index].sourceRect;
						destinationRect.X = (int)(mapSegment[l, i].location.X - scroll.X * scale);
						destinationRect.Y = (int)(mapSegment[l, i].location.Y - scroll.Y * scale);
						destinationRect.Width = (int)(sourceRect.Width * scale);
						destinationRect.Height = (int)(sourceRect.Height * scale);

						spriteBatch.Draw(mapsTexture[segDef[mapSegment[l, i].Index].sourceIndex],
							destinationRect, sourceRect, color);
					}
				}
			}
			spriteBatch.End();
		}


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

        public void Read()
        {
            BinaryReader file = new BinaryReader(File.Open(@"Content/data/" + path + ".dat", FileMode.Open));

            // read ledge information first
            for (int i = 0; i < ledges.Length; i++)
            {
                ledges[i] = new Ledge();
                ledges[i].TotalNodes = file.ReadInt32();
                for (int n = 0; n < ledges[i].TotalNodes; n++)
                {
                    ledges[i].Nodes[n] = new Vector2(
                    file.ReadSingle(), file.ReadSingle());
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
    }
}
