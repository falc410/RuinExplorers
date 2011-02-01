using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuinExplorers.MapClasses;
using RuinExplorers.CharacterClasses;

namespace RuinExplorers.AIClasses
{
    /// <summary>
    /// Here is our AI base class--we'll be extending this for our Zombie AI class in chapter 8
    /// and eventually a Wraith and Carlos AI class.  
    /// </summary>
    public class AI
    {
        public const int JOB_IDLE = 0;
        public const int JOB_MELEE_CHASE = 1;
        public const int JOB_SHOOT_CHASE = 2;
        public const int JOB_AVOID = 3;

        protected int job = JOB_IDLE;
        protected int targ = -1;
        protected float jobFrame = 0f;

        protected Character me;

        public int FindTarg(Character[] c)
        {
            int closest = -1;
            float d = 0f;

            for (int i = 0; i < c.Length; i++)
            {
                if (i != me.ID)
                {
                    if (c[i] != null)
                    {
                        if (c[i].Team != me.Team)
                        {
                            float newD = (me.Location - c[i].Location).Length();
                            if (closest == -1 || newD < d)
                            {
                                d = newD;
                                closest = i;
                            }
                        }
                    }
                }
            }

            return closest;
        }

        public virtual void Update(Character[] c, int ID, Map map)
        {
            me = c[ID];

            me.keyLeft = false;
            me.keyRight = false;
            me.keyUp = false;
            me.keyDown = false;
            me.keyAttack = false;
            me.keySecondary = false;
            me.keyJump = false;

            jobFrame -= RuinExplorersMain.FrameTime;

            DoJob(c, ID);
        }

        protected void DoJob(Character[] c, int ID)
        {
            switch (job)
            {
                case JOB_IDLE:
                    //do nothing!
                    break;
                case JOB_MELEE_CHASE:
                    if (targ > -1 && c[targ] != null)
                    {
                        if (!ChaseTarg(c, c[ID].Scale * 100f))
                        {
                            if (!FaceTarg(c))
                            {
                                me.keyAttack = true;
                            }
                        }
                    }
                    else
                        targ = FindTarg(c);
                    break;

                case JOB_AVOID:
                    if (targ > -1 && c[targ] != null)
                    {
                        AvoidTarg(c, 500f);

                    }
                    else
                        targ = FindTarg(c);
                    break;

                case JOB_SHOOT_CHASE:
                    if (targ > -1 && c[targ] != null)
                    {
                        if (!ChaseTarg(c, 150f))
                        {
                            if (!FaceTarg(c))
                            {
                                me.keySecondary = true;
                            }
                        }
                    }
                    else
                        targ = FindTarg(c);
                    break;
            }
            if (!me.keyAttack && !me.keySecondary)
            {
                if (me.keyLeft)
                {
                    if (FriendInWay(c, ID, CharacterDirection.Left))
                        me.keyLeft = false;
                }
                if (me.keyRight)
                {
                    if (FriendInWay(c, ID, CharacterDirection.Right))
                        me.keyRight = false;
                }
            }
        }

        private bool FriendInWay(Character[] c, int ID, CharacterDirection face)
        {
            for (int i = 0; i < c.Length; i++)
            {
                if (i != ID)
                {
                    if (c[i] != null)
                    {
                        if (me.Team == c[i].Team)
                        {
                            if (me.Location.Y > c[i].Location.Y - 100f &&
                                me.Location.Y < c[i].Location.Y + 10f)
                            {
                                if (face == CharacterDirection.Right)
                                {
                                    if (c[i].Location.X > me.Location.X &&
                                        c[i].Location.X < me.Location.X + 70f)
                                        return true;
                                }
                                else
                                {
                                    if (c[i].Location.X < me.Location.X &&
                                        c[i].Location.X > me.Location.X - 70f)
                                        return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        protected bool ChaseTarg(Character[] c, float distance)
        {
            if (c[targ] == null)
                return false;
            if (me.Location.X > c[targ].Location.X + distance)
            {
                me.keyLeft = true;
                return true;
            }
            else if (me.Location.X < c[targ].Location.X - distance)
            {
                me.keyRight = true;
                return true;
            }
            return false;
        }

        protected bool AvoidTarg(Character[] c, float distance)
        {
            if (c[targ] == null)
                return false;
            if (me.Location.X < c[targ].Location.X + distance)
            {
                me.keyRight = true;
                return true;
            }
            else if (me.Location.X > c[targ].Location.X - distance)
            {
                me.keyLeft = true;
                return true;
            }
            return false;
        }

        protected bool FaceTarg(Character[] c)
        {
            if (c[targ] == null)
                return false;
            if (me.Location.X > c[targ].Location.X && me.Face == CharacterDirection.Right)
            {
                me.keyLeft = true;
                return true;
            }
            else if (me.Location.X > c[targ].Location.X && me.Face == CharacterDirection.Right)
            {
                me.keyRight = true;
                return true;
            }
            else
                return false;
        }
    }
}
