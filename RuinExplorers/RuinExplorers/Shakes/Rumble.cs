using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RuinExplorers.Shakes
{
    class Rumble
    {
        private Vector2 rumbleValue = Vector2.Zero;
        private PlayerIndex playerIndex;
        
        public Rumble(int index)
        {
            playerIndex = (PlayerIndex)index;
        }

        public void Update()
        {
            if (rumbleValue.X > 0f)
            {
                rumbleValue.X -= RuinExplorersMain.FrameTime;
                if (rumbleValue.X < 0f) rumbleValue.X = 0f;
            }
            if (rumbleValue.Y > 0f)
            {
                rumbleValue.Y -= RuinExplorersMain.FrameTime;
                if (rumbleValue.Y < 0f) rumbleValue.Y = 0f;
            }

            GamePad.SetVibration(playerIndex,rumbleValue.X, rumbleValue.Y);
        }

        public float Left
        {
            get { return rumbleValue.X; }
            set { rumbleValue.X = value; }
        }
        public float Right
        {
            get { return rumbleValue.Y; }
            set { rumbleValue.Y = value; }
        }
    }
}
