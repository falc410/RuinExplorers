using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RuinExplorers.Helpers;
using RuinExplorers.MapClasses;
using RuinExplorers.CharacterClasses;
using Microsoft.Xna.Framework.Graphics;

namespace RuinExplorers.Particles
{
    class Blood : Particle
    {
        public Blood(Vector2 location, Vector2 trajectory, float r, float g, float b, float a, float size, int icon)
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
            rotation = GlobalFunctions.GetAngle(Vector2.Zero, trajectory);
            frame = RandomGenerator.GetRandomFloat(0.3f, 0.7f);
        }

        /// <summary>
        /// Updates the blood particles which are slighly affected by gravity.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <param name="map">The map.</param>
        /// <param name="particleManager">The particle manager.</param>
        /// <param name="characters">The characters.</param>
        public override void Update(float gameTime, Map map, ParticleManager particleManager, Character[] characters)
        {
            trajectory.Y += gameTime * 100f;

            if (trajectory.X < -10f)
                trajectory.X += gameTime * 200f;
            if (trajectory.X > 10f)
                trajectory.X -= gameTime * 200f;

            rotation = GlobalFunctions.GetAngle(Vector2.Zero, trajectory);

            base.Update(gameTime, map, particleManager, characters);
        }

        /// <summary>
        /// Scale to make it wide thin blood streaks.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="spriteTexture">The sprite texture.</param>
        public override void Draw(SpriteBatch spriteBatch, Texture2D spriteTexture)
        {
            Rectangle sourceRect = new Rectangle(flag * 64, 0, 64, 64);

            float frameAlpha;

            if (frame > 0.9f)
                frameAlpha = (1.0f - frame) * 10f;
            else
                frameAlpha = (frame / 0.9f);

            spriteBatch.Draw(spriteTexture, GameLocation, sourceRect,
                new Color(new Vector4(r, g, b, a * frameAlpha)), rotation, new Vector2(32.0f, 32.0f),
                new Vector2(size * 2f, size * 0.5f), SpriteEffects.None, 1.0f);
        }
    }
}
