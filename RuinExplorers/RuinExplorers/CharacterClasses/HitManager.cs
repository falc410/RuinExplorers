using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuinExplorers.Particles;
using Microsoft.Xna.Framework;

namespace RuinExplorers.CharacterClasses
{
    class HitManager
    {

        public static bool CheckHit(Particle particle, Character[] character, ParticleManager particleManager)
        {
            bool r = false;
            Character.CharacterDirection tFace = GetFaceFromTrajectory(particle.trajectory);

            for (int i = 0; i < character.Length; i++)
            {
                if (i != particle.owner)
                {
                    if (character[i] != null)
                    {
                        if (character[i].InHitBounds(particle.location))
                        {
                            if (tFace == Character.CharacterDirection.Left)
                                character[i].Face = Character.CharacterDirection.Right;
                            else
                                character[i].Face = Character.CharacterDirection.Left;

                            character[i].SetAnim("idle");
                            character[i].SetAnim("hit");
                            character[i].Slide(-100f);

                            particleManager.MakeBulletBlood(particle.location, particle.trajectory / 2f);
                            particleManager.MakeBulletBlood(particle.location, -particle.trajectory);
                            // imho white smoke doesn't look so cool when zombies get hit by bullets!
                            //particleManager.MakeBulletDust(particle.location, particle.trajectory);

                            r = true;
                        }
                    }
                }
            }
            return r;
        }
        
        public static Character.CharacterDirection GetFaceFromTrajectory(Vector2 trajectory)
        {
            return (trajectory.X <= 0) ? Character.CharacterDirection.Left : Character.CharacterDirection.Right;

        }
    }
}
