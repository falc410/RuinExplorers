using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RuinExplorers.MapClasses
{
    class Ledge
    {
        Vector2[] nodes = new Vector2[16];
        private int totalNodes = 0;
        public int isHardLedge = 0;

        public int TotalNodes
        {
            get { return totalNodes; }
            set { totalNodes = value; }
        }
        public Vector2[] Nodes
        {
            get { return nodes; }
        }

    }
}
