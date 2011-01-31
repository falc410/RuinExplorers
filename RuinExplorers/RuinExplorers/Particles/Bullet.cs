using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RuinExplorers.Helpers;
using RuinExplorers.CharacterClasses;
using RuinExplorers.MapClasses;

namespace RuinExplorers.Particles
{
    class Bullet : Particle
    {
        public Bullet(Vector2 location, Vector2 trajectory, int owner)
        {
            this.location = location;
            this.trajectory = trajectory;
            this.owner = owner;
            rotation = GlobalFunctions.GetAngle(Vector2.Zero, trajectory);
            Exists = true;
            frame = 0.5f;
            Additive = true;
        }

        public override void Draw(SpriteBatch spriteBatch, Texture2D spriteTexture)
        {
            spriteBatch.Draw(spriteTexture, GameLocation, new Rectangle(0, 128, 64, 64),
                new Color(new Vector4(1f, 0.8f, 0.6f, 0.2f)), rotation, new Vector2(32f, 32f),
                new Vector2(1f, 0.1f), SpriteEffects.None, 1.0f);
        }

        public override void Update(float gameTime, Map map, ParticleManager particleManager, Character[] characters)
        {
            if (HitManager.CheckHit(this, characters, particleManager))
                frame = 0f;

            if (map.CheckParticleCollision(location))
            {
                frame = 0f;
                particleManager.MakeBulletDust(location, trajectory);
            }
            base.Update(gameTime, map, particleManager, characters);
        }
    }
}
