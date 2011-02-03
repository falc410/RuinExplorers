using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RuinExplorers.CharacterClasses;

namespace RuinExplorers.MapClasses
{
    public class Bucket
    {
        BucketItem[] bucketItems = new BucketItem[64];
        public int Size;
        float updateFrame = 0f;
        public bool IsEmpty = false;

        public Bucket(int size)
        {
            for (int i = 0; i < bucketItems.Length; i++)
            {
                bucketItems[i] = null;
            }
            this.Size = size;
        }

        public void AddItem(Vector2 location, CharacterType characterType)
        {
            for (int i = 0; i < bucketItems.Length; i++)
            {
                if (bucketItems[i] == null)
                {
                    bucketItems[i] = new BucketItem(location, characterType);
                    return;
                }
            }
        }

        public void Update(Character[] characters)
        {
            updateFrame -= RuinExplorersMain.FrameTime;

            if (updateFrame > 0)
                return;

            updateFrame = 1f;
            int monsters = 0;

            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] != null)
                    if (characters[i].Team == Character.TEAM_NPC)
                        monsters++;
            }

            if (monsters < Size)
            {
                for (int i = 0; i < bucketItems.Length; i++)
                {
                    if (bucketItems[i] != null)
                    {
                        for (int n = 0; n < characters.Length; n++)
                        {
                            if (characters[n] == null)
                            {
                                characters[n] = new Character(bucketItems[i].location, RuinExplorersMain.CharacterDefinitions[(int)bucketItems[i].characterType], n, Character.TEAM_NPC);
                                bucketItems[i] = null;
                                return;
                            }
                        }
                    }
                }
                if (monsters == 0)
                        IsEmpty = true;            
            }
        }
    }
}
