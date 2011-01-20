using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharacterEditor.Character
{
    class CharacterDefinition
    {
        Animation[] animations;
        Frame[] frames;
        public string Path;

        public int HeadIndex;
        public int TorsoIndex;
        public int LegsIndex;
        public int WeaponIndex;

        public CharacterDefinition()
        {
            animations = new Animation[64];
            for (int i = 0; i < animations.Length; i++)
            {
                animations[i] = new Animation();
            }
            frames = new Frame[512];
            for (int i = 0; i < frames.Length; i++)
            {
                frames[i] = new Frame();
            }

            Path = "char";
        }

        public Animation[] Animation
        {
            get { return animations; }
        }

        public Frame[] Frames
        {
            get { return frames; }
        }
    }
}
