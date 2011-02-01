using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RuinExplorers.MapClasses
{
    /// <summary>
    /// A Ledge is used for collision detection. It consists of
    /// an array of 16 nodes. A ledge can either be a soft ledge or
    /// hard ledge - meaning that a character can not move past it.
    /// A node is a simple Vector2 object.
    /// </summary>
    public class Ledge
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
