using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RuinExplorers.Helpers;

namespace RuinExplorers.Shakes
{
    class Quake
    {
        private float val;

        public void Update()
        {
            if (val > 0f)
                val -= RuinExplorersMain.FrameTime;
            else if (val < 0f)
                val = 0f;
        }

        public float Value
        {
            get { return val; }
            set { val = value; }
        }

        public Vector2 Vector
        {
            get
            {
                if (val <= 0f)
                    return Vector2.Zero;

                return RandomGenerator.GetRandomVector2(-val, val, -val, val) * 10f;

            }
        }
    }
}
