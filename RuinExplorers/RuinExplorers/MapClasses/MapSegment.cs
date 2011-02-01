using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RuinExplorers.MapClasses
{
    /// <summary>
    /// One segment on a map. Got a location and index value
    /// </summary>
    public class MapSegment
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
