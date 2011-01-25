using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CharacterEditorWindows.Character
{
    class Part
    {
        public Vector2 Location;
        public float Rotation;
        public Vector2 Scaling;
        public int Index;
        public int Flip;

        /// <summary>
        /// Initializes a new instance of the <see cref="Part"/> class.
        /// </summary>
        public Part()
        {
            Index = -1;
            Scaling = new Vector2(1.0f, 1.0f);
        }
    }
}
