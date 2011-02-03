using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RuinExplorers.Helpers;
using Microsoft.Xna.Framework.Graphics;

namespace RuinExplorers.Particles
{
    class Fog : Particle
    {
        public Fog(Vector2 location)
        {
            this.location = location;
            this.trajectory = new Vector2(80f, -30f);
            this.size = RandomGenerator.GetRandomFloat(6f, 8f);
            this.flag = RandomGenerator.GetRandomInt(0, 4);
            this.owner = -1;
            this.Exists = true;
            this.frame = (float)Math.PI * 2f;
            this.Additive = true;
            this.rotation = RandomGenerator.GetRandomFloat(0f, 6.28f);
        }

        public override void Draw(SpriteBatch spriteBatch, Texture2D spriteTexture)
        {
            spriteBatch.Draw(spriteTexture, GameLocation,
                new Rectangle(flag * 64, 0, 64, 64),
                new Color(new Vector4(1f, 1f, 1f, (float)Math.Sin(frame / 2) * 0.2f)),
                rotation + frame / 4f, new Vector2(32.0f, 32.0f), size, SpriteEffects.None, 1.0f);            
        }
    }
}
