using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MapEditor.MapClasses
{
    class MapSegment
    {
        public Vector2 location;
        int segmentIndex;

        public int Index
        {
            get { return segmentIndex; }
            set { segmentIndex = value; }
        }
    }
}
