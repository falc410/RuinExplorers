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
        ScriptLine[] scripts;

        public KeyFrame()
        {
            FrameReference = -1;
            Duration = 0;
            
            scripts = new ScriptLine[4];
           
        }

        public ScriptLine[] Scripts
        {
            get { return scripts; }
        }
    }
}
