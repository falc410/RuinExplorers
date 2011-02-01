using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RuinExplorers.Helpers;

namespace RuinExplorers.Particles
{
    class Heat : Particle
    {
        public Heat(Vector2 loc,
           Vector2 traj,
           float size)
        {
            this.location = loc;
            this.trajectory = traj;
            this.size = size;
            this.flag = RandomGenerator.GetRandomInt(0, 4);
            this.owner = -1;
            this.Exists = true;
            this.rotation = RandomGenerator.GetRandomFloat(0f, 6.28f);
            this.frame = RandomGenerator.GetRandomFloat(.5f, .785f);
            this.refract = true;
        }



        public override void Draw(SpriteBatch sprite, Texture2D spritesTex)
        {

            Rectangle sRect = new Rectangle(flag * 64, 64, 64, 64);

            a = (float)Math.Sin((double)frame * 4.0) * .1f;


            sprite.Draw(spritesTex, GameLocation, sRect, new Color(
                new Vector4(1f, 0f, 0f, a)),
                rotation + frame * 16f, new Vector2(32.0f, 32.0f),
                size,
                SpriteEffects.None, 1.0f);
        }
    }
}
