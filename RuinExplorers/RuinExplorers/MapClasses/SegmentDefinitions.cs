using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RuinExplorers.MapClasses
{
    /// <summary>
    /// Used to define segments on a texture
    /// segmentDefinition requires a Name, a sourceIndex (Texture), a source Rectangle
    /// where the segment is located on the texture and additional flags which
    /// might be used for particle or script system in the future
    /// </summary>
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
