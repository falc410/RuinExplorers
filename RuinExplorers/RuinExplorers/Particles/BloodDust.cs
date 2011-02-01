using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RuinExplorers.Particles
{
    class BloodDust : Particle
    {
        public BloodDust(Vector2 location, Vector2 trajectory, float r, float g, float b, float a, float size, int icon)
        {
            this.location = location;
            this.trajectory = trajectory;
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
            this.size = size;
            this.flag = icon;
            owner = -1;
            Exists = true;
            frame = 1.0f;
        }

        public override void Draw(SpriteBatch sprite, Texture2D spritesTex)
        {
            sprite.Draw(spritesTex, GameLocation,
            new Rectangle(flag * 64, 0, 64, 64), new Color(
            new Vector4(r, g, b, a * frame)),
            rotation, new Vector2(32.0f, 32.0f), size,
            SpriteEffects.None, 1.0f);
        }
    }
}
