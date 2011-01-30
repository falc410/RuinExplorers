using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using RuinExplorers.MapClasses;
using RuinExplorers.CharacterClasses;

namespace RuinExplorers.Particles
{
    class ParticleManager
    {
        Particle[] particles = new Particle[1024];
        SpriteBatch spriteBatch;

        public ParticleManager(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void AddParticle(Particle newParticle)
        {
            AddParticle(newParticle, false);
        }

        public void AddParticle(Particle newParticle, bool background)
        {
            for (int i = 0; i < particles.Length; i++)
            {
                if (particles[i] == null)
                {
                    particles[i] = newParticle;
                    particles[i].Background = background;
                    break;
                }
            }
        }

        public void UpdateParticles(float frameTime, Map map, Character[] characters)
        {
            for (int i = 0; i < particles.Length; i++)
            {
                if (particles[i] != null)
                {
                    particles[i].Update(frameTime, map, this, characters);
                    if (!particles[i].Exists)
                        particles[i] = null;
                }
            }
        }

        public void DrawParticles(Texture2D spritesTexture, bool background)
        {
            spriteBatch.Begin();
            foreach (Particle p in particles)
            {
                if (p != null)
                {
                    if (p.Background == background)
                        p.Draw(spriteBatch, spritesTexture);                    
                }
                
            }
            spriteBatch.End();
        }
    }
}
