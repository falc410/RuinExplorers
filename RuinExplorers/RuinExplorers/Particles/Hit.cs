using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RuinExplorers.CharacterClasses;

namespace RuinExplorers.Particles
{
    class Hit : Particle
    {
        public Hit(Vector2 location, Vector2 trajectory, int owner, int flag)
        {
            this.location = location;
            this.trajectory = trajectory;
            this.owner = owner;
            this.flag = flag;

            Exists = true;
            frame = 0.5f;
        }

        public override void Update(float gameTime, MapClasses.Map map, ParticleManager particleManager, CharacterClasses.Character[] characters)
        {
            HitManager.CheckHit(this, characters, particleManager);
            KillMe();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Graphics.Texture2D spriteTexture)
        {
            // don't draw anything!
        }
    }
}
