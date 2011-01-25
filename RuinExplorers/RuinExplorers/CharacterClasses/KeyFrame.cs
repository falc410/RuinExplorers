using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuinExplorers.CharacterClasses
{
    /// <summary>
    /// A KeyFrame contains an array of scripts[4] a duration and a reference to a frame
    /// </summary>
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
