using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RuinExplorers.Shakes
{
    class Blast
    {
        private float val;
        private float mag;
        public Vector2 Center;
        
        public void Update()
        {
            if (val >= 0f)
                val -= RuinExplorersMain.FrameTime * 5f;
            else if (val < 0f)
                val = 0f;
        }
        
        public float Value
        {
            get { return val; }
            set { val = value; }
        }

        public float Magnitude
        {
            get { return mag; }
            set { mag = value; }
        }
    }
}
