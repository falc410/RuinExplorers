using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RuinExplorers.MapClasses;
using RuinExplorers.CharacterClasses;
using Microsoft.Xna.Framework.Graphics;

namespace RuinExplorers.Particles
{
    class Particle
    {
        protected Vector2 location;
        protected Vector2 trajectory;

        protected float frame;
        protected float r, g, b, a;
        protected float size;
        protected float rotation;

        protected int flag;
        protected int owner;

        public bool Exists;
        public bool Background;

        public Vector2 GameLocation
        {
            get { return location - RuinExplorersMain.Scroll; }
        }

        public Particle()
        {
            Exists = false;
        }

        public virtual void Update(float gameTime, Map map, ParticleManager particleManager, Character[] characters)
        {
            location += trajectory * gameTime;
            frame -= gameTime;
            if (frame < 0.0f)
                KillMe();
        }

        public virtual void KillMe()
        {
            Exists = false;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Texture2D spriteTexture)
        {

        }

    }
}
