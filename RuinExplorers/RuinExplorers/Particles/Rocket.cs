using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RuinExplorers.CharacterClasses;
using RuinExplorers.MapClasses;
using RuinExplorers.Helpers;

namespace RuinExplorers.Particles
{
    class Rocket : Particle
    {
        public Rocket(Vector2 loc, Vector2 traj, int owner)
        {
            this.location = loc;
            this.trajectory = traj;
            this.owner = owner;
            this.frame = 4f;
            this.Exists = true;
        }       

        public override void Update(float gameTime, Map map, ParticleManager pMan, Character[] c)
        {
            if (HitManager.CheckHit(this, c, pMan))
                frame = 0f;

            trajectory.Y = (float)Math.Sin((double)frame * 13.0) * 150f;

            if (map.CheckParticleCollision(location))
            {
                this.frame = 0f;
                pMan.MakeExplosion(location, 1f);
            }

            pMan.AddParticle(new Fire(location, -trajectory / 8f,
                .5f, RandomGenerator.GetRandomInt(0, 4)));
            pMan.AddParticle(new Smoke(location,
                RandomGenerator.GetRandomVector2(-20f, 20f, -50f, 10f)
                - trajectory / 10f,
                1f, .8f, .6f, 1f, .5f,
                RandomGenerator.GetRandomInt(0, 4)));
            pMan.AddParticle(new Heat(location,
                RandomGenerator.GetRandomVector2(-20f, 20f, -50f, -10f),
                RandomGenerator.GetRandomFloat(.5f, 2f)));

            base.Update(gameTime, map, pMan, c);

        }
    }
}
