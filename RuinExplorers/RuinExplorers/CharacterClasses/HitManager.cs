using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuinExplorers.Particles;
using Microsoft.Xna.Framework;
using RuinExplorers.Audio;
using RuinExplorers.Shakes;

namespace RuinExplorers.CharacterClasses
{
    class HitManager
    {

        public static bool CheckHit(Particle particle, Character[] character, ParticleManager particleManager)
        {
            bool r = false;
            CharacterDirection tFace = GetFaceFromTrajectory(particle.trajectory);

            for (int i = 0; i < character.Length; i++)
            {
                if (i != particle.owner)
                {
                    if (character[i] != null)
                    {
                        if (character[i].DyingFrame < 0f && !character[i].Ethereal)
                        {

                            if (character[i].InHitBounds(particle.location))
                            {
                                float hVal = 1f;
                                character[i].LastHitBy = particle.owner;

                                #region hit by bullet

                                if (particle is Bullet)
                                {
                                    if (!r)
                                    {
                                        hVal *= 4f;

                                        if (tFace == CharacterDirection.Left)
                                            character[i].Face = CharacterDirection.Right;
                                        else
                                            character[i].Face = CharacterDirection.Left;

                                        character[i].SetAnim("idle");
                                        character[i].SetAnim("hit");
                                        character[i].Slide(-100f);
                                        Sound.PlayCue("bullethit");

                                        particleManager.MakeBulletBlood(particle.location, particle.trajectory / 2);
                                        particleManager.MakeBulletBlood(particle.location, -particle.trajectory);
                                        // imho white smoke doesn't look so cool when zombies get hit by bullets!
                                        //particleManager.MakeBulletDust(particle.location, particle.trajectory);

                                        r = true;
                                    }
                                }
                                #endregion

                                #region hit by hit particle

                                else if (particle is Hit)
                                {
                                    character[i].Face = (tFace == CharacterDirection.Left) ? CharacterDirection.Right : CharacterDirection.Left;
                                    float tX = 1f;
                                    if (tFace == CharacterDirection.Left)
                                        tX = -1f;

                                    character[i].SetAnim("idle");
                                    character[i].SetAnim("hit");
                                    Sound.PlayCue("zombiehit");

                                    if (character[i].State == CharacterState.Ground)
                                        character[i].Slide(-200f);
                                    else
                                        character[i].Slide(-50f);

                                    switch (particle.flag)
                                    {
                                        case Character.TRIG_ZOMBIE_HIT:
                                            hVal *= 5f;
                                            particleManager.MakeBloodSplash(particle.location, new Vector2(50f * tX, 100f));
                                            break;
                                        case Character.TRIG_WRENCH_DIAG_DOWN:
                                            hVal *= 5f;
                                            particleManager.MakeBloodSplash(particle.location,
                                        new Vector2(50f * tX, 100f));
                                            RuinExplorersMain.SlowTime = 0.1f;
                                            break;
                                        case Character.TRIG_WRENCH_DIAG_UP:
                                            hVal *= 5f;
                                            particleManager.MakeBloodSplash(particle.location,
                                            new Vector2(-50f * tX, -100f));
                                            RuinExplorersMain.SlowTime = 0.1f;
                                            break;
                                        case Character.TRIG_WRENCH_UP:
                                            hVal *= 5f;
                                            particleManager.MakeBloodSplash(particle.location,
                                            new Vector2(30f * tX, -100f));
                                            RuinExplorersMain.SlowTime = 0.1f;
                                            break;
                                        case Character.TRIG_WRENCH_DOWN:
                                            hVal *= 5f;
                                            particleManager.MakeBloodSplash(particle.location,
                                            new Vector2(-50f * tX, 100f));
                                            RuinExplorersMain.SlowTime = 0.1f;
                                            break;
                                        case Character.TRIG_WRENCH_UPPERCUT:
                                            hVal *= 15f;
                                            particleManager.MakeBloodSplash(particle.location,
                                            new Vector2(-50f * tX, -150f));
                                            character[i].Trajectory.X = 100f * tX;
                                            character[i].SetAnim("jhit");
                                            character[i].SetJump(700f);
                                            RuinExplorersMain.SlowTime = 0.125f;
                                            QuakeManager.SetQuake(0.5f);
                                            QuakeManager.SetBlast(0.5f, particle.location);
                                            break;
                                        case Character.TRIG_WRENCH_SMACKDOWN:
                                            hVal *= 15f;
                                            particleManager.MakeBloodSplash(particle.location,
                                            new Vector2(-50f * tX, 150f));
                                            character[i].SetAnim("jfall");
                                            character[i].SetJump(-900f);
                                            RuinExplorersMain.SlowTime = 0.125f;
                                            break;
                                        case Character.TRIG_KICK:
                                            hVal *= 15f;
                                            particleManager.MakeBloodSplash(particle.location,
                                            new Vector2(300f * tX, 0f));
                                            character[i].Trajectory.X = 1000f * tX;
                                            character[i].SetAnim("jhit");
                                            character[i].SetJump(300f);
                                            RuinExplorersMain.SlowTime = 0.25f;
                                            //QuakeManager.SetBlast(0.5f, particle.location);
                                            break;
                                    }
                                }
                                #endregion

                                #region hitting characters in air

                                if (character[i].State == CharacterState.Air)
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

                                character[i].HP -= (int)hVal;

                                // calculate score
                                if (character[i].LastHitBy == 0)
                                {
                                    RuinExplorersMain.Score += (int)hVal * 50;
                                }

                                if (character[i].HP < 0)
                                {
                                    if (character[i].AnimationName == "hit")
                                        character[i].SetAnim("diehit");
                                    if (i == 0)
                                    {
                                        if (character[i].AnimationName == "hit")
                                        {
                                            character[i].SetAnim("jmid");
                                            character[i].SetJump(300f);
                                        }
                                        RuinExplorersMain.Menu.Die();
                                    }
                                }
                            }
                        }
                    }
                }               
            }
            return r;
        }
        
        public static CharacterDirection GetFaceFromTrajectory(Vector2 trajectory)
        {
            return (trajectory.X <= 0) ? CharacterDirection.Left : CharacterDirection.Right;

        }
    }
}
