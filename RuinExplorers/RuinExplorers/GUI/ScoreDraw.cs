using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RuinExplorers.GUI
{
    public enum Justification
    {
        Left = 0,
        Right
    }

    class ScoreDraw
    {
        SpriteBatch spriteBatch;
        Texture2D spritesTexture;

        public ScoreDraw(SpriteBatch spriteBatch, Texture2D spritesTexture)
        {
            this.spriteBatch = spriteBatch;
            this.spritesTexture = spritesTexture;
        }

        public void Draw(long score, Vector2 location, Color color, Justification justify)
        {
            int place = 0;

            if (justify == Justification.Left)
            {
                location.X -= 17f;
                long s = score;
                if (s == 0)
                    location.X += 17f;
                else
                    while (s > 0)
                    {
                        s /= 10;
                        location.X += 17f;
                    }
            }

            while (true)
            {
                long digit = score % 10;
                score = score / 10;

                spriteBatch.Draw(spritesTexture, location + new Vector2((float)place * -17f, 0f),
                    new Rectangle((int)digit * 16, 224, 16, 32), color);

                place++;
                if (score <= 0)
                    return;
            }
        }
    }
}
