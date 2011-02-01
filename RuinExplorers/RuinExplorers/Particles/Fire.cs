using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RuinExplorers.Particles
{
    class Fire : Particle
    {
        public Fire(Vector2 location, Vector2 trajectory, float size, int icon)
        {
            this.location = location;
            this.trajectory = trajectory;
            this.size = size;
            this.flag = icon;
            this.Exists = true;
            this.frame = 0.5f;
            this.Additive = true;
        }

        public Fire(Vector2 loc, Vector2 traj, float size, int icon, float frame)
        {
            this.location = loc;
            this.trajectory = traj;
            this.size = size;
            this.flag = icon;
            this.Exists = true;
            this.frame = frame;
            this.Additive = true;
        }

        public override void Draw(SpriteBatch spriteBatch, Texture2D spriteTexture)
        {
            if (frame > 0.5f)
                return;

            Rectangle sourceRect = new Rectangle(flag * 64, 64, 64, 64);
            float bright = frame * 5.0f;
            float tsize;
            // blue channel will fade out, fire will grow to full size
            if (frame > 0.4)
            {
                r = 1.0f;
                g = 1.0f;
                b = (frame - 0.4f) * 10.0f;
                if (frame > 0.45f)
                    tsize = (0.5f - frame) * size * 20.0f;
                else
                    tsize = size;
            }
                // green fades out
            else if (frame > 0.3f)
            {
                r = 1.0f;
                g = (frame - 0.3f) * 10.0f;
                b = 0.0f;
                tsize = size;
            }
                // red fades out, size shrinks to zero
            else
            {
                r = frame * 3.3f;
                g = 0.0f;
                b = 0.0f;
                tsize = (frame / 0.3f) * size;
            }

            // rotate one way or the other as frame decreases
            if (flag % 2 == 0)
                rotation = (frame * 7.0f + size * 20.0f);
            else
                rotation = (-frame * 11.0f + size * 20.0f);

            spriteBatch.Draw(spriteTexture,GameLocation,sourceRect,new Color(new Vector4(r,g,b,1.0f)),
                rotation,new Vector2(32.0f,32.0f),tsize,SpriteEffects.None,1.0f);
        }
    }
}
