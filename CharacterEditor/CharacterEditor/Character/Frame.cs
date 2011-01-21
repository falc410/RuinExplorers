using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharacterEditor.Character
{
    class Frame
    {
        Part[] parts;
        public string Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Frame"/> class.
        /// </summary>
        public Frame()
        {
            parts = new Part[16];
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = new Part();
            }
            Name = String.Empty; 
        }

        /// <summary>
        /// Gets the parts.
        /// </summary>
        public Part[] Parts
        {
            get { return parts; }
        }
    }
}
