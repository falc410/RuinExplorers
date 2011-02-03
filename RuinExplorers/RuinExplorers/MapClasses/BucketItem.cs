using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RuinExplorers.CharacterClasses;

namespace RuinExplorers.MapClasses
{
    class BucketItem
    {
        public Vector2 location;
        public CharacterType characterType;

        public BucketItem(Vector2 location, CharacterType characterType)
        {
            this.location = location;
            this.characterType = characterType;
        }
    }
}
