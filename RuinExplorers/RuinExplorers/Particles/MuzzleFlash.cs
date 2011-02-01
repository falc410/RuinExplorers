using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RuinExplorers.Helpers;
using Microsoft.Xna.Framework.Graphics;

namespace RuinExplorers.Particles
{
    class MuzzleFlash : Particle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MuzzleFlash"/> class.
        /// Has a very short life span and random rotation.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="trajectory">The trajectory.</param>
        /// <param name="size">The size.</param>
        public MuzzleFlash(Vector2 location, Vector2 trajectory, float size)
        {
            this.location = location;
            this.trajectory = trajectory;
            this.size = size;
            this.rotation = RandomGenerator.GetRandomFloat(0f, 6.28f);
            this.Exists = true;
            this.frame = 0.05f;
            this.Additive = true;
                
        }

        /// <summary>
        /// Draws with a slight reddish tint, rapidly fading out.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="spriteTexture">The sprite texture.</param>
        public override void Draw(SpriteBatch spriteBatch, Texture2D spriteTexture)
        {
            spriteBatch.Draw(spriteTexture, GameLocation, new Rectangle(64, 128, 64, 64),
                new Color(new Vector4(1f, 0.8f, 0.6f, frame * 8f)), rotation, new Vector2(32f, 32f),
                size - frame, SpriteEffects.None, 1.0f);
        }
    }
}
