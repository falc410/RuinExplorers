using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RuinExplorers.Particles
{
    class Shockwave : Particle
    {
        public Shockwave(Vector2 loc, bool refract, float size)
        {
            this.location = loc;
            this.size = size;
            this.owner = -1;
            this.Exists = true;
            this.frame = .5f;
            this.refract = refract;
        }

    

        public override void Draw(SpriteBatch sprite, Texture2D spritesTex)
        {
            Rectangle sRect = new Rectangle(
                128
                + (refract ? 0 : 64),
                128, 64, 64);

            a = frame * (refract ? 1f : 0.5f);

            float gb = (refract ? 0f : 1f);

            sprite.Draw(spritesTex, GameLocation, sRect, new Color(
                new Vector4(1f, gb, gb, a)),
                rotation + frame * 16f, new Vector2(32.0f, 32.0f),
                size * (.5f - frame) * 2f,
                SpriteEffects.None, 1.0f);


        }
    }
}
