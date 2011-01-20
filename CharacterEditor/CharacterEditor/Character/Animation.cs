using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharacterEditor.Character
{
    class Animation
    {
        public string Name;
        KeyFrame[] keyFrames;

        public Animation()
        {
            Name = String.Empty;
            keyFrames = new KeyFrame[64];
            for (int i = 0; i < keyFrames.Length; i++)
            {
                keyFrames[i] = new KeyFrame();
            }
        }

        public KeyFrame[] KeyFrames
        {
            get { return keyFrames; }
        }
    }
}
