using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharacterEditorWindows.Character
{
    class KeyFrame
    {
        public int FrameReference;
        public int Duration;
        string[] scripts;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyFrame"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets the scripts.
        /// </summary>
        public string[] Scripts
        {
            get { return scripts; }
        }
    }
}
