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

namespace TextLibrary
{
    public class Text
    {
        private float privateSize = 1f;
        private Color privateColor = Color.White;
        SpriteFont font;
        SpriteBatch spriteBatch;

        public Text(SpriteBatch _sprite, SpriteFont _font)
        {
            this.font = _font;
            this.spriteBatch = _sprite;
        }

        public Color color
        {
            get { return privateColor; }
            set { privateColor = value; }
        }

        public float size
        {
            get { return privateSize; }
            set { privateSize = value; }
        }

        public void DrawText(int x, int y, String s)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font, s, new Vector2((float)x, (float)y), color, 0f, new Vector2(), size, SpriteEffects.None, 1f);

            spriteBatch.End();
        }

        public bool DrawClickText(int x, int y, String s, int mosX, int mosY, bool mouseClick)
        {
            color = Color.White;

            bool r = false;

            if (mosX > x && mosY > y &&
                mosX < x + font.MeasureString(s).X * size &&
                mosY < y + font.MeasureString(s).Y * size)
            {
                color = Color.Yellow;
                if (mouseClick)
                    r = true;
            }
            DrawText(x, y, s);
            return r;
        }
    }
}
