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

                            #region hit by bullet

                            if (particle is Bullet)
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
                            #endregion

                            #region hit by hit particle

                            else if (particle is Hit)
                            {
                                character[i].Face = (tFace == Character.CharacterDirection.Left) ? Character.CharacterDirection.Right : Character.CharacterDirection.Left;
                                float tX = 1f;
                                if (tFace == Character.CharacterDirection.Left)
                                    tX = -1f;

                                character[i].SetAnim("idle");
                                character[i].SetAnim("hit");

                                if (character[i].State == Character.CharacterState.Ground)
                                    character[i].Slide(-200f);
                                else
                                    character[i].Slide(-50f);

                                switch (particle.flag)
                                {
                                    case Character.TRIG_WRENCH_DIAG_DOWN:
                                        particleManager.MakeBloodSplash(particle.location,
                                    new Vector2(50f * tX, 100f));
                                        RuinExplorersMain.SlowTime = 0.1f;
                                        break;
                                    case Character.TRIG_WRENCH_DIAG_UP:
                                        particleManager.MakeBloodSplash(particle.location,
                                        new Vector2(-50f * tX, -100f));
                                        RuinExplorersMain.SlowTime = 0.1f;
                                        break;
                                    case Character.TRIG_WRENCH_UP:
                                        particleManager.MakeBloodSplash(particle.location,
                                        new Vector2(30f * tX, -100f));
                                        RuinExplorersMain.SlowTime = 0.1f;
                                        break;
                                    case Character.TRIG_WRENCH_DOWN:
                                        particleManager.MakeBloodSplash(particle.location,
                                        new Vector2(-50f * tX, 100f));
                                        RuinExplorersMain.SlowTime = 0.1f;
                                        break;
                                    case Character.TRIG_WRENCH_UPPERCUT:
                                        particleManager.MakeBloodSplash(particle.location,
                                        new Vector2(-50f * tX, -150f));
                                        character[i].Trajectory.X = 100f * tX;
                                        character[i].SetAnim("jhit");
                                        character[i].SetJump(700f);
                                        RuinExplorersMain.SlowTime = 0.125f;
                                        break;
                                    case Character.TRIG_WRENCH_SMACKDOWN:
                                        particleManager.MakeBloodSplash(particle.location,
                                        new Vector2(-50f * tX, 150f));
                                        character[i].SetAnim("jfall");
                                        character[i].SetJump(-900f);
                                        RuinExplorersMain.SlowTime = 0.125f;
                                        break;
                                    case Character.TRIG_KICK:
                                        particleManager.MakeBloodSplash(particle.location,
                                        new Vector2(300f * tX, 0f));
                                        character[i].Trajectory.X = 1000f * tX;
                                        character[i].SetAnim("jhit");
                                        character[i].SetJump(300f);
                                        RuinExplorersMain.SlowTime = 0.25f;
                                        break;
                                }
                            }
                            #endregion

                            #region hitting characters in air

                            if (character[i].State == Character.CharacterState.Air)
                            {
                                if (character[i].AnimationName == "hit")
                                {
                                    character[i].SetAnim("jmid");
                                    character[i].SetJump(300f);
                                    if (particle is Hit)
                                    {
                                        if (character[particle.owner].Team == Character.TEAM_PLAYERS)
                                        {
                                            character[i].Location.Y = character[particle.owner].Location.Y;
                                        }
                                    }
                                }
                            }
                            #endregion
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
