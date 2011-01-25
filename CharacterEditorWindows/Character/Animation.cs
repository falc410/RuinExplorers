using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharacterEditorWindows.Character
{
    class Animation
    {
        public string Name;
        KeyFrame[] keyFrames;

        /// <summary>
        /// Initializes a new instance of the <see cref="Animation"/> class.
        /// </summary>
        public Animation()
        {
            Name = String.Empty;
            keyFrames = new KeyFrame[64];
            for (int i = 0; i < keyFrames.Length; i++)
            {
                keyFrames[i] = new KeyFrame();
            }
        }

        /// <summary>
        /// Gets the key frames.
        /// </summary>
        public KeyFrame[] KeyFrames
        {
            get { return keyFrames; }
        }
    }
}
