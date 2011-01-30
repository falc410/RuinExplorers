using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RuinExplorers.Particles
{
    class Smoke : Particle
    {
        public Smoke(Vector2 location, Vector2 trajectory, float r, float g,
            float b, float a, float size, int icon)
        {
            this.location = location;
            this.trajectory = trajectory;
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
            this.size = size;
            this.flag = icon;
            this.owner = -1;
            this.Exists = true;
            this.frame = 1.0f;
        }

        public override void Update(float gameTime, MapClasses.Map map, ParticleManager particleManager, CharacterClasses.Character[] characters)
        {
            if (frame < 0.5f)
            {
                if (trajectory.Y < -10.0f)
                    trajectory.Y += gameTime * 500.0f;
                if (trajectory.X < -10.0f)
                    trajectory.X += gameTime * 150.0f;
                if (trajectory.X > 10.0f)
                    trajectory.X -= gameTime * 150.0f;
            }
            base.Update(gameTime, map, particleManager, characters);
        }

        public override void Draw(SpriteBatch spriteBatch, Texture2D spriteTexture)
        {
            Rectangle sourceRect = new Rectangle(flag * 64, 0, 64, 64);
            float frameAlpha;

            if (frame > 0.9f)
                frameAlpha = (1.0f - frame) * 10.0f;
            else
                frameAlpha = (frame / 0.9f);

            spriteBatch.Draw(spriteTexture, GameLocation, sourceRect, new Color(new Vector4(frame * r,
                frame * g, frame * b, a * frameAlpha)), rotation, new Vector2(32.0f, 32.0f),
                size + (1.0f - frame), SpriteEffects.None, 1.0f);            
        }
    }
}
