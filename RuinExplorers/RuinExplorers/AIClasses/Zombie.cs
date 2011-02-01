using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuinExplorers.CharacterClasses;
using RuinExplorers.MapClasses;
using RuinExplorers.Helpers;

namespace RuinExplorers.AIClasses
{
    class Zombie : AI
    {
        public override void Update(Character[] c, int ID, Map map)
        {
            me = c[ID];

            if (jobFrame < 0f)
            {
                float r = RandomGenerator.GetRandomFloat(0f, 1f);
                if (r < 0.6f)
                {
                    job = JOB_MELEE_CHASE;
                    jobFrame = RandomGenerator.GetRandomFloat(2f, 4f);
                    FindTarg(c);
                }
                else if (r < 0.8f)
                {
                    job = JOB_AVOID;
                    jobFrame = RandomGenerator.GetRandomFloat(1f, 2f);
                    FindTarg(c);
                }
                else
                {
                    job = JOB_IDLE;
                    jobFrame = RandomGenerator.GetRandomFloat(.5f, 1f);
                }
            }

            base.Update(c, ID, map);
        }
    }
}
