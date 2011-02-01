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
    public class Particle
    {
        public Vector2 location;
        public Vector2 trajectory;
       
        protected float frame;
        protected float r, g, b, a;
        protected float size;
        protected float rotation;

        public int flag;
        public int owner;

        public bool Exists;
        public bool Background;
        private bool additive;

        public bool Additive
        {
            get { return additive; }
            set { additive = value; }
        }

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
