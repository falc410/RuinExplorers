using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuinExplorers.CharacterClasses
{
    class KeyFrame
    {
        public int FrameReference;
        public int Duration;
        string[] scripts;

        public KeyFrame()
        {
            FrameReference = -1;
            Duration = 0;
            scripts = new string[4];
            for (int i = 0; i < scripts.Length; i++)
            {
                scripts[i] = String.Empty;
            }
        }

        public string[] Scripts
        {
            get { return scripts; }
        }
    }
}
