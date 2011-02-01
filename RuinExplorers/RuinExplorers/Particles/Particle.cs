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
        public const byte PARTICLE_NONE = 0;
        public const byte PARTICLE_BLOOD = 1;
        public const byte PARTICLE_BLOOD_DUST = 2;
        public const byte PARTICLE_BULLET = 3;
        public const byte PARTICLE_FIRE = 4;
        public const byte PARTICLE_FOG = 5;
        public const byte PARTICLE_HEAT = 6;
        public const byte PARTICLE_HIT = 7;
        public const byte PARTICLE_MUZZLEFLASH = 8;
        public const byte PARTICLE_ROCKET = 9;
        public const byte PARTICLE_SHOCKWAVE = 10;
        public const byte PARTICLE_SMOKE = 11;

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

        public bool refract;

        #region Properties
        
        public bool Additive
        {
            get { return additive; }
            set { additive = value; }
        }

        public Vector2 GameLocation
        {
            get { return location - RuinExplorersMain.Scroll; }
        }

        #endregion

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
