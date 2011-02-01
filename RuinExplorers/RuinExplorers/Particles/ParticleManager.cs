using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using RuinExplorers.MapClasses;
using RuinExplorers.CharacterClasses;
using Microsoft.Xna.Framework;
using RuinExplorers.Helpers;

namespace RuinExplorers.Particles
{
    public class ParticleManager
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

        public void MakeBullet(Vector2 location, Vector2 trajectory, Character.CharacterDirection face, int owner)
        {
            switch (face)
            {
                case Character.CharacterDirection.Left:
                    AddParticle(new Bullet(location, new Vector2(-trajectory.X, trajectory.Y) + RandomGenerator.GetRandomVector2(-90.0f, 90f, -90f, 90f),
                        owner));
                    MakeMuzzleFlash(location, new Vector2(-trajectory.X, trajectory.Y));
                    break;
                case Character.CharacterDirection.Right:
                    AddParticle(new Bullet(location, trajectory + RandomGenerator.GetRandomVector2(-90.0f, 90f, -90f, 90f),
                        owner));
                    MakeMuzzleFlash(location, trajectory);
                    break;
                default:
                    break;
            }
        }

        public void MakeBulletDust(Vector2 location, Vector2 trajectory)
        {
            for (int i = 0; i < 16; i++)
            {
                // send a bit of light smoke back in the direction the bullet came from, at much slower and random speed
                AddParticle(new Smoke(location, RandomGenerator.GetRandomVector2(-50f, 50f, -50f, 10f) - trajectory * RandomGenerator.GetRandomFloat(0.001f, 0.1f),
                    1f, 1f, 1f, 0.25f, RandomGenerator.GetRandomFloat(0.05f, 0.25f), RandomGenerator.GetRandomInt(0, 4)));
                // create softer darker smoke
                AddParticle(new Smoke(location, RandomGenerator.GetRandomVector2(-50f, 50f, -50f, 10f) - trajectory * RandomGenerator.GetRandomFloat(0.001f, 0.1f),
                   0.5f, 0.5f, 0.5f, 0.25f, RandomGenerator.GetRandomFloat(0.1f, 0.5f), RandomGenerator.GetRandomInt(0, 4)));
            }
        }

        public void MakeBulletBlood(Vector2 location, Vector2 trajectory)
        {
            for (int i = 0; i < 32; i++)
            {
                AddParticle(new Blood(location, trajectory * -1f * RandomGenerator.GetRandomFloat(0.01f, 0.1f) +
                    RandomGenerator.GetRandomVector2(-50f, 50f, -50f, 50f), 1f, 0f, 0f, 1f, RandomGenerator.GetRandomFloat(0.1f, 0.3f),
                    RandomGenerator.GetRandomInt(0, 4)));
            }
        }

        public void MakeBloodSplash(Vector2 location, Vector2 trajectory)
        {
            trajectory += RandomGenerator.GetRandomVector2(-100f, 100f, -100f, 100f);

            for (int i = 0; i < 64; i++)
            {
                AddParticle(new Blood(location, trajectory * RandomGenerator.GetRandomFloat(0.1f, 3.5f) +
                    RandomGenerator.GetRandomVector2(-70f, 70f, -70f, 70f), 1f, 0f, 0f, 1f,
                    RandomGenerator.GetRandomFloat(0.01f, 0.25f), RandomGenerator.GetRandomInt(0, 4)));

                AddParticle(new Blood(location, trajectory * RandomGenerator.GetRandomFloat(-0.2f, 0f) +
                    RandomGenerator.GetRandomVector2(-120f, 120f, -120f, 120f), 1f, 0f, 0f, 1f,
                    RandomGenerator.GetRandomFloat(0.01f, 0.25f), RandomGenerator.GetRandomInt(0, 4)));
            }
            // I think it's overkill to have steam on normal hits
            //MakeBulletDust(location, trajectory * -20f);
            //MakeBulletDust(location, trajectory * 10f);
        }

        /// <summary>
        /// Creates 16 MuzzleFlash Particles trailing off in a direction defined
        /// by trajectory, with particle size decreasing the farther the particles are
        /// from the source. Also creates a little puff of smoke.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="trajectory">The trajectory.</param>
        public void MakeMuzzleFlash(Vector2 location, Vector2 trajectory)
        {
            for (int i = 0; i < 16; i++)
            {
                AddParticle(new MuzzleFlash(location + (trajectory * (float)i) * 0.001f + RandomGenerator.GetRandomVector2(-5f,5f,-5f,5f),
                    trajectory / 5f, (20f - (float)i) * 0.06f));
            }
            for (int i = 0; i < 4; i++)
			{
                AddParticle(new Smoke(location,RandomGenerator.GetRandomVector2(-30f,30f,-100f,0f),
                    0f,0f,0f,0.25f,RandomGenerator.GetRandomFloat(0.25f,1.0f),RandomGenerator.GetRandomInt(0,4)));
			}
        }

        public void DrawParticles(Texture2D spritesTexture, bool background)
        {
            //spritebatch for alphablend particles
            spriteBatch.Begin();
            foreach (Particle p in particles)
            {
                if (p != null)
                {
                    if (!p.Additive && p.Background == background)
                        p.Draw(spriteBatch, spritesTexture);                    
                }
                
            }
            spriteBatch.End();

            //seperate spritebatch for additive mode
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            foreach (Particle p in particles)
            {
                if (p != null)
                {
                    if (p.Additive && p.Background == background)
                        p.Draw(spriteBatch, spritesTexture);
                }
            }
            spriteBatch.End();
        }
    }
}
