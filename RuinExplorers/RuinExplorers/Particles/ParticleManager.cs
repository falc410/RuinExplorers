using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using RuinExplorers.MapClasses;
using RuinExplorers.CharacterClasses;
using Microsoft.Xna.Framework;
using RuinExplorers.Helpers;
using RuinExplorers.Shakes;
using RuinExplorers.Audio;

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

        /// <summary>
        /// Create a new Particle.
        /// </summary>
        /// <param name="newParticle">The new particle.</param>
        public void AddParticle(Particle newParticle)
        {
            AddParticle(newParticle, false);
        }

        /// <summary>
        /// Create a new Particle.
        /// </summary>
        /// <param name="newParticle">The new particle.</param>
        /// <param name="background">specifies whether the particle is drawn behind characters or in front.</param>
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

        /// <summary>
        /// Updates all active particles.
        /// </summary>
        /// <param name="frameTime">The frame time - time delta that has elapsed since the last update.</param>
        /// <param name="map">The current map.</param>
        /// <param name="characters">The characters array.</param>
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

        /// <summary>
        /// Makes a bullet with muzzle flash.
        /// </summary>
        /// <param name="location">The location to create the bullet from.</param>
        /// <param name="trajectory">bullet trajectory.</param>
        /// <param name="face">facing of the owner.</param>
        /// <param name="owner">The owner of the bullet.</param>
        public void MakeBullet(Vector2 location, Vector2 trajectory, CharacterDirection face, int owner)
        {
            switch (face)
            {
                case CharacterDirection.Left:
                    AddParticle(new Bullet(location, new Vector2(-trajectory.X, trajectory.Y) + RandomGenerator.GetRandomVector2(-90.0f, 90f, -90f, 90f),
                        owner));
                    MakeMuzzleFlash(location, new Vector2(-trajectory.X, trajectory.Y));
                    break;
                case CharacterDirection.Right:
                    AddParticle(new Bullet(location, trajectory + RandomGenerator.GetRandomVector2(-90.0f, 90f, -90f, 90f),
                        owner));
                    MakeMuzzleFlash(location, trajectory);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Makes dust to match bullet exit wound.
        /// </summary>
        /// <param name="location">The location of impact.</param>
        /// <param name="trajectory">The trajectory of the bullet.</param>
        public void MakeBulletDust(Vector2 location, Vector2 trajectory)
        {
            for (int i = 0; i < 16; i++)
            {
                // send a bit of light smoke back in the direction the bullet came from, at much slower and random speed
                AddParticle(new Smoke(location, RandomGenerator.GetRandomVector2(-50f, 50f, -50f, 10f) - trajectory * RandomGenerator.GetRandomFloat(0.001f, 0.1f),
                    1f, 1f, 1f, 0.25f, RandomGenerator.GetRandomFloat(0.05f, 0.25f), RandomGenerator.GetRandomInt(0, 4)));
                // create softer darker smoke
                AddParticle(new Smoke(location, RandomGenerator.GetRandomVector2(-50f, 50f, -50f, 10f),
                   0.5f, 0.5f, 0.5f, 0.25f, RandomGenerator.GetRandomFloat(0.1f, 0.5f), RandomGenerator.GetRandomInt(0, 4)));
            }
        }

        /// <summary>
        /// Makes an exit wound.
        /// </summary>
        /// <param name="location">The location of the bullet impact.</param>
        /// <param name="trajectory">The trajectory of the bullet.</param>
        public void MakeBulletBlood(Vector2 location, Vector2 trajectory)
        {
            for (int i = 0; i < 32; i++)
            {
                AddParticle(new Blood(location, trajectory * -1f * RandomGenerator.GetRandomFloat(0.01f, 0.1f) +
                    RandomGenerator.GetRandomVector2(-50f, 50f, -50f, 50f), 1f, 0f, 0f, 1f, RandomGenerator.GetRandomFloat(0.1f, 0.3f),
                    RandomGenerator.GetRandomInt(0, 4)));
            }
        }

        /// <summary>
        /// Makes blood splash that splatters in a direction
        /// </summary>
        /// <param name="location">The location of blood impact.</param>
        /// <param name="trajectory">blood splatter direction.</param>
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
        /// Make wraith missle explosion, using smoke, fire, and a shockwave refraction effect.
        /// </summary>
        /// <param name="loc">Explosion location</param>
        /// <param name="mag">Explosion magnitude--affects particle size</param>
        public void MakeExplosion(Vector2 loc, float mag)
        {
            for (int i = 0; i < 8; i++)
                AddParticle(new Smoke(loc,
                    RandomGenerator.GetRandomVector2(-100f, 100f,
                    -100f, 100f),
                    1f, .8f, .6f, 1f,
                    RandomGenerator.GetRandomFloat(1f, 1.5f),
                    RandomGenerator.GetRandomInt(0, 4)));
            for (int i = 0; i < 8; i++)
                AddParticle(new Fire(loc,
                    RandomGenerator.GetRandomVector2(-80f, 80f, -80f, 80f),
                    1f, RandomGenerator.GetRandomInt(0, 4)));

            AddParticle(new Shockwave(loc, true, 25f));
            AddParticle(new Shockwave(loc, false, 10f));
            Sound.PlayCue("explode");
            QuakeManager.SetQuake(.5f);
            QuakeManager.SetBlast(1f, loc);
        }

        /// <summary>
        /// Creates 16 MuzzleFlash Particles trailing off in a direction defined
        /// by trajectory, with particle size decreasing the farther the particles are
        /// from the source. A muzzleflash is comprised of heat haze, muzzleflash sprites and smoke.
        /// </summary>
        /// <param name="location">The location to make muzzle flash from.</param>
        /// <param name="trajectory">The trajectory of the bullet making the muzzleflash.</param>
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
            // looks silly imho
            for (int i = 4; i < 12; i++)
                AddParticle(new Heat(
                    location + (trajectory * (float)i) * 0.001f
                    + RandomGenerator.GetRandomVector2(-30f, 30f, -30f, 30f),
                    RandomGenerator.GetRandomVector2(-30f, 30f, -100f, 0f),
                    RandomGenerator.GetRandomFloat(.5f, 1.1f)));
        }

        /// <summary>
        /// Draws all active particles.
        /// </summary>
        /// <param name="spritesTexture">The texture used for particles.</param>
        /// <param name="background">specify wether this is a background pass or foreground draw pass</param>
        public void DrawParticles(Texture2D spritesTexture, bool background)
        {
            //spritebatch for alphablend particles
            spriteBatch.Begin();
            foreach (Particle p in particles)
            {
                if (p != null)
                {
                    if (!p.Additive && p.Background == background && !p.refract)
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
                    if (p.Additive && p.Background == background && !p.refract)
                        p.Draw(spriteBatch, spritesTexture);
                }
            }
            spriteBatch.End();
        }

        /// <summary>
        /// Draw all active refract particles.
        /// </summary>
        /// <param name="spritesTex">Texture to use for particles</param>
        public void DrawRefractParticles(Texture2D spritesTex)
        {
            spriteBatch.Begin();

            foreach (Particle p in particles)
            {
                if (p != null)
                {
                    if (p.refract)
                        p.Draw(spriteBatch, spritesTex);
                }
            }
            spriteBatch.End();
        }
    }
}
