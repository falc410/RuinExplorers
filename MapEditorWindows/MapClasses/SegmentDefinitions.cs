using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MapEditorWindows.MapClasses
{
    class SegmentDefinitions
    {
        private string Name;
        private int SourceIndex;
        private Rectangle SourceRect;
        private int Flags;
       
        public Rectangle sourceRect
        {
            get { return SourceRect; }
        }

        public String name
        {
            get { return Name; }
        }

        public int sourceIndex
        {
            get { return SourceIndex; }
        }

        public SegmentDefinitions(string _name, int _sourceIndex, Rectangle _srcRect, int _flags)
        {
            this.Name = _name;
            this.SourceIndex = _sourceIndex;
            this.SourceRect =_srcRect;
            this.Flags = _flags;
        }
    }
}
